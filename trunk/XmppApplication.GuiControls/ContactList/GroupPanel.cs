//
// GroupPanel.cs
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

namespace XmppApplication.GuiControls
{
	public partial class GroupPanel : UserControl
	{
		private bool expanded = true;

		public GroupPanel ()
		{
			InitializeComponent ();

			GroupHeader1.ExpandedChanged += new EventHandler (GroupHeader1_ExpandedChanged);
			ItemPanel.ControlAdded += new ControlEventHandler (ItemPanel_ControlAdded);
			Layout += new LayoutEventHandler (GroupPanel_Layout);
			ItemPanel.Layout += new LayoutEventHandler (GroupPanel_Layout);
		}

		#region Properties
		public bool Expanded {
			get { return expanded; }
			set {
				if (expanded != value) {
					expanded = value;
					PerformLayout ();
				}
			}
		}
		
		public ControlCollection Items {
			get { return ItemPanel.Controls; }
		}
		
		public new string Text {
			get { return GroupHeader1.Text; }
			set { GroupHeader1.Text = value; }
		}
		#endregion

		#region Private Methods
		void GroupPanel_Layout (object sender, LayoutEventArgs e)
		{
			// Calculate how tall the GroupPanel should be based on enabled (visible) ContactItems
			// Also, if no ContactItems are visible, hide the GroupPanel
			if (expanded) {
				int y = 0;
				
				foreach (Control c in Items)
					if (c.Enabled)
						y += c.Height;
						
				if (y == 0)
					Visible = false;
				else
					Visible = true;
					
				Height = y + GroupHeader1.Height + 1;
			} else
				Height = GroupHeader1.Bottom;
		}

		void ItemPanel_ControlAdded (object sender, ControlEventArgs e)
		{
			ContactItem newci = (ContactItem)e.Control;
			
			// Sort the contact list alphabetically by the Nickname/Jid line
			foreach (ContactItem ci in ItemPanel.Controls)
				if (newci.TextLineOne.ToLower ().CompareTo (ci.TextLineOne.ToLower ()) > 0) {
					ItemPanel.Controls.SetChildIndex (newci, ItemPanel.Controls.GetChildIndex (ci));
					break;
				}
				
			newci.Dock = DockStyle.Top;
		}

		void GroupHeader1_ExpandedChanged (object sender, EventArgs e)
		{
			Expanded = GroupHeader1.Expanded;
		}
		#endregion
	}
}
