//
// RosterItem.cs
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
using System.Drawing;
using System.Windows.Forms;

namespace XmppApplication.Base
{
	public class RosterItem : Component
	{
		#region Fields
		private jabber.JID jid;
		private List<ActionImage> action_images = new List<ActionImage> ();
		private Image base_avatar = XmppImages.DefaultAvatar;
		private bool base_avatar_is_default = true;

		private ContextMenuStrip context_menu = new ContextMenuStrip ();
		private List<RosterResource> connected_resources = new List<RosterResource> ();
		private Dictionary<DefaultContextMenu, ToolStripMenuItem> default_context_menu_items = new Dictionary<DefaultContextMenu, ToolStripMenuItem> ();
		#endregion

		#region Public Constructor
		public RosterItem (jabber.JID jid)
		{
			this.jid = jid;

			CreateContextMenu ();
		}
		#endregion

		#region Public Properties
		public jabber.protocol.iq.Item JabberRosterItem
		{
			//Provide access to the jabber-net Item
			get { return XmppGlobal.InternalRoster[jid]; }
		}

		public bool IsAvailable
		{
			//Convenience property to see if this contact is online
			get { return XmppGlobal.InternalPresence.IsAvailable (jid); }
		}

		public jabber.JID Jid
		{
			//This RosterItem's Jid
			get { return jid; }
		}

		public ContextMenuStrip ContextMenu
		{
			//The ContextMenu created for this RosterItem
			get { return context_menu; }
		}

		public jabber.protocol.iq.Subscription Subscription
		{
			//The subscription we have to/from this contact
			get { return this.JabberRosterItem.Subscription; }
		}

		public List<RosterResource> ConnectedResources
		{
			//The RosterResources that are currently connected for this RosterItem
			get { return connected_resources; }
		}

		public string Nickname
		{
			//Get/Set the Nickname for this RosterItem
			get { return this.JabberRosterItem.Nickname; }
			set
			{
				//Note that this is set on the server, which will push a new Item to us with the updated Nickname
				jabber.protocol.iq.Item i = this.JabberRosterItem;
				i.Nickname = value;

				jabber.protocol.iq.RosterIQ ri = new jabber.protocol.iq.RosterIQ (XmppGlobal.Connection.JabberDocument);

				ri.Query.AppendChild (ri.OwnerDocument.ImportNode (i, true));
				ri.Type = jabber.protocol.client.IQType.set;

				XmppGlobal.InternalClient.Write (ri);
			}
		}

		public Image BaseAvatar
		{
			//The unmodified avatar for this RosterItem
			get { return base_avatar; }
			set
			{
				base_avatar = value;
				base_avatar_is_default = false;

				OnAvatarChanged (EventArgs.Empty);
			}
		}

		public Image Avatar
		{
			//The modified avatar for this RosterItem
			// - If the contact is away, we fade it and put an away overlay image on it
			// - If the contact is offline, we convert the avatar to grayscale
			get
			{
				if (this.IsAvailable) {
					jabber.protocol.client.Presence p = this.GetPresence ();

					if (p.Show == null) {
						if (p.Status != null && p.Status.ToLower ().StartsWith ("idle")) {
							return ImageManipulation.OverlayImage (ImageManipulation.FadeImage (BaseAvatar, 0.4f), XmppImages.AwayOverlay);
						} else {
							return BaseAvatar;
						}
					} else {
						switch (p.Show) {
							case "away":
							case "xa":
							case "dnd":
								return ImageManipulation.OverlayImage (ImageManipulation.FadeImage (BaseAvatar, 0.4f), XmppImages.AwayOverlay);
							default:
								if (p.Status != null && p.Status.ToLower ().StartsWith ("idle")) {
									return ImageManipulation.OverlayImage (ImageManipulation.FadeImage (BaseAvatar, 0.4f), XmppImages.AwayOverlay);
								} else {
									return BaseAvatar;
								}
						}
					}
				} else {
					return ImageManipulation.ConvertImageToGrayscale (BaseAvatar);
				}
			}
		}
		#endregion

		#region Public Methods
		// Add a new ActionImage to this RosterItem
		public ActionImage AddActionImage (Image image, string toolTip)
		{
			ActionImage ai = new ActionImage (image, toolTip);

			action_images.Add (ai);
			OnActionImageAdded (new ActionImageEventArgs (ai));

			return ai;
		}

