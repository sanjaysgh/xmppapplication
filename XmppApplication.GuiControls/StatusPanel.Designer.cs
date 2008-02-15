namespace XmppApplication.GuiControls
{
	partial class StatusPanel
	{
		/// <summary> 
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary> 
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose (bool disposing)
		{
			if (disposing && (components != null)) {
				components.Dispose ();
			}
			base.Dispose (disposing);
		}

		#region Component Designer generated code

		/// <summary> 
		/// Required method for Designer support - do not modify 
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent ()
		{
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager (typeof (StatusPanel));
			this.BarLabel = new System.Windows.Forms.Label ();
			this.CloseButton = new System.Windows.Forms.PictureBox ();
			this.SidePictureBox = new System.Windows.Forms.PictureBox ();
			((System.ComponentModel.ISupportInitialize)(this.CloseButton)).BeginInit ();
			((System.ComponentModel.ISupportInitialize)(this.SidePictureBox)).BeginInit ();
			this.SuspendLayout ();
			// 
			// BarLabel
			// 
			this.BarLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
				    | System.Windows.Forms.AnchorStyles.Left)
				    | System.Windows.Forms.AnchorStyles.Right)));
			this.BarLabel.BackColor = System.Drawing.Color.Transparent;
			this.BarLabel.Font = new System.Drawing.Font ("Trebuchet MS", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.BarLabel.Location = new System.Drawing.Point (0, 2);
			this.BarLabel.Margin = new System.Windows.Forms.Padding (0);
			this.BarLabel.Name = "BarLabel";
			this.BarLabel.Size = new System.Drawing.Size (179, 15);
			this.BarLabel.TabIndex = 6;
			this.BarLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// CloseButton
			// 
			this.CloseButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.CloseButton.BackColor = System.Drawing.Color.Transparent;
			this.CloseButton.Image = ((System.Drawing.Image)(resources.GetObject ("CloseButton.Image")));
			this.CloseButton.Location = new System.Drawing.Point (183, -1);
			this.CloseButton.Name = "CloseButton";
			this.CloseButton.Size = new System.Drawing.Size (22, 22);
			this.CloseButton.TabIndex = 5;
			this.CloseButton.TabStop = false;
			// 
			// SidePictureBox
			// 
			this.SidePictureBox.BackColor = System.Drawing.Color.Transparent;
			this.SidePictureBox.Location = new System.Drawing.Point (156, 2);
			this.SidePictureBox.Name = "SidePictureBox";
			this.SidePictureBox.Size = new System.Drawing.Size (22, 22);
			this.SidePictureBox.TabIndex = 7;
			this.SidePictureBox.TabStop = false;
			this.SidePictureBox.Visible = false;
			// 
			// StatusBarPanel
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF (6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.Color.LightYellow;
			this.Controls.Add (this.BarLabel);
			this.Controls.Add (this.CloseButton);
			this.Controls.Add (this.SidePictureBox);
			this.Margin = new System.Windows.Forms.Padding (0);
			this.Name = "StatusBarPanel";
			this.Size = new System.Drawing.Size (205, 23);
			((System.ComponentModel.ISupportInitialize)(this.CloseButton)).EndInit ();
			((System.ComponentModel.ISupportInitialize)(this.SidePictureBox)).EndInit ();
			this.ResumeLayout (false);

		}

		#endregion

		internal System.Windows.Forms.Label BarLabel;
		internal System.Windows.Forms.PictureBox CloseButton;
		internal System.Windows.Forms.PictureBox SidePictureBox;
	}
}
