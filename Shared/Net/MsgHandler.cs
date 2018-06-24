﻿using System.Collections.Generic;

namespace Shared.Net
{
	/// <summary>
	/// 消息处理器的容器
	/// </summary>
	public class MsgHandler
	{
		public delegate ErrorCode Handler( byte[] data, int offset, int size, int msgID );

		private readonly Dictionary<int, Handler> _handlers = new Dictionary<int, Handler>();

		public void Register( int msgID, Handler handler )
		{
			if ( this._handlers.ContainsKey( msgID ) )
				return;
			this._handlers[msgID] = handler;
		}

		public bool Contains( int msgID )
		{
			return this._handlers.ContainsKey( msgID );
		}

		public bool TryGetHandler( int msgID, out Handler handler )
		{
			return this._handlers.TryGetValue( msgID, out handler );
		}

		public void Clear()
		{
			this._handlers.Clear();
		}
	}

	/// <summary>
	/// 转发消息处理器的容器
	/// </summary>
	public class TransHandler
	{
		public delegate ErrorCode Handler( byte[] data, int offset, int size, int transID, int msgID, uint gcNetID );

		private readonly Dictionary<int, Handler> _handlers = new Dictionary<int, Handler>();

		public void Register( int msgID, Handler handler )
		{
			this._handlers[msgID] = handler;
		}

		public bool Contains( int msgID )
		{
			return this._handlers.ContainsKey( msgID );
		}

		public bool TryGetHandler( int msgID, out Handler handler )
		{
			return this._handlers.TryGetValue( msgID, out handler );
		}

		public void Clear()
		{
			this._handlers.Clear();
		}
	}
}