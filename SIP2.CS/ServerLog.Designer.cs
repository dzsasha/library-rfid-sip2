namespace IS.SIP2.CS
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
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.tabControl = new System.Windows.Forms.TabControl();
            this.tabPageLog = new System.Windows.Forms.TabPage();
            this.textLog = new System.Windows.Forms.RichTextBox();
            this.tabPageConfig = new System.Windows.Forms.TabPage();
            this.checkDebug = new System.Windows.Forms.CheckBox();
            this.label5 = new System.Windows.Forms.Label();
            this.textAddress = new System.Windows.Forms.MaskedTextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.numericMax = new System.Windows.Forms.NumericUpDown();
            this.label3 = new System.Windows.Forms.Label();
            this.comboProto = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.numericPort = new System.Windows.Forms.NumericUpDown();
            this.textObject = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.tabControl.SuspendLayout();
            this.tabPageLog.SuspendLayout();
            this.tabPageConfig.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericMax)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericPort)).BeginInit();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.button1.Location = new System.Drawing.Point(12, 230);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 1;
            this.button1.Text = "Start";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.button2.Location = new System.Drawing.Point(93, 230);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 2;
            this.button2.Text = "Stop";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button3
            // 
            this.button3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.button3.Location = new System.Drawing.Point(174, 230);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(75, 23);
            this.button3.TabIndex = 3;
            this.button3.Text = "Close";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // tabControl
            // 
            this.tabControl.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl.Controls.Add(this.tabPageLog);
            this.tabControl.Controls.Add(this.tabPageConfig);
            this.tabControl.Location = new System.Drawing.Point(12, 12);
            this.tabControl.Name = "tabControl";
            this.tabControl.SelectedIndex = 0;
            this.tabControl.Size = new System.Drawing.Size(237, 212);
            this.tabControl.TabIndex = 4;
            // 
            // tabPageLog
            // 
            this.tabPageLog.Controls.Add(this.textLog);
            this.tabPageLog.Location = new System.Drawing.Point(4, 22);
            this.tabPageLog.Name = "tabPageLog";
            this.tabPageLog.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageLog.Size = new System.Drawing.Size(229, 186);
            this.tabPageLog.TabIndex = 0;
            this.tabPageLog.Text = "Log";
            this.tabPageLog.UseVisualStyleBackColor = true;
            // 
            // textLog
            // 
            this.textLog.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textLog.Font = new System.Drawing.Font("Lucida Console", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textLog.Location = new System.Drawing.Point(6, 6);
            this.textLog.Name = "textLog";
            this.textLog.ReadOnly = true;
            this.textLog.Size = new System.Drawing.Size(217, 174);
            this.textLog.TabIndex = 1;
            this.textLog.Text = "";
            // 
            // tabPageConfig
            // 
            this.tabPageConfig.AutoScroll = true;
            this.tabPageConfig.Controls.Add(this.checkDebug);
            this.tabPageConfig.Controls.Add(this.label5);
            this.tabPageConfig.Controls.Add(this.textAddress);
            this.tabPageConfig.Controls.Add(this.label4);
            this.tabPageConfig.Controls.Add(this.numericMax);
            this.tabPageConfig.Controls.Add(this.label3);
            this.tabPageConfig.Controls.Add(this.comboProto);
            this.tabPageConfig.Controls.Add(this.label2);
            this.tabPageConfig.Controls.Add(this.numericPort);
            this.tabPageConfig.Controls.Add(this.textObject);
            this.tabPageConfig.Controls.Add(this.label1);
            this.tabPageConfig.Location = new System.Drawing.Point(4, 22);
            this.tabPageConfig.Name = "tabPageConfig";
            this.tabPageConfig.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageConfig.Size = new System.Drawing.Size(229, 186);
            this.tabPageConfig.TabIndex = 1;
            this.tabPageConfig.Text = "Config";
            this.tabPageConfig.UseVisualStyleBackColor = true;
            // 
            // checkDebug
            // 
            this.checkDebug.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.checkDebug.AutoSize = true;
            this.checkDebug.Location = new System.Drawing.Point(77, 139);
            this.checkDebug.Name = "checkDebug";
            this.checkDebug.Size = new System.Drawing.Size(58, 17);
            this.checkDebug.TabIndex = 12;
            this.checkDebug.Text = "Debug";
            this.checkDebug.UseVisualStyleBackColor = true;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(6, 36);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(76, 13);
            this.label5.TabIndex = 2;
            this.label5.Text = "Listen Address";
            // 
            // textAddress
            // 
            this.textAddress.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textAddress.Location = new System.Drawing.Point(88, 33);
            this.textAddress.Mask = "###.###.###.###";
            this.textAddress.Name = "textAddress";
            this.textAddress.Size = new System.Drawing.Size(135, 20);
            this.textAddress.TabIndex = 3;
            this.textAddress.TextMaskFormat = System.Windows.Forms.MaskFormat.ExcludePromptAndLiterals;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 115);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(60, 13);
            this.label4.TabIndex = 8;
            this.label4.Text = "Max clients";
            // 
            // numericMax
            // 
            this.numericMax.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.numericMax.Location = new System.Drawing.Point(88, 113);
            this.numericMax.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericMax.Name = "numericMax";
            this.numericMax.Size = new System.Drawing.Size(135, 20);
            this.numericMax.TabIndex = 9;
            this.numericMax.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 88);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(46, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "Protocol";
            // 
            // comboProto
            // 
            this.comboProto.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.comboProto.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboProto.FormattingEnabled = true;
            this.comboProto.Location = new System.Drawing.Point(88, 85);
            this.comboProto.Name = "comboProto";
            this.comboProto.Size = new System.Drawing.Size(135, 21);
            this.comboProto.TabIndex = 7;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 59);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(38, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "IP-port";
            // 
            // numericPort
            // 
            this.numericPort.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.numericPort.Location = new System.Drawing.Point(88, 59);
            this.numericPort.Maximum = new decimal(new int[] {
            65535,
            0,
            0,
            0});
            this.numericPort.Minimum = new decimal(new int[] {
            1024,
            0,
            0,
            0});
            this.numericPort.Name = "numericPort";
            this.numericPort.Size = new System.Drawing.Size(135, 20);
            this.numericPort.TabIndex = 5;
            this.numericPort.Value = new decimal(new int[] {
            1024,
            0,
            0,
            0});
            // 
            // textObject
            // 
            this.textObject.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textObject.Location = new System.Drawing.Point(88, 6);
            this.textObject.Name = "textObject";
            this.textObject.Size = new System.Drawing.Size(135, 20);
            this.textObject.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(63, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "COM-server";
            // 
            // ServerLog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(260, 265);
            this.Controls.Add(this.tabControl);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.MinimumSize = new System.Drawing.Size(268, 292);
            this.Name = "ServerLog";
            this.Text = "Server SIP2";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.ServerLog_FormClosed);
            this.tabControl.ResumeLayout(false);
            this.tabPageLog.ResumeLayout(false);
            this.tabPageConfig.ResumeLayout(false);
            this.tabPageConfig.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericMax)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericPort)).EndInit();
            this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.Button button1;
		private System.Windows.Forms.Button button2;
		private System.Windows.Forms.Button button3;
		private System.Windows.Forms.TabControl tabControl;
		private System.Windows.Forms.TabPage tabPageLog;
		private System.Windows.Forms.TabPage tabPageConfig;
		private System.Windows.Forms.RichTextBox textLog;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.NumericUpDown numericPort;
		private System.Windows.Forms.TextBox textObject;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.NumericUpDown numericMax;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.ComboBox comboProto;
		private System.Windows.Forms.MaskedTextBox textAddress;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.CheckBox checkDebug;
	}
}