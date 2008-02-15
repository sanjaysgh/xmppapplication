//
// ServiceBrowser.cs
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
using System.Drawing.Drawing2D;
using System.Windows.Forms;
using jabber.protocol.client;
using jabber.protocol.iq;
using XmppApplication.Base;

namespace XmppApplication
{
	public partial class ServiceBrowser : Form
	{
		private Color gradient_color_one = Color.FromArgb (214, 230, 255);
		private Color gradient_color_two = Color.FromArgb (186, 213, 249);

		private jabber.JID current_jid;
		private string current_node = string.Empty;
		
		private Stack<ItemNode> back_history = new Stack<ItemNode> ();
		private Stack<ItemNode> forward_history = new Stack<ItemNode> ();
		
		private bool got_one_response;
		private bool was_stopped;
		
		public ServiceBrowser ()
		{
			InitializeComponent ();
			
			Spinner.Image = XmppImages.Spinner;
			BackButton.Image = XmppImages.Back16;
			ForwardButton.Image = XmppImages.Forward16;
			RefreshButton.Image = XmppImages.Refresh16;
			StopButton.Image = XmppImages.Stop16;
			HomeButton.Image = XmppImages.Home16;
			GoButton.Image = XmppImages.Search16;
			ActionButton.Image = XmppImages.Gear22;
			ErrorPicture.Image = XmppImages.Error16;
			
			if (ToolStrip1.Renderer is ToolStripProfessionalRenderer)
				(ToolStrip1.Renderer as ToolStripProfessionalRenderer).RoundedEdges = false;

			ActionButton.Click += new EventHandler (ActionButton_Click);
			AddressTextBox.GotFocus += new EventHandler (AddressTextBox_GotFocus);
			AddressTextBox.KeyDown += new KeyEventHandler (AddressTextBox_KeyDown);
			ErrorPicture.Click += new EventHandler (ErrorPicture_Click);
			ServiceListView.DoubleClick += new EventHandler (ServiceListView_DoubleClick);
		}

		#region Protected Methods
		protected override void OnPaintBackground (PaintEventArgs e)
		{
			base.OnPaintBackground (e);

			Rectangle r = new Rectangle (0, ToolStrip1.Bottom, Width, 42);

			using (LinearGradientBrush b = new LinearGradientBrush (r, gradient_color_one, gradient_color_two, LinearGradientMode.Vertical))
				e.Graphics.FillRectangle (b, r);

			e.Graphics.DrawLine (Pens.DarkGray, 0, ToolStrip1.Bottom + 42, Right, ToolStrip1.Bottom + 42);
		}
		#endregion

		#region Private Methods
		// Show the ActionMenu when the ActionButton is clicked
		private void ActionButton_Click (object sender, EventArgs e)
		{
			ActionMenu.Show (ActionButton, new Point (1, ActionButton.Height - 1));
		}

		// Manage the back button entry list
		private void AddBackJid (jabber.JID jid, string node)
		{
			if (back_history.Count > 0) {
				ItemNode inode = back_history.Peek ();
				
				if (inode.Jid != jid || inode.Node != node) {
					back_history.Push (new ItemNode (jid, node));
					BackButton.Enabled = true;
				}
			} else {
				back_history.Push (new ItemNode (jid, node));
				BackButton.Enabled = true;
			}
		}

		// Manage the forward button entry list
		private void AddForwardJid (jabber.JID jid, string node)
		{
			forward_history.Push (new ItemNode (jid, node));
			ForwardButton.Enabled = true;
		}

		// When the AddressTextBox gets focus, select everything in it for easy delete 
		private void AddressTextBox_GotFocus (object sender, EventArgs e)
		{
			AddressTextBox.SelectAll ();
		}

		// If the user presses Enter while typing in the AddressTextBox, begin the query
		private void AddressTextBox_KeyDown (object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Enter) {
				GoButton_Click (this, e);
				e.SuppressKeyPress = true;
			}
		}

		// User clicked the back button
		private void BackButton_Click (object sender, EventArgs e)
		{
			ItemNode node = back_history.Pop ();

			AddForwardJid (current_jid, current_node);

			if (back_history.Count == 0)
				BackButton.Enabled = false;

			AddressTextBox.Text = node.Jid.ToString ();
			SubmitQuery (node.Jid, node.Node, false);
		}

		// Clicking on the error icon should display the error
		private void ErrorPicture_Click (object sender, EventArgs e)
		{
			MessageBox.Show ((string)ErrorPicture.Tag);
		}

		// User clicked the forward button
		private void ForwardButton_Click (object sender, EventArgs e)
		{
			ItemNode node = forward_history.Pop ();

			AddBackJid (current_jid, current_node);

			if (forward_history.Count == 0)
				ForwardButton.Enabled = false;

			AddressTextBox.Text = node.Jid.ToString ();
			SubmitQuery (node.Jid, node.Node, false);
		}

