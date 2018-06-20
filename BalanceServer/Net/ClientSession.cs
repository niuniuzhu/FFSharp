﻿using Core.Misc;
using Google.Protobuf;
using Shared.Net;

namespace BalanceServer.Net
{
	public class ClientSession : SrvCliSession
	{
		protected ClientSession( uint id ) : base( id )
		{
			this._msgHandler.Register( ( int )GCToBS.MsgNum.EMsgToBsfromGcOneClinetLogin, this.MSGOneClientLogin );
		}

		protected override void SendInitData()
		{
		}

		protected override void OnRealEstablish()
		{
		}

		protected override void OnClose()
		{
		}

		public override void OnError( string error )
		{
			this.Close();
		}

		private bool MSGOneClientLogin( byte[] data, int offset, int size, int msgID )
		{
			//收到第2消息：客户端连接BS，向LS请求用户是否合法连接
			GCToBS.OneClinetLogin oneClientLogin = new GCToBS.OneClinetLogin();
			oneClientLogin.MergeFrom( data, offset, size );

			Logger.Log( $"user({oneClientLogin.Uin})({oneClientLogin.Sessionid})({this.id}) ask login bs" );
			oneClientLogin.Nsid = this.id;

			this.owner.SendMsgToSession( SessionType.ClientB2L, oneClientLogin, ( int )BSToLS.MsgID.EMsgToLsfromBcOneClinetLoginCheck );

			return true;
		}

		protected override bool HandleUnhandledMsg( byte[] data, int offset, int size, int msgID )
		{
			return true;
		}
	}
}