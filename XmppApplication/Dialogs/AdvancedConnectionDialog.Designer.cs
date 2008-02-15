namespace XmppApplication
{
	partial class AdvancedConnectionDialog
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
			this.ResourcePriorityTextbox = new System.Windows.Forms.TextBox ();
			this.TableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel ();
			this.OK_Button = new System.Windows.Forms.Button ();
			this.Cancel_Button = new System.Windows.Forms.Button ();
			this.Label4 = new System.Windows.Forms.Label ();
			this.Label1 = new System.Windows.Forms.Label ();
			this.ResourceTextBox = new System.Windows.Forms.TextBox ();
			this.GroupBox2 = new System.Windows.Forms.GroupBox ();
			this.Label5 = new System.Windows.Forms.Label ();
			this.ServerHostTextbox = new System.Windows.Forms.TextBox ();
			this.GroupBox1 = new System.Windows.Forms.GroupBox ();
			this.Label3 = new System.Windows.Forms.Label ();
			this.ServerPortTextbox = new System.Windows.Forms.TextBox ();
			this.Label2 = new System.Windows.Forms.Label ();
			this.AlwaysEncryptRadio = new System.Windows.Forms.RadioButton ();
			this.PreferEncryptRadio = new System.Windows.Forms.RadioButton ();
			this.GroupBox3 = new System.Windows.Forms.GroupBox ();
			this.NeverEncryptRadio = new System.Windows.Forms.RadioButton ();
			this.TableLayoutPanel1.SuspendLayout ();
			this.GroupBox2.SuspendLayout ();
			this.GroupBox1.SuspendLayout ();
			this.GroupBox3.SuspendLayout ();
			this.SuspendLayout ();
			// 
			// ResourcePriorityTextbox
			// 
			this.ResourcePriorityTextbox.Location = new System.Drawing.Point (109, 45);
			this.ResourcePriorityTextbox.Name = "ResourcePriorityTextbox";
			this.ResourcePriorityTextbox.Size = new System.Drawing.Size (67, 20);
			this.ResourcePriorityTextbox.TabIndex = 17;
			// 
			// TableLayoutPanel1
			// 
			this.TableLayoutPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.TableLayoutPanel1.ColumnCount = 2;
			this.TableLayoutPanel1.ColumnStyles.Add (new System.Windows.Forms.ColumnStyle (System.Windows.Forms.SizeType.Percent, 50F));
			this.TableLayoutPanel1.ColumnStyles.Add (new System.Windows.Forms.ColumnStyle (System.Windows.Forms.SizeType.Percent, 50F));
			this.TableLayoutPanel1.Controls.Add (this.OK_Button, 0, 0);
			this.TableLayoutPanel1.Controls.Add (this.Cancel_Button, 1, 0);
			this.TableLayoutPanel1.Location = new System.Drawing.Point (165, 274);
			this.TableLayoutPanel1.Name = "TableLayoutPanel1";
			this.TableLayoutPanel1.RowCount = 1;
			this.TableLayoutPanel1.RowStyles.Add (new System.Windows.Forms.RowStyle (System.Windows.Forms.SizeType.Percent, 50F));
			this.TableLayoutPanel1.Size = new System.Drawing.Size (146, 29);
			this.TableLayoutPanel1.TabIndex = 23;
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
			this.Label4.AutoSize = true;
			this.Label4.Location = new System.Drawing.Point (9, 48);
			this.Label4.Name = "Label4";
			this.Label4.Size = new System.Drawing.Size (90, 13);
			this.Label4.TabIndex = 16;
			this.Label4.Text = "Resource Priority:";
			// 
			// Label1
			// 
			this.Label1.AutoSize = true;
			this.Label1.Location = new System.Drawing.Point (15, 20);
			this.Label1.Name = "Label1";
			this.Label1.Size = new System.Drawing.Size (66, 13);
			this.Label1.TabIndex = 8;
			this.Label1.Text = "Server Host:";
			// 
			// ResourceTextBox
			// 
			this.ResourceTextBox.Location = new System.Drawing.Point (109, 19);
			this.ResourceTextBox.Name = "ResourceTextBox";
			this.ResourceTextBox.Size = new System.Drawing.Size (67, 20);
			this.ResourceTextBox.TabIndex = 19;
			// 
			// GroupBox2
			// 
			this.GroupBox2.Controls.Add (this.Label4);
			this.GroupBox2.Controls.Add (this.ResourcePriorityTextbox);
			this.GroupBox2.Controls.Add (this.ResourceTextBox);
			this.GroupBox2.Controls.Add (this.Label5);
			this.GroupBox2.Location = new System.Drawing.Point (12, 93);
			this.GroupBox2.Name = "GroupBox2";
			this.GroupBox2.Size = new System.Drawing.Size (295, 75);
			this.GroupBox2.TabIndex = 25;
			this.GroupBox2.TabStop = false;
			this.GroupBox2.Text = "Resource Options";
			// 
			// Label5
			// 
			this.Label5.AutoSize = true;
			this.Label5.Location = new System.Drawing.Point (42, 22);
			this.Label5.Name = "Label5";
			this.Label5.Size = new System.Drawing.Size (56, 13);
			this.Label5.TabIndex = 18;
			this.Label5.Text = "Resource:";
			// 
			// ServerHostTextbox
			// 
			this.ServerHostTextbox.Location = new System.Drawing.Point (87, 17);
			this.ServerHostTextbox.Name = "ServerHostTextbox";
			this.ServerHostTextbox.Size = new System.Drawing.Size (191, 20);
			this.ServerHostTextbox.TabIndex = 9;
			// 
			// GroupBox1
			// 
			this.GroupBox1.Controls.Add (this.Label1);
			this.GroupBox1.Controls.Add (this.ServerHostTextbox);
			this.GroupBox1.Controls.Add (this.Label3);
			this.GroupBox1.Controls.Add (this.ServerPortTextbox);
			this.GroupBox1.Location = new System.Drawing.Point (12, 12);
			this.GroupBox1.Name = "GroupBox1";
			this.GroupBox1.Size = new System.Drawing.Size (295, 75);
			this.GroupBox1.TabIndex = 24;
			this.GroupBox1.TabStop = false;
			this.GroupBox1.Text = "Server Options";
			// 
			// Label3
			// 
			this.Label3.AutoSize = true;
			this.Label3.Location = new System.Drawing.Point (15, 46);
			this.Label3.Name = "Label3";
			this.Label3.Size = new System.Drawing.Size (63, 13);
			this.Label3.TabIndex = 14;
			this.Label3.Text = "Server Port:";
			// 
			// ServerPortTextbox
			// 
			this.ServerPortTextbox.Location = new System.Drawing.Point (87, 43);
			this.ServerPortTextbox.Name = "ServerPortTextbox";
			this.ServerPortTextbox.Size = new System.Drawing.Size (67, 20);
			this.ServerPortTextbox.TabIndex = 15;
			// 
			// Label2
			// 
			this.Label2.AutoSize = true;
			this.Label2.Location = new System.Drawing.Point (6, 23);
			this.Label2.Name = "Label2";
			this.Label2.Size = new System.Drawing.Size (60, 13);
			this.Label2.TabIndex = 10;
			this.Label2.Text = "Encryption:";
			// 
			// AlwaysEncryptRadio
			// 
			this.AlwaysEncryptRadio.AutoSize = true;
			this.AlwaysEncryptRadio.Location = new System.Drawing.Point (73, 22);
			this.AlwaysEncryptRadio.Name = "AlwaysEncryptRadio";
			this.AlwaysEncryptRadio.Size = new System.Drawing.Size (130, 17);
			this.AlwaysEncryptRadio.TabIndex = 11;
			this.AlwaysEncryptRadio.TabStop = true;
			this.AlwaysEncryptRadio.Text = "Always use encryption";
			this.AlwaysEncryptRadio.UseVisualStyleBackColor = true;
			// 
			// PreferEncryptRadio
			// 
			this.PreferEncryptRadio.AutoSize = true;
			this.PreferEncryptRadio.Location = new System.Drawing.Point (73, 41);
			this.PreferEncryptRadio.Name = "PreferEncryptRadio";
			this.PreferEncryptRadio.Size = new System.Drawing.Size (149, 17);
			this.PreferEncryptRadio.TabIndex = 12;
			this.PreferEncryptRadio.TabStop = true;
			this.PreferEncryptRadio.Text = "Use encryption if available";
			this.PreferEncryptRadio.UseVisualStyleBackColor = true;
			// 
			// GroupBox3
			// 
			this.GroupBox3.Controls.Add (this.Label2);
			this.GroupBox3.Controls.Add (this.AlwaysEncryptRadio);
			this.GroupBox3.Controls.Add (this.PreferEncryptRadio);
			this.GroupBox3.Controls.Add (this.NeverEncryptRadio);
			this.GroupBox3.Location = new System.Drawing.Point (12, 174);
			this.GroupBox3.Name = "GroupBox3";
			this.GroupBox3.Size = new System.Drawing.Size (295, 86);
			this.GroupBox3.TabIndex = 26;
			this.GroupBox3.TabStop = false;
			this.GroupBox3.Text = "Encryption Options";
			// 
			// NeverEncryptRadio
			// 
			this.NeverEncryptRadio.AutoSize = true;
			this.NeverEncryptRadio.Location = new System.Drawing.Point (73, 60);
			this.NeverEncryptRadio.Name = "NeverEncryptRadio";
			this.NeverEncryptRadio.Size = new System.Drawing.Size (126, 17);
			this.NeverEncryptRadio.TabIndex = 13;
			this.NeverEncryptRadio.TabStop = true;
			this.NeverEncryptRadio.Text = "Never use encryption";
			this.NeverEncryptRadio.UseVisualStyleBackColor = true;
			// 
			// AdvancedConnectionDialog
			// 
			this.AcceptButton = this.OK_Button;
			this.AutoScaleDimensions = new System.Drawing.SizeF (6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.CancelButton = this.Cancel_Button;
			this.ClientSize = new System.Drawing.Size (323, 315);
			this.Controls.Add (this.TableLayoutPanel1);
			this.Controls.Add (this.GroupBox2);
			this.Controls.Add (this.GroupBox1);
			this.Controls.Add (this.GroupBox3);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "AdvancedConnectionDialog";
			this.ShowInTaskbar = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "Advanced Connection Options";
			this.TableLayoutPanel1.ResumeLayout (false);
			this.GroupBox2.ResumeLayout (false);
			this.GroupBox2.PerformLayout ();
			this.GroupBox1.ResumeLayout (false);
			this.GroupBox1.PerformLayout ();
			this.GroupBox3.ResumeLayout (false);
			this.GroupBox3.PerformLayout ();
			this.ResumeLayout (false);

		}

		#endregion

		internal System.Windows.Forms.TextBox ResourcePriorityTextbox;
		internal System.Windows.Forms.TableLayoutPanel TableLayoutPanel1;
		internal System.Windows.Forms.Button OK_Button;
		internal System.Windows.Forms.Button Cancel_Button;
		internal System.Windows.Forms.Label Label4;
		internal System.Windows.Forms.Label Label1;
		internal System.Windows.Forms.TextBox ResourceTextBox;
		internal System.Windows.Forms.GroupBox GroupBox2;
		internal System.Windows.Forms.Label Label5;
		internal System.Windows.Forms.TextBox ServerHostTextbox;
		internal System.Windows.Forms.GroupBox GroupBox1;
		internal System.Windows.Forms.Label Label3;
		internal System.Windows.Forms.TextBox ServerPortTextbox;
		internal System.Windows.Forms.Label Label2;
		internal System.Windows.Forms.RadioButton AlwaysEncryptRadio;
		internal System.Windows.Forms.RadioButton PreferEncryptRadio;
		internal System.Windows.Forms.GroupBox GroupBox3;
		internal System.Windows.Forms.RadioButton NeverEncryptRadio;
	}
}