namespace XmppApplication
{
	partial class ExtensionConfigurationDialog
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
			this.Label5 = new System.Windows.Forms.Label ();
			this.Label6 = new System.Windows.Forms.Label ();
			this.Label3 = new System.Windows.Forms.Label ();
			this.Label4 = new System.Windows.Forms.Label ();
			this.Label2 = new System.Windows.Forms.Label ();
			this.ExtensionList = new System.Windows.Forms.ListView ();
			this.ColumnHeader1 = new System.Windows.Forms.ColumnHeader ();
			this.Label1 = new System.Windows.Forms.Label ();
			this.CloseButton = new System.Windows.Forms.Button ();
			this.Button1 = new System.Windows.Forms.Button ();
			this.SuspendLayout ();
			// 
			// Label5
			// 
			this.Label5.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
				    | System.Windows.Forms.AnchorStyles.Right)));
			this.Label5.Font = new System.Drawing.Font ("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.Label5.Location = new System.Drawing.Point (242, 159);
			this.Label5.Name = "Label5";
			this.Label5.Size = new System.Drawing.Size (314, 41);
			this.Label5.TabIndex = 16;
			this.Label5.Text = "Jonathan Pobst\r\nBob Dole\r\nZack Braff";
			// 
			// Label6
			// 
			this.Label6.AutoSize = true;
			this.Label6.Font = new System.Drawing.Font ("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.Label6.Location = new System.Drawing.Point (242, 140);
			this.Label6.Name = "Label6";
			this.Label6.Size = new System.Drawing.Size (64, 16);
			this.Label6.TabIndex = 15;
			this.Label6.Text = "Author(s)";
			// 
			// Label3
			// 
			this.Label3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
				    | System.Windows.Forms.AnchorStyles.Right)));
			this.Label3.Font = new System.Drawing.Font ("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.Label3.Location = new System.Drawing.Point (242, 72);
			this.Label3.Name = "Label3";
			this.Label3.Size = new System.Drawing.Size (314, 68);
			this.Label3.TabIndex = 14;
			this.Label3.Text = "Adds an action image that links to a buddy\'s webpage.";
			// 
			// Label4
			// 
			this.Label4.AutoSize = true;
			this.Label4.Font = new System.Drawing.Font ("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.Label4.Location = new System.Drawing.Point (242, 53);
			this.Label4.Name = "Label4";
			this.Label4.Size = new System.Drawing.Size (79, 16);
			this.Label4.TabIndex = 13;
			this.Label4.Text = "Description";
			// 
			// Label2
			// 
			this.Label2.AutoSize = true;
			this.Label2.Font = new System.Drawing.Font ("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.Label2.Location = new System.Drawing.Point (242, 30);
			this.Label2.Name = "Label2";
			this.Label2.Size = new System.Drawing.Size (110, 14);
			this.Label2.TabIndex = 12;
			this.Label2.Text = "Webpage Action Icon";
			// 
			// ExtensionList
			// 
			this.ExtensionList.CheckBoxes = true;
			this.ExtensionList.Columns.AddRange (new System.Windows.Forms.ColumnHeader[] {
            this.ColumnHeader1});
			this.ExtensionList.Location = new System.Drawing.Point (12, 11);
			this.ExtensionList.Name = "ExtensionList";
			this.ExtensionList.Size = new System.Drawing.Size (224, 238);
			this.ExtensionList.TabIndex = 10;
			this.ExtensionList.UseCompatibleStateImageBehavior = false;
			this.ExtensionList.View = System.Windows.Forms.View.Details;
			// 
			// ColumnHeader1
			// 
			this.ColumnHeader1.Text = "Available Extensions";
			this.ColumnHeader1.Width = 220;
			// 
			// Label1
			// 
			this.Label1.AutoSize = true;
			this.Label1.Font = new System.Drawing.Font ("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.Label1.Location = new System.Drawing.Point (242, 11);
			this.Label1.Name = "Label1";
			this.Label1.Size = new System.Drawing.Size (90, 16);
			this.Label1.TabIndex = 11;
			this.Label1.Text = "Plugin Name";
			// 
			// CloseButton
			// 
			this.CloseButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.CloseButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.CloseButton.Location = new System.Drawing.Point (481, 221);
			this.CloseButton.Name = "CloseButton";
			this.CloseButton.Size = new System.Drawing.Size (75, 28);
			this.CloseButton.TabIndex = 9;
			this.CloseButton.Text = "Close";
			this.CloseButton.UseVisualStyleBackColor = true;
			this.CloseButton.Click += new System.EventHandler (this.CloseButton_Click);
			// 
			// Button1
			// 
			this.Button1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.Button1.Location = new System.Drawing.Point (242, 219);
			this.Button1.Name = "Button1";
			this.Button1.Size = new System.Drawing.Size (138, 30);
			this.Button1.TabIndex = 17;
			this.Button1.Text = " Configure Extension";
			this.Button1.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
			this.Button1.UseVisualStyleBackColor = true;
			// 
			// ExtensionConfigurationDialog
			// 
			this.AcceptButton = this.CloseButton;
			this.AutoScaleDimensions = new System.Drawing.SizeF (6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.CancelButton = this.CloseButton;
			this.ClientSize = new System.Drawing.Size (568, 260);
			this.Controls.Add (this.Button1);
			this.Controls.Add (this.Label5);
			this.Controls.Add (this.Label6);
			this.Controls.Add (this.Label3);
			this.Controls.Add (this.Label4);
			this.Controls.Add (this.Label2);
			this.Controls.Add (this.ExtensionList);
			this.Controls.Add (this.Label1);
			this.Controls.Add (this.CloseButton);
			this.Name = "ExtensionConfigurationDialog";
			this.Text = "Extension Configuration";
			this.Load += new System.EventHandler (this.ExtensionConfigurationDialog_Load);
			this.ResumeLayout (false);
			this.PerformLayout ();

		}

		#endregion

		internal System.Windows.Forms.Button Button1;
		internal System.Windows.Forms.Label Label5;
		internal System.Windows.Forms.Label Label6;
		internal System.Windows.Forms.Label Label3;
		internal System.Windows.Forms.Label Label4;
		internal System.Windows.Forms.Label Label2;
		internal System.Windows.Forms.ListView ExtensionList;
		internal System.Windows.Forms.ColumnHeader ColumnHeader1;
		internal System.Windows.Forms.Label Label1;
		internal System.Windows.Forms.Button CloseButton;
	}
}