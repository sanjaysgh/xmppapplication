//
// GradientPanel.cs
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

using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace XmppApplication.GuiControls
{
	public class GradientPanel : Panel
	{
		private Color gradient_color_start;
		private Color gradient_color_end;

		public GradientPanel ()
		{
			this.ResizeRedraw = true;
			this.gradient_color_start = ProfessionalColors.ToolStripGradientBegin;
			this.gradient_color_end = ProfessionalColors.ToolStripGradientEnd;
		}

		#region Protected Methods
		protected override void OnPaintBackground (PaintEventArgs e)
		{
			base.OnPaintBackground (e);

			if (this.Width == 0 || this.Height == 0)
				return;

			Rectangle highlight_rectangle = new Rectangle (0, 0, this.Width, this.Height);

			using (LinearGradientBrush lgb = new LinearGradientBrush (highlight_rectangle, gradient_color_start, gradient_color_end, LinearGradientMode.Vertical))
				e.Graphics.FillRectangle (lgb, highlight_rectangle);

			e.Graphics.DrawLine (Pens.DarkGray, 0, this.Bottom - 1, this.Right, this.Bottom - 1);
		}
		#endregion
	}
}