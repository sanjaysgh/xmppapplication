//
// StatusChooser.cs
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

namespace XmppApplication.GuiControls
{
	public partial class StatusChooser : UserControl
	{
		private bool hover;
		private bool enabled;
		
		public StatusChooser ()
		{
			InitializeComponent ();

			base.Text = "Offline";
			
			MouseEnter += new EventHandler (StatusChooser_MouseEnter);
			MouseLeave += new EventHandler (StatusChooser_MouseLeave);
			Resize += new EventHandler (StatusChooser_Resize);
		}

		#region Public Properties
		public new bool Enabled {
			get { return enabled; }
			set { enabled = value; Invalidate (); }
		}
		
		public new string Text {
			get { return base.Text; }
			set { base.Text = value; Invalidate (); }
		}
		#endregion

		#region Protected Methods
		protected override void OnClick (EventArgs e)
		{
			if (enabled)
				base.OnClick (e);
		}

		protected override void OnPaint (PaintEventArgs e)
		{
			base.OnPaint (e);
			
			int y = (Height - TextRenderer.MeasureText (Text, Font).Height) / 2;
			TextRenderer.DrawText (e.Graphics, Text, Font, new Point (2, y), Color.Black);
		}
		
		protected override void OnPaintBackground (PaintEventArgs e)
		{
			base.OnPaintBackground (e);
			
			if (Width == 0 || Height == 0)
				return;
				
			if (hover && enabled) {
				Rectangle r = new Rectangle (0, 0, Width - 1, Height - 1);
				
				using (LinearGradientBrush b = new LinearGradientBrush (r, ProfessionalColors.MenuItemSelectedGradientBegin, ProfessionalColors.MenuItemSelectedGradientEnd, LinearGradientMode.Vertical)) {
					PaintFunctions.FillRoundedRectangle (e.Graphics, r, 5f, b);
					PaintFunctions.DrawRoundedRectangle (e.Graphics, r, 5f, Pens.Black);
				}
			}
			
			if (enabled)
				PaintFunctions.DrawDownChevron (e.Graphics, new Point (Width - 15, (Height - 4) / 2), Pens.Black);
		}
		#endregion
		
		#region Private Methods
		void StatusChooser_MouseEnter (object sender, EventArgs e)
		{
			hover = true;
			Invalidate ();
		}

		void StatusChooser_MouseLeave (object sender, EventArgs e)
		{
			hover = false;
			Invalidate ();
		}

		void StatusChooser_Resize (object sender, EventArgs e)
		{
			Invalidate ();
		}
		#endregion
	}
}
