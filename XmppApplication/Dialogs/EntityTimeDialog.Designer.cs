namespace XmppApplication
{
	partial class EntityTimeDialog
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
			this.TimeTextBox = new System.Windows.Forms.TextBox ();
			this.TimeZoneTextBox = new System.Windows.Forms.TextBox ();
			this.UtcTextBox = new System.Windows.Forms.TextBox ();
			this.Label3 = new System.Windows.Forms.Label ();
			this.Label2 = new System.Windows.Forms.Label ();
			this.Label1 = new System.Windows.Forms.Label ();
			this.Spinner = new System.Windows.Forms.PictureBox ();
			this.JidLabel = new System.Windows.Forms.Label ();
			((System.ComponentModel.ISupportInitialize)(this.Spinner)).BeginInit ();
			this.SuspendLayout ();
			// 
			// CloseButton
			// 
			this.CloseButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.CloseButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.CloseButton.Location = new System.Drawing.Point (294, 127);
			this.CloseButton.Name = "CloseButton";
			this.CloseButton.Size = new System.Drawing.Size (75, 25);
			this.CloseButton.TabIndex = 68;
			this.CloseButton.Text = "Close";
			this.CloseButton.UseVisualStyleBackColor = true;
			this.CloseButton.Click += new System.EventHandler (this.CloseButton_Click);
			// 
			// TimeTextBox
			// 
			this.TimeTextBox.BackColor = System.Drawing.Color.White;
			this.TimeTextBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.TimeTextBox.Font = new System.Drawing.Font ("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.TimeTextBox.Location = new System.Drawing.Point (79, 98);
			this.TimeTextBox.Name = "TimeTextBox";
			this.TimeTextBox.ReadOnly = true;
			this.TimeTextBox.Size = new System.Drawing.Size (268, 13);
			this.TimeTextBox.TabIndex = 67;
			this.TimeTextBox.TabStop = false;
			// 
			// TimeZoneTextBox
			// 
			this.TimeZoneTextBox.BackColor = System.Drawing.Color.White;
			this.TimeZoneTextBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.TimeZoneTextBox.Font = new System.Drawing.Font ("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.TimeZoneTextBox.Location = new System.Drawing.Point (79, 76);
			this.TimeZoneTextBox.Name = "TimeZoneTextBox";
			this.TimeZoneTextBox.ReadOnly = true;
			this.TimeZoneTextBox.Size = new System.Drawing.Size (268, 13);
			this.TimeZoneTextBox.TabIndex = 66;
			this.TimeZoneTextBox.TabStop = false;
			// 
			// UtcTextBox
			// 
			this.UtcTextBox.BackColor = System.Drawing.Color.White;
			this.UtcTextBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.UtcTextBox.Font = new System.Drawing.Font ("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.UtcTextBox.Location = new System.Drawing.Point (79, 54);
			this.UtcTextBox.Name = "UtcTextBox";
			this.UtcTextBox.ReadOnly = true;
			this.UtcTextBox.Size = new System.Drawing.Size (268, 13);
			this.UtcTextBox.TabIndex = 65;
			this.UtcTextBox.TabStop = false;
			// 
			// Label3
			// 
			this.Label3.AutoSize = true;
			this.Label3.Location = new System.Drawing.Point (40, 97);
			this.Label3.Name = "Label3";
			this.Label3.Size = new System.Drawing.Size (33, 13);
			this.Label3.TabIndex = 64;
			this.Label3.Text = "Time:";
			// 
			// Label2
			// 
			this.Label2.AutoSize = true;
			this.Label2.Location = new System.Drawing.Point (12, 75);
			this.Label2.Name = "Label2";
			this.Label2.Size = new System.Drawing.Size (61, 13);
			this.Label2.TabIndex = 63;
			this.Label2.Text = "Time Zone:";
			// 
			// Label1
			// 
			this.Label1.AutoSize = true;
			this.Label1.Location = new System.Drawing.Point (15, 53);
			this.Label1.Name = "Label1";
			this.Label1.Size = new System.Drawing.Size (58, 13);
			this.Label1.TabIndex = 62;
			this.Label1.Text = "UTC Time:";
			// 
			// Spinner
			// 
			this.Spinner.Location = new System.Drawing.Point (353, 48);
			this.Spinner.Name = "Spinner";
			this.Spinner.Size = new System.Drawing.Size (16, 16);
			this.Spinner.TabIndex = 61;
			this.Spinner.TabStop = false;
			this.Spinner.Visible = false;
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
			// 
			// EntityTimeDialog
			// 
			this.AcceptButton = this.CloseButton;
			this.AutoScaleDimensions = new System.Drawing.SizeF (6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.Color.White;
			this.CancelButton = this.CloseButton;
			this.ClientSize = new System.Drawing.Size (380, 162);
			this.Controls.Add (this.CloseButton);
			this.Controls.Add (this.TimeTextBox);
			this.Controls.Add (this.TimeZoneTextBox);
			this.Controls.Add (this.UtcTextBox);
			this.Controls.Add (this.Label3);
			this.Controls.Add (this.Label2);
			this.Controls.Add (this.Label1);
			this.Controls.Add (this.Spinner);
			this.Controls.Add (this.JidLabel);
			this.Name = "EntityTimeDialog";
			this.Text = "Entity Time";
			((System.ComponentModel.ISupportInitialize)(this.Spinner)).EndInit ();
			this.ResumeLayout (false);
			this.PerformLayout ();

		}

		#endregion

		internal System.Windows.Forms.Button CloseButton;
		internal System.Windows.Forms.TextBox TimeTextBox;
		internal System.Windows.Forms.TextBox TimeZoneTextBox;
		internal System.Windows.Forms.TextBox UtcTextBox;
		internal System.Windows.Forms.Label Label3;
		internal System.Windows.Forms.Label Label2;
		internal System.Windows.Forms.Label Label1;
		internal System.Windows.Forms.PictureBox Spinner;
		internal System.Windows.Forms.Label JidLabel;
	}
}