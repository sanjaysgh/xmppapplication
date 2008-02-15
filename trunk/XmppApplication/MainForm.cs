//
// MainForm.cs
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
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using System.Xml;
using XmppApplication.Base;
using XmppApplication.GuiControls;
using XmppApplication.Interfaces;

namespace XmppApplication
{
	public partial class MainForm : Form
	{
		private ContextMenuStrip away_context_menu = new ContextMenuStrip ();
		private StatusPanel away_status_bar;
		private Dictionary<string, MessageWindow> message_windows = new Dictionary<string,MessageWindow> ();

		#region Constructor
		public MainForm ()
		{
			InitializeComponent ();

			// Load settings from config file
			txtUserJid.Text = XmppApplication.Properties.Settings.Default.UserJid;
			txtPassword.Text = XmppApplication.Properties.Settings.Default.Password;
			
			txtUserJid_LostFocus (this, EventArgs.Empty);
			
			ConnectingSpinner.Image = XmppImages.Spinner;
			
			XmppGlobal.SetGuiForm (this);
			XmppGlobal.Debug.DebugWindow = new XmppApplication.GuiControls.DebugWindow ();

			PictureBox1.Image = XmppImages.DefaultAvatar;

			foreach (Extension e in ExtensionManager.GetExtensions (Path.Combine (Path.GetDirectoryName (Application.ExecutablePath), "Extensions")))
				e.Initialize ();
			
			this.Text = "Xmpp Client";

			XmppGlobal.Connection.Authenticated += new EventHandler (OnConnect);
			XmppGlobal.Connection.Disconnected += new EventHandler (Connection_Disconnected);
			XmppGlobal.Messaging.GotMessage += new EventHandler<MessageEventArgs> (Messaging_GotMessage);
			XmppGlobal.Roster.GotRosterItem += new EventHandler<RosterItemEventArgs> (GotRosterItem);
			XmppGlobal.Roster.RosterBegin += new EventHandler (OnRosterBegin);
			XmppGlobal.Roster.RosterEnd += new EventHandler (OnRosterEnd);
			XmppGlobal.Presence.AwayMessagesListChanged += new EventHandler (Presence_AwayMessagesListChanged);
			XmppGlobal.Presence.GotSubscriptionRequest += new EventHandler<PresenceItemEventArgs> (Presence_GotSubscriptionRequest);

			StatusChooser1.Click += new EventHandler (StatusChooser1_Click);
			txtUserJid.GotFocus += new EventHandler (txtUserJid_GotFocus);
			txtUserJid.LostFocus += new EventHandler (txtUserJid_LostFocus);
			
			ToolStripManager.Renderer = new ToolStripProfessionalRenderer (new CustomColorTable ());
		}
		#endregion

		#region Private Methods
		private void ActionImageAdded (object sender, ActionImageEventArgs e)
		{
			RosterItem ri = (RosterItem)sender;
			ContactItem ci = ContactListPanel.GetContactItem (ri.Jid.Bare);

			if (ci != null)
				ci.AddActionImage (e.Item, e.Item.ToolTip);
		}

		private void AddBuddyToolStripMenuItem_Click (object sender, EventArgs e)
		{
			AddContactDialog acd = new AddContactDialog ();
			acd.Show ();
		}

		// User clicked a saved away message
		private void AwayMessage_Click (object sender, EventArgs e)
		{
			AwayMessageItem ami = (AwayMessageItem)((sender as ToolStripMenuItem).Tag);

			XmppGlobal.Presence.SetPresence (ami.Type, ami.Message);

			SetAwayStatusBar (ami.Message);
		}

		// User closed the away status bar, set them back to available
		private void AwayMessageStatusBar_Closed (object sender, EventArgs e)
		{
			XmppGlobal.Presence.SetPresence (Availability.Available, "Online");
			StatusChooser1.Text = "Online";
			StatusPanel.Controls.Remove (away_status_bar);
			away_status_bar = null;
		}

