//
// ContactItem.cs
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
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace XmppApplication.GuiControls
{
	public partial class ContactItem : UserControl
	{
		private bool hover;
		private Image avatar;
		private Image small_avatar;
		private List<PictureBox> action_images = new List<PictureBox> ();
		private int maximum_action_images = 3;
		private ContactItemStyle style = ContactItemStyle.Regular;

		private string line_one_text = string.Empty;
		private string line_two_text = string.Empty;

		private Font line_one_font;
		private Color line_one_color;
		private Rectangle line_one_bounds;
		private Font line_two_font;
		private Color line_two_color;
		private Rectangle line_two_bounds;

		private Color gradient_color_one = Color.FromArgb (214, 230, 255);
		private Color gradient_color_two = Color.FromArgb (186, 213, 249);

		private Rectangle highlight_rectangle;
		private Brush highlight_brush;
		private Pen border_pen;

		#region Constructors
		public ContactItem () : this (string.Empty, string.Empty, null)
		{
		}

		public ContactItem (string line1, string line2, Image avatar)
		{
			InitializeComponent ();

			SetStyle (ControlStyles.OptimizedDoubleBuffer, true);
			SetStyle (ControlStyles.AllPaintingInWmPaint, true);
			SetStyle (ControlStyles.Opaque, true);

			// Set text and avatar
			line_one_text = line1;
			line_two_text = line2;
			Image = avatar;

			// Set colors and fonts
			border_pen = new Pen (Color.FromArgb (131, 150, 195));
			line_one_font = new Font ("Trebuchet MS", 8.25f, FontStyle.Bold);
			line_two_font = new Font ("Trebuchet MS", 6.75f, FontStyle.Italic);
			line_one_color = Color.Black;
			line_two_color = Color.Gray;
			BackColor = Color.White;

			Enabled = false;
			
			MouseEnter += new EventHandler (ContactItem_MouseEnter);
			MouseLeave += new EventHandler (ContactItem_MouseLeave);
			MouseCaptureChanged += new EventHandler (ContactItem_MouseLeave);
			Layout += new LayoutEventHandler (ContactItem_Layout);
		}
		#endregion

		#region Properties
		public Image Image {
			get { return avatar; }
			set {
				if (value != null)
					avatar = new Bitmap (value, 32, 32);
				else
					avatar = null;
					
				Invalidate ();
			}
		}

		public int MaximumActionImages {
			get { return maximum_action_images; }
			set {
				maximum_action_images = value;
				
				PerformLayout ();
			}
		}

		public ContactItemStyle Style {
			get { return style; }
			set {
				style = value;
				
				PerformLayout ();
				Invalidate ();
			}
		}

		public string TextLineOne {
			get { return line_one_text; }
			set { line_one_text = value; Invalidate (); }
		}

		public string TextLineTwo {
			get { return line_two_text; }
			set { line_two_text = value; Invalidate (); }
		}
		#endregion

		#region Action Images
		public PictureBox AddActionImage (PictureBox p, string tooltip)
		{
			p.Size = new Size (16, 16);
			p.BackColor = Color.Transparent;
			
			ToolTip1.SetToolTip (p, tooltip);
			
			action_images.Add (p);
			Controls.Add (p);

			p.MouseEnter += new EventHandler (ContactItem_MouseEnter);
			p.MouseLeave += new EventHandler (ContactItem_MouseLeave);
			
			return p;
		}
		
		public PictureBox AddActionImage (Image image, string tooltip)
		{
			PictureBox p = new PictureBox ();
			p.Image = image;
			
			return AddActionImage (p, tooltip);
		}

		public void RemoveActionImage (PictureBox actionImage)
		{
			if (action_images.Contains (actionImage)) {
				action_images.Remove (actionImage);
				Controls.Remove (actionImage);
			}
		}
		#endregion

		#region Handled Events
		void ContactItem_MouseEnter (object sender, EventArgs e)
		{
			hover = true;
			Invalidate ();
		}

		void ContactItem_MouseLeave (object sender, EventArgs e)
		{
			hover = false;
			Invalidate ();
		}

		void ContactItem_Layout (object sender, LayoutEventArgs e)
		{
			// Layout action images from right to left
			int x = Width - 2;
			int index = 0;
			
			foreach (PictureBox p in action_images) {
				if (index > maximum_action_images)
					p.Hide ();
				else {
					x = x - p.Width;
					p.Location = new Point (x, 2);
					p.Show ();
					x--;
				}
			
				index++;
			}
			
			// Set bounds for text lines
			switch (style) {
				case ContactItemStyle.Regular:
					Height = 36;
					
					line_one_bounds = new Rectangle (35, 3, x - 29, 16);
					line_two_bounds = new Rectangle (35, 17, Width - 33, 15);
					break;
				case ContactItemStyle.Compact:
					Height = 20;
					
					line_one_bounds = new Rectangle (19, 2, x - 13, 16);
					break;
			}
			
			highlight_rectangle = new Rectangle (0, 0, Width - 1, Height - 1);
			
			if (highlight_brush != null)
				highlight_brush.Dispose ();
				
			highlight_brush = new LinearGradientBrush (highlight_rectangle, gradient_color_one, gradient_color_two, LinearGradientMode.Vertical);
			
			Invalidate ();
		}

		
		#endregion

		#region Protected Methods
		protected override void OnPaint (PaintEventArgs e)
		{
			base.OnPaint (e);
			
			Graphics g = e.Graphics;
			
			// Clear the canvas
			g.Clear (BackColor);
			
			// Draw background highlight if hovering
			if (hover) {
				g.FillRectangle (highlight_brush, highlight_rectangle);
				PaintFunctions.DrawRoundedRectangle (g, highlight_rectangle, 5, border_pen);
			}
			
			// If there is an avatar, draw it
			if (avatar != null) {
				switch (style) {
					case ContactItemStyle.Regular:
						g.DrawImage (avatar, 2, 2);
						break;
					case ContactItemStyle.Compact:
						if (small_avatar == null)
							small_avatar = new Bitmap (avatar, 16, 16);
							
						g.DrawImage (small_avatar, 2, 2);
						break;
					default:
						break;
				}
			}
			
			// Draw the text lines
			TextRenderer.DrawText (e.Graphics, line_one_text, line_one_font, line_one_bounds, line_one_color, Color.Transparent, TextFormatFlags.EndEllipsis);
			
			if (style == ContactItemStyle.Regular)
				TextRenderer.DrawText (e.Graphics, line_two_text, line_two_font, line_two_bounds, line_two_color, Color.Transparent, TextFormatFlags.EndEllipsis);
		}
		#endregion
	}
}
