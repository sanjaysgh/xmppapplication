//
// UserVCardDialog.cs
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
using System.Drawing.Drawing2D;
using System.Windows.Forms;
using XmppApplication.Base;

namespace XmppApplication
{
	public partial class UserVCardDialog : Form
	{
		#region Local Variables
		private Color gradient_color1 = Color.FromArgb (214, 230, 255);
		private Color gradient_color2 = Color.FromArgb (186, 213, 249);
		#endregion

		#region Public Constructor
		public UserVCardDialog ()
		{
			InitializeComponent ();

			Spinner.Image = XmppImages.Spinner;
			PictureBox3.Image = XmppImages.Email16;
			PictureBox4.Image = XmppImages.Web16;
			
			CloseButton.Click += new EventHandler (CloseButton_Click);
			EmailLink.LinkClicked += new LinkLabelLinkClickedEventHandler (EmailLink_LinkClicked);
			WebLink.LinkClicked += new LinkLabelLinkClickedEventHandler (WebLink_LinkClicked);
			CommentTextBox.LinkClicked += new LinkClickedEventHandler (CommentTextBox_LinkClicked);
		}
		#endregion

		#region Public Methods
		public void LoadVCard (jabber.JID jid)
		{
			Text = string.Format ("Information for {0}", jid.Bare);
			JidLabel.Text = jid.Bare;
			
			jabber.protocol.iq.VCardIQ iq = XmppGlobal.Queries.CreateVCardQuery ();
			iq.To = new jabber.JID (jid.Bare);
			iq.Type = jabber.protocol.client.IQType.get;
			
			XmppGlobal.Queries.SendQuery (iq, new QueryCallback (GotVCard), null);
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
		private void GotVCard (object sender, jabber.protocol.client.IQ iq, object data)
		{
			jabber.protocol.iq.VCard vcard = (jabber.protocol.iq.VCard)iq.Query;
			
			if (iq.Type != jabber.protocol.client.IQType.result)
				return;
				
			PopulateName (vcard);
			PopulateAddresses (vcard);
			PopulateTelephones (vcard);
			
			EmailLink.Text = vcard.Email;
			CommentTextBox.Text = vcard.Description;
			
			if (vcard.Url != null)
				WebLink.Text = vcard.Url.ToString ();
				
			PhotoPictureBox.Image = XmppImages.DefaultAvatar;
			
			if (vcard.Photo != null)
				if (vcard.Photo["BINVAL"] != null)
					PhotoPictureBox.Image = ImageManipulation.Base64ToImage (vcard.Photo["BINVAL"].InnerText);
					
			Spinner.Visible = false;
		}
		
		private void PopulateAddresses (jabber.protocol.iq.VCard vcard)
		{
			if (vcard.GetAddress (jabber.protocol.iq.AddressLocation.work) != null) {
				Address1TypeLabel.Text = "Work:";
				Address1TextBox.Lines = FormatAddress (vcard.GetAddress (jabber.protocol.iq.AddressLocation.work));
			}

			if (vcard.GetAddress (jabber.protocol.iq.AddressLocation.home) != null) {
				if (Address1TextBox.Text.Trim ().Length == 0) {
					Address1TypeLabel.Text = "Home:";
					Address1TextBox.Lines = FormatAddress (vcard.GetAddress (jabber.protocol.iq.AddressLocation.home));
				} else {
					Address2TypeLabel.Text = "Home:";
					Address2TextBox.Lines = FormatAddress (vcard.GetAddress (jabber.protocol.iq.AddressLocation.home));
					return;
				}
			}

			if (vcard.GetAddress (jabber.protocol.iq.AddressLocation.unknown) != null) {
				if (Address1TextBox.Text.Trim ().Length == 0) {
					Address1TypeLabel.Text = "Address:";
					Address1TextBox.Lines = FormatAddress (vcard.GetAddress (jabber.protocol.iq.AddressLocation.unknown));
				} else {
					Address2TypeLabel.Text = "Address:";
					Address2TextBox.Lines = FormatAddress (vcard.GetAddress (jabber.protocol.iq.AddressLocation.unknown));
					return;
				}
			}
		}
		
		private void PopulateName (jabber.protocol.iq.VCard vcard)
		{
			List<string> names = new List<string> ();
			
			if (!string.IsNullOrEmpty (vcard.FullName)) {
				if (!string.IsNullOrEmpty (vcard.Nickname))
					names.Add (string.Format ("{0} ({1})", vcard.FullName.Trim (), vcard.Nickname.Trim ()));
				else
					names.Add (vcard.FullName.Trim ());
			} else {
				if (!string.IsNullOrEmpty (vcard.Nickname))
					names.Add (vcard.Nickname.Trim ());
			}
			
			if (!string.IsNullOrEmpty (vcard.Title))
				names.Add (vcard.Title.Trim ());
				
			if (vcard.Organization != null) {
				if (!string.IsNullOrEmpty (vcard.Organization.Unit))
					names.Add (vcard.Organization.Unit.Trim ());
				if (!string.IsNullOrEmpty (vcard.Organization.OrgName))
					names.Add (vcard.Organization.OrgName.Trim ());
			}
			
			NameTextBox.Lines = names.ToArray ();

			switch (NameTextBox.Lines.Length) {
				case 1:
					NameTextBox.Height = 14;
					NameTextBox.Top = 69;
					break;
				case 2:
					NameTextBox.Height = 28;
					NameTextBox.Top = 62;
					break;
				case 3:
					NameTextBox.Height = 42;
					NameTextBox.Top = 55;
					break;
				case 4:
					NameTextBox.Height = 56;
					NameTextBox.Top = 48;
					break;
			}
		}
		
		private void PopulateTelephones (jabber.protocol.iq.VCard vcard)
		{
			if (vcard.GetTelephone (jabber.protocol.iq.TelephoneType.voice, jabber.protocol.iq.TelephoneLocation.work) != null)
				FillInPhoneTextBox ("Work:", vcard.GetTelephone (jabber.protocol.iq.TelephoneType.voice, jabber.protocol.iq.TelephoneLocation.work).Number);
				
			foreach (jabber.protocol.iq.VCard.VTelephone t in vcard.GetTelephoneList ())
				if (t["CELL"] != null)
					FillInPhoneTextBox ("Cell:", t.Number);

			if (vcard.GetTelephone (jabber.protocol.iq.TelephoneType.voice, jabber.protocol.iq.TelephoneLocation.home) != null)
				FillInPhoneTextBox ("Work:", vcard.GetTelephone (jabber.protocol.iq.TelephoneType.voice, jabber.protocol.iq.TelephoneLocation.home).Number);

			if (vcard.GetTelephone (jabber.protocol.iq.TelephoneType.voice, jabber.protocol.iq.TelephoneLocation.unknown) != null)
				FillInPhoneTextBox ("Work:", vcard.GetTelephone (jabber.protocol.iq.TelephoneType.voice, jabber.protocol.iq.TelephoneLocation.unknown).Number);
		
			foreach (jabber.protocol.iq.VCard.VTelephone t in vcard.GetTelephoneList ())
				if (t["PAGER"] != null)
					FillInPhoneTextBox ("Pager:", t.Number);

			foreach (jabber.protocol.iq.VCard.VTelephone t in vcard.GetTelephoneList ())
				if (t["FAX"] != null)
					FillInPhoneTextBox ("Fax:", t.Number);
		}
		
		private void FillInPhoneTextBox (string label, string text)
		{
			if (string.IsNullOrEmpty (text))
				return;
				
			if (Phone1Label.Text.Length == 0) {
				Phone1Label.Text = label;
				Phone1TextBox.Text = text;
			} else if (Phone2Label.Text.Length == 0) {
				Phone2Label.Text = label;
				Phone2TextBox.Text = text;
			}
		}
		
		private string[] FormatAddress (jabber.protocol.iq.VCard.VAddress address)
		{
			List<string> names = new List<string> ();

			if (!string.IsNullOrEmpty (address.Street))
				names.Add (address.Street.Trim ());

			if (!string.IsNullOrEmpty (address.Extra))
				names.Add (address.Extra.Trim ());
				
			string csz = string.Empty;
			
			if (!string.IsNullOrEmpty (address.Locality))
				csz += address.Locality.Trim ();
				
			if (!string.IsNullOrEmpty (address.Region))
				csz += csz.Length > 0 ? string.Format (", {0}", address.Region.Trim ()) : address.Region.Trim ();
				
			if (!string.IsNullOrEmpty (address.PostalCode))
				csz += csz.Length > 0 ? string.Format (", {0}", address.PostalCode.Trim ()) : address.PostalCode.Trim ();
			
			if (csz.Length > 0)
				names.Add (csz);
				
			if (!string.IsNullOrEmpty (address.Country))
				names.Add (address.Country.Trim ());
				
			return names.ToArray ();
		}

		private void CommentTextBox_LinkClicked (object sender, LinkClickedEventArgs e)
		{
			Process.Start (e.LinkText);
		}

		private void WebLink_LinkClicked (object sender, LinkLabelLinkClickedEventArgs e)
		{
			Process.Start (WebLink.Text);
		}

		private void EmailLink_LinkClicked (object sender, LinkLabelLinkClickedEventArgs e)
		{
			Process.Start (string.Format ("mailto:{0}", EmailLink.Text));
		}

		private void CloseButton_Click (object sender, EventArgs e)
		{
			Close ();
		}
		#endregion
	}
}