		private void ConnectButton_Click (object sender, EventArgs e)
		{
			// Make sure a JID and password were entered
			if (txtUserJid.TextLength == 0 || txtUserJid.Text == "username@server.com") {
				MessageBox.Show ("You must enter an IM address.");
				return;
			} else if (txtPassword.TextLength == 0) {
				MessageBox.Show ("You must enter your password.");
				return;
			}
			
			// Make sure a valid JID was entered
			jabber.JID UserJid;

			try {
				UserJid = new jabber.JID (this.txtUserJid.Text);
			} catch (Exception) {
				MessageBox.Show ("Invalid IM address entered.  Please try again.");
				return;
			}

			this.AcceptButton = null;
			ConnectButton.Enabled = false;
			ConnectingLabel.Visible = true;
			ConnectingSpinner.Visible = true;

			// Save settings
			Properties.Settings.Default.UserJid = txtUserJid.Text;
			Properties.Settings.Default.Save ();

			// Give the UI changes a chance to update
			Application.DoEvents ();
			
			//Set all the login parameters
			XmppGlobal.Connection.Username = UserJid.User;
			XmppGlobal.Connection.Server = UserJid.Server;
			XmppGlobal.Connection.Password = this.txtPassword.Text;
			XmppGlobal.Connection.Port = 5222;
			XmppGlobal.Connection.Resource = "Test";
			XmppGlobal.Connection.Priority = 1;
			XmppGlobal.Connection.Encryption = (EncryptionMode)0;

			// We don't treat anyone special, except Google  :/
			if (XmppGlobal.Connection.Server == "gmail.com")
				XmppGlobal.Connection.NetworkHost = "talk.google.com";
			else
				XmppGlobal.Connection.NetworkHost = string.Empty;
			
			XmppGlobal.Connection.Connect ();
		}

		private void Connection_Disconnected (object sender, EventArgs e)
		{
			// Switch from contact list mode to login mode
			LoginPanel.Show ();
			ContactListPanel.Hide ();
			ContactListPanel.Controls.Clear ();

			LogoffMenu.Enabled = false;
			AddBuddyToolStripMenuItem.Enabled = false;
			ServerDiscoToolStripMenuItem.Enabled = false;

			StatusChooser1.Text = "Offline";
			StatusChooser1.Enabled = false;
			StatusPanel.Controls.Remove (away_status_bar);
			away_status_bar = null;

			ConnectingLabel.Visible = false;
			ConnectingSpinner.Visible = false;
			ConnectButton.Enabled = true;
			AcceptButton = ConnectButton;
		}

		private void ContactItem_DoubleClick (object sender, EventArgs e)
		{
			ContactItem ci = (ContactItem)sender;

			InstantMessageMenuItem_Clicked (XmppGlobal.Roster[new jabber.JID ((string)ci.Tag)].GetContextMenuItem (DefaultContextMenu.InstantMessage), null);
		}

		private void ContactItem_MouseDown (object sender, MouseEventArgs e)
		{
			ContactItem ci = (ContactItem)sender;

			if (e.Button == MouseButtons.Right) {
				RosterItem ri = XmppGlobal.Roster[new jabber.JID ((string)ci.Tag)];
				ri.ContextMenu.Show (Control.MousePosition);
			}
		}

		private void DebugWindowMenu_Click (object sender, EventArgs e)
		{
			XmppGlobal.Debug.ShowDebugWindow ();
		}

		private void ExitMenu_Click (object sender, EventArgs e)
		{
			Close ();
		}

		private void GetInformationMenuItem_Click (object sender, EventArgs e)
		{
			RosterItem ri = (RosterItem)(sender as ToolStripMenuItem).Tag;

			UserVCardDialog uvd = new UserVCardDialog ();
			uvd.LoadVCard (ri.Jid);
			uvd.Show ();
		}

		private void GotRosterItem (object sender, RosterItemEventArgs e)
		{
			if ((e.Item.ParentNode.ParentNode as XmlElement).GetAttribute ("type") != "result")
				return;

			if (e.Item.Subscription != jabber.protocol.iq.Subscription.both && e.Item.Subscription != jabber.protocol.iq.Subscription.to)
				return;

			string group = "Unfiled";

			if (e.RosterItem.JabberRosterItem.GetGroups ().Length > 0)
				group = e.RosterItem.JabberRosterItem.GetGroups ()[0].GroupName;

			ContactItem ci = new ContactItem (e.RosterItem.GetDisplayName (), "Offline", null);

			ci.Tag = e.RosterItem.Jid.Bare;
			ci.Visible = false;
			ci.Image = XmppImages.DefaultAvatar;

			ContactListPanel.AddContactItem (ci, group);

			e.RosterItem.PresenceChanged += new EventHandler<PresenceItemEventArgs> (PresenceChanged);
			e.RosterItem.ActionImageAdded += new EventHandler<ActionImageEventArgs> (ActionImageAdded);
			e.RosterItem.AvatarChanged += new EventHandler (RosterItem_AvatarChanged);
			e.RosterItem.RosterItemChanged += new EventHandler<RosterItemEventArgs> (RosterItem_RosterItemChanged);

			e.RosterItem.ContextMenu.Items[0].Click += new EventHandler (InstantMessageMenuItem_Clicked);
			e.RosterItem.ContextMenu.Items[1].Click += new EventHandler (GetInformationMenuItem_Click);
			e.RosterItem.ContextMenu.Items[3].Click += new EventHandler (RenameMenuItem_Click);

			ci.MouseDown += new MouseEventHandler (ContactItem_MouseDown);
			ci.DoubleClick += new EventHandler (ContactItem_DoubleClick);
		}

