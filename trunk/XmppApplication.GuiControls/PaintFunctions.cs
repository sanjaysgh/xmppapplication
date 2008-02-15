//
// PaintFunctions.cs
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

namespace XmppApplication.GuiControls
{
	public static class PaintFunctions
	{
		// Create a rounded rectangle path with a given Rectangle and a given corner Diameter
		public static GraphicsPath CreateRoundedRectanglePath (Rectangle rect, float diameter)
		{
			GraphicsPath path = new GraphicsPath ();
			RectangleF arcrect = new RectangleF (rect.Location, new SizeF (diameter, diameter));
			
			// Top left arc
			path.AddArc (arcrect, 190, 90);
			path.AddLine (rect.Left + (int)(diameter / 2), rect.Top, rect.Left + rect.Width  - (int)(diameter / 2), rect.Top);
			
			// Top right arc
			arcrect.X = rect.Right - diameter;
			path.AddArc (arcrect, 270, 90);
			path.AddLine (rect.Left + rect.Width, rect.Top + (int)(diameter / 2), rect.Left + rect.Width, rect.Top + rect.Height - (int)(diameter / 2));
			
			// Bottom right arc
			arcrect.Y = rect.Bottom - diameter;
			path.AddArc (arcrect, 0, 90);
			
			// Bottom left arc
			arcrect.X = rect.Left;
			path.AddArc (arcrect, 90, 90);
			
			path.CloseFigure ();
			return path;
			
		}

		// Draw a rounded rectangle at a given Rectangle with a given corner Diameter 
		public static void DrawRoundedRectangle (Graphics g, Rectangle rect, float diameter, Pen p)
		{
			g.SmoothingMode = SmoothingMode.HighQuality;
			
			using (GraphicsPath path = CreateRoundedRectanglePath (rect, diameter))
				g.DrawPath (p, path);
		}

		// Draw a filled rounded rectangle at a given Rectangle with a given corner Diameter
		public static void FillRoundedRectangle (Graphics g, Rectangle rect, float diameter, Brush b)
		{
			g.SmoothingMode = SmoothingMode.HighQuality;

			using (GraphicsPath path = CreateRoundedRectanglePath (rect, diameter))
				g.FillPath (b, path);
		}

		// Draw a triangle pointing down
		public static void DrawDownChevron (Graphics g, Point location, Pen p)
		{
			g.DrawLine (p, location.X, location.Y, location.X + 8, location.Y);
			g.DrawLine (p, location.X + 1, location.Y + 1, location.X + 7, location.Y + 1);
			g.DrawLine (p, location.X + 2, location.Y + 2, location.X + 6, location.Y + 2);
			g.DrawLine (p, location.X + 3, location.Y + 3, location.X + 5, location.Y + 3);
		}

		// Draw a triangle pointing right
		public static void DrawRightChevron (Graphics g, Point location, Pen p)
		{
			g.DrawLine (p, location.X, location.Y, location.X, location.Y + 8);
			g.DrawLine (p, location.X + 1, location.Y + 1, location.X + 1, location.Y + 7);
			g.DrawLine (p, location.X + 2, location.Y + 2, location.X + 2, location.Y + 6);
			g.DrawLine (p, location.X + 3, location.Y + 3, location.X + 3, location.Y + 5);
		}

		// Convert an Image to an Icon
		public static Icon ImageToIcon (Bitmap image)
		{
			return System.Drawing.Icon.FromHandle (image.GetHicon ());
		}
	}
}
