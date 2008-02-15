//
// ContactWebsitePlugin.cs
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
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;
using jabber.protocol.iq;
using XmppApplication.Base;
using XmppApplication.Interfaces;

namespace ContactWebsitePlugin
{
	public class ContactWebsitePlugin : Extension
	{
		private Dictionary<jabber.JID, ActionImage> action_images = new Dictionary<jabber.JID,ActionImage> ();

		#region Extension Methods
		public override void Initialize ()
		{
			XmppGlobal.Roster.GotRosterItem += new EventHandler<RosterItemEventArgs> (Roster_GotRosterItem);
		}
		#endregion
		
		#region Extension Properties
		public override string Name {
			get { return "Contact Webpage"; }
		}

		public override string Description {
			get { return "Adds an action image that links to a contact's webpage."; }
		}

		public override string[] Authors {
			get { return new string[] {"Jonathan Pobst"}; }
		}
		#endregion

		#region Private Methods
		private void Roster_GotRosterItem (object sender, RosterItemEventArgs e)
		{
			e.RosterItem.VCardReceived += new EventHandler<VCardEventArgs> (RosterItem_VCardReceived);
		}

		private void RosterItem_VCardReceived (object sender, VCardEventArgs e)
		{
			RosterItem ri = (RosterItem)sender;

			if (e.Item.Query is VCard) {
				VCard vcard = (VCard)e.Item.Query;

				if (vcard != null) {
					if (vcard.Url != null) {
						ActionImage ai = null;

						if (action_images.TryGetValue (ri.Jid, out ai))
							ai.Tag = vcard.Url.ToString ();
						else {
							ai = ri.AddActionImage (XmppImages.Web16, "View Webpage");
							ai.Tag = vcard.Url.ToString ();
							ai.BackColor = Color.Transparent;
							action_images.Add (ri.Jid, ai);
							ai.Click += new EventHandler (Webpage_Click);
						}
					}
				}
			}
		}

		private void Webpage_Click (object sender, EventArgs e)
		{
			Process.Start ((string)(sender as PictureBox).Tag);
		}
		#endregion
	}
}