		// TODO: This is messy and I don't like it.  The problem is that I want things hooking into the Base
		// to be able to create and access chat windows.  But chat windows are created and managed by the application
		// and not the library.  For now, the library just raises an event saying to show a chat window.
		private void InstantMessageMenuItem_Clicked (object sender, EventArgs e)
		{
			RosterItem ri = (RosterItem)(sender as ToolStripMenuItem).Tag;

			MessageWindow msg;

			// Create a message window or use an existing one
			if (!message_windows.ContainsKey (ri.Jid.Bare)) {
				msg = new MessageWindow (ri.Jid);
				message_windows.Add (ri.Jid.Bare, msg);
			} else
				msg = message_windows[ri.Jid.Bare];

			msg.Show ();
		}

		private void LogoffMenu_Click (object sender, EventArgs e)
		{
			XmppGlobal.Connection.Disconnect ();
		}

		// Called when we receive a Message from the server
		private void Messaging_GotMessage (object sender, MessageEventArgs e)
		{
			switch (e.Item.Type) {
				case jabber.protocol.client.MessageType.chat:
				case jabber.protocol.client.MessageType.normal:
					if (e.Item.Body != null && e.Item.Body.Trim ().Length > 0) {
						MessageWindow msg;

						// Create a message window or use an existing one
						if (!message_windows.ContainsKey (e.Item.From.Bare)) {
							msg = new MessageWindow (e.Item.From);
							message_windows.Add (e.Item.From.Bare, msg);
						} else
							msg = message_windows[e.Item.From.Bare];

						msg.Show ();
						msg.GotMessage (e.Item);
					}

					break;
			}
		}

		// User clicked "New Away Message"
		private void NewAwayMessage_Click (object sender, EventArgs e)
		{
			NewAwayMessageDialog dialog = new NewAwayMessageDialog ();

			if (dialog.ShowDialog () == DialogResult.OK) {
				if (dialog.AwayMessageTextBox.TextLength > 0) {
					// Set current presence
					XmppGlobal.Presence.SetPresence (Availability.Away, dialog.AwayMessageTextBox.Text);
					SetAwayStatusBar (dialog.AwayMessageTextBox.Text);

					// User wants to save the away message
					if (dialog.SaveMessageCheckBox.Checked) {
						string title = dialog.TitleTextBox.Text;

						if (title.Length == 0)
							title = dialog.AwayMessageTextBox.Text.PadRight (30).Substring (0, 30).Trim ();

						XmppGlobal.Presence.AwayMessages.Add (new AwayMessageItem (Availability.Away, title, dialog.AwayMessageTextBox.Text));
					}
				}
			}
		}

		private void OnConnect (object sender, EventArgs e)
		{
			// Switch from login mode to contact list mode
			ContactListPanel.Show ();
			LoginPanel.Hide ();

			LogoffMenu.Enabled = true;
			AddBuddyToolStripMenuItem.Enabled = true;
			ServerDiscoToolStripMenuItem.Enabled = true;
			
			PopulateAwayMessages ();
			
			UserLabel.Text = XmppGlobal.Connection.Username;
			StatusChooser1.Text = "Online";
			StatusChooser1.Enabled = true;
		}

		// Suspend ContactList layout for performance
		private void OnRosterBegin (object sender, EventArgs e)
		{
			XmppGlobal.Presence.SetPresence (Availability.Available, "Online");
			ContactListPanel.SuspendLayout ();
		}

		// Resume ContactList layout
		private void OnRosterEnd (object sender, EventArgs e)
		{
			ContactListPanel.ResumeLayout ();
		}

		private void PluginConfigurationToolStripMenuItem_Click (object sender, EventArgs e)
		{
			ExtensionConfigurationDialog dialog = new ExtensionConfigurationDialog ();
			dialog.ShowDialog ();
		}

		private void PopulateAwayMessages ()
		{
			away_context_menu.Items.Clear ();
			away_context_menu.Items.Add ("New Away Message", null, new EventHandler (NewAwayMessage_Click));
			
			if (XmppGlobal.Presence.AwayMessages.Count > 0) {
				// Create the remove menu and the menu separator
				ToolStripMenuItem RemoveMenu = (ToolStripMenuItem)away_context_menu.Items.Add ("Remove Away Message");
				away_context_menu.Items.Add (new ToolStripSeparator ());
				
				// Add each message to the remove menu and the available messages
				foreach (AwayMessageItem ami in XmppGlobal.Presence.AwayMessages) {
					ToolStripMenuItem tsmi = new ToolStripMenuItem (ami.Title, null, new EventHandler (AwayMessage_Click));
					tsmi.Tag = ami;
					away_context_menu.Items.Add (tsmi);
					
					ToolStripMenuItem tsmi2 = new ToolStripMenuItem (ami.Title, null, new EventHandler (RemoveAwayMessage_Click));
					tsmi2.Tag = ami;
					RemoveMenu.DropDownItems.Add (tsmi2);
				}
			}
		}

