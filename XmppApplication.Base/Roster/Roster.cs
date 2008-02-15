//
// Roster.cs
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
using System.ComponentModel;
using System.Windows.Forms;
using System.Xml;

namespace XmppApplication.Base
{
	public class Roster : Component, IDictionary<jabber.JID, RosterItem>
	{
		private Dictionary<jabber.JID, RosterItem> roster_items = new Dictionary<jabber.JID, RosterItem> ();

		#region Internal Constructors
		internal Roster ()
		{
			XmppGlobal.InternalRoster.OnRosterBegin += new bedrock.ObjectHandler (GotRosterBeginHandler);
			XmppGlobal.InternalRoster.OnRosterEnd += new bedrock.ObjectHandler (GotRosterEndHandler);
			XmppGlobal.InternalRoster.OnRosterItem += new jabber.client.RosterItemHandler (GotRosterItemHandler);
		}
		#endregion

		#region Protected Methods
		protected void OnGotRosterItem (RosterItemEventArgs e)
		{
			EventHandler<RosterItemEventArgs> eh = (EventHandler<RosterItemEventArgs>)(Events[GotRosterItemEvent]);
			if (eh != null)
				eh (this, e);
		}

		protected void OnRosterBegin (EventArgs e)
		{
			EventHandler eh = (EventHandler)(Events[RosterBeginEvent]);
			if (eh != null)
				eh (this, e);
		}

		protected void OnRosterItemRemoved (RosterItemEventArgs e)
		{
			EventHandler<RosterItemEventArgs> eh = (EventHandler<RosterItemEventArgs>)(Events[RosterItemRemovedEvent]);
			if (eh != null)
				eh (this, e);
		}

		protected void OnRosterEnd (EventArgs e)
		{
			EventHandler eh = (EventHandler)(Events[RosterEndEvent]);
			if (eh != null)
				eh (this, e);
		}
		#endregion

		#region Private Methods
		private void GotRosterBeginHandler (object sender)
		{
			OnRosterBegin (EventArgs.Empty);
		}

		private void GotRosterEndHandler (object sender)
		{
			OnRosterEnd (EventArgs.Empty);
		}

		private void GotRosterItemHandler (object sender, jabber.protocol.iq.Item ri)
		{
			try {
				// See if we already have this Item in our collection
				RosterItem item;
				roster_items.TryGetValue (ri.JID, out item);

				// If it's new, add it to our roster and raise the GotRosterItem event
				if (item == null) {
					item = new RosterItem (ri.JID);
					roster_items.Add (ri.JID, item);

					OnGotRosterItem (new RosterItemEventArgs (item, ri));
				} else {
					// If it's a remove roster update, remove the RosterItem as raise the RosterItemRemoved event
					if (ri.Subscription == jabber.protocol.iq.Subscription.remove) {
						roster_items.Remove (item.Jid);
						OnRosterItemRemoved (new RosterItemEventArgs (item, ri));
					} else {
						// If it's an update, send it to the existing RosterItem, which will handle raising events
						item.GotUpdatedRosterItem (ri);
					}
				}

				// If the server sent us a "set" (update) roster item, we are supposed to acknowledge it with a "result"
				if ((ri.ParentNode.ParentNode as XmlElement).GetAttribute ("type") == "set") {
					jabber.protocol.client.IQ result = (jabber.protocol.client.IQ)ri.ParentNode.ParentNode;
					result.Type = jabber.protocol.client.IQType.result;
					result.Swap ();
					XmppGlobal.InternalClient.Write (result);
				}
			} catch (Exception ex) {
				MessageBox.Show (ex.ToString ());
			}
		}
		#endregion

		#region Public Events
		static object GotRosterItemEvent = new object ();
		static object RosterBeginEvent = new object ();
		static object RosterItemRemovedEvent = new object ();
		static object RosterEndEvent = new object ();

		public event EventHandler<RosterItemEventArgs> GotRosterItem
		{
			add { Events.AddHandler (GotRosterItemEvent, value); }
			remove { Events.RemoveHandler (GotRosterItemEvent, value); }
		}

		public event EventHandler RosterBegin
		{
			add { Events.AddHandler (RosterBeginEvent, value); }
			remove { Events.RemoveHandler (RosterBeginEvent, value); }
		}

		public event EventHandler<RosterItemEventArgs> RosterItemRemoved
		{
			add { Events.AddHandler (RosterItemRemovedEvent, value); }
			remove { Events.RemoveHandler (RosterItemRemovedEvent, value); }
		}

		public event EventHandler RosterEnd
		{
			add { Events.AddHandler (RosterEndEvent, value); }
			remove { Events.RemoveHandler (RosterEndEvent, value); }
		}
		#endregion

