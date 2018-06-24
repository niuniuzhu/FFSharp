﻿using Core.Misc;
using Google.Protobuf;
using Shared;
using Shared.Net;

namespace CentralServer.Net
{
	public class GateSession : SrvCliSession
	{
		protected GateSession( uint id ) : base( id )
		{
			this._msgHandler.Register( ( int )GSToCS.MsgID.EMsgToCsfromGsAskRegiste, this.MsgHandleInit );
			//this._msgHandler.Register( ( int )GSToCS.MsgID.EMsgToCsfromGsAskRegiste, this.OnMsgFromGSAskRegiste );
			//this._msgHandler.Register( ( int )GSToCS.MsgID.EMsgToCsfromGsAskPing, this.OnMsgFromGSAskPing );
			//this._msgHandler.Register(( int )GSToCS.MsgID.EMsgToCsfromGsReportGcmsg, this.OnMsgFromGSReportGCMsg);
		}

		protected override void SendInitData()
		{
			long time = TimeUtils.utcTime;
			CSToGS.AskRegisteRet msg = new CSToGS.AskRegisteRet
			{
				Registe = 0,
				Curtime = time,
				Ssbaseid = CS.instance.m_sCSKernelCfg.un32SSBaseIdx
			};

			//for ( uint i = 0; i < CS.instance.m_sCSKernelCfg.un32MaxSSNum; i++ )
			//{
			//	CSToGS.AskRegisteRet.Types.SSInfo pSsinfo =
			//		new CSToGS.AskRegisteRet.Types.SSInfo
			//		{
			//			Ssid = CS.instance.m_pcSSInfoList[i].m_n32SSID,
			//			Ip = CS.instance.m_pcSSInfoList[i].m_sListenIP,
			//			Port = CS.instance.m_pcSSInfoList[i].m_n32ListenPort,
			//			Netstate = ( int )CS.instance.m_pcSSInfoList[i].m_eSSNetState
			//		};
			//}

			byte[] data = msg.ToByteArray();
			this.owner.TranMsgToSession( this.id, data, 0, data.Length, ( int )CSToGS.MsgID.EMsgToGsfromCsAskRegisteRet, 0, 0 );
		}

		protected override void OnRealEstablish()
		{
			CSGSInfo pcGSInfo = CS.instance.GetCGSInfoByNSID( this.id );
			if ( pcGSInfo != null )
				Logger.Info( $"GS({pcGSInfo.m_n32GSID}) Connected" );
		}

		protected override void OnClose()
		{
			CSGSInfo pcGSInfo = CS.instance.GetCGSInfoByNSID( this.id );
			if ( pcGSInfo == null )
				return;
			Logger.Info( $"GS({pcGSInfo.m_n32GSID}) DisConnected" );
			int pos = ( int )( pcGSInfo.m_n32GSID - CS.instance.m_sCSKernelCfg.un32GSBaseIdx );
			pcGSInfo.m_eGSNetState = EServerNetState.SnsClosed;
			pcGSInfo.m_n32NSID = 0;
			pcGSInfo.m_tLastConnMilsec = 0;
			CS.instance.m_psGSNetInfoList[pos].tConnMilsec = 0;
			CS.instance.m_psGSNetInfoList[pos].pcGSInfo = null;
		}

		private ErrorCode MsgHandleInit( byte[] data, int offset, int size, int msgID1 )
		{
			int msgID = 0;
			uint gcNetID = 0;
			//剥离第二层消息ID
			offset += ByteUtils.Decode32i( data, offset, ref msgID );
			//剥离客户端网络ID
			offset += ByteUtils.Decode32u( data, offset, ref gcNetID );
			size -= 2 * sizeof( int );

			GSToCS.AskRegiste msg = new GSToCS.AskRegiste();
			msg.MergeFrom( data, offset, size );

			//找到位置号
			int gsPos = -1;
			CSGSInfo csgsInfo = null;
			for ( int i = 0; i < CS.instance.m_sCSKernelCfg.un32MaxGSNum; i++ )
			{
				if ( msg.Gsid != CS.instance.m_pcGSInfoList[i].m_n32GSID )
					continue;
				csgsInfo = CS.instance.m_pcGSInfoList[i];
				gsPos = i;
				break;
			}

			if ( null == csgsInfo )
			{
				this.Close();
				return ErrorCode.InvalidGSID;
			}

			if ( csgsInfo.m_szUserPwd != msg.Usepwd )
			{
				this.Close();
				return ErrorCode.InvalidUserPwd;
			}

			// 加入GS
			long time = TimeUtils.utcTime;
			csgsInfo.m_eGSNetState = EServerNetState.SnsFree;
			csgsInfo.m_n32NSID = this.id;
			this.logicID = csgsInfo.m_n32GSID;
			csgsInfo.m_tLastConnMilsec = time;
			csgsInfo.m_sListenIP = msg.Ip;
			csgsInfo.m_n32ListenPort = msg.Port;
			CS.instance.m_psGSNetInfoList[gsPos].pcGSInfo = csgsInfo;
			csgsInfo.m_n64MsgReceived++;
			csgsInfo.m_n64DataReceived += msg.CalculateSize();
			csgsInfo.m_un32ConnTimes++;
			csgsInfo.m_tLastConnMilsec = time;
			csgsInfo.m_tLastPingMilSec = time;

			this.SetInited( true, true );
			return ErrorCode.Success;
		}

