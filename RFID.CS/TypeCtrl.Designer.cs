namespace InformSystema.RFID.CS
{
	partial class TypeCtrl
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

		#region Component Designer generated code

		/// <summary> 
		/// Required method for Designer support - do not modify 
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.components = new System.ComponentModel.Container();
			this.cbId = new System.Windows.Forms.ComboBox();
			this.label1 = new System.Windows.Forms.Label();
			this.splitCont = new System.Windows.Forms.SplitContainer();
			this.lbTypes = new System.Windows.Forms.ListBox();
			this.button1 = new System.Windows.Forms.Button();
			this.button2 = new System.Windows.Forms.Button();
			this.contextMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
			((System.ComponentModel.ISupportInitialize)(this.splitCont)).BeginInit();
			this.splitCont.Panel1.SuspendLayout();
			this.splitCont.SuspendLayout();
			this.SuspendLayout();
			// 
			// cbId
			// 
			this.cbId.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.cbId.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cbId.FormattingEnabled = true;
			this.cbId.Location = new System.Drawing.Point(96, 3);
			this.cbId.Name = "cbId";
			this.cbId.Size = new System.Drawing.Size(151, 21);
			this.cbId.TabIndex = 0;
			this.cbId.SelectedIndexChanged += new System.EventHandler(this.cbId_SelectedIndexChanged);
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(3, 6);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(87, 13);
			this.label1.TabIndex = 1;
			this.label1.Text = "Идентификатор";
			// 
			// splitCont
			// 
			this.splitCont.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.splitCont.Location = new System.Drawing.Point(6, 30);
			this.splitCont.Name = "splitCont";
			// 
			// splitCont.Panel1
			// 
			this.splitCont.Panel1.Controls.Add(this.button2);
			this.splitCont.Panel1.Controls.Add(this.lbTypes);
			this.splitCont.Size = new System.Drawing.Size(314, 195);
			this.splitCont.SplitterDistance = 104;
			this.splitCont.TabIndex = 2;
			// 
			// lbTypes
			// 
			this.lbTypes.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.lbTypes.FormattingEnabled = true;
			this.lbTypes.Location = new System.Drawing.Point(3, 3);
			this.lbTypes.Name = "lbTypes";
			this.lbTypes.Size = new System.Drawing.Size(98, 160);
			this.lbTypes.TabIndex = 0;
			this.lbTypes.SelectedIndexChanged += new System.EventHandler(this.lbTypes_SelectedIndexChanged);
			// 
			// button1
			// 
			this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.button1.Location = new System.Drawing.Point(253, 3);
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size(67, 23);
			this.button1.TabIndex = 3;
			this.button1.Text = "&Обновить";
			this.button1.UseVisualStyleBackColor = true;
			this.button1.Click += new System.EventHandler(this.button1_Click);
			// 
			// button2
			// 
			this.button2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.button2.Location = new System.Drawing.Point(3, 169);
			this.button2.Name = "button2";
			this.button2.Size = new System.Drawing.Size(98, 23);
			this.button2.TabIndex = 1;
			this.button2.Text = "&Добавить";
			this.button2.UseVisualStyleBackColor = true;
			this.button2.Click += new System.EventHandler(this.button2_Click);
			// 
			// contextMenu
			// 
			this.contextMenu.Name = "contextMenu";
			this.contextMenu.Size = new System.Drawing.Size(61, 4);
			// 
			// TypeCtrl
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.Controls.Add(this.button1);
			this.Controls.Add(this.splitCont);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.cbId);
			this.Name = "TypeCtrl";
			this.Size = new System.Drawing.Size(323, 228);
			this.splitCont.Panel1.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.splitCont)).EndInit();
			this.splitCont.ResumeLayout(false);
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.ComboBox cbId;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.SplitContainer splitCont;
		private System.Windows.Forms.ListBox lbTypes;
		private System.Windows.Forms.Button button1;
		private System.Windows.Forms.Button button2;
		private System.Windows.Forms.ContextMenuStrip contextMenu;


	}
}
