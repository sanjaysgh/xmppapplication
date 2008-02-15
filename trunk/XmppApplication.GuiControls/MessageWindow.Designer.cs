namespace XmppApplication.GuiControls
{
	partial class MessageWindow
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

		#region Windows Form Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent ()
		{
			this.SplitContainer1 = new System.Windows.Forms.SplitContainer ();
			this.RichTextBox1 = new System.Windows.Forms.RichTextBox ();
			this.StatusBarPanel1 = new XmppApplication.GuiControls.StatusPanel ();
			this.OutgoingTextBox = new System.Windows.Forms.RichTextBox ();
			this.Panel1 = new System.Windows.Forms.Panel ();
			this.SendButton = new System.Windows.Forms.Button ();
			this.ChattingWith = new System.Windows.Forms.Label ();
			this.UserAvatar = new System.Windows.Forms.PictureBox ();
			this.SplitContainer1.Panel1.SuspendLayout ();
			this.SplitContainer1.Panel2.SuspendLayout ();
			this.SplitContainer1.SuspendLayout ();
			this.Panel1.SuspendLayout ();
			((System.ComponentModel.ISupportInitialize)(this.UserAvatar)).BeginInit ();
			this.SuspendLayout ();
			// 
			// SplitContainer1
			// 
			this.SplitContainer1.BackColor = System.Drawing.Color.LightGray;
			this.SplitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.SplitContainer1.FixedPanel = System.Windows.Forms.FixedPanel.Panel2;
			this.SplitContainer1.Location = new System.Drawing.Point (0, 43);
			this.SplitContainer1.Name = "SplitContainer1";
			this.SplitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
			// 
			// SplitContainer1.Panel1
			// 
			this.SplitContainer1.Panel1.Controls.Add (this.RichTextBox1);
			this.SplitContainer1.Panel1.Controls.Add (this.StatusBarPanel1);
			// 
			// SplitContainer1.Panel2
			// 
			this.SplitContainer1.Panel2.Controls.Add (this.OutgoingTextBox);
			this.SplitContainer1.Panel2.Controls.Add (this.Panel1);
			this.SplitContainer1.Size = new System.Drawing.Size (495, 295);
			this.SplitContainer1.SplitterDistance = 261;
			this.SplitContainer1.SplitterWidth = 2;
			this.SplitContainer1.TabIndex = 48;
			// 
			// RichTextBox1
			// 
			this.RichTextBox1.BackColor = System.Drawing.Color.White;
			this.RichTextBox1.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.RichTextBox1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.RichTextBox1.Font = new System.Drawing.Font ("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.RichTextBox1.Location = new System.Drawing.Point (0, 23);
			this.RichTextBox1.Name = "RichTextBox1";
			this.RichTextBox1.ReadOnly = true;
			this.RichTextBox1.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.ForcedVertical;
			this.RichTextBox1.Size = new System.Drawing.Size (495, 238);
			this.RichTextBox1.TabIndex = 0;
			this.RichTextBox1.Text = "";
			// 
			// StatusBarPanel1
			// 
			this.StatusBarPanel1.BackColor = System.Drawing.Color.LightYellow;
			this.StatusBarPanel1.BezelColor = System.Drawing.Color.PaleGoldenrod;
			this.StatusBarPanel1.CloseButtonDefaultBackColor = System.Drawing.Color.Transparent;
			this.StatusBarPanel1.CloseButtonHoverBackColor = System.Drawing.Color.PaleGoldenrod;
			this.StatusBarPanel1.CloseButtonVisible = false;
			this.StatusBarPanel1.Dock = System.Windows.Forms.DockStyle.Top;
			this.StatusBarPanel1.DrawBezel = true;
			this.StatusBarPanel1.Image = null;
			this.StatusBarPanel1.ImageStretchMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
			this.StatusBarPanel1.Location = new System.Drawing.Point (0, 0);
			this.StatusBarPanel1.Margin = new System.Windows.Forms.Padding (0);
			this.StatusBarPanel1.Name = "StatusBarPanel1";
			this.StatusBarPanel1.Size = new System.Drawing.Size (495, 23);
			this.StatusBarPanel1.TabIndex = 1;
			this.StatusBarPanel1.Visible = false;
			// 
			// OutgoingTextBox
			// 
			this.OutgoingTextBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.OutgoingTextBox.Dock = System.Windows.Forms.DockStyle.Fill;
			this.OutgoingTextBox.Font = new System.Drawing.Font ("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.OutgoingTextBox.Location = new System.Drawing.Point (0, 0);
			this.OutgoingTextBox.Name = "OutgoingTextBox";
			this.OutgoingTextBox.Size = new System.Drawing.Size (432, 32);
			this.OutgoingTextBox.TabIndex = 0;
			this.OutgoingTextBox.Text = "";
			// 
			// Panel1
			// 
			this.Panel1.BackColor = System.Drawing.Color.White;
			this.Panel1.Controls.Add (this.SendButton);
			this.Panel1.Dock = System.Windows.Forms.DockStyle.Right;
			this.Panel1.Location = new System.Drawing.Point (432, 0);
			this.Panel1.Name = "Panel1";
			this.Panel1.Size = new System.Drawing.Size (63, 32);
			this.Panel1.TabIndex = 29;
			// 
			// SendButton
			// 
			this.SendButton.Location = new System.Drawing.Point (2, 2);
			this.SendButton.Name = "SendButton";
			this.SendButton.Size = new System.Drawing.Size (59, 27);
			this.SendButton.TabIndex = 1;
			this.SendButton.Text = "Send";
			this.SendButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
			this.SendButton.UseVisualStyleBackColor = true;
			// 
			// ChattingWith
			// 
			this.ChattingWith.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
				    | System.Windows.Forms.AnchorStyles.Right)));
			this.ChattingWith.AutoEllipsis = true;
			this.ChattingWith.BackColor = System.Drawing.Color.Transparent;
			this.ChattingWith.Font = new System.Drawing.Font ("Tahoma", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.ChattingWith.ForeColor = System.Drawing.Color.Black;
			this.ChattingWith.Location = new System.Drawing.Point (43, 3);
			this.ChattingWith.Name = "ChattingWith";
			this.ChattingWith.Size = new System.Drawing.Size (426, 32);
			this.ChattingWith.TabIndex = 50;
			this.ChattingWith.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// UserAvatar
			// 
			this.UserAvatar.BackColor = System.Drawing.Color.Transparent;
			this.UserAvatar.Location = new System.Drawing.Point (5, 2);
			this.UserAvatar.Name = "UserAvatar";
			this.UserAvatar.Size = new System.Drawing.Size (32, 32);
			this.UserAvatar.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
			this.UserAvatar.TabIndex = 49;
			this.UserAvatar.TabStop = false;
			// 
			// MessageWindow
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF (6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size (495, 338);
			this.Controls.Add (this.SplitContainer1);
			this.Controls.Add (this.ChattingWith);
			this.Controls.Add (this.UserAvatar);
			this.Name = "MessageWindow";
			this.Padding = new System.Windows.Forms.Padding (0, 43, 0, 0);
			this.Text = "MessageWindow";
			this.SplitContainer1.Panel1.ResumeLayout (false);
			this.SplitContainer1.Panel2.ResumeLayout (false);
			this.SplitContainer1.ResumeLayout (false);
			this.Panel1.ResumeLayout (false);
			((System.ComponentModel.ISupportInitialize)(this.UserAvatar)).EndInit ();
			this.ResumeLayout (false);

		}

		#endregion

		internal System.Windows.Forms.SplitContainer SplitContainer1;
		internal System.Windows.Forms.RichTextBox RichTextBox1;
		internal XmppApplication.GuiControls.StatusPanel StatusBarPanel1;
		internal System.Windows.Forms.RichTextBox OutgoingTextBox;
		internal System.Windows.Forms.Panel Panel1;
		internal System.Windows.Forms.Button SendButton;
		internal System.Windows.Forms.Label ChattingWith;
		internal System.Windows.Forms.PictureBox UserAvatar;

	}
}