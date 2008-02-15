//
// StatusPanel.cs
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
	public partial class StatusPanel : UserControl
	{
		private Pen bezel_pen = Pens.Goldenrod;
		private Color close_button_default_back_color = Color.Transparent;
		private Color close_button_hover_back_color = Color.LightGoldenrodYellow;
		
		private bool draw_bezel = true;
		
		public StatusPanel ()
		{
			InitializeComponent ();

			CloseButton.Click += new EventHandler (CloseButton_Click);
			CloseButton.MouseEnter += new EventHandler (CloseButton_MouseEnter);
			CloseButton.MouseLeave += new EventHandler (CloseButton_MouseLeave);

			Layout += new LayoutEventHandler (StatusBarPanel_Layout);
		}

		#region Public Properties
		public Color BezelColor {
			get { return bezel_pen.Color; }
			set { bezel_pen = new Pen (value); }
		}
		
		public Color CloseButtonDefaultBackColor {
			get { return close_button_default_back_color; }
			set { close_button_default_back_color = value; }
		}
		
		public Color CloseButtonHoverBackColor {
			get { return close_button_hover_back_color; }
			set { close_button_hover_back_color = value; }
		}
		
		public bool CloseButtonVisible {
			get { return CloseButton.Visible; }
			set { CloseButton.Visible = value; }
		}
		
		public bool DrawBezel {
			get { return draw_bezel; }
			set { draw_bezel = value; }
		}
		
		public Image Image {
			get { return SidePictureBox.Image; }
			set { SidePictureBox.Image = value; PerformLayout (); }
		}
		
		public PictureBoxSizeMode ImageStretchMode {
			get { return SidePictureBox.SizeMode; }
			set { SidePictureBox.SizeMode = value; }
		}
		
		public override string Text {
			get { return BarLabel.Text; }
			set { BarLabel.Text = value; }
		}
		#endregion

		#region Protected Methods
		protected void OnBarClosed (EventArgs e)
		{
			EventHandler eh = (EventHandler)(Events[BarClosedEvent]);
			if (eh != null)
				eh (this, e);
		}

		protected override void OnPaintBackground (PaintEventArgs e)
		{
			base.OnPaintBackground (e);
			
			if (draw_bezel)
				e.Graphics.DrawLine (bezel_pen, 0, Height - 1, Width, Height - 1);
		}
		#endregion

		#region Private Methods
		private void CloseButton_Click (object sender, EventArgs e)
		{
			OnBarClosed (EventArgs.Empty);
		}

		private void CloseButton_MouseEnter (object sender, EventArgs e)
		{
			CloseButton.BackColor = close_button_hover_back_color;
		}

		private void CloseButton_MouseLeave (object sender, EventArgs e)
		{
			CloseButton.BackColor = close_button_default_back_color;
		}

		private void StatusBarPanel_Layout (object sender, LayoutEventArgs e)
		{
			CloseButton.Location = new Point (Width - CloseButton.Width, 0);
			
			if (SidePictureBox.Image == null) {
				BarLabel.Location = new Point (0, CloseButton.Left - 1);
				SidePictureBox.Visible = false;
			} else {
				SidePictureBox.Location = new Point (1, (int)((Height - SidePictureBox.Height) / 2));
				SidePictureBox.Visible = true;
				BarLabel.Width = CloseButton.Left - SidePictureBox.Width - 1;
				BarLabel.Left = SidePictureBox.Right;
			}
		}
		#endregion

		#region Events
		static object BarClosedEvent = new object ();

		public event EventHandler BarClosed {
			add { Events.AddHandler (BarClosedEvent, value); }
			remove { Events.RemoveHandler (BarClosedEvent, value); }
		}
		#endregion
	}
}
