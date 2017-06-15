namespace InformSystema.SIP2.CS
{
	partial class ServerLog
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
			this.textLog = new System.Windows.Forms.RichTextBox();
			this.SuspendLayout();
			// 
			// textLog
			// 
			this.textLog.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.textLog.Location = new System.Drawing.Point(12, 12);
			this.textLog.Name = "textLog";
			this.textLog.Size = new System.Drawing.Size(268, 249);
			this.textLog.TabIndex = 0;
			this.textLog.Text = "";
			// 
			// ServerLog
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(292, 273);
			this.Controls.Add(this.textLog);
			this.Name = "ServerLog";
			this.Text = "Сервер SIP2";
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.RichTextBox textLog;
	}
}