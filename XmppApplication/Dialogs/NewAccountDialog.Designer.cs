namespace XmppApplication
{
	partial class NewAccountDialog
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
			this.lblJid = new System.Windows.Forms.Label ();
			this.Label6 = new System.Windows.Forms.Label ();
			this.txtConfirmPassword = new System.Windows.Forms.TextBox ();
			this.ErrorProvider = new System.Windows.Forms.ErrorProvider (this.components);
			this.Label1 = new System.Windows.Forms.Label ();
			this.chkRememberPassword = new System.Windows.Forms.CheckBox ();
			this.Label5 = new System.Windows.Forms.Label ();
			this.txtPassword = new System.Windows.Forms.TextBox ();
			this.Cancel_Button = new System.Windows.Forms.Button ();
			this.Label4 = new System.Windows.Forms.Label ();
			this.cmbServer = new System.Windows.Forms.ComboBox ();
			this.Label3 = new System.Windows.Forms.Label ();
			this.ToolTip1 = new System.Windows.Forms.ToolTip (this.components);
			this.txtUsername = new System.Windows.Forms.TextBox ();
			this.Label2 = new System.Windows.Forms.Label ();
			this.TableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel ();
			this.OK_Button = new System.Windows.Forms.Button ();
			((System.ComponentModel.ISupportInitialize)(this.ErrorProvider)).BeginInit ();
			this.TableLayoutPanel1.SuspendLayout ();
			this.SuspendLayout ();
			// 
			// lblJid
			// 
			this.lblJid.BackColor = System.Drawing.Color.LightYellow;
			this.lblJid.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.lblJid.Font = new System.Drawing.Font ("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lblJid.Location = new System.Drawing.Point (157, 179);
			this.lblJid.Name = "lblJid";
			this.lblJid.Size = new System.Drawing.Size (184, 20);
			this.lblJid.TabIndex = 36;
			this.lblJid.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// Label6
			// 
			this.Label6.Font = new System.Drawing.Font ("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.Label6.Location = new System.Drawing.Point (33, 178);
			this.Label6.Name = "Label6";
			this.Label6.Size = new System.Drawing.Size (121, 20);
			this.Label6.TabIndex = 35;
			this.Label6.Text = "Your IM address will be:";
			this.Label6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// txtConfirmPassword
			// 
			this.txtConfirmPassword.Font = new System.Drawing.Font ("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.txtConfirmPassword.Location = new System.Drawing.Point (157, 116);
			this.txtConfirmPassword.Name = "txtConfirmPassword";
			this.txtConfirmPassword.Size = new System.Drawing.Size (184, 21);
			this.txtConfirmPassword.TabIndex = 33;
			this.txtConfirmPassword.UseSystemPasswordChar = true;
			// 
			// ErrorProvider
			// 
			this.ErrorProvider.BlinkStyle = System.Windows.Forms.ErrorBlinkStyle.NeverBlink;
			this.ErrorProvider.ContainerControl = this;
			// 
			// Label1
			// 
			this.Label1.AutoSize = true;
			this.Label1.Location = new System.Drawing.Point (33, 9);
			this.Label1.Name = "Label1";
			this.Label1.Size = new System.Drawing.Size (357, 13);
			this.Label1.TabIndex = 37;
			this.Label1.Text = "Enter the following information to create a new instant messaging account.";
			// 
			// chkRememberPassword
			// 
			this.chkRememberPassword.Font = new System.Drawing.Font ("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.chkRememberPassword.Location = new System.Drawing.Point (181, 140);
			this.chkRememberPassword.Name = "chkRememberPassword";
			this.chkRememberPassword.Size = new System.Drawing.Size (136, 24);
			this.chkRememberPassword.TabIndex = 34;
			this.chkRememberPassword.Text = "Remember Password";
			// 
			// Label5
			// 
			this.Label5.Font = new System.Drawing.Font ("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.Label5.Location = new System.Drawing.Point (53, 116);
			this.Label5.Name = "Label5";
			this.Label5.Size = new System.Drawing.Size (104, 20);
			this.Label5.TabIndex = 32;
			this.Label5.Text = "Confirm Password:";
			this.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// txtPassword
			// 
			this.txtPassword.Font = new System.Drawing.Font ("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.txtPassword.Location = new System.Drawing.Point (157, 92);
			this.txtPassword.Name = "txtPassword";
			this.txtPassword.Size = new System.Drawing.Size (184, 21);
			this.txtPassword.TabIndex = 31;
			this.txtPassword.UseSystemPasswordChar = true;
			// 
			// Cancel_Button
			// 
			this.Cancel_Button.Anchor = System.Windows.Forms.AnchorStyles.None;
			this.Cancel_Button.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.Cancel_Button.Location = new System.Drawing.Point (76, 3);
			this.Cancel_Button.Name = "Cancel_Button";
			this.Cancel_Button.Size = new System.Drawing.Size (67, 23);
			this.Cancel_Button.TabIndex = 1;
			this.Cancel_Button.Text = "Cancel";
			this.Cancel_Button.Click += new System.EventHandler (this.Cancel_Button_Click);
			// 
			// Label4
			// 
			this.Label4.Font = new System.Drawing.Font ("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.Label4.Location = new System.Drawing.Point (53, 92);
			this.Label4.Name = "Label4";
			this.Label4.Size = new System.Drawing.Size (104, 20);
			this.Label4.TabIndex = 30;
			this.Label4.Text = "Password:";
			this.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// cmbServer
			// 
			this.cmbServer.Font = new System.Drawing.Font ("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.cmbServer.Items.AddRange (new object[] {
            "jabber.org"});
			this.cmbServer.Location = new System.Drawing.Point (157, 68);
			this.cmbServer.Name = "cmbServer";
			this.cmbServer.Size = new System.Drawing.Size (184, 21);
			this.cmbServer.TabIndex = 29;
			this.cmbServer.Text = "jabber.org";
			// 
			// Label3
			// 
			this.Label3.Font = new System.Drawing.Font ("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.Label3.Location = new System.Drawing.Point (53, 68);
			this.Label3.Name = "Label3";
			this.Label3.Size = new System.Drawing.Size (104, 20);
			this.Label3.TabIndex = 28;
			this.Label3.Text = "Server:";
			this.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// txtUsername
			// 
			this.txtUsername.Font = new System.Drawing.Font ("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.txtUsername.Location = new System.Drawing.Point (157, 44);
			this.txtUsername.Name = "txtUsername";
			this.txtUsername.Size = new System.Drawing.Size (184, 21);
			this.txtUsername.TabIndex = 27;
			// 
			// Label2
			// 
			this.Label2.Font = new System.Drawing.Font ("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.Label2.Location = new System.Drawing.Point (53, 44);
			this.Label2.Name = "Label2";
			this.Label2.Size = new System.Drawing.Size (104, 20);
			this.Label2.TabIndex = 26;
			this.Label2.Text = "Username:";
			this.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// TableLayoutPanel1
			// 
			this.TableLayoutPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.TableLayoutPanel1.ColumnCount = 2;
			this.TableLayoutPanel1.ColumnStyles.Add (new System.Windows.Forms.ColumnStyle (System.Windows.Forms.SizeType.Percent, 50F));
			this.TableLayoutPanel1.ColumnStyles.Add (new System.Windows.Forms.ColumnStyle (System.Windows.Forms.SizeType.Percent, 50F));
			this.TableLayoutPanel1.Controls.Add (this.OK_Button, 0, 0);
			this.TableLayoutPanel1.Controls.Add (this.Cancel_Button, 1, 0);
			this.TableLayoutPanel1.Location = new System.Drawing.Point (277, 235);
			this.TableLayoutPanel1.Name = "TableLayoutPanel1";
			this.TableLayoutPanel1.RowCount = 1;
			this.TableLayoutPanel1.RowStyles.Add (new System.Windows.Forms.RowStyle (System.Windows.Forms.SizeType.Percent, 50F));
			this.TableLayoutPanel1.Size = new System.Drawing.Size (146, 29);
			this.TableLayoutPanel1.TabIndex = 25;
			// 
			// OK_Button
			// 
			this.OK_Button.Anchor = System.Windows.Forms.AnchorStyles.None;
			this.OK_Button.Location = new System.Drawing.Point (3, 3);
			this.OK_Button.Name = "OK_Button";
			this.OK_Button.Size = new System.Drawing.Size (67, 23);
			this.OK_Button.TabIndex = 0;
			this.OK_Button.Text = "OK";
			this.OK_Button.Click += new System.EventHandler (this.OK_Button_Click);
			// 
			// NewAccountDialog
			// 
			this.AcceptButton = this.OK_Button;
			this.AutoScaleDimensions = new System.Drawing.SizeF (6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.CancelButton = this.Cancel_Button;
			this.ClientSize = new System.Drawing.Size (435, 276);
			this.Controls.Add (this.lblJid);
			this.Controls.Add (this.Label6);
			this.Controls.Add (this.txtConfirmPassword);
			this.Controls.Add (this.Label1);
			this.Controls.Add (this.chkRememberPassword);
			this.Controls.Add (this.Label5);
			this.Controls.Add (this.txtPassword);
			this.Controls.Add (this.Label4);
			this.Controls.Add (this.cmbServer);
			this.Controls.Add (this.Label3);
			this.Controls.Add (this.txtUsername);
			this.Controls.Add (this.Label2);
			this.Controls.Add (this.TableLayoutPanel1);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "NewAccountDialog";
			this.ShowInTaskbar = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "Create New IM Account";
			((System.ComponentModel.ISupportInitialize)(this.ErrorProvider)).EndInit ();
			this.TableLayoutPanel1.ResumeLayout (false);
			this.ResumeLayout (false);
			this.PerformLayout ();

		}

		#endregion

		internal System.Windows.Forms.Label lblJid;
		internal System.Windows.Forms.Label Label6;
		internal System.Windows.Forms.TextBox txtConfirmPassword;
		internal System.Windows.Forms.ErrorProvider ErrorProvider;
		internal System.Windows.Forms.Label Label1;
		internal System.Windows.Forms.CheckBox chkRememberPassword;
		internal System.Windows.Forms.Label Label5;
		internal System.Windows.Forms.TextBox txtPassword;
		internal System.Windows.Forms.Label Label4;
		internal System.Windows.Forms.ComboBox cmbServer;
		internal System.Windows.Forms.Label Label3;
		internal System.Windows.Forms.TextBox txtUsername;
		internal System.Windows.Forms.Label Label2;
		internal System.Windows.Forms.TableLayoutPanel TableLayoutPanel1;
		internal System.Windows.Forms.Button OK_Button;
		internal System.Windows.Forms.Button Cancel_Button;
		internal System.Windows.Forms.ToolTip ToolTip1;
	}
}