		// We handle Context Menus here instead of in the Application so that plugins can later add their
		// own menu items to the context menus.
		private void CreateContextMenu ()
		{
			default_context_menu_items[DefaultContextMenu.InstantMessage] = new ToolStripMenuItem ("Instant Message", XmppApplication.Base.Properties.Resources.InstantMessage16);
			default_context_menu_items[DefaultContextMenu.InstantMessage].Tag = this;
			context_menu.Items.Add (default_context_menu_items[DefaultContextMenu.InstantMessage]);

			default_context_menu_items[DefaultContextMenu.GetInformation] = new ToolStripMenuItem ("Get Information", XmppApplication.Base.Properties.Resources.VCard16);
			default_context_menu_items[DefaultContextMenu.GetInformation].Tag = this;
			context_menu.Items.Add (default_context_menu_items[DefaultContextMenu.GetInformation]);

			context_menu.Items.Add (new ToolStripSeparator ());

			default_context_menu_items[DefaultContextMenu.Rename] = new ToolStripMenuItem ("Rename", XmppApplication.Base.Properties.Resources.Rename16);
			default_context_menu_items[DefaultContextMenu.Rename].Tag = this;
			context_menu.Items.Add (default_context_menu_items[DefaultContextMenu.Rename]);

			default_context_menu_items[DefaultContextMenu.Remove] = new ToolStripMenuItem ("Remove", XmppApplication.Base.Properties.Resources.Remove16);
			default_context_menu_items[DefaultContextMenu.Remove].Tag = this;
			context_menu.Items.Add (default_context_menu_items[DefaultContextMenu.Remove]);
		}

		public ToolStripMenuItem GetContextMenuItem (DefaultContextMenu menu)
		{
			return default_context_menu_items[menu];
		}

		public string GetDisplayName ()
		{
			if (!string.IsNullOrEmpty (JabberRosterItem.Nickname))
				return JabberRosterItem.Nickname;

			if (!string.IsNullOrEmpty (JabberRosterItem.JID.User))
				return JabberRosterItem.JID.User;

			if (!string.IsNullOrEmpty (JabberRosterItem.JID.ToString ()))
				return JabberRosterItem.JID.ToString ();

			return string.Empty;
		}

		public jabber.protocol.client.Presence GetPresence ()
		{
			return XmppGlobal.InternalPresence[jid];
		}

		// Remove an existing ActionImage from this RosterItem
		public void RemoveActionImage (ActionImage actionImage)
		{
			action_images.Remove (actionImage);
			OnActionImageRemoved (new ActionImageEventArgs (actionImage));
		}

		// Remove an existing ActionImage from this RosterItem
		public void RemoveActionImage (string name)
		{
			foreach (ActionImage ai in action_images)
				if (ai.Name == name) {
					action_images.Remove (ai);
					OnActionImageRemoved (new ActionImageEventArgs (ai));
					break;
				}
		}

		public void RequestVCard (QueryCallback callback, object state, bool forceRefresh)
		{
			jabber.protocol.client.IQ cached = XmppGlobal.InternalQueryCache.VCard[jid];

			if (!forceRefresh && cached != null) {
				if (callback != null)
					callback.Invoke (this, cached, state);
			} else {
				jabber.protocol.iq.VCardIQ iq = new jabber.protocol.iq.VCardIQ (XmppGlobal.InternalClient.Document);
				iq.To = jid;

				XmppGlobal.InternalTracker.BeginIQ (iq, new jabber.connection.IqCB (GotVCardResponse), new CallbackState (callback, state));
			}
		}
		#endregion

		#region Protected Methods
		protected void OnActionImageAdded (ActionImageEventArgs e)
		{
			EventHandler<ActionImageEventArgs> eh = (EventHandler<ActionImageEventArgs>)(Events[ActionImageAddedEvent]);
			if (eh != null)
				eh (this, e);

		}

		protected void OnActionImageRemoved (ActionImageEventArgs e)
		{
			EventHandler<ActionImageEventArgs> eh = (EventHandler<ActionImageEventArgs>)(Events[ActionImageRemovedEvent]);
			if (eh != null)
				eh (this, e);

		}

		protected void OnActionImageTooltipChanged (ActionImageEventArgs e)
		{
			EventHandler<ActionImageEventArgs> eh = (EventHandler<ActionImageEventArgs>)(Events[ActionImageToolTipChangedEvent]);
			if (eh != null)
				eh (this, e);

		}

