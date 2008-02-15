namespace XmppApplication
{
	partial class SubscriptionRequestDialog
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
			this.TableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel ();
			this.OK_Button = new System.Windows.Forms.Button ();
			this.Cancel_Button = new System.Windows.Forms.Button ();
			this.RequestLabel = new System.Windows.Forms.Label ();
			this.AddCheckBox = new System.Windows.Forms.CheckBox ();
			this.TableLayoutPanel1.SuspendLayout ();
			this.SuspendLayout ();
			// 
			// TableLayoutPanel1
			// 
			this.TableLayoutPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.TableLayoutPanel1.ColumnCount = 2;
			this.TableLayoutPanel1.ColumnStyles.Add (new System.Windows.Forms.ColumnStyle (System.Windows.Forms.SizeType.Percent, 50F));
			this.TableLayoutPanel1.ColumnStyles.Add (new System.Windows.Forms.ColumnStyle (System.Windows.Forms.SizeType.Percent, 50F));
			this.TableLayoutPanel1.Controls.Add (this.OK_Button, 0, 0);
			this.TableLayoutPanel1.Controls.Add (this.Cancel_Button, 1, 0);
			this.TableLayoutPanel1.Location = new System.Drawing.Point (188, 91);
			this.TableLayoutPanel1.Name = "TableLayoutPanel1";
			this.TableLayoutPanel1.RowCount = 1;
			this.TableLayoutPanel1.RowStyles.Add (new System.Windows.Forms.RowStyle (System.Windows.Forms.SizeType.Percent, 50F));
			this.TableLayoutPanel1.Size = new System.Drawing.Size (146, 29);
			this.TableLayoutPanel1.TabIndex = 3;
			// 
			// OK_Button
			// 
			this.OK_Button.Anchor = System.Windows.Forms.AnchorStyles.None;
			this.OK_Button.Location = new System.Drawing.Point (3, 3);
			this.OK_Button.Name = "OK_Button";
			this.OK_Button.Size = new System.Drawing.Size (67, 23);
			this.OK_Button.TabIndex = 0;
			this.OK_Button.Text = "Allow";
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
			this.Cancel_Button.Text = "Deny";
			this.Cancel_Button.Click += new System.EventHandler (this.Cancel_Button_Click);
			// 
			// RequestLabel
			// 
			this.RequestLabel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
				    | System.Windows.Forms.AnchorStyles.Right)));
			this.RequestLabel.Location = new System.Drawing.Point (12, 12);
			this.RequestLabel.Name = "RequestLabel";
			this.RequestLabel.Size = new System.Drawing.Size (322, 35);
			this.RequestLabel.TabIndex = 4;
			// 
			// AddCheckBox
			// 
			this.AddCheckBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
				    | System.Windows.Forms.AnchorStyles.Right)));
			this.AddCheckBox.Location = new System.Drawing.Point (15, 50);
			this.AddCheckBox.Name = "AddCheckBox";
			this.AddCheckBox.Size = new System.Drawing.Size (319, 20);
			this.AddCheckBox.TabIndex = 5;
			this.AddCheckBox.Text = "Add user to my buddy list";
			this.AddCheckBox.UseVisualStyleBackColor = true;
			this.AddCheckBox.Visible = false;
			// 
			// SubscriptionRequestDialog
			// 
			this.AcceptButton = this.OK_Button;
			this.AutoScaleDimensions = new System.Drawing.SizeF (6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.CancelButton = this.Cancel_Button;
			this.ClientSize = new System.Drawing.Size (347, 133);
			this.Controls.Add (this.TableLayoutPanel1);
			this.Controls.Add (this.RequestLabel);
			this.Controls.Add (this.AddCheckBox);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "SubscriptionRequestDialog";
			this.ShowInTaskbar = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "Subscription Request";
			this.TableLayoutPanel1.ResumeLayout (false);
			this.ResumeLayout (false);

		}

		#endregion

		internal System.Windows.Forms.TableLayoutPanel TableLayoutPanel1;
		internal System.Windows.Forms.Button OK_Button;
		internal System.Windows.Forms.Button Cancel_Button;
		internal System.Windows.Forms.Label RequestLabel;
		internal System.Windows.Forms.CheckBox AddCheckBox;
	}
}