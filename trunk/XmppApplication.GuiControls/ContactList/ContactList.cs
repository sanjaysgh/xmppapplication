//
// ContactList.cs
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

using System.Collections.Generic;
using System.Windows.Forms;

namespace XmppApplication.GuiControls
{
	public class ContactList : Panel
	{
		private Dictionary<string, GroupPanel> group_panels = new Dictionary<string,GroupPanel> ();
		private ContactItemStyle style = ContactItemStyle.Regular;

		public ContactList ()
		{
			ControlAdded += new ControlEventHandler (ContactList_ControlAdded);
			ControlRemoved += new ControlEventHandler (ContactList_ControlRemoved);
		}

		#region Properties
		public ContactItemStyle Style {
			get { return style; }
			set {
				style = value;
				
				// Update all the ContactItems with the new style
				foreach (GroupPanel gp in group_panels.Values)
					foreach (ContactItem ci in gp.Items)
						ci.Style = style;
			}
		}
		#endregion

		#region Public Methods
		public void AddContactItem (ContactItem ci, string groupName)
		{
			if (!group_panels.ContainsKey (groupName)) {
				GroupPanel gp = new GroupPanel ();
				gp.Text = groupName;
				
				Controls.Add (gp);
			}
			
			ci.Style = style;
			
			group_panels[groupName].Items.Add (ci);
		}
		
		public GroupPanel GetGroupPanel (string groupName)
		{
			if (group_panels.ContainsKey (groupName))
				return group_panels[groupName];
				
			return null;
		}
		
		public ContactItem GetContactItem (string bareJid)
		{
			foreach (GroupPanel gp in group_panels.Values)
				foreach (ContactItem ci in gp.Items)
					if ((ci.Tag as string) == bareJid)
						return ci;
						
			return null;
		}
		#endregion
		
		#region Private Methods
		private void ContactList_ControlAdded (object sender, ControlEventArgs e)
		{
			if (e.Control is GroupPanel) {
				GroupPanel gp = (GroupPanel)e.Control;
				gp.Dock = DockStyle.Top;
				
				group_panels.Add (gp.Text, gp);
			}
		}

		private void ContactList_ControlRemoved (object sender, ControlEventArgs e)
		{
			if (e.Control is GroupPanel) {
				GroupPanel gp = (GroupPanel)e.Control;
				group_panels.Remove (gp.Text);
			}
		}
		#endregion
	}
}
