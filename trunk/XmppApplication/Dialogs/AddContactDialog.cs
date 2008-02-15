//
// AddContactDialog.cs
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
	public partial class AddContactDialog : Form
	{
		public AddContactDialog ()
		{
			InitializeComponent ();
		}

		#region Private Methods
		private void OK_Button_Click (object sender, EventArgs e)
		{
			if (IsFormValid ()) {
				XmppGlobal.Roster.Add (txtJid.Text, txtNickname.Text.Trim ());
				
				DialogResult = DialogResult.OK;
				Close ();
			}
		}

		private void Cancel_Button_Click (object sender, EventArgs e)
		{
			DialogResult = DialogResult.Cancel;
			Close ();
		}
		
		private bool IsFormValid ()
		{
			if (txtJid.TextLength == 0) {
				MessageBox.Show ("IM address must be filled in.");
				return false;
			}

			try {
				jabber.JID j = new jabber.JID (txtJid.Text);
			} catch (jabber.JIDFormatException) {
				MessageBox.Show ("IM address is not valid.");
				return false;
			}
			
			return true;
		}
		#endregion
	}
}