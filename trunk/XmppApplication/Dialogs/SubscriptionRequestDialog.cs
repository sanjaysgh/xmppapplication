//
// SubscriptionRequestDialog.cs
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
using System.Windows.Forms;
using XmppApplication.Base;

namespace XmppApplication
{
	public partial class SubscriptionRequestDialog : Form
	{
		private jabber.protocol.client.Presence request;

		#region Constructors
		public SubscriptionRequestDialog ()
		{
			InitializeComponent ();
		}

		public SubscriptionRequestDialog (jabber.protocol.client.Presence request)
		{
			InitializeComponent ();
			
			this.request = request;
			
			RequestLabel.Text = string.Format ("{0} would like to add you to their contact list.  Is this OK?", request.From.Bare);
			
			AddCheckBox.Visible = false;
			
			if (!XmppGlobal.Roster.ContainsKey (request.From))
				if (!XmppGlobal.Roster.ContainsKey (new jabber.JID (request.From.Bare)))
					AddCheckBox.Visible = true;
		}
		#endregion

		#region Private Methods
		private void Cancel_Button_Click (object sender, EventArgs e)
		{
			jabber.protocol.client.Presence p = new jabber.protocol.client.Presence (XmppGlobal.Connection.JabberDocument);

			p.To = request.From;
			p.Type = jabber.protocol.client.PresenceType.unsubscribed;

			XmppGlobal.Connection.SendPacket (p);

			DialogResult = DialogResult.Cancel;
			Close ();
		}

		private void OK_Button_Click (object sender, EventArgs e)
		{
			jabber.protocol.client.Presence p = new jabber.protocol.client.Presence (XmppGlobal.Connection.JabberDocument);
			
			p.To = request.From;
			p.Type = jabber.protocol.client.PresenceType.subscribed;
			
			XmppGlobal.Connection.SendPacket (p);
			
			if (AddCheckBox.Checked) {
				XmppGlobal.Roster.Add (request.From.Bare, string.Empty);
				
				jabber.protocol.client.Presence p2 = new jabber.protocol.client.Presence (XmppGlobal.Connection.JabberDocument);
				
				p2.To = request.From;
				p2.Type = jabber.protocol.client.PresenceType.subscribe;
				XmppGlobal.Connection.SendPacket (p2);
			}
			
			DialogResult = DialogResult.OK;
			Close ();
		}
		#endregion

	}
}