namespace XmppApplication
{
	partial class ServiceBrowser
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
			this.components = new System.ComponentModel.Container ();
			this.ServiceListView = new System.Windows.Forms.ListView ();
			this.ColumnHeader5 = new System.Windows.Forms.ColumnHeader ();
			this.ColumnHeader6 = new System.Windows.Forms.ColumnHeader ();
			this.ColumnHeader9 = new System.Windows.Forms.ColumnHeader ();
			this.Label1 = new System.Windows.Forms.Label ();
			this.ActionButton = new System.Windows.Forms.Button ();
			this.Label4 = new System.Windows.Forms.Label ();
			this.ToolStrip1 = new System.Windows.Forms.ToolStrip ();
			this.BackButton = new System.Windows.Forms.ToolStripButton ();
			this.ForwardButton = new System.Windows.Forms.ToolStripButton ();
			this.ToolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator ();
			this.RefreshButton = new System.Windows.Forms.ToolStripButton ();
			this.StopButton = new System.Windows.Forms.ToolStripButton ();
			this.HomeButton = new System.Windows.Forms.ToolStripButton ();
			this.ToolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator ();
			this.ToolStripLabel1 = new System.Windows.Forms.ToolStripLabel ();
			this.AddressTextBox = new System.Windows.Forms.ToolStripTextBox ();
			this.GoButton = new System.Windows.Forms.ToolStripButton ();
			this.IdentityCategoryTypeLabel = new System.Windows.Forms.Label ();
			this.IdentityAddressLabel = new System.Windows.Forms.Label ();
			this.IdentityNameLabel = new System.Windows.Forms.Label ();
			this.ToolStripContainer2 = new System.Windows.Forms.ToolStripContainer ();
			this.ToolTip1 = new System.Windows.Forms.ToolTip (this.components);
			this.ErrorPicture = new System.Windows.Forms.PictureBox ();
			this.ActionMenu = new System.Windows.Forms.ContextMenuStrip (this.components);
			this.Spinner = new System.Windows.Forms.PictureBox ();
			this.ToolStrip1.SuspendLayout ();
			this.ToolStripContainer2.TopToolStripPanel.SuspendLayout ();
			this.ToolStripContainer2.SuspendLayout ();
			((System.ComponentModel.ISupportInitialize)(this.ErrorPicture)).BeginInit ();
			((System.ComponentModel.ISupportInitialize)(this.Spinner)).BeginInit ();
			this.SuspendLayout ();
			// 
			// ServiceListView
			// 
			this.ServiceListView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
				    | System.Windows.Forms.AnchorStyles.Left)
				    | System.Windows.Forms.AnchorStyles.Right)));
			this.ServiceListView.Columns.AddRange (new System.Windows.Forms.ColumnHeader[] {
            this.ColumnHeader5,
            this.ColumnHeader6,
            this.ColumnHeader9});
			this.ServiceListView.FullRowSelect = true;
			this.ServiceListView.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
			this.ServiceListView.Location = new System.Drawing.Point (12, 107);
			this.ServiceListView.MultiSelect = false;
			this.ServiceListView.Name = "ServiceListView";
			this.ServiceListView.Size = new System.Drawing.Size (490, 187);
			this.ServiceListView.Sorting = System.Windows.Forms.SortOrder.Ascending;
			this.ServiceListView.TabIndex = 58;
			this.ServiceListView.UseCompatibleStateImageBehavior = false;
			this.ServiceListView.View = System.Windows.Forms.View.Details;
			// 
			// ColumnHeader5
			// 
			this.ColumnHeader5.Text = "Service";
			this.ColumnHeader5.Width = 127;
			// 
			// ColumnHeader6
			// 
			this.ColumnHeader6.Text = "Address";
			this.ColumnHeader6.Width = 167;
			// 
			// ColumnHeader9
			// 
			this.ColumnHeader9.Text = "Node";
			this.ColumnHeader9.Width = 173;
			// 
			// Label1
			// 
			this.Label1.AutoSize = true;
			this.Label1.Location = new System.Drawing.Point (13, 91);
			this.Label1.Name = "Label1";
			this.Label1.Size = new System.Drawing.Size (97, 13);
			this.Label1.TabIndex = 59;
			this.Label1.Text = "Available Services:";
			// 
			// ActionButton
			// 
			this.ActionButton.Location = new System.Drawing.Point (425, 32);
			this.ActionButton.Name = "ActionButton";
			this.ActionButton.Size = new System.Drawing.Size (77, 30);
			this.ActionButton.TabIndex = 60;
			this.ActionButton.Text = " Actions";
			this.ActionButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
			this.ActionButton.UseVisualStyleBackColor = true;
			this.ActionButton.Visible = false;
			// 
			// Label4
			// 
			this.Label4.BackColor = System.Drawing.Color.Transparent;
			this.Label4.Font = new System.Drawing.Font ("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.Label4.Location = new System.Drawing.Point (206, 33);
			this.Label4.Name = "Label4";
			this.Label4.Size = new System.Drawing.Size (101, 15);
			this.Label4.TabIndex = 57;
			this.Label4.Text = "Category - Type:";
			this.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			this.Label4.Visible = false;
			// 
			// ToolStrip1
			// 
			this.ToolStrip1.Dock = System.Windows.Forms.DockStyle.None;
			this.ToolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
			this.ToolStrip1.Items.AddRange (new System.Windows.Forms.ToolStripItem[] {
            this.BackButton,
            this.ForwardButton,
            this.ToolStripSeparator2,
            this.RefreshButton,
            this.StopButton,
            this.HomeButton,
            this.ToolStripSeparator1,
            this.ToolStripLabel1,
            this.AddressTextBox,
            this.GoButton});
			this.ToolStrip1.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.HorizontalStackWithOverflow;
			this.ToolStrip1.Location = new System.Drawing.Point (0, 0);
			this.ToolStrip1.Name = "ToolStrip1";
			this.ToolStrip1.Size = new System.Drawing.Size (514, 25);
			this.ToolStrip1.Stretch = true;
			this.ToolStrip1.TabIndex = 1;
			this.ToolStrip1.Text = "ToolStrip1";
			// 
			// BackButton
			// 
			this.BackButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.BackButton.Enabled = false;
			this.BackButton.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.BackButton.Name = "BackButton";
			this.BackButton.Size = new System.Drawing.Size (23, 22);
			this.BackButton.Text = "Back";
			this.BackButton.Click += new System.EventHandler (this.BackButton_Click);
			// 
			// ForwardButton
			// 
			this.ForwardButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.ForwardButton.Enabled = false;
			this.ForwardButton.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.ForwardButton.Name = "ForwardButton";
			this.ForwardButton.Size = new System.Drawing.Size (23, 22);
			this.ForwardButton.Text = "ToolStripButton1";
			this.ForwardButton.ToolTipText = "Forward";
			this.ForwardButton.Click += new System.EventHandler (this.ForwardButton_Click);
			// 
			// ToolStripSeparator2
			// 
			this.ToolStripSeparator2.Name = "ToolStripSeparator2";
			this.ToolStripSeparator2.Size = new System.Drawing.Size (6, 25);
			// 
			// RefreshButton
			// 
			this.RefreshButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.RefreshButton.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.RefreshButton.Name = "RefreshButton";
			this.RefreshButton.Size = new System.Drawing.Size (23, 22);
			this.RefreshButton.Text = "ToolStripButton2";
			this.RefreshButton.ToolTipText = "Refresh";
			this.RefreshButton.Click += new System.EventHandler (this.RefreshButton_Click);
			// 
			// StopButton
			// 
			this.StopButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.StopButton.Enabled = false;
			this.StopButton.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.StopButton.Name = "StopButton";
			this.StopButton.Size = new System.Drawing.Size (23, 22);
			this.StopButton.Text = "Stop";
			this.StopButton.ToolTipText = "Stop";
			this.StopButton.Click += new System.EventHandler (this.StopButton_Click);
			// 
			// HomeButton
			// 
			this.HomeButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.HomeButton.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.HomeButton.Name = "HomeButton";
			this.HomeButton.Size = new System.Drawing.Size (23, 22);
			this.HomeButton.Text = "Home";
			this.HomeButton.Click += new System.EventHandler (this.HomeButton_Click);
			// 
			// ToolStripSeparator1
			// 
			this.ToolStripSeparator1.Name = "ToolStripSeparator1";
			this.ToolStripSeparator1.Size = new System.Drawing.Size (6, 25);
			// 
			// ToolStripLabel1
			// 
			this.ToolStripLabel1.Name = "ToolStripLabel1";
			this.ToolStripLabel1.Size = new System.Drawing.Size (55, 22);
			this.ToolStripLabel1.Text = "Address: ";
			// 
			// AddressTextBox
			// 
			this.AddressTextBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.AddressTextBox.Name = "AddressTextBox";
			this.AddressTextBox.Size = new System.Drawing.Size (250, 25);
			// 
			// GoButton
			// 
			this.GoButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.GoButton.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.GoButton.Name = "GoButton";
			this.GoButton.Size = new System.Drawing.Size (23, 22);
			this.GoButton.Text = "ToolStripButton5";
			this.GoButton.ToolTipText = "Go";
			this.GoButton.Click += new System.EventHandler (this.GoButton_Click);
			// 
			// IdentityCategoryTypeLabel
			// 
			this.IdentityCategoryTypeLabel.BackColor = System.Drawing.Color.Transparent;
			this.IdentityCategoryTypeLabel.Font = new System.Drawing.Font ("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.IdentityCategoryTypeLabel.Location = new System.Drawing.Point (304, 34);
			this.IdentityCategoryTypeLabel.Name = "IdentityCategoryTypeLabel";
			this.IdentityCategoryTypeLabel.Size = new System.Drawing.Size (115, 15);
			this.IdentityCategoryTypeLabel.TabIndex = 56;
			// 
			// IdentityAddressLabel
			// 
			this.IdentityAddressLabel.BackColor = System.Drawing.Color.Transparent;
			this.IdentityAddressLabel.Font = new System.Drawing.Font ("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.IdentityAddressLabel.Location = new System.Drawing.Point (16, 55);
			this.IdentityAddressLabel.Name = "IdentityAddressLabel";
			this.IdentityAddressLabel.Size = new System.Drawing.Size (403, 15);
			this.IdentityAddressLabel.TabIndex = 55;
			// 
			// IdentityNameLabel
			// 
			this.IdentityNameLabel.BackColor = System.Drawing.Color.Transparent;
			this.IdentityNameLabel.Font = new System.Drawing.Font ("Tahoma", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.IdentityNameLabel.ForeColor = System.Drawing.Color.Black;
			this.IdentityNameLabel.Location = new System.Drawing.Point (13, 27);
			this.IdentityNameLabel.Name = "IdentityNameLabel";
			this.IdentityNameLabel.Size = new System.Drawing.Size (199, 24);
			this.IdentityNameLabel.TabIndex = 54;
			// 
			// ToolStripContainer2
			// 
			this.ToolStripContainer2.BottomToolStripPanelVisible = false;
			// 
			// ToolStripContainer2.ContentPanel
			// 
			this.ToolStripContainer2.ContentPanel.Size = new System.Drawing.Size (514, 0);
			this.ToolStripContainer2.ContentPanel.Visible = false;
			this.ToolStripContainer2.Dock = System.Windows.Forms.DockStyle.Top;
			this.ToolStripContainer2.LeftToolStripPanelVisible = false;
			this.ToolStripContainer2.Location = new System.Drawing.Point (0, 0);
			this.ToolStripContainer2.Name = "ToolStripContainer2";
			this.ToolStripContainer2.RightToolStripPanelVisible = false;
			this.ToolStripContainer2.Size = new System.Drawing.Size (514, 25);
			this.ToolStripContainer2.TabIndex = 53;
			this.ToolStripContainer2.Text = "ToolStripContainer2";
			// 
			// ToolStripContainer2.TopToolStripPanel
			// 
			this.ToolStripContainer2.TopToolStripPanel.Controls.Add (this.ToolStrip1);
			// 
			// ErrorPicture
			// 
			this.ErrorPicture.Location = new System.Drawing.Point (486, 85);
			this.ErrorPicture.Name = "ErrorPicture";
			this.ErrorPicture.Size = new System.Drawing.Size (16, 16);
			this.ErrorPicture.TabIndex = 62;
			this.ErrorPicture.TabStop = false;
			this.ToolTip1.SetToolTip (this.ErrorPicture, "There was an error getting info returned by the entity.");
			this.ErrorPicture.Visible = false;
			// 
			// ActionMenu
			// 
			this.ActionMenu.Name = "ActionMenu";
			this.ActionMenu.Size = new System.Drawing.Size (61, 4);
			// 
			// Spinner
			// 
			this.Spinner.Location = new System.Drawing.Point (486, 85);
			this.Spinner.Name = "Spinner";
			this.Spinner.Size = new System.Drawing.Size (16, 16);
			this.Spinner.TabIndex = 61;
			this.Spinner.TabStop = false;
			this.Spinner.Visible = false;
			// 
			// ServiceBrowser
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF (6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.Color.White;
			this.ClientSize = new System.Drawing.Size (514, 299);
			this.Controls.Add (this.Spinner);
			this.Controls.Add (this.ServiceListView);
			this.Controls.Add (this.Label1);
			this.Controls.Add (this.ActionButton);
			this.Controls.Add (this.Label4);
			this.Controls.Add (this.IdentityCategoryTypeLabel);
			this.Controls.Add (this.IdentityAddressLabel);
			this.Controls.Add (this.IdentityNameLabel);
			this.Controls.Add (this.ToolStripContainer2);
			this.Controls.Add (this.ErrorPicture);
			this.MinimumSize = new System.Drawing.Size (522, 333);
			this.Name = "ServiceBrowser";
			this.Text = "Service Browser";
			this.ToolStrip1.ResumeLayout (false);
			this.ToolStrip1.PerformLayout ();
			this.ToolStripContainer2.TopToolStripPanel.ResumeLayout (false);
			this.ToolStripContainer2.TopToolStripPanel.PerformLayout ();
			this.ToolStripContainer2.ResumeLayout (false);
			this.ToolStripContainer2.PerformLayout ();
			((System.ComponentModel.ISupportInitialize)(this.ErrorPicture)).EndInit ();
			((System.ComponentModel.ISupportInitialize)(this.Spinner)).EndInit ();
			this.ResumeLayout (false);
			this.PerformLayout ();

		}

		#endregion

		internal System.Windows.Forms.PictureBox Spinner;
		internal System.Windows.Forms.ListView ServiceListView;
		internal System.Windows.Forms.ColumnHeader ColumnHeader5;
		internal System.Windows.Forms.ColumnHeader ColumnHeader6;
		internal System.Windows.Forms.ColumnHeader ColumnHeader9;
		internal System.Windows.Forms.ToolStripButton RefreshButton;
		internal System.Windows.Forms.ToolStripButton ForwardButton;
		internal System.Windows.Forms.ToolStripButton BackButton;
		internal System.Windows.Forms.Label Label1;
		internal System.Windows.Forms.Button ActionButton;
		internal System.Windows.Forms.Label Label4;
		internal System.Windows.Forms.ToolStrip ToolStrip1;
		internal System.Windows.Forms.ToolStripSeparator ToolStripSeparator2;
		internal System.Windows.Forms.ToolStripButton StopButton;
		internal System.Windows.Forms.ToolStripButton HomeButton;
		internal System.Windows.Forms.ToolStripSeparator ToolStripSeparator1;
		internal System.Windows.Forms.ToolStripLabel ToolStripLabel1;
		internal System.Windows.Forms.ToolStripTextBox AddressTextBox;
		internal System.Windows.Forms.ToolStripButton GoButton;
		internal System.Windows.Forms.Label IdentityCategoryTypeLabel;
		internal System.Windows.Forms.Label IdentityAddressLabel;
		internal System.Windows.Forms.Label IdentityNameLabel;
		internal System.Windows.Forms.ToolStripContainer ToolStripContainer2;
		internal System.Windows.Forms.ToolTip ToolTip1;
		internal System.Windows.Forms.PictureBox ErrorPicture;
		internal System.Windows.Forms.ContextMenuStrip ActionMenu;
	}
}