		// User clicked on Get Commands menu item
		private void GetCommandAction_Click (object sender, EventArgs e)
		{
			CommandsIQ iq = XmppGlobal.Queries.CreateCommandsQuery ();
			ItemNode node = (ItemNode)(sender as ToolStripItem).Tag;
			
			iq.To = node.Jid;
			iq.Type = IQType.set;
			(iq.Query as Command).Node = node.Node;
			(iq.Query as Command).Action = CommandAction.execute;
			
			XmppGlobal.Connection.SendPacket (iq);			
		}

		// User clicked the Get Information (vcard) ActionMenu
		private void GetInformationAction_Click (object sender, EventArgs e)
		{
			UserVCardDialog dialog = new UserVCardDialog ();
			dialog.LoadVCard ((jabber.JID)(sender as ToolStripItem).Tag);
			dialog.Show ();
		}

		// User clicked the Get Time ActionMenu
		private void GetTimeAction_Click (object sender, EventArgs e)
		{
			EntityTimeDialog dialog = new EntityTimeDialog ();
			dialog.LoadEntityTime ((jabber.JID)(sender as ToolStripItem).Tag);
			dialog.Show ();
		}

		// User clicked the Get Version ActionMenu
		private void GetVersionAction_Click (object sender, EventArgs e)
		{
			EntityVersionDialog dialog = new EntityVersionDialog ();
			dialog.LoadEntityVersion ((jabber.JID)(sender as ToolStripItem).Tag);
			dialog.Show ();
		}

		// User clicked the go button
		private void GoButton_Click (object sender, EventArgs e)
		{
			if (current_jid != null)
				AddBackJid (current_jid, current_node);

			forward_history.Clear ();
			ForwardButton.Enabled = false;

			SubmitQuery (new jabber.JID (AddressTextBox.Text), string.Empty, false);
		}

		// There was an error, stop everything and display error image
		private void GotErrorBack (IQ iq)
		{
			StopButton.Enabled = false;
			Spinner.Visible = false;
			ErrorPicture.Visible = true;
			ErrorPicture.Tag = iq.OuterXml;
		}

		// We got back our disco#items commands query result
		private void GotCommandItemsQuery (object sender, IQ iq, object state)
		{
			// If the user clicked stop, ignore this result
			if (was_stopped)
				return;

			try {
				if (iq.Type == IQType.result) {
					DiscoItems item = (DiscoItems)iq.Query;
					
					foreach (ToolStripItem tsi in ActionMenu.Items) {
						if (tsi.Text == "More Commands") {
							ToolStripMenuItem mi = (ToolStripMenuItem)tsi;
							
							mi.DropDownItems.Clear ();
							
							foreach (DiscoItem i in item.GetItems ())
								mi.DropDownItems.Add (i.Named, null, new EventHandler (GetCommandAction_Click)).Tag = new ItemNode (iq.From, i.Node);
								
							if (mi.DropDownItems.Count == 0)
								mi.DropDownItems.Add ("None");
						}
					}
				} else if (iq.Type == IQType.error)
					MessageBox.Show ("Commands error");
			} catch (Exception) {
				GotErrorBack (iq);
				MessageBox.Show (string.Format ("Had a problem with Commands response: {0}", iq.OuterXml));
				throw;
			}
		}

		// We got back our disco#info query result
		private void GotInfoQuery (object sender, IQ iq, object state)
		{
			// If the user clicked stop, ignore this result
			if (was_stopped)
				return;

			try {
				if (iq.Type == IQType.result) {
					DiscoInfo info = (DiscoInfo)iq.Query;
					
					// If there is an <identity> node, display the data
					if (info.GetIdentities ().Length > 0) {
						DiscoIdentity i = info.GetIdentities ()[0];
						
						IdentityNameLabel.Text = i.Named.Trim ();
						IdentityAddressLabel.Text = iq.From.ToString ();
						IdentityCategoryTypeLabel.Text = string.Format ("{0} - {1}", i.Category.Trim (), i.Type.Trim ());
						
						Label4.Visible = true;
					}
					
					// Create the actions menu button
					PopulateActions (iq);
					
					// Track how many responses we have gotten back
					TurnOffSpinner ();
				} else if (iq.Type == IQType.error)
					GotErrorBack (iq);
			} catch (Exception) {
				GotErrorBack (iq);
				MessageBox.Show (string.Format ("Had a problem with Info response: {0}", iq.OuterXml));
			}
		}
		
		// We got back our disco#items query result
		private void GotItemsQuery (object sender, IQ iq, object state)
		{
			// If the user clicked stop, ignore this result
			if (was_stopped)
				return;

			try {
				if (iq.Type == IQType.result) {
					DiscoItems item = (DiscoItems)iq.Query;
					
					// Put each returned <item> into the ServiceListView
					foreach (DiscoItem i in item.GetItems ()) {
						string name = i.Named;
						
						if (string.IsNullOrEmpty (name))
							name = i.Jid.ToString ();
							
						string node = string.Empty;
						
						if (i.Node != null)
							node = i.Node;
							
						ServiceListView.Items.Add (new ListViewItem (new string[] {name, i.Jid.ToString (), node}));
					}
					
					TurnOffSpinner ();
				} else if (iq.Type == IQType.error)
					GotErrorBack (iq);
			} catch (Exception) {
				GotErrorBack (iq);
				MessageBox.Show (string.Format ("Had a problem with Items response: {0}", iq.OuterXml));
			}
		}