		#region IDictionary<JID,RosterItem> Members
		// Public method for callers to get a new contact added to the Roster
		// Note that we do not add it to our internal roster, the server will send a roster item push
		public void Add (string jid, string nickname, string[] groups)
		{
			// Add the contact to our roster
			jabber.protocol.iq.RosterIQ riq = new jabber.protocol.iq.RosterIQ (XmppGlobal.InternalClient.Document);

			riq.Type = jabber.protocol.client.IQType.set;

			jabber.protocol.iq.Roster r = (jabber.protocol.iq.Roster)riq.Query;
			jabber.protocol.iq.Item i = r.AddItem ();

			i.JID = new jabber.JID (jid);

			foreach (string g in groups)
				i.AddGroup (g);

			if (!string.IsNullOrEmpty (nickname))
				i.Nickname = nickname;

			XmppGlobal.InternalClient.Write (riq);

			// Subscribe to the contact's presence
			jabber.protocol.client.Presence p = new jabber.protocol.client.Presence (XmppGlobal.InternalClient.Document);
			p.Type = jabber.protocol.client.PresenceType.subscribe;
			p.To = new jabber.JID (jid);

			XmppGlobal.InternalClient.Write (p);
		}

		// Convenience overload
		public void Add (string jid, string nickname)
		{
			Add (jid, nickname, null);
		}

		// Convenience overload
		public void Add (string jid)
		{
			Add (jid, string.Empty, null);
		}

		public void Add (jabber.JID key, RosterItem value)
		{
			throw new Exception ("The method or operation is not implemented.");
		}

		public bool ContainsKey (jabber.JID key)
		{
			return roster_items.ContainsKey (key);
		}

		public ICollection<jabber.JID> Keys
		{
			get { return roster_items.Keys; }
		}

		// Remove the contact from our Roster
		// Note that we do not remove it from our internal roster, the server will send a roster item push
		public void Remove (jabber.JID key, bool cancelContactsSubscriptionToUs)
		{
			//if (cancelContactsSubscriptionToUs) {
			//        jabber.protocol.iq.RosterIQ riq = new jabber.protocol.iq.RosterIQ (XmppGlobal.InternalClient.Document);

			//        riq.Type = jabber.protocol.client.IQType.set;

			//        jabber.protocol.iq.Roster r = riq.Query;
			//        jabber.protocol.iq.Item i = r.AddItem ();

			//        i.JID = key;
			//        i.Subscription = jabber.protocol.iq.Subscription.remove;

			//        XmppGlobal.InternalClient.Write (riq);
			//} else {
			//        // This is just we unsubscribe to them, they will still be in our roster with a "from" subscription
			//        jabber.protocol.client.Presence p = new jabber.protocol.client.Presence (XmppGlobal.InternalClient.Document);
			//        p.Type = jabber.protocol.client.PresenceType.unsubscribe;
			//        p.To = key;

			//        XmppGlobal.InternalClient.Write (p);
			//}
		}

		public bool Remove (jabber.JID key)
		{
			throw new Exception ("The method or operation is not implemented.");
		}

		public bool TryGetValue (jabber.JID key, out RosterItem value)
		{
			return roster_items.TryGetValue (key, out value);
		}

		public ICollection<RosterItem> Values
		{
			get { return roster_items.Values; }
		}

		public RosterItem this[jabber.JID key]
		{
			get
			{
				return roster_items[key];
			}
			set
			{
				roster_items[key] = value;
			}
		}

		#endregion

		#region ICollection<KeyValuePair<JID,RosterItem>> Members

		public void Add (KeyValuePair<jabber.JID, RosterItem> item)
		{
			throw new Exception ("The method or operation is not implemented.");
		}

		public void Clear ()
		{
			roster_items.Clear ();
		}

		public bool Contains (KeyValuePair<jabber.JID, RosterItem> item)
		{
			return roster_items.ContainsKey (item.Key) && roster_items.ContainsValue (item.Value);
		}

		public void CopyTo (KeyValuePair<jabber.JID, RosterItem>[] array, int arrayIndex)
		{
			throw new Exception ("The method or operation is not implemented.");
		}

		public int Count
		{
			get { return roster_items.Count; }
		}

		public bool IsReadOnly
		{
			get { return false; }
		}

		public bool Remove (KeyValuePair<jabber.JID, RosterItem> item)
		{
			throw new Exception ("The method or operation is not implemented.");
		}

		#endregion

		#region IEnumerable<KeyValuePair<JID,RosterItem>> Members

		public IEnumerator<KeyValuePair<jabber.JID, RosterItem>> GetEnumerator ()
		{
			return roster_items.GetEnumerator ();
		}

		#endregion

		#region IEnumerable Members

		System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator ()
		{
			return roster_items.GetEnumerator ();
		}

		#endregion
	}
}