		private void Presence_AwayMessagesListChanged (object sender, EventArgs e)
		{
			// TODO serialiaze and save
			PopulateAwayMessages ();
		}

		// Called when someone asks for a subscription to us
		private void Presence_GotSubscriptionRequest (object sender, PresenceItemEventArgs e)
		{
			SubscriptionRequestDialog dialog = new SubscriptionRequestDialog (e.Item);
			dialog.Show ();
		}

		private void PresenceChanged (object sender, PresenceItemEventArgs e)
		{
			RosterItem ri = (RosterItem)sender;
			jabber.protocol.client.Presence pres = ri.GetPresence ();

			if (pres == null)
				pres = e.Item;

			ContactItem ci = null;

			if (pres != null) {
				ci = ContactListPanel.GetContactItem (ri.Jid.Bare);

				if (pres.Status != null)
					ci.TextLineTwo = pres.Status;
				else if (pres.Show != null)
					ci.TextLineTwo = pres.Show;
				else
					ci.TextLineTwo = "Online";
			}

			switch (pres.Type) {
				case jabber.protocol.client.PresenceType.available:
					if (!(ci == null)) {
						ci.Enabled = true;
						ci.Visible = true;
						ci.Image = ri.Avatar;
					}
					break;
				case jabber.protocol.client.PresenceType.unavailable:
					if (ci != null) {
						ci.Enabled = false;
						ci.Visible = false;
					}
					break;
			}
		}

		// User wants to delete a saved away message
		private void RemoveAwayMessage_Click (object sender, EventArgs e)
		{
			XmppGlobal.Presence.AwayMessages.Remove ((AwayMessageItem)((sender as ToolStripItem).Tag));
		}

		private void RenameMenuItem_Click (object sender, EventArgs e)
		{
			RosterItem ri = (RosterItem)(sender as ToolStripMenuItem).Tag;

			RenameContactDialog rcd = new RenameContactDialog ();
			rcd.Setup (ri);

			if (rcd.ShowDialog () == DialogResult.OK && !string.IsNullOrEmpty (rcd.ContactNameTextBox.Text))
				ri.Nickname = rcd.ContactNameTextBox.Text;
		}

		private void RosterItem_AvatarChanged (object sender, EventArgs e)
		{
			RosterItem ri = (RosterItem)sender;
			ContactItem ci = ContactListPanel.GetContactItem (ri.Jid.Bare);

			if (ci != null)
				ci.Image = ri.Avatar;
		}

		private void RosterItem_RosterItemChanged (object sender, RosterItemEventArgs e)
		{
			ContactListPanel.GetContactItem (e.RosterItem.Jid.ToString ()).TextLineOne = e.RosterItem.GetDisplayName ();
		}

		private void ServerDiscoToolStripMenuItem_Click (object sender, EventArgs e)
		{
			ServiceBrowser sb = new ServiceBrowser ();
			sb.Show ();
		}

		private void SetAwayStatusBar (string awayMessage)
		{
			if (away_status_bar == null) {
				StatusPanel sbp = new StatusPanel ();

				sbp.Image = XmppImages.AwayOverlay;
				sbp.Text = awayMessage;
				sbp.Width = StatusPanel.Width;
				sbp.ImageStretchMode = PictureBoxSizeMode.CenterImage;
				sbp.Visible = true;

				sbp.BarClosed += new EventHandler (AwayMessageStatusBar_Closed);

				away_status_bar = sbp;
				StatusPanel.Controls.Add (sbp);
			} else
				away_status_bar.Text = awayMessage;

			StatusChooser1.Text = "Away";
		}

		private void StatusChooser1_Click (object sender, EventArgs e)
		{
			away_context_menu.Show (StatusChooser1, new Point (0, StatusChooser1.Height));
		}

		private void txtUserJid_GotFocus (object sender, EventArgs e)
		{
			txtUserJid.ForeColor = Color.Black;
			txtUserJid.Font = new Font (txtUserJid.Font, FontStyle.Regular);
			
			if (txtUserJid.Text == "username@server.com")
				txtUserJid.Text = string.Empty;
		}

		private void txtUserJid_LostFocus (object sender, EventArgs e)
		{
			if (txtUserJid.TextLength == 0 || txtUserJid.Text == "username@server.com") {
				txtUserJid.ForeColor = Color.DarkGray;
				txtUserJid.Font = new Font (txtUserJid.Font, FontStyle.Italic);
				txtUserJid.Text = "username@server.com";
			}
		}
		#endregion
	}
}