		// User clicked the home button
		private void HomeButton_Click (object sender, EventArgs e)
		{
			AddressTextBox.Text = XmppGlobal.Connection.Server;
			GoButton_Click (this, e);
		}

		// Using the DiscoInfo we got back, find actions we support and create a menu item for them
		private void PopulateActions (IQ info)
		{
			ActionMenu.Items.Clear ();
			ActionButton.Visible = false;
			
			ToolStripMenuItem cmi = null;
			
			foreach (DiscoFeature f in (info.Query as DiscoInfo).GetFeatures ()) {
				switch (f.Var)
				{
					case "jabber:iq:time":
						ToolStripMenuItem tsi = new ToolStripMenuItem ("Get Time", XmppImages.Time16, new EventHandler (GetTimeAction_Click));
						tsi.Tag = info.From;
						ActionMenu.Items.Add (tsi);
						break;
					case "jabber:iq:version":
						ToolStripMenuItem tsi2 = new ToolStripMenuItem ("Get Version", XmppImages.Properties16, new EventHandler (GetVersionAction_Click));
						tsi2.Tag = info.From;
						ActionMenu.Items.Add (tsi2);
						break;
					case "vcard-temp":
						ToolStripMenuItem tsi3 = new ToolStripMenuItem ("Get Information", XmppImages.VCard16, new EventHandler (GetInformationAction_Click));
						tsi3.Tag = info.From;
						ActionMenu.Items.Add (tsi3);
						break;
					case "jabber:iq:search":
						ActionMenu.Items.Add ("Search (not implemented)");
						break;
					case "jabber:iq:register":
						ActionMenu.Items.Add ("Register (not implemented)");
						break;
					case "http://jabber.org/protocol/commands":
						cmi = new ToolStripMenuItem ("More Commands", XmppImages.Gear16);
						cmi.DropDownItems.Add ("Requesting Commands..");
						XmppGlobal.Disco.DiscoItemsQuery (info.From, "http://jabber.org/protocol/commands", true, new QueryCallback (GotCommandItemsQuery), null);
						break;
				}
			}

			// We want the More Commands menu item to be at the bottom, after a separator
			if (cmi != null) {
				if (ActionMenu.Items.Count > 0)
					ActionMenu.Items.Add (new ToolStripSeparator ());
					
				ActionMenu.Items.Add (cmi);
			}
			
			if (ActionMenu.Items.Count > 0)
				ActionButton.Visible = true;
		}

		// User clicked the refresh button
		private void RefreshButton_Click (object sender, EventArgs e)
		{
			if (current_jid != null) {
				AddressTextBox.Text = current_jid.ToString ();

				SubmitQuery (current_jid, string.Empty, true);
			}
		}

		// User double clicked a service, navigate to it
		private void ServiceListView_DoubleClick (object sender, EventArgs e)
		{
			if (ServiceListView.SelectedItems.Count == 1) {
				ListViewItem li = ServiceListView.SelectedItems[0];
				
				AddressTextBox.Text = li.SubItems[1].Text;
				
				if (current_jid != null)
					AddBackJid (current_jid, current_node);
					
				forward_history.Clear ();
				ForwardButton.Enabled = false;
				
				SubmitQuery (new jabber.JID (AddressTextBox.Text), li.SubItems[2].Text, false);
			}
		}

		// User clicked the stop button
		private void StopButton_Click (object sender, EventArgs e)
		{
			StopButton.Enabled = false;
			Spinner.Visible = false;
			was_stopped = true;
		}

		// Submit a new query
		private void SubmitQuery (jabber.JID jid, string node, bool refresh)
		{
			IdentityNameLabel.Text = string.Empty;
			IdentityAddressLabel.Text = string.Empty;
			IdentityCategoryTypeLabel.Text = string.Empty;
			
			Label4.Visible = false;
			ActionButton.Visible = false;
			StopButton.Enabled = true;
			Spinner.Visible = true;
			ErrorPicture.Visible = false;
			got_one_response = false;
			was_stopped = false;
			
			ServiceListView.Items.Clear ();
			
			AddressTextBox.SelectAll ();
			
			current_jid = jid;
			current_node = node;
			
			XmppGlobal.Disco.DiscoInfoQuery (jid, node, refresh, new QueryCallback (GotInfoQuery), null);
			XmppGlobal.Disco.DiscoItemsQuery (jid, node, refresh, new QueryCallback (GotItemsQuery), null);
		}
		
		// We send out two requests, turn off the spinner and stop button
		// when we get BOTH responses back
		private void TurnOffSpinner ()
		{
			if (got_one_response) {
				StopButton.Enabled = false;
				Spinner.Visible = false;
			} else
				got_one_response = true;
		}
		#endregion
	}
}