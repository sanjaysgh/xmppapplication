namespace XmppApplication
{
	partial class RenameContactDialog
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
			this.Ok_Button = new System.Windows.Forms.Button ();
			this.ContactNameTextBox = new System.Windows.Forms.TextBox ();
			this.ContactNameLabel = new System.Windows.Forms.Label ();
			this.Label2 = new System.Windows.Forms.Label ();
			this.Label1 = new System.Windows.Forms.Label ();
			this.JidLabel = new System.Windows.Forms.Label ();
			this.Cancel_Button = new System.Windows.Forms.Button ();
			this.SuspendLayout ();
			// 
			// Ok_Button
			// 
			this.Ok_Button.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.Ok_Button.DialogResult = System.Windows.Forms.DialogResult.OK;
			this.Ok_Button.Location = new System.Drawing.Point (261, 110);
			this.Ok_Button.Name = "Ok_Button";
			this.Ok_Button.Size = new System.Drawing.Size (75, 25);
			this.Ok_Button.TabIndex = 68;
			this.Ok_Button.Text = "Ok";
			this.Ok_Button.UseVisualStyleBackColor = true;
			// 
			// ContactNameTextBox
			// 
			this.ContactNameTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
				    | System.Windows.Forms.AnchorStyles.Right)));
			this.ContactNameTextBox.BackColor = System.Drawing.Color.White;
			this.ContactNameTextBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.ContactNameTextBox.Location = new System.Drawing.Point (79, 76);
			this.ContactNameTextBox.Name = "ContactNameTextBox";
			this.ContactNameTextBox.Size = new System.Drawing.Size (256, 20);
			this.ContactNameTextBox.TabIndex = 66;
			this.ContactNameTextBox.TabStop = false;
			// 
			// ContactNameLabel
			// 
			this.ContactNameLabel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
				    | System.Windows.Forms.AnchorStyles.Right)));
			this.ContactNameLabel.Location = new System.Drawing.Point (76, 53);
			this.ContactNameLabel.Name = "ContactNameLabel";
			this.ContactNameLabel.Size = new System.Drawing.Size (260, 13);
			this.ContactNameLabel.TabIndex = 64;
			// 
			// Label2
			// 
			this.Label2.Location = new System.Drawing.Point (12, 78);
			this.Label2.Name = "Label2";
			this.Label2.Size = new System.Drawing.Size (61, 13);
			this.Label2.TabIndex = 63;
			this.Label2.Text = "To:";
			this.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// Label1
			// 
			this.Label1.Location = new System.Drawing.Point (15, 53);
			this.Label1.Name = "Label1";
			this.Label1.Size = new System.Drawing.Size (58, 13);
			this.Label1.TabIndex = 62;
			this.Label1.Text = "Rename:";
			this.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// JidLabel
			// 
			this.JidLabel.BackColor = System.Drawing.Color.Transparent;
			this.JidLabel.Font = new System.Drawing.Font ("Tahoma", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.JidLabel.ForeColor = System.Drawing.Color.Black;
			this.JidLabel.Location = new System.Drawing.Point (13, 11);
			this.JidLabel.Name = "JidLabel";
			this.JidLabel.Size = new System.Drawing.Size (356, 24);
			this.JidLabel.TabIndex = 60;
			this.JidLabel.Text = "Rename Contact";
			// 
			// Cancel_Button
			// 
			this.Cancel_Button.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.Cancel_Button.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.Cancel_Button.Location = new System.Drawing.Point (180, 110);
			this.Cancel_Button.Name = "Cancel_Button";
			this.Cancel_Button.Size = new System.Drawing.Size (75, 25);
			this.Cancel_Button.TabIndex = 69;
			this.Cancel_Button.Text = "Cancel";
			this.Cancel_Button.UseVisualStyleBackColor = true;
			// 
			// RenameContactDialog
			// 
			this.AcceptButton = this.Ok_Button;
			this.CancelButton = this.Cancel_Button;
			this.ClientSize = new System.Drawing.Size (347, 145);
			this.Controls.Add (this.Cancel_Button);
			this.Controls.Add (this.Ok_Button);
			this.Controls.Add (this.ContactNameTextBox);
			this.Controls.Add (this.ContactNameLabel);
			this.Controls.Add (this.Label2);
			this.Controls.Add (this.Label1);
			this.Controls.Add (this.JidLabel);
			this.Name = "RenameContactDialog";
			this.Text = "Rename Contact";
			this.ResumeLayout (false);
			this.PerformLayout ();

		}

		#endregion

		internal System.Windows.Forms.Button Ok_Button;
		internal System.Windows.Forms.TextBox ContactNameTextBox;
		internal System.Windows.Forms.Label ContactNameLabel;
		internal System.Windows.Forms.Label Label2;
		internal System.Windows.Forms.Label Label1;
		internal System.Windows.Forms.Label JidLabel;
		internal System.Windows.Forms.Button Cancel_Button;
	}
}