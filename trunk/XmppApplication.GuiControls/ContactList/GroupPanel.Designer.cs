namespace XmppApplication.GuiControls
{
	partial class GroupPanel
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
			this.GroupHeader1 = new XmppApplication.GuiControls.GroupHeader ();
			this.ItemPanel = new System.Windows.Forms.Panel ();
			this.SuspendLayout ();
			// 
			// GroupHeader1
			// 
			this.GroupHeader1.BackColor = System.Drawing.Color.White;
			this.GroupHeader1.Dock = System.Windows.Forms.DockStyle.Top;
			this.GroupHeader1.Expanded = true;
			this.GroupHeader1.Location = new System.Drawing.Point (1, 1);
			this.GroupHeader1.Margin = new System.Windows.Forms.Padding (0, 0, 0, 1);
			this.GroupHeader1.Name = "GroupHeader1";
			this.GroupHeader1.Size = new System.Drawing.Size (198, 20);
			this.GroupHeader1.TabIndex = 0;
			// 
			// ItemPanel
			// 
			this.ItemPanel.BackColor = System.Drawing.Color.White;
			this.ItemPanel.Dock = System.Windows.Forms.DockStyle.Fill;
			this.ItemPanel.Location = new System.Drawing.Point (1, 21);
			this.ItemPanel.Name = "ItemPanel";
			this.ItemPanel.Size = new System.Drawing.Size (198, 0);
			this.ItemPanel.TabIndex = 2;
			// 
			// GroupPanel
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF (6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.Color.White;
			this.Controls.Add (this.ItemPanel);
			this.Controls.Add (this.GroupHeader1);
			this.DoubleBuffered = true;
			this.Margin = new System.Windows.Forms.Padding (0);
			this.Name = "GroupPanel";
			this.Padding = new System.Windows.Forms.Padding (1, 1, 1, 0);
			this.Size = new System.Drawing.Size (200, 20);
			this.ResumeLayout (false);

		}

		#endregion

		private GroupHeader GroupHeader1;
		internal System.Windows.Forms.Panel ItemPanel;

	}
}
