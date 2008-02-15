//
// AdvancedConnectionDialog.cs
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
	public partial class AdvancedConnectionDialog : Form
	{
		public AdvancedConnectionDialog ()
		{
			InitializeComponent ();

			Load += new EventHandler (AdvancedConnectionDialog_Load);
		}

		#region Private Methods
		private void AdvancedConnectionDialog_Load (object sender, EventArgs e)
		{
			ServerHostTextbox.Text = XmppApplication.Properties.Settings.Default.NetworkHost;
			ServerPortTextbox.Text = XmppApplication.Properties.Settings.Default.Port.ToString ();
			ResourceTextBox.Text = XmppApplication.Properties.Settings.Default.Resource;
			ResourcePriorityTextbox.Text = XmppApplication.Properties.Settings.Default.Priority.ToString ();

			switch ((EncryptionMode)XmppApplication.Properties.Settings.Default.EncryptionMode) {
				case EncryptionMode.NoEncryption:
					NeverEncryptRadio.Checked = true;
					break;
				case EncryptionMode.PreferEncryption:
				default:
					PreferEncryptRadio.Checked = true;
					break;
				case EncryptionMode.ForceEncryption:
					AlwaysEncryptRadio.Checked = true;
					break;
			}
		}

		private void Cancel_Button_Click (object sender, EventArgs e)
		{
			DialogResult = DialogResult.Cancel;
			Close ();
		}
		
		private void OK_Button_Click (object sender, EventArgs e)
		{
			DialogResult = DialogResult.OK;

			XmppApplication.Properties.Settings.Default.NetworkHost = ServerHostTextbox.Text;
			XmppApplication.Properties.Settings.Default.Port = int.Parse (ServerPortTextbox.Text);
			XmppApplication.Properties.Settings.Default.Resource = ResourceTextBox.Text;
			XmppApplication.Properties.Settings.Default.Priority = int.Parse (ResourcePriorityTextbox.Text);
			
			if (AlwaysEncryptRadio.Checked)
				XmppApplication.Properties.Settings.Default.EncryptionMode = (int)EncryptionMode.ForceEncryption;
			else if (PreferEncryptRadio.Checked)
				XmppApplication.Properties.Settings.Default.EncryptionMode = (int)EncryptionMode.PreferEncryption;
			else if (NeverEncryptRadio.Checked)
				XmppApplication.Properties.Settings.Default.EncryptionMode = (int)EncryptionMode.NoEncryption;
			else
				XmppApplication.Properties.Settings.Default.EncryptionMode = (int)EncryptionMode.PreferEncryption;
			
			Close ();
		}
		#endregion
	}
}