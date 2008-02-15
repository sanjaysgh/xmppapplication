namespace XmppApplication
{
	partial class NewAwayMessageDialog
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
			this.Label1 = new System.Windows.Forms.Label ();
			this.TitleTextBox = new System.Windows.Forms.TextBox ();
			this.SaveMessageCheckBox = new System.Windows.Forms.CheckBox ();
			this.AwayMessageTextBox = new System.Windows.Forms.TextBox ();
			this.Cancel_Button = new System.Windows.Forms.Button ();
			this.OK_Button = new System.Windows.Forms.Button ();
			this.TableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel ();
			this.TableLayoutPanel1.SuspendLayout ();
			this.SuspendLayout ();
			// 
			// Label1
			// 
			this.Label1.AutoSize = true;
			this.Label1.Location = new System.Drawing.Point (4, 8);
			this.Label1.Name = "Label1";
			this.Label1.Size = new System.Drawing.Size (76, 13);
			this.Label1.TabIndex = 9;
			this.Label1.Text = "Title (optional):";
			// 
			// TitleTextBox
			// 
			this.TitleTextBox.Location = new System.Drawing.Point (82, 5);
			this.TitleTextBox.Name = "TitleTextBox";
			this.TitleTextBox.Size = new System.Drawing.Size (236, 20);
			this.TitleTextBox.TabIndex = 8;
			// 
			// SaveMessageCheckBox
			// 
			this.SaveMessageCheckBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.SaveMessageCheckBox.AutoSize = true;
			this.SaveMessageCheckBox.Location = new System.Drawing.Point (7, 127);
			this.SaveMessageCheckBox.Name = "SaveMessageCheckBox";
			this.SaveMessageCheckBox.Size = new System.Drawing.Size (180, 17);
			this.SaveMessageCheckBox.TabIndex = 7;
			this.SaveMessageCheckBox.Text = "Keep this message for future use";
			this.SaveMessageCheckBox.UseVisualStyleBackColor = true;
			// 
			// AwayMessageTextBox
			// 
			this.AwayMessageTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
				    | System.Windows.Forms.AnchorStyles.Left)
				    | System.Windows.Forms.AnchorStyles.Right)));
			this.AwayMessageTextBox.Location = new System.Drawing.Point (7, 29);
			this.AwayMessageTextBox.Multiline = true;
			this.AwayMessageTextBox.Name = "AwayMessageTextBox";
			this.AwayMessageTextBox.Size = new System.Drawing.Size (311, 92);
			this.AwayMessageTextBox.TabIndex = 5;
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
			// TableLayoutPanel1
			// 
			this.TableLayoutPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.TableLayoutPanel1.ColumnCount = 2;
			this.TableLayoutPanel1.ColumnStyles.Add (new System.Windows.Forms.ColumnStyle (System.Windows.Forms.SizeType.Percent, 50F));
			this.TableLayoutPanel1.ColumnStyles.Add (new System.Windows.Forms.ColumnStyle (System.Windows.Forms.SizeType.Percent, 50F));
			this.TableLayoutPanel1.Controls.Add (this.Cancel_Button, 1, 0);
			this.TableLayoutPanel1.Controls.Add (this.OK_Button, 0, 0);
			this.TableLayoutPanel1.Location = new System.Drawing.Point (175, 149);
			this.TableLayoutPanel1.Name = "TableLayoutPanel1";
			this.TableLayoutPanel1.RowCount = 1;
			this.TableLayoutPanel1.RowStyles.Add (new System.Windows.Forms.RowStyle (System.Windows.Forms.SizeType.Percent, 50F));
			this.TableLayoutPanel1.Size = new System.Drawing.Size (146, 29);
			this.TableLayoutPanel1.TabIndex = 6;
			// 
			// NewAwayMessageDialog
			// 
			this.AcceptButton = this.OK_Button;
			this.AutoScaleDimensions = new System.Drawing.SizeF (6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.CancelButton = this.Cancel_Button;
			this.ClientSize = new System.Drawing.Size (325, 183);
			this.Controls.Add (this.Label1);
			this.Controls.Add (this.TitleTextBox);
			this.Controls.Add (this.SaveMessageCheckBox);
			this.Controls.Add (this.AwayMessageTextBox);
			this.Controls.Add (this.TableLayoutPanel1);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "NewAwayMessageDialog";
			this.ShowInTaskbar = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "New Away Message";
			this.TableLayoutPanel1.ResumeLayout (false);
			this.ResumeLayout (false);
			this.PerformLayout ();

		}

		#endregion

		internal System.Windows.Forms.Label Label1;
		internal System.Windows.Forms.TextBox TitleTextBox;
		internal System.Windows.Forms.CheckBox SaveMessageCheckBox;
		internal System.Windows.Forms.TextBox AwayMessageTextBox;
		internal System.Windows.Forms.Button Cancel_Button;
		internal System.Windows.Forms.Button OK_Button;
		internal System.Windows.Forms.TableLayoutPanel TableLayoutPanel1;
	}
}