//
// RenameContactDialog.cs
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
using XmppApplication.Base;

namespace XmppApplication
{
	public partial class RenameContactDialog : Form
	{
		#region Local Variables
		private Color gradient_color1 = Color.FromArgb (214, 230, 255);
		private Color gradient_color2 = Color.FromArgb (186, 213, 249);
		#endregion

		public RenameContactDialog ()
		{
			InitializeComponent ();
		}

		#region Public Methods
		public void Setup (RosterItem ri)
		{
			if (!string.IsNullOrEmpty (ri.Nickname))
				ContactNameLabel.Text = ri.Nickname;
			else
				ContactNameLabel.Text = ri.Jid.Bare;
		}
		#endregion
		
		#region Protected Methods
		protected override void OnPaintBackground (PaintEventArgs e)
		{
			base.OnPaintBackground (e);

			Rectangle rect = new Rectangle (0, 0, Width, 42);
			LinearGradientBrush lgb = new LinearGradientBrush (rect, gradient_color1, gradient_color2, LinearGradientMode.Vertical);

			e.Graphics.FillRectangle (lgb, rect);
			e.Graphics.DrawLine (Pens.DarkGray, 0, 42, Right, 42);
		}
		#endregion

	}
}