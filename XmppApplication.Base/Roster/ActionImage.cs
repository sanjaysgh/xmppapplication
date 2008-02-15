//
// ActionImage.cs
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
using System.Windows.Forms;

namespace XmppApplication.Base
{
	public class ActionImage : PictureBox
	{
		private string tooltip = string.Empty;

		#region Public Constructors
		public ActionImage ()
		{
			this.Name = Guid.NewGuid ().ToString ().Replace ("-", "");
			this.BackColor = Color.Transparent;
			this.SizeMode = PictureBoxSizeMode.StretchImage;
			this.Size = new Size (16, 16);
		}

		public ActionImage (Image image, string toolTip)
			: this ()
		{
			this.Image = image;
			this.tooltip = toolTip;
		}
		#endregion

		#region Public Properties
		public string ToolTip
		{
			get { return tooltip; }
			set
			{
				tooltip = value;

				OnToolTipChanged (EventArgs.Empty);
			}
		}
		#endregion

		#region Protected Methods
		protected void OnToolTipChanged (EventArgs e)
		{
			EventHandler eh = (EventHandler)(Events[ToolTipChangedEvent]);
			if (eh != null)
				eh (this, e);

		}
		#endregion

		#region Public Events
		static object ToolTipChangedEvent = new object ();

		public event EventHandler ToolTipChanged
		{
			add { Events.AddHandler (ToolTipChangedEvent, value); }
			remove { Events.RemoveHandler (ToolTipChangedEvent, value); }
		}
		#endregion
	}
}