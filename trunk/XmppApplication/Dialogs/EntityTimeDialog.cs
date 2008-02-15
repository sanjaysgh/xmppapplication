//
// EntityTimeDialog.cs
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
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;
using jabber.protocol.client;
using jabber.protocol.iq;
using XmppApplication.Base;

namespace XmppApplication
{
	public partial class EntityTimeDialog : Form
	{
		private Color gradient_color_one = Color.FromArgb (214, 230, 255);
		private Color gradient_color_two = Color.FromArgb (186, 213, 249);
		
		public EntityTimeDialog ()
		{
			InitializeComponent ();
			
			Spinner.Image = XmppImages.Spinner;
		}

		#region Public Methods
		public void LoadEntityTime (jabber.JID jid)
		{
			TimeIQ iq = XmppGlobal.Queries.CreateTimeQuery ();
			
			iq.To = jid;
			
			XmppGlobal.Queries.SendQuery (iq, new QueryCallback (GotTimeQuery), null);
			
			JidLabel.Text = jid.ToString ();
			Spinner.Visible = true;
		}
		#endregion

		#region Protected Methods
		protected override void OnPaintBackground (PaintEventArgs e)
		{
			base.OnPaintBackground (e);
			
			Rectangle r = new Rectangle (0, 0, Width, 42);
			
			using (LinearGradientBrush b = new LinearGradientBrush (r, gradient_color_one, gradient_color_two, LinearGradientMode.Vertical))
				e.Graphics.FillRectangle (b, r);
				
			e.Graphics.DrawLine (Pens.DarkGray, 0, 42, Right, 42);
		}
		#endregion

		#region Private Methods
		private void CloseButton_Click (object sender, EventArgs e)
		{
			Close ();
		}
		
		private void GotTimeQuery (object sender, IQ iq, object state)
		{
			try {
				if (iq.Type == IQType.result)
					if (iq.Query is Time) {
						Time t = (Time)iq.Query;
						
						UtcTextBox.Text = t.UTC.ToString ();
						TimeZoneTextBox.Text = IsNull (t.TZ, "(Not reported)");
						TimeTextBox.Text = IsNull (t.Display, "(Not reported)");
						
						Spinner.Visible = false;
					}
			} catch (Exception) {
				Spinner.Visible = false;
				MessageBox.Show (string.Format ("Invalid Time response received:\n{0}", iq.OuterXml));
			}
		}
		
		private string IsNull (string value, string defaultValue)
		{
			if (string.IsNullOrEmpty (value))
				return defaultValue;
				
			return value;
		}
		#endregion
	}
}