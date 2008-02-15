//
// MessageWindow.cs
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
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;
using XmppApplication.Base;
using XmppApplication.Interfaces;

namespace XmppApplication.GuiControls
{
	public partial class MessageWindow : Form, IMessageWindow
	{
		#region Local Variables
		private Color gradient_color1 = Color.FromArgb(214, 230, 255);
		private Color gradient_color2 = Color.FromArgb(186, 213, 249);
		private jabber.JID foreign_jid;
		private jabber.protocol.client.MessageType message_type = jabber.protocol.client.MessageType.chat;
		private string thread_id;
		#endregion

		#region Public Constructors
		public MessageWindow (jabber.JID jid)
		{
			InitializeComponent ();
			
			foreign_jid = jid;
			thread_id = Guid.NewGuid ().ToString ().Replace ("-", "");
			UserAvatar.Image = XmppImages.DefaultAvatar;

			Activated += new EventHandler (MessageWindow_Activated);
			FormClosing += new FormClosingEventHandler (MessageWindow_FormClosing);
			Load += new EventHandler (MessageWindow_Load);
			OutgoingTextBox.KeyDown += new KeyEventHandler (OutgoingTextBox_KeyDown);
			RichTextBox1.LinkClicked += new LinkClickedEventHandler (RichTextBox1_LinkClicked);
			SendButton.Click += new EventHandler (SendButton_Click);
		}

		public MessageWindow (RosterItem ri)
		{
			InitializeComponent ();

			foreign_jid = ri.Jid;
			thread_id = Guid.NewGuid ().ToString ().Replace ("-", "");
			UserAvatar.Image = ri.Avatar;

			Activated += new EventHandler (MessageWindow_Activated);
			FormClosing += new FormClosingEventHandler (MessageWindow_FormClosing);
			Load += new EventHandler (MessageWindow_Load);
			
			OutgoingTextBox.KeyDown += new KeyEventHandler (OutgoingTextBox_KeyDown);
			RichTextBox1.LinkClicked += new LinkClickedEventHandler (RichTextBox1_LinkClicked);
			SendButton.Click += new EventHandler (SendButton_Click);
		}

		void MessageWindow_FormClosing (object sender, FormClosingEventArgs e)
		{
			Hide ();
			e.Cancel = true;
		}
		#endregion

		#region Protected Methods
		protected override void OnPaintBackground (PaintEventArgs e)
		{
			base.OnPaintBackground (e);
			
			Rectangle rect = new Rectangle (0, 0, Width, 42);
			LinearGradientBrush lgb = new LinearGradientBrush (rect, gradient_color1, gradient_color2, LinearGradientMode.Vertical);
			
			e.Graphics.FillRectangle (lgb, rect);
			e.Graphics.DrawLine (Pens.DarkGray, 0, 42, Right, 42);
		}
		#endregion

		#region Private Methods
		private void MessageWindow_Load (object sender, EventArgs e)
		{
			RosterItem ri = null;
			
			if (!XmppGlobal.Roster.TryGetValue (foreign_jid, out ri))
				XmppGlobal.Roster.TryGetValue (new jabber.JID (foreign_jid.Bare), out ri);
				
			if (ri == null) {
				this.Text = foreign_jid.Bare;
				this.Icon = PaintFunctions.ImageToIcon ((Bitmap)XmppImages.DefaultAvatar);
				this.ChattingWith.Text = string.Format ("Chatting with {0}", foreign_jid.ToString ());
			} else {
				this.Text = ri.GetDisplayName ();
				this.Icon = PaintFunctions.ImageToIcon ((Bitmap)ri.BaseAvatar);
				this.ChattingWith.Text = string.Format ("Chatting with {0}", ri.GetDisplayName ());

				ri.PresenceChanged += new EventHandler<PresenceItemEventArgs> (PresenceChanged);
				PresenceChanged (ri, new PresenceItemEventArgs (ri.GetPresence ()));
			}
			
			StatusBarPanel1.Image = XmppImages.AwayOverlay;
		}

		private void MessageWindow_Activated (object sender, EventArgs e)
		{
			OutgoingTextBox.Focus ();
		}

		private void OutgoingTextBox_KeyDown (object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Enter && e.Modifiers != Keys.Shift) {
				SendButton_Click (null, null);
				e.SuppressKeyPress = true;
				e.Handled = true;
			}
		}

		private void PresenceChanged (object sender, PresenceItemEventArgs e)
		{
			RosterItem ri = (RosterItem)sender;
			jabber.protocol.client.Presence pres = ri.GetPresence ();
			
			if (pres == null) {
				StatusBarPanel1.Text = string.Format ("{0} is offline.", ri.GetDisplayName ());
				StatusBarPanel1.Visible = true;
			} else {
				switch (pres.Type) {
					case jabber.protocol.client.PresenceType.available:
						switch (pres.Show) {
							case "away":
							case "xa":
							case "dnd":
								if (pres.Status == null)
									StatusBarPanel1.Text = string.Format ("{0} is away.", ri.GetDisplayName ());
								else
									StatusBarPanel1.Text = string.Format ("{0} is away. {1}", ri.GetDisplayName (), pres.Status.Trim ().Length > 0 ? string.Format (" ({0})", pres.Status.Trim ()) : string.Empty);
									
								StatusBarPanel1.Visible = true;
								break;
							default:
								StatusBarPanel1.Visible = false;
								break;
						}
						break;
					case jabber.protocol.client.PresenceType.unavailable:
						StatusBarPanel1.Text = string.Format ("{0} is offline.", ri.GetDisplayName ());
						StatusBarPanel1.Visible = true;
						break;
				}
			}
			
			UserAvatar.Image = ri.Avatar;
		}

		private void RichTextBox1_LinkClicked (object sender, LinkClickedEventArgs e)
		{
			Process.Start (e.LinkText);
		}

		private void SendButton_Click (object sender, EventArgs e)
		{
			if (OutgoingTextBox.TextLength > 0) {
				RichTextBox1.SelectionColor = Color.Blue;
				RichTextBox1.AppendText (string.Format ("({0}) Me: ", DateTime.Now.ToString ("hh:mm:ss")));
				RichTextBox1.SelectionColor = Color.Black;
				RichTextBox1.AppendText (string.Format ("{0}\n", OutgoingTextBox.Text));

				XmppGlobal.Messaging.SendMessage (foreign_jid, OutgoingTextBox.Text, message_type, thread_id);
				OutgoingTextBox.Text = string.Empty;
				XmppSounds.PlaySound (DefaultSounds.MessageIn);
			}
		}
		#endregion
		
		#region IChatWindow Members
		public jabber.JID GetForeignJid ()
		{
			return foreign_jid;
		}

		public void GotMessage (jabber.protocol.client.Message msg)
		{
			foreign_jid = msg.From;
			message_type = msg.Type;
			thread_id = msg.Thread;
			
			if (msg.Body.Trim ().Length > 0) {
				RichTextBox1.SelectionColor = Color.Red;
				RichTextBox1.AppendText (string.Format ("({0}) {1}: ", DateTime.Now.ToString ("hh:mm:ss"), Text));
				RichTextBox1.SelectionColor = Color.Black;
				RichTextBox1.AppendText (string.Format ("{0}\n", msg.Body));
				
				XmppSounds.PlaySound (DefaultSounds.MessageIn);			
			}
		}
		#endregion
	}
}