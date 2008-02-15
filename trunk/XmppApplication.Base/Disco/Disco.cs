//
// Disco.cs
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
using System.Collections.Generic;
using System.Text;
using jabber.protocol.iq;
using jabber.protocol.client;
using System.Xml;

namespace XmppApplication.Base
{
	public class Disco
	{
		private DiscoInfo disco_info;
		
		internal Disco ()
		{
			disco_info = new DiscoInfo (XmppGlobal.InternalClient.Document);
			
			AddIdentity ("client", "pc", "XmppApplication");
			AddFeature ("http://jabber.org/protocol/disco#info");

			XmppGlobal.InternalClient.OnIQ += new jabber.client.IQHandler (GotIQ);
		}

		#region Public Methods
		public void AddFeature (string var)
		{
			disco_info.AddFeature (var);
		}
		
		public void AddIdentity (string category, string discoType, string name)
		{
			disco_info.AddIdentity (category, discoType, name, "en");
		}

		public void DiscoInfoQuery (jabber.JID to, string node, bool refresh, QueryCallback callback, object state)
		{
			if (!refresh) {
				IQ cache_version = XmppGlobal.InternalQueryCache.DiscoInfo[to.ToString () + "!!!!!" + node];

				if (cache_version != null) {
					callback.Invoke (this, cache_version, state);
					return;
				}
			}

			DiscoInfoIQ iq = XmppGlobal.Queries.CreateDiscoInfoQuery ();
			iq.To = to;

			if (!string.IsNullOrEmpty (node))
				iq.Node = node;

			XmppGlobal.Queries.SendQuery (iq, callback, state);
		}

		public void DiscoItemsQuery (jabber.JID to, string node, bool refresh, QueryCallback callback, object state)
		{
			if (!refresh) {
				IQ cache_version = XmppGlobal.InternalQueryCache.DiscoItems[to.ToString () + "!!!!!" + node];

				if (cache_version != null) {
					callback.Invoke (this, cache_version, state);
					return;
				}
			}

			DiscoItemsIQ iq = XmppGlobal.Queries.CreateDiscoItemsQuery ();
			iq.To = to;

			if (!string.IsNullOrEmpty (node))
				iq.Node = node;

			XmppGlobal.Queries.SendQuery (iq, callback, state);
		}
		#endregion

		#region Private Methods
		private bool CheckForFormData (XmlElement xml)
		{
			if (xml.OuterXml.Contains ("jabber:x:data"))
				return true;
				
			return false;
		}
		
		private void GotIQ (object sender, IQ iq)
		{
			switch (iq.Type) {
				case IQType.get:
					if (iq.Query is DiscoInfo) {
						DiscoInfoIQ outdisco = new DiscoInfoIQ (XmppGlobal.InternalClient.Document);
						outdisco.Query = (XmlElement)disco_info.Clone ();
						outdisco.To = iq.From;
						outdisco.ID = iq.ID;
						outdisco.Type = IQType.result;
						XmppGlobal.Connection.SendPacket (outdisco);
					}
					break;
				case IQType.result:
					if (iq.Query is DiscoInfo)
						XmppGlobal.InternalQueryCache.DiscoInfo[iq.From.ToString () + "!!!!!" + (iq.Query as DiscoInfo).Node] = iq;
					else if (iq.Query is DiscoItems)
						XmppGlobal.InternalQueryCache.DiscoItems[iq.From.ToString () + "!!!!!" + (iq.Query as DiscoItems).Node] = iq;
					break;
			}
			
			//TODO: dataforms
			//if (CheckForFormData (iq)) {
			//        DataForm f = new DataForm ();
			//        f.LoadForm (iq);
			//        f.Show ();
			//}
		}
		#endregion
	}
}