		protected void OnAvatarChanged (EventArgs e)
		{
			EventHandler eh = (EventHandler)(Events[AvatarChangedEvent]);
			if (eh != null)
				eh (this, e);

		}

		protected void OnPresenceChanged (PresenceItemEventArgs e)
		{
			EventHandler<PresenceItemEventArgs> eh = (EventHandler<PresenceItemEventArgs>)(Events[PresenceChangedEvent]);
			if (eh != null)
				eh (this, e);

		}

		protected void OnRosterItemChanged (RosterItemEventArgs e)
		{
			EventHandler<RosterItemEventArgs> eh = (EventHandler<RosterItemEventArgs>)(Events[RosterItemChangedEvent]);
			if (eh != null)
				eh (this, e);

		}

		protected void OnVCardReceived (VCardEventArgs e)
		{
			EventHandler<VCardEventArgs> eh = (EventHandler<VCardEventArgs>)(Events[VCardReceivedEvent]);
			if (eh != null)
				eh (this, e);

		}
		#endregion

		#region Internal/Private Methods
		internal void GotPresenceItem (jabber.protocol.client.Presence pres)
		{
			switch (pres.Type) {
				case jabber.protocol.client.PresenceType.available:
					RequestVCard (null, null, false);
					OnPresenceChanged (new PresenceItemEventArgs (pres));
					break;
				case jabber.protocol.client.PresenceType.unavailable:
					OnPresenceChanged (new PresenceItemEventArgs (pres));
					break;
			}
		}

		internal void GotUpdatedRosterItem (jabber.protocol.iq.Item item)
		{
			OnRosterItemChanged (new RosterItemEventArgs (this, item));
		}

		internal void GotVCardResponse (object sender, jabber.protocol.client.IQ response, object data)
		{
			try {
				XmppGlobal.InternalQueryCache.VCard[response.From.Bare] = response;

				jabber.protocol.iq.VCard vcard = (jabber.protocol.iq.VCard)response.Query;

				if (vcard.Photo != null)
					if (vcard.Photo["BINVAL"] != null)
						BaseAvatar = ImageManipulation.Base64ToImage (vcard.Photo["BINVAL"].InnerText);

				OnVCardReceived (new VCardEventArgs (response));

				CallbackState state = (CallbackState)data;

				if (state.Callback != null)
					state.Callback.Invoke (sender, response, state.State);
			} catch (Exception ex) {
				Console.WriteLine (ex.ToString ());
			}
		}
		#endregion

		#region Public Events
		static object ActionImageAddedEvent = new object ();
		static object ActionImageRemovedEvent = new object ();
		static object ActionImageToolTipChangedEvent = new object ();
		static object AvatarChangedEvent = new object ();
		static object PresenceChangedEvent = new object ();
		static object RosterItemChangedEvent = new object ();
		static object VCardReceivedEvent = new object ();

		public event EventHandler<ActionImageEventArgs> ActionImageAdded
		{
			add { Events.AddHandler (ActionImageAddedEvent, value); }
			remove { Events.RemoveHandler (ActionImageAddedEvent, value); }
		}

		public event EventHandler<ActionImageEventArgs> ActionImageRemoved
		{
			add { Events.AddHandler (ActionImageRemovedEvent, value); }
			remove { Events.RemoveHandler (ActionImageRemovedEvent, value); }
		}

		public event EventHandler<ActionImageEventArgs> ActionImageToolTipChanged
		{
			add { Events.AddHandler (ActionImageToolTipChangedEvent, value); }
			remove { Events.RemoveHandler (ActionImageToolTipChangedEvent, value); }
		}

		public event EventHandler AvatarChanged
		{
			add { Events.AddHandler (AvatarChangedEvent, value); }
			remove { Events.RemoveHandler (AvatarChangedEvent, value); }
		}

		public event EventHandler<PresenceItemEventArgs> PresenceChanged
		{
			add { Events.AddHandler (PresenceChangedEvent, value); }
			remove { Events.RemoveHandler (PresenceChangedEvent, value); }
		}

		public event EventHandler<RosterItemEventArgs> RosterItemChanged
		{
			add { Events.AddHandler (RosterItemChangedEvent, value); }
			remove { Events.RemoveHandler (RosterItemChangedEvent, value); }
		}

		public event EventHandler<VCardEventArgs> VCardReceived
		{
			add { Events.AddHandler (VCardReceivedEvent, value); }
			remove { Events.RemoveHandler (VCardReceivedEvent, value); }
		}
		#endregion
	}
}