namespace XmppApplication
{
	partial class AddContactDialog
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
			this.Label2 = new System.Windows.Forms.Label ();
			this.txtNickname = new System.Windows.Forms.TextBox ();
			this.Label1 = new System.Windows.Forms.Label ();
			this.Label7 = new System.Windows.Forms.Label ();
			this.OK_Button = new System.Windows.Forms.Button ();
			this.txtJid = new System.Windows.Forms.TextBox ();
			this.TableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel ();
			this.Cancel_Button = new System.Windows.Forms.Button ();
			this.TableLayoutPanel1.SuspendLayout ();
			this.SuspendLayout ();
			// 
			// Label2
			// 
			this.Label2.Location = new System.Drawing.Point (12, 63);
			this.Label2.Name = "Label2";
			this.Label2.Size = new System.Drawing.Size (96, 16);
			this.Label2.TabIndex = 16;
			this.Label2.Text = "Nickname:";
			this.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// txtNickname
			// 
			this.txtNickname.Location = new System.Drawing.Point (116, 63);
			this.txtNickname.Name = "txtNickname";
			this.txtNickname.Size = new System.Drawing.Size (248, 20);
			this.txtNickname.TabIndex = 15;
			// 
			// Label1
			// 
			this.Label1.AutoSize = true;
			this.Label1.Location = new System.Drawing.Point (35, 11);
			this.Label1.Name = "Label1";
			this.Label1.Size = new System.Drawing.Size (329, 13);
			this.Label1.TabIndex = 14;
			this.Label1.Text = "Enter the IM address of the user you want to add to your contact list.";
			// 
			// Label7
			// 
			this.Label7.Location = new System.Drawing.Point (12, 40);
			this.Label7.Name = "Label7";
			this.Label7.Size = new System.Drawing.Size (96, 16);
			this.Label7.TabIndex = 13;
			this.Label7.Text = "IM Address:";
			this.Label7.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
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
			// txtJid
			// 
			this.txtJid.Location = new System.Drawing.Point (116, 40);
			this.txtJid.Name = "txtJid";
			this.txtJid.Size = new System.Drawing.Size (248, 20);
			this.txtJid.TabIndex = 12;
			// 
			// TableLayoutPanel1
			// 
			this.TableLayoutPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.TableLayoutPanel1.ColumnCount = 2;
			this.TableLayoutPanel1.ColumnStyles.Add (new System.Windows.Forms.ColumnStyle (System.Windows.Forms.SizeType.Percent, 50F));
			this.TableLayoutPanel1.ColumnStyles.Add (new System.Windows.Forms.ColumnStyle (System.Windows.Forms.SizeType.Percent, 50F));
			this.TableLayoutPanel1.Controls.Add (this.OK_Button, 0, 0);
			this.TableLayoutPanel1.Controls.Add (this.Cancel_Button, 1, 0);
			this.TableLayoutPanel1.Location = new System.Drawing.Point (241, 95);
			this.TableLayoutPanel1.Name = "TableLayoutPanel1";
			this.TableLayoutPanel1.RowCount = 1;
			this.TableLayoutPanel1.RowStyles.Add (new System.Windows.Forms.RowStyle (System.Windows.Forms.SizeType.Percent, 50F));
			this.TableLayoutPanel1.Size = new System.Drawing.Size (146, 29);
			this.TableLayoutPanel1.TabIndex = 11;
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
			// AddContactDialog
			// 
			this.AcceptButton = this.OK_Button;
			this.AutoScaleDimensions = new System.Drawing.SizeF (6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.CancelButton = this.Cancel_Button;
			this.ClientSize = new System.Drawing.Size (399, 134);
			this.Controls.Add (this.Label2);
			this.Controls.Add (this.txtNickname);
			this.Controls.Add (this.Label1);
			this.Controls.Add (this.Label7);
			this.Controls.Add (this.txtJid);
			this.Controls.Add (this.TableLayoutPanel1);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "AddContactDialog";
			this.ShowInTaskbar = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "Add New Contact";
			this.TableLayoutPanel1.ResumeLayout (false);
			this.ResumeLayout (false);
			this.PerformLayout ();

		}

		#endregion

		internal System.Windows.Forms.Label Label2;
		internal System.Windows.Forms.TextBox txtNickname;
		internal System.Windows.Forms.Label Label1;
		internal System.Windows.Forms.Label Label7;
		internal System.Windows.Forms.Button OK_Button;
		internal System.Windows.Forms.TextBox txtJid;
		internal System.Windows.Forms.TableLayoutPanel TableLayoutPanel1;
		internal System.Windows.Forms.Button Cancel_Button;
	}
}