		private ErrorCode OnMsgFromGSAskRegiste( CSGSInfo csgsInfo, byte[] data, int offset, int size )
		{
			GSToCS.AskRegiste sMsg = new GSToCS.AskRegiste();
			sMsg.MergeFrom( data, offset, size );

			// 找到位置号
			int gsPos = -1;
			CSGSInfo pcGSInfo = null;
			for ( int i = 0; i < CS.instance.m_sCSKernelCfg.un32MaxGSNum; i++ )
			{
				if ( sMsg.Gsid != CS.instance.m_pcGSInfoList[i].m_n32GSID )
					continue;
				pcGSInfo = CS.instance.m_pcGSInfoList[i];
				gsPos = i;
				break;
			}

			ErrorCode n32Registe = ErrorCode.Success;
			if ( null == pcGSInfo )
			{
				n32Registe = ErrorCode.InvalidGSID;
			}

			if ( ErrorCode.Success == n32Registe )
			{
				if ( pcGSInfo.m_szUserPwd != sMsg.Usepwd )
					n32Registe = ErrorCode.InvalidUserPwd;
			}

			long tCurUTCMilsec = TimeUtils.utcTime;
			if ( ErrorCode.Success == n32Registe )
			{
				pcGSInfo.m_eGSNetState = EServerNetState.SnsFree;
				pcGSInfo.m_n32NSID = csgsInfo.m_n32NSID;
				pcGSInfo.m_tLastConnMilsec = tCurUTCMilsec;
				pcGSInfo.m_sListenIP = sMsg.Ip;
				pcGSInfo.m_n32ListenPort = sMsg.Port;
				CS.instance.m_psGSNetInfoList[gsPos].pcGSInfo = pcGSInfo;

				pcGSInfo.m_n64MsgReceived++;
				pcGSInfo.m_n64DataReceived += sMsg.CalculateSize();
				pcGSInfo.m_un32ConnTimes++;
				pcGSInfo.m_tLastConnMilsec = tCurUTCMilsec;
				pcGSInfo.m_tLastPingMilSec = tCurUTCMilsec;
				Logger.Info( $"Gate Server with GSID {pcGSInfo.m_n32GSID} registed at net session {gsPos}, total conn times {pcGSInfo.m_un32ConnTimes}" );
			}

			CSToGS.AskRegisteRet sAskRegisteRet = new CSToGS.AskRegisteRet();
			sAskRegisteRet.Registe = ( int )n32Registe;
			sAskRegisteRet.Curtime = tCurUTCMilsec;
			if ( ErrorCode.Success == n32Registe )
			{
				sAskRegisteRet.Ssbaseid = CS.instance.m_sCSKernelCfg.un32SSBaseIdx;
				for ( int i = 0; i < CS.instance.m_sCSKernelCfg.un32MaxSSNum; i++ )
				{
					CSSSInfo csssInfo = CS.instance.m_pcSSInfoList[i];
					CSToGS.AskRegisteRet.Types.SSInfo pSSInfo =
						new CSToGS.AskRegisteRet.Types.SSInfo
						{
							Ssid = csssInfo.m_n32SSID,
							Ip = csssInfo.m_sListenIP,
							Port = csssInfo.m_n32ListenPort,
							Netstate = ( int )csssInfo.m_eSSNetState
						};
					sAskRegisteRet.Ssinfo.Add( pSSInfo );
				}
			}

			CS.instance.netSessionMgr.TranMsgToSession( csgsInfo.m_n32NSID, sAskRegisteRet, ( int )CSToGS.MsgID.EMsgToGsfromCsAskRegisteRet, 0, 0 );

			if ( ErrorCode.Success != n32Registe )
				CS.instance.netSessionMgr.DisconnectOne( csgsInfo.m_n32NSID );

			return ErrorCode.Success;
		}

		private ErrorCode OnMsgFromGSAskPing( CSGSInfo cpigsinfo, byte[] data, int offset, int size )
		{
			throw new System.NotImplementedException();
		}

		private ErrorCode OnMsgFromGSReportGCMsg( CSGSInfo cpigsinfo, byte[] data, int offset, int size )
		{
			throw new System.NotImplementedException();
		}
	}
}