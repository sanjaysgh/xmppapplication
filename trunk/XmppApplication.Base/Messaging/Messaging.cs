//
// Messaging.cs
//
// Author:
//   Jonathan Pobst  <monkey@jpobst.com>
//
// Copyright (C) 2008 Jonathan Pobst
//
// Permission is hereby granted, free of charge, to any person obtaining
// a copy of this software and associated documentation files (the
// "Software"), to deal in the Software without restriction, including
// without limitation the rights to use, copy, modify, merge, publish,
// distribute, sublicense, and/or sell copies of the Software, and to
// permit persons to whom the Software is furnished to do so, subject to
// the following conditions:
// 
// The above copyright notice and this permission notice shall be
// included in all copies or substantial portions of the Software.
// 
// THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND,
// EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF
// MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND
// NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT HOLDERS BE
// LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION
// OF CONTRACT, TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN CONNECTION
// WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE SOFTWARE.
//

using System;
using jabber;
using jabber.protocol.client;

namespace XmppApplication.Base
{
	public class Messaging
	{
		internal Messaging ()
		{
			XmppGlobal.InternalClient.OnMessage += new jabber.client.MessageHandler (InternalClient_OnMessage);
		}

		#region Public Methods
		public void SendMessage (JID toJid, string body)
		{
			Message m = new Message (XmppGlobal.InternalClient.Document);
			
			m.To = toJid;
			m.Body = body;
			m.Type = MessageType.chat;
			
			XmppGlobal.InternalClient.Write (m);
		}

		public void SendMessage (JID toJid, string body, MessageType type)
		{
			Message m = new Message (XmppGlobal.InternalClient.Document);

			m.To = toJid;
			m.Body = body;
			m.Type = type;

			XmppGlobal.InternalClient.Write (m);
		}

		public void SendMessage (JID toJid, string body, MessageType type, string threadID)
		{
			Message m = new Message (XmppGlobal.InternalClient.Document);

			m.To = toJid;
			m.Body = body;
			m.Type = type;
			m.Thread = threadID;
			
			XmppGlobal.InternalClient.Write (m);
		}
		#endregion
		
		#region Protected Methods
		void InternalClient_OnMessage (object sender, jabber.protocol.client.Message msg)
		{
			OnGotMessage (new MessageEventArgs (msg));
		}
		
		protected void OnGotMessage (MessageEventArgs e)
		{
			if (GotMessage != null)
				GotMessage (this, e);
		}
		#endregion

		#region Events
		public event EventHandler<MessageEventArgs> GotMessage;
		#endregion

	}
}
