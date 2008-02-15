using XmppApplication.GuiControls;

namespace XmppApplication
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
		this.LogoffMenu = new System.Windows.Forms.ToolStripMenuItem ();
		this.FileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem ();
		this.ExitMenu = new System.Windows.Forms.ToolStripMenuItem ();
		this.ActionsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem ();
		this.AddBuddyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem ();
		this.PluginConfigurationToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem ();
		this.ServerDiscoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem ();
		this.MenuStrip1 = new System.Windows.Forms.MenuStrip ();
		this.HelpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem ();
		this.DebugWindowMenu = new System.Windows.Forms.ToolStripMenuItem ();
		this.ToggleStyleToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem ();
		this.DataForm1ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem ();
		this.DataForm2ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem ();
		this.ConnectingLabel = new System.Windows.Forms.Label ();
		this.ToolStripContainer1 = new System.Windows.Forms.ToolStripContainer ();
		this.LoginPanel = new System.Windows.Forms.Panel ();
		this.label3 = new System.Windows.Forms.Label ();
		this.ConnectingSpinner = new System.Windows.Forms.PictureBox ();
		this.txtPassword = new System.Windows.Forms.TextBox ();
		this.txtUserJid = new System.Windows.Forms.TextBox ();
		this.Label2 = new System.Windows.Forms.Label ();
		this.Label1 = new System.Windows.Forms.Label ();
		this.ConnectButton = new System.Windows.Forms.Button ();
		this.ContactListPanel = new XmppApplication.GuiControls.ContactList ();
		this.StatusPanel = new System.Windows.Forms.FlowLayoutPanel ();
		this.TopPanel = new XmppApplication.GuiControls.GradientPanel ();
		this.UserLabel = new System.Windows.Forms.Label ();
		this.PictureBox1 = new System.Windows.Forms.PictureBox ();
		this.StatusChooser1 = new XmppApplication.GuiControls.StatusChooser ();
		this.MenuStrip1.SuspendLayout ();
		this.ToolStripContainer1.ContentPanel.SuspendLayout ();
		this.ToolStripContainer1.TopToolStripPanel.SuspendLayout ();
		this.ToolStripContainer1.SuspendLayout ();
		this.LoginPanel.SuspendLayout ();
		((System.ComponentModel.ISupportInitialize)(this.ConnectingSpinner)).BeginInit ();
		this.TopPanel.SuspendLayout ();
		((System.ComponentModel.ISupportInitialize)(this.PictureBox1)).BeginInit ();
		this.SuspendLayout ();
		// 
		// LogoffMenu
		// 
		this.LogoffMenu.Enabled = false;
		this.LogoffMenu.Name = "LogoffMenu";
		this.LogoffMenu.Size = new System.Drawing.Size (109, 22);
		this.LogoffMenu.Text = "Logoff";
		this.LogoffMenu.Click += new System.EventHandler (this.LogoffMenu_Click);
		// 
		// FileToolStripMenuItem
		// 
		this.FileToolStripMenuItem.DropDownItems.AddRange (new System.Windows.Forms.ToolStripItem[] {
            this.LogoffMenu,
            this.ExitMenu});
		this.FileToolStripMenuItem.Name = "FileToolStripMenuItem";
		this.FileToolStripMenuItem.Size = new System.Drawing.Size (37, 20);
		this.FileToolStripMenuItem.Text = "&File";
		// 
		// ExitMenu
		// 
		this.ExitMenu.Name = "ExitMenu";
		this.ExitMenu.Size = new System.Drawing.Size (109, 22);
		this.ExitMenu.Text = "Exit";
		this.ExitMenu.Click += new System.EventHandler (this.ExitMenu_Click);
		// 
		// ActionsToolStripMenuItem
		// 
		this.ActionsToolStripMenuItem.DropDownItems.AddRange (new System.Windows.Forms.ToolStripItem[] {
            this.AddBuddyToolStripMenuItem,
            this.PluginConfigurationToolStripMenuItem,
            this.ServerDiscoToolStripMenuItem});
		this.ActionsToolStripMenuItem.Name = "ActionsToolStripMenuItem";
		this.ActionsToolStripMenuItem.Size = new System.Drawing.Size (59, 20);
		this.ActionsToolStripMenuItem.Text = "&Actions";
		// 
		// AddBuddyToolStripMenuItem
		// 
		this.AddBuddyToolStripMenuItem.Enabled = false;
		this.AddBuddyToolStripMenuItem.Name = "AddBuddyToolStripMenuItem";
		this.AddBuddyToolStripMenuItem.Size = new System.Drawing.Size (185, 22);
		this.AddBuddyToolStripMenuItem.Text = "Add Buddy";
		this.AddBuddyToolStripMenuItem.Click += new System.EventHandler (this.AddBuddyToolStripMenuItem_Click);
		// 
		// PluginConfigurationToolStripMenuItem
		// 
		this.PluginConfigurationToolStripMenuItem.Name = "PluginConfigurationToolStripMenuItem";
		this.PluginConfigurationToolStripMenuItem.Size = new System.Drawing.Size (185, 22);
		this.PluginConfigurationToolStripMenuItem.Text = "Plugin Configuration";
		this.PluginConfigurationToolStripMenuItem.Visible = false;
		this.PluginConfigurationToolStripMenuItem.Click += new System.EventHandler (this.PluginConfigurationToolStripMenuItem_Click);
		// 
		// ServerDiscoToolStripMenuItem
		// 
		this.ServerDiscoToolStripMenuItem.Enabled = false;
		this.ServerDiscoToolStripMenuItem.Name = "ServerDiscoToolStripMenuItem";
		this.ServerDiscoToolStripMenuItem.Size = new System.Drawing.Size (185, 22);
		this.ServerDiscoToolStripMenuItem.Text = "Service Browser";
		this.ServerDiscoToolStripMenuItem.Click += new System.EventHandler (this.ServerDiscoToolStripMenuItem_Click);
		// 
		// MenuStrip1
		// 
		this.MenuStrip1.Dock = System.Windows.Forms.DockStyle.None;
		this.MenuStrip1.Items.AddRange (new System.Windows.Forms.ToolStripItem[] {
            this.FileToolStripMenuItem,
            this.ActionsToolStripMenuItem,
            this.HelpToolStripMenuItem});
		this.MenuStrip1.Location = new System.Drawing.Point (0, 0);
		this.MenuStrip1.Name = "MenuStrip1";
		this.MenuStrip1.Size = new System.Drawing.Size (211, 24);
		this.MenuStrip1.TabIndex = 0;
		this.MenuStrip1.Text = "MenuStrip1";
		// 
		// HelpToolStripMenuItem
		// 
		this.HelpToolStripMenuItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
		this.HelpToolStripMenuItem.DropDownItems.AddRange (new System.Windows.Forms.ToolStripItem[] {
            this.DebugWindowMenu,
            this.ToggleStyleToolStripMenuItem,
            this.DataForm1ToolStripMenuItem,
            this.DataForm2ToolStripMenuItem});
		this.HelpToolStripMenuItem.Name = "HelpToolStripMenuItem";
		this.HelpToolStripMenuItem.Size = new System.Drawing.Size (44, 20);
		this.HelpToolStripMenuItem.Text = "&Help";
		// 
		// DebugWindowMenu
		// 
		this.DebugWindowMenu.Name = "DebugWindowMenu";
		this.DebugWindowMenu.Size = new System.Drawing.Size (156, 22);
		this.DebugWindowMenu.Text = "Debug Window";
		this.DebugWindowMenu.Click += new System.EventHandler (this.DebugWindowMenu_Click);
		// 
		// ToggleStyleToolStripMenuItem
		// 
		this.ToggleStyleToolStripMenuItem.Name = "ToggleStyleToolStripMenuItem";
		this.ToggleStyleToolStripMenuItem.Size = new System.Drawing.Size (156, 22);
		this.ToggleStyleToolStripMenuItem.Text = "Toggle Style";
		this.ToggleStyleToolStripMenuItem.Visible = false;
		// 
		// DataForm1ToolStripMenuItem
		// 
		this.DataForm1ToolStripMenuItem.Name = "DataForm1ToolStripMenuItem";
		this.DataForm1ToolStripMenuItem.Size = new System.Drawing.Size (156, 22);
		this.DataForm1ToolStripMenuItem.Text = "Data Form 1";
		this.DataForm1ToolStripMenuItem.Visible = false;
		// 
		// DataForm2ToolStripMenuItem
		// 
		this.DataForm2ToolStripMenuItem.Name = "DataForm2ToolStripMenuItem";
		this.DataForm2ToolStripMenuItem.Size = new System.Drawing.Size (156, 22);
		this.DataForm2ToolStripMenuItem.Text = "Data Form 2";
		this.DataForm2ToolStripMenuItem.Visible = false;
		// 
		// ConnectingLabel
		// 
		this.ConnectingLabel.Location = new System.Drawing.Point (76, 171);
		this.ConnectingLabel.Name = "ConnectingLabel";
		this.ConnectingLabel.Size = new System.Drawing.Size (76, 13);
		this.ConnectingLabel.TabIndex = 41;
		this.ConnectingLabel.Text = "Connecting...";
		this.ConnectingLabel.Visible = false;
		// 
		// ToolStripContainer1
		// 
		this.ToolStripContainer1.BottomToolStripPanelVisible = false;
		// 
		// ToolStripContainer1.ContentPanel
		// 
		this.ToolStripContainer1.ContentPanel.Controls.Add (this.LoginPanel);
		this.ToolStripContainer1.ContentPanel.Controls.Add (this.ContactListPanel);
		this.ToolStripContainer1.ContentPanel.Controls.Add (this.StatusPanel);
		this.ToolStripContainer1.ContentPanel.Controls.Add (this.TopPanel);
		this.ToolStripContainer1.ContentPanel.Size = new System.Drawing.Size (211, 409);
		this.ToolStripContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
		this.ToolStripContainer1.LeftToolStripPanelVisible = false;
		this.ToolStripContainer1.Location = new System.Drawing.Point (0, 0);
		this.ToolStripContainer1.Name = "ToolStripContainer1";
		this.ToolStripContainer1.RightToolStripPanelVisible = false;
		this.ToolStripContainer1.Size = new System.Drawing.Size (211, 433);
		this.ToolStripContainer1.TabIndex = 12;
		this.ToolStripContainer1.Text = "ToolStripContainer1";
		// 
		// ToolStripContainer1.TopToolStripPanel
		// 
		this.ToolStripContainer1.TopToolStripPanel.Controls.Add (this.MenuStrip1);
		// 
		// LoginPanel
		// 
		this.LoginPanel.BackColor = System.Drawing.Color.White;
		this.LoginPanel.Controls.Add (this.label3);
		this.LoginPanel.Controls.Add (this.ConnectingSpinner);
		this.LoginPanel.Controls.Add (this.ConnectingLabel);
		this.LoginPanel.Controls.Add (this.txtPassword);
		this.LoginPanel.Controls.Add (this.txtUserJid);
		this.LoginPanel.Controls.Add (this.Label2);
		this.LoginPanel.Controls.Add (this.Label1);
		this.LoginPanel.Controls.Add (this.ConnectButton);
		this.LoginPanel.Dock = System.Windows.Forms.DockStyle.Fill;
		this.LoginPanel.Location = new System.Drawing.Point (0, 38);
		this.LoginPanel.Name = "LoginPanel";
		this.LoginPanel.Size = new System.Drawing.Size (211, 371);
		this.LoginPanel.TabIndex = 24;
		// 
		// label3
		// 
		this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
		this.label3.Location = new System.Drawing.Point (12, 317);
		this.label3.Name = "label3";
		this.label3.Size = new System.Drawing.Size (188, 45);
		this.label3.TabIndex = 42;
		this.label3.Text = "Note: You must already have a Jabber/XMPP account.  This client cannot create one" +
		    " for you.";
		// 
		// ConnectingSpinner
		// 
		this.ConnectingSpinner.Location = new System.Drawing.Point (57, 170);
		this.ConnectingSpinner.Name = "ConnectingSpinner";
		this.ConnectingSpinner.Size = new System.Drawing.Size (16, 16);
		this.ConnectingSpinner.TabIndex = 40;
		this.ConnectingSpinner.TabStop = false;
		this.ConnectingSpinner.Visible = false;
		// 
		// txtPassword
		// 
		this.txtPassword.Location = new System.Drawing.Point (14, 91);
		this.txtPassword.Name = "txtPassword";
		this.txtPassword.Size = new System.Drawing.Size (179, 20);
		this.txtPassword.TabIndex = 31;
		this.txtPassword.UseSystemPasswordChar = true;
		// 
		// txtUserJid
		// 
		this.txtUserJid.Location = new System.Drawing.Point (14, 51);
		this.txtUserJid.Name = "txtUserJid";
		this.txtUserJid.Size = new System.Drawing.Size (179, 20);
		this.txtUserJid.TabIndex = 30;
		// 
		// Label2
		// 
		this.Label2.AutoSize = true;
		this.Label2.Location = new System.Drawing.Point (12, 76);
		this.Label2.Name = "Label2";
		this.Label2.Size = new System.Drawing.Size (56, 13);
		this.Label2.TabIndex = 27;
		this.Label2.Text = "Password:";
		// 
		// Label1
		// 
		this.Label1.AutoSize = true;
		this.Label1.Location = new System.Drawing.Point (12, 36);
		this.Label1.Name = "Label1";
		this.Label1.Size = new System.Drawing.Size (63, 13);
		this.Label1.TabIndex = 26;
		this.Label1.Text = "IM Address:";
		// 
		// ConnectButton
		// 
		this.ConnectButton.Location = new System.Drawing.Point (52, 145);
		this.ConnectButton.Name = "ConnectButton";
		this.ConnectButton.Size = new System.Drawing.Size (100, 23);
		this.ConnectButton.TabIndex = 25;
		this.ConnectButton.Text = "Log In";
		this.ConnectButton.UseVisualStyleBackColor = true;
		this.ConnectButton.Click += new System.EventHandler (this.ConnectButton_Click);
		// 
		// ContactListPanel
		// 
		this.ContactListPanel.AutoScroll = true;
		this.ContactListPanel.BackColor = System.Drawing.Color.White;
		this.ContactListPanel.Dock = System.Windows.Forms.DockStyle.Fill;
		this.ContactListPanel.Location = new System.Drawing.Point (0, 38);
		this.ContactListPanel.Margin = new System.Windows.Forms.Padding (0);
		this.ContactListPanel.Name = "ContactListPanel";
		this.ContactListPanel.Size = new System.Drawing.Size (211, 371);
		this.ContactListPanel.Style = XmppApplication.GuiControls.ContactItemStyle.Regular;
		this.ContactListPanel.TabIndex = 25;
		this.ContactListPanel.Visible = false;
		// 
		// StatusPanel
		// 
		this.StatusPanel.AutoSize = true;
		this.StatusPanel.Dock = System.Windows.Forms.DockStyle.Top;
		this.StatusPanel.Location = new System.Drawing.Point (0, 38);
		this.StatusPanel.Name = "StatusPanel";
		this.StatusPanel.Size = new System.Drawing.Size (211, 0);
		this.StatusPanel.TabIndex = 26;
		// 
		// TopPanel
		// 
		this.TopPanel.Controls.Add (this.UserLabel);
		this.TopPanel.Controls.Add (this.PictureBox1);
		this.TopPanel.Controls.Add (this.StatusChooser1);
		this.TopPanel.Dock = System.Windows.Forms.DockStyle.Top;
		this.TopPanel.Location = new System.Drawing.Point (0, 0);
		this.TopPanel.Name = "TopPanel";
		this.TopPanel.Size = new System.Drawing.Size (211, 38);
		this.TopPanel.TabIndex = 47;
		// 
		// UserLabel
		// 
		this.UserLabel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
			    | System.Windows.Forms.AnchorStyles.Right)));
		this.UserLabel.BackColor = System.Drawing.Color.Transparent;
		this.UserLabel.Location = new System.Drawing.Point (42, 3);
		this.UserLabel.Name = "UserLabel";
		this.UserLabel.Size = new System.Drawing.Size (158, 13);
		this.UserLabel.TabIndex = 3;
		// 
		// PictureBox1
		// 
		this.PictureBox1.BackColor = System.Drawing.Color.Transparent;
		this.PictureBox1.Location = new System.Drawing.Point (3, 3);
		this.PictureBox1.Name = "PictureBox1";
		this.PictureBox1.Size = new System.Drawing.Size (32, 32);
		this.PictureBox1.TabIndex = 0;
		this.PictureBox1.TabStop = false;
		// 
		// StatusChooser1
		// 
		this.StatusChooser1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
			    | System.Windows.Forms.AnchorStyles.Right)));
		this.StatusChooser1.BackColor = System.Drawing.Color.Transparent;
		this.StatusChooser1.Enabled = false;
		this.StatusChooser1.Location = new System.Drawing.Point (38, 17);
		this.StatusChooser1.Name = "StatusChooser1";
		this.StatusChooser1.Size = new System.Drawing.Size (170, 17);
		this.StatusChooser1.TabIndex = 2;
		// 
		// MainForm
		// 
		this.AcceptButton = this.ConnectButton;
		this.AutoScaleDimensions = new System.Drawing.SizeF (6F, 13F);
		this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
		this.ClientSize = new System.Drawing.Size (211, 433);
		this.Controls.Add (this.ToolStripContainer1);
		this.Name = "MainForm";
		this.Text = "Form1";
		this.MenuStrip1.ResumeLayout (false);
		this.MenuStrip1.PerformLayout ();
		this.ToolStripContainer1.ContentPanel.ResumeLayout (false);
		this.ToolStripContainer1.ContentPanel.PerformLayout ();
		this.ToolStripContainer1.TopToolStripPanel.ResumeLayout (false);
		this.ToolStripContainer1.TopToolStripPanel.PerformLayout ();
		this.ToolStripContainer1.ResumeLayout (false);
		this.ToolStripContainer1.PerformLayout ();
		this.LoginPanel.ResumeLayout (false);
		this.LoginPanel.PerformLayout ();
		((System.ComponentModel.ISupportInitialize)(this.ConnectingSpinner)).EndInit ();
		this.TopPanel.ResumeLayout (false);
		((System.ComponentModel.ISupportInitialize)(this.PictureBox1)).EndInit ();
		this.ResumeLayout (false);

        }

        #endregion

        internal System.Windows.Forms.ToolStripMenuItem LogoffMenu;
        internal System.Windows.Forms.ToolStripMenuItem FileToolStripMenuItem;
        internal System.Windows.Forms.ToolStripMenuItem ExitMenu;
        internal System.Windows.Forms.ToolStripMenuItem ActionsToolStripMenuItem;
        internal System.Windows.Forms.ToolStripMenuItem AddBuddyToolStripMenuItem;
        internal System.Windows.Forms.ToolStripMenuItem PluginConfigurationToolStripMenuItem;
	    internal System.Windows.Forms.ToolStripMenuItem ServerDiscoToolStripMenuItem;
        internal System.Windows.Forms.PictureBox PictureBox1;
        internal System.Windows.Forms.MenuStrip MenuStrip1;
        internal System.Windows.Forms.ToolStripMenuItem HelpToolStripMenuItem;
        internal System.Windows.Forms.ToolStripMenuItem DebugWindowMenu;
        internal System.Windows.Forms.ToolStripMenuItem ToggleStyleToolStripMenuItem;
        internal System.Windows.Forms.ToolStripMenuItem DataForm1ToolStripMenuItem;
        internal System.Windows.Forms.ToolStripMenuItem DataForm2ToolStripMenuItem;
        internal XmppApplication.GuiControls.StatusChooser StatusChooser1;
        internal XmppApplication.GuiControls.GradientPanel TopPanel;
        internal System.Windows.Forms.PictureBox ConnectingSpinner;
	    internal System.Windows.Forms.Label ConnectingLabel;
        internal ContactList ContactListPanel;
        internal System.Windows.Forms.ToolStripContainer ToolStripContainer1;
	    internal System.Windows.Forms.Panel LoginPanel;
        internal System.Windows.Forms.TextBox txtPassword;
        internal System.Windows.Forms.TextBox txtUserJid;
        internal System.Windows.Forms.Label Label2;
        internal System.Windows.Forms.Label Label1;
        internal System.Windows.Forms.Button ConnectButton;
        internal System.Windows.Forms.FlowLayoutPanel StatusPanel;
	    private System.Windows.Forms.Label label3;
	    private System.Windows.Forms.Label UserLabel;

    }
}

