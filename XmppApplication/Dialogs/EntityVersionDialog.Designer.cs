namespace XmppApplication
{
	partial class EntityVersionDialog
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
			this.CloseButton = new System.Windows.Forms.Button ();
			this.OSTextBox = new System.Windows.Forms.TextBox ();
			this.VersionTextBox = new System.Windows.Forms.TextBox ();
			this.NameTextBox = new System.Windows.Forms.TextBox ();
			this.Label3 = new System.Windows.Forms.Label ();
			this.Label2 = new System.Windows.Forms.Label ();
			this.Label1 = new System.Windows.Forms.Label ();
			this.JidLabel = new System.Windows.Forms.Label ();
			this.Spinner = new System.Windows.Forms.PictureBox ();
			((System.ComponentModel.ISupportInitialize)(this.Spinner)).BeginInit ();
			this.SuspendLayout ();
			// 
			// CloseButton
			// 
			this.CloseButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.CloseButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.CloseButton.Location = new System.Drawing.Point (293, 127);
			this.CloseButton.Name = "CloseButton";
			this.CloseButton.Size = new System.Drawing.Size (75, 25);
			this.CloseButton.TabIndex = 68;
			this.CloseButton.Text = "Close";
			this.CloseButton.UseVisualStyleBackColor = true;
			this.CloseButton.Click += new System.EventHandler (this.CloseButton_Click);
			// 
			// OSTextBox
			// 
			this.OSTextBox.BackColor = System.Drawing.Color.White;
			this.OSTextBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.OSTextBox.Font = new System.Drawing.Font ("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.OSTextBox.Location = new System.Drawing.Point (78, 98);
			this.OSTextBox.Name = "OSTextBox";
			this.OSTextBox.ReadOnly = true;
			this.OSTextBox.Size = new System.Drawing.Size (268, 13);
			this.OSTextBox.TabIndex = 67;
			this.OSTextBox.TabStop = false;
			// 
			// VersionTextBox
			// 
			this.VersionTextBox.BackColor = System.Drawing.Color.White;
			this.VersionTextBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.VersionTextBox.Font = new System.Drawing.Font ("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.VersionTextBox.Location = new System.Drawing.Point (78, 76);
			this.VersionTextBox.Name = "VersionTextBox";
			this.VersionTextBox.ReadOnly = true;
			this.VersionTextBox.Size = new System.Drawing.Size (268, 13);
			this.VersionTextBox.TabIndex = 66;
			this.VersionTextBox.TabStop = false;
			// 
			// NameTextBox
			// 
			this.NameTextBox.BackColor = System.Drawing.Color.White;
			this.NameTextBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.NameTextBox.Font = new System.Drawing.Font ("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.NameTextBox.Location = new System.Drawing.Point (78, 54);
			this.NameTextBox.Name = "NameTextBox";
			this.NameTextBox.ReadOnly = true;
			this.NameTextBox.Size = new System.Drawing.Size (268, 13);
			this.NameTextBox.TabIndex = 65;
			this.NameTextBox.TabStop = false;
			// 
			// Label3
			// 
			this.Label3.AutoSize = true;
			this.Label3.Location = new System.Drawing.Point (47, 98);
			this.Label3.Name = "Label3";
			this.Label3.Size = new System.Drawing.Size (25, 13);
			this.Label3.TabIndex = 64;
			this.Label3.Text = "OS:";
			// 
			// Label2
			// 
			this.Label2.AutoSize = true;
			this.Label2.Location = new System.Drawing.Point (27, 76);
			this.Label2.Name = "Label2";
			this.Label2.Size = new System.Drawing.Size (45, 13);
			this.Label2.TabIndex = 63;
			this.Label2.Text = "Version:";
			// 
			// Label1
			// 
			this.Label1.AutoSize = true;
			this.Label1.Location = new System.Drawing.Point (34, 54);
			this.Label1.Name = "Label1";
			this.Label1.Size = new System.Drawing.Size (38, 13);
			this.Label1.TabIndex = 62;
			this.Label1.Text = "Name:";
			// 
			// JidLabel
			// 
			this.JidLabel.BackColor = System.Drawing.Color.Transparent;
			this.JidLabel.Font = new System.Drawing.Font ("Tahoma", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.JidLabel.ForeColor = System.Drawing.Color.Black;
			this.JidLabel.Location = new System.Drawing.Point (12, 11);
			this.JidLabel.Name = "JidLabel";
			this.JidLabel.Size = new System.Drawing.Size (356, 24);
			this.JidLabel.TabIndex = 60;
			// 
			// Spinner
			// 
			this.Spinner.Location = new System.Drawing.Point (352, 48);
			this.Spinner.Name = "Spinner";
			this.Spinner.Size = new System.Drawing.Size (16, 16);
			this.Spinner.TabIndex = 61;
			this.Spinner.TabStop = false;
			this.Spinner.Visible = false;
			// 
			// EntityVersionDialog
			// 
			this.AcceptButton = this.CloseButton;
			this.AutoScaleDimensions = new System.Drawing.SizeF (6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.Color.White;
			this.CancelButton = this.CloseButton;
			this.ClientSize = new System.Drawing.Size (380, 162);
			this.Controls.Add (this.CloseButton);
			this.Controls.Add (this.OSTextBox);
			this.Controls.Add (this.VersionTextBox);
			this.Controls.Add (this.NameTextBox);
			this.Controls.Add (this.Label3);
			this.Controls.Add (this.Label2);
			this.Controls.Add (this.Label1);
			this.Controls.Add (this.Spinner);
			this.Controls.Add (this.JidLabel);
			this.Name = "EntityVersionDialog";
			this.Text = "Entity Version";
			((System.ComponentModel.ISupportInitialize)(this.Spinner)).EndInit ();
			this.ResumeLayout (false);
			this.PerformLayout ();

		}

		#endregion

		internal System.Windows.Forms.Button CloseButton;
		internal System.Windows.Forms.TextBox OSTextBox;
		internal System.Windows.Forms.TextBox VersionTextBox;
		internal System.Windows.Forms.TextBox NameTextBox;
		internal System.Windows.Forms.Label Label3;
		internal System.Windows.Forms.Label Label2;
		internal System.Windows.Forms.Label Label1;
		internal System.Windows.Forms.PictureBox Spinner;
		internal System.Windows.Forms.Label JidLabel;
	}
}