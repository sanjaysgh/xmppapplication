//
// ExtensionConfigurationDialog.cs
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
	public partial class ExtensionConfigurationDialog : Form
	{
		public ExtensionConfigurationDialog ()
		{
			InitializeComponent ();
			
			Button1.Image = XmppImages.Gear22;
		}

		#region Private Methods
		private void CloseButton_Click (object sender, EventArgs e)
		{
			Close ();
		}

		private void ExtensionConfigurationDialog_Load (object sender, EventArgs e)
		{
			// Samples
			ExtensionList.Items.Add ("Webpage Action Image");
			ExtensionList.Items.Add ("System Tray Icon");
			ExtensionList.Items.Add ("What's Playing?");
			ExtensionList.Items.Add ("Where in the World?");
			ExtensionList.Items.Add ("File Sharing");
			ExtensionList.Items.Add ("Auto Idle");
			ExtensionList.Items.Add ("Xbox Live Presence");
		}
		#endregion
	}
}