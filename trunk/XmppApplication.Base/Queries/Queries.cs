//
// Queries.cs
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

using jabber.protocol.client;
using jabber.protocol.iq;

namespace XmppApplication.Base
{
	public class Queries
	{
		internal Queries ()
		{
		}
		
		#region Public Methods
		public CommandsIQ CreateCommandsQuery ()
		{
			CommandsIQ iq = new CommandsIQ (XmppGlobal.InternalClient.Document);
			iq.Type = jabber.protocol.client.IQType.get;
			return iq;
		}

		public DiscoInfoIQ CreateDiscoInfoQuery ()
		{
			DiscoInfoIQ iq = new DiscoInfoIQ (XmppGlobal.InternalClient.Document);
			iq.Type = jabber.protocol.client.IQType.get;
			return iq;
		}

		public DiscoItemsIQ CreateDiscoItemsQuery ()
		{
			DiscoItemsIQ iq = new DiscoItemsIQ (XmppGlobal.InternalClient.Document);
			iq.Type = jabber.protocol.client.IQType.get;
			return iq;
		}

		public TimeIQ CreateTimeQuery ()
		{
			TimeIQ iq = new TimeIQ (XmppGlobal.InternalClient.Document);
			iq.Type = jabber.protocol.client.IQType.get;
			return iq;
		}

		public VersionIQ CreateVersionQuery ()
		{
			VersionIQ iq = new VersionIQ (XmppGlobal.InternalClient.Document);
			iq.Type = jabber.protocol.client.IQType.get;
			return iq;
		}
	
		public VCardIQ CreateVCardQuery ()
		{
			return new VCardIQ (XmppGlobal.InternalClient.Document);
		}
		
		public void SendQuery (IQ iq, QueryCallback callback, object state)
		{
			XmppGlobal.InternalTracker.BeginIQ (iq, new jabber.connection.IqCB (GotQueryResponse), new CallbackState (callback, state));
		}
		#endregion

		#region Private Methods
		private void GotQueryResponse (object sender, IQ response, object data)
		{
			CallbackState state = (CallbackState)data;
			
			if (state.Callback != null)
				state.Callback.Invoke (sender, response, state.State);
		}
		#endregion
	}
}
