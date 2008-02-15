//
// NewAccountDialog.cs
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

namespace XmppApplication
{
	public partial class NewAccountDialog : Form
	{
		public NewAccountDialog ()
		{
			InitializeComponent ();

			cmbServer.TextChanged += new EventHandler (cmbServer_TextChanged);
			txtUsername.TextChanged += new EventHandler (cmbServer_TextChanged);
		}


		#region Private Methods
		private void Cancel_Button_Click (object sender, EventArgs e)
		{
			DialogResult = DialogResult.Cancel;
			Close ();
		}

		private void cmbServer_TextChanged (object sender, EventArgs e)
		{
			UpdateJid ();
		}

		private bool IsFormValid ()
		{
			bool is_valid = true;

			if (txtUsername.TextLength == 0) {
				ErrorProvider.SetError (txtUsername, "Username must be filled in.");
				is_valid = false;
			} else
				ErrorProvider.SetError (txtUsername, string.Empty);

			if (cmbServer.Text.Length == 0) {
				ErrorProvider.SetError (cmbServer, "Server must be filled in.");
				is_valid = false;
			} else
				ErrorProvider.SetError (cmbServer, string.Empty);

			if (txtPassword.TextLength == 0) {
				ErrorProvider.SetError (txtPassword, "Password must be filled in.");
				is_valid = false;
			} else
				ErrorProvider.SetError (txtPassword, string.Empty);

			if (txtPassword.Text != txtConfirmPassword.Text) {
				ErrorProvider.SetError (txtConfirmPassword, "Passwords must match.");
				is_valid = false;
			} else
				ErrorProvider.SetError (txtConfirmPassword, string.Empty);
				
			return is_valid;
		}
		
		private void OK_Button_Click (object sender, EventArgs e)
		{
			if (IsFormValid ()) {
				SaveFields ();
				DialogResult = DialogResult.OK;
				Close ();
			}
		}

		private void SaveFields ()
		{
			XmppApplication.Properties.Settings.Default.UserJid = lblJid.Text.Trim ();
			XmppApplication.Properties.Settings.Default.SavePassword = chkRememberPassword.Checked;
			
			if (chkRememberPassword.Checked)
				XmppApplication.Properties.Settings.Default.Password = txtPassword.Text.Trim ();
				
			XmppApplication.Properties.Settings.Default.Save ();
		}

		private void UpdateJid ()
		{
			if (txtUsername.TextLength > 0 && cmbServer.Text.Length > 0)
				lblJid.Text = string.Format ("{0}@{1}", txtUsername.Text, cmbServer.Text);
		}
		#endregion
	}
}