//
// GroupHeader.cs
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

namespace XmppApplication.GuiControls
{
	public partial class GroupHeader : UserControl
	{
		private Font font = new Font ("Trebuchet MS", 8, FontStyle.Bold);
		private Brush header_brush = Brushes.Silver;
		private bool expanded = true;

		public GroupHeader ()
		{
			InitializeComponent ();

			SetStyle (ControlStyles.AllPaintingInWmPaint, true);
			SetStyle (ControlStyles.Opaque, true);
			SetStyle (ControlStyles.OptimizedDoubleBuffer, true);

			Click += new EventHandler (GroupHeader_Click);
			ClientSizeChanged += new EventHandler (GroupHeader_ClientSizeChanged);
		}

		#region Properties
		public bool Expanded {
			get { return expanded; }
			set { expanded = value; }
		}
		#endregion

		#region Protected Methods
		void GroupHeader_Click (object sender, EventArgs e)
		{
			expanded = !expanded;
			Invalidate ();
			
			OnExpandedChanged (EventArgs.Empty);
		}

		void GroupHeader_ClientSizeChanged (object sender, EventArgs e)
		{
			Invalidate ();
		}

		protected void OnExpandedChanged (EventArgs e)
		{
			if (ExpandedChanged != null)
				ExpandedChanged (this, e);
		}

		protected override void OnPaint (PaintEventArgs e)
		{
			base.OnPaint (e);
			
			Graphics g = e.Graphics;
			
			// Clear the canvas
			g.Clear (BackColor);
			
			// Draw the arrow
			if (expanded)
				PaintFunctions.DrawDownChevron (g, new Point (7, 8), Pens.DimGray);
			else
				PaintFunctions.DrawRightChevron (g, new Point (8, 5), Pens.DimGray);
				
			// Draw the text
			TextRenderer.DrawText (g, Text, font, new Point (18, 2), Color.Black);
		}
		#endregion

		#region Events
		public event EventHandler ExpandedChanged;
		#endregion
	}
}
