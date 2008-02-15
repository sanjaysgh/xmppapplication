//
// Presence.cs
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
using System.Collections.Specialized;
using System.IO;
using System.Xml.Serialization;
using jabber.protocol.client;

namespace XmppApplication.Base
{
	public class Presence
	{
		private EventingList<AwayMessageItem> away_messages = new EventingList<AwayMessageItem> ();

		internal Presence ()
		{
			away_messages.ListChanged += new EventHandler (away_messages_ListChanged);
			XmppGlobal.InternalClient.OnPresence += new jabber.client.PresenceHandler (InternalClient_OnPresence);
		}

		#region Properties
		public EventingList<AwayMessageItem> AwayMessages {
			get { return away_messages; }
		}
		#endregion
		
		#region Public Methods
		public void LoadAwayMessages (StringCollection awayArray)
		{
			away_messages.Clear ();
			
			XmlSerializer xs = new XmlSerializer (typeof (AwayMessageItem));
			
			foreach (string s in awayArray)
				away_messages.Add ((AwayMessageItem)xs.Deserialize (new StreamReader (s)));
		}
		
		public StringCollection SerializeAwayMessages ()
		{
			XmlSerializer xs = new XmlSerializer (typeof (AwayMessageItem));
			StringCollection sc = new StringCollection ();
			
			foreach (AwayMessageItem ami in away_messages) {
				StringWriter sw = new StringWriter ();
				xs.Serialize (sw, ami);
				sc.Add (sw.ToString ());
			}
			
			return sc;
		}
		
		public void SetPresence (Availability status, string message)
		{
			SetPresence (status, message, 1);
		}
		
		public void SetPresence (Availability status, string message, int priority)
		{
			switch (status) {
				case Availability.Available:
					XmppGlobal.InternalClient.Presence (PresenceType.available, message, "", priority);
					break;
				case Availability.Chat:
					XmppGlobal.InternalClient.Presence (PresenceType.available, message, "chat", priority);
					break;
				case Availability.Away:
					XmppGlobal.InternalClient.Presence (PresenceType.available, message, "away", priority);
					break;
				case Availability.ExtendedAway:
					XmppGlobal.InternalClient.Presence (PresenceType.available, message, "xa", priority);
					break;
				case Availability.DoNotDisturb:
					XmppGlobal.InternalClient.Presence (PresenceType.available, message, "dnd", priority);
					break;
			}
		}
		#endregion
		
		#region Protected Methods
		protected void OnAwayMessagesListChanged (EventArgs e)
		{
			if (AwayMessagesListChanged != null)
				AwayMessagesListChanged (this, e);
		}

		protected void OnGotPresenceItem (PresenceItemEventArgs e)
		{
			if (GotPresenceItem != null)
				GotPresenceItem (this, e);
		}

		protected void OnGotSubscriptionRequest (PresenceItemEventArgs e)
		{
			if (GotSubscriptionRequest != null)
				GotSubscriptionRequest (this, e);
		}
		#endregion

		#region Private Methods
		private void InternalClient_OnPresence (object sender, jabber.protocol.client.Presence pres)
		{
			switch (pres.Type) {
				case jabber.protocol.client.PresenceType.available:
				case jabber.protocol.client.PresenceType.unavailable:
					RosterItem ri;

					if (XmppGlobal.Roster.TryGetValue (new jabber.JID (pres.From.Bare), out ri))
						ri.GotPresenceItem (pres);
					break;
				case jabber.protocol.client.PresenceType.subscribe:
					OnGotSubscriptionRequest (new PresenceItemEventArgs (pres));
					break;
			}

			OnGotPresenceItem (new PresenceItemEventArgs (pres));
		}

		private void away_messages_ListChanged (object sender, EventArgs e)
		{
			OnAwayMessagesListChanged (EventArgs.Empty);
		}
		#endregion

		#region Events
		public event EventHandler<PresenceItemEventArgs> GotPresenceItem;
		public event EventHandler<PresenceItemEventArgs> GotSubscriptionRequest;
		public event EventHandler AwayMessagesListChanged;
		#endregion
	}
}
