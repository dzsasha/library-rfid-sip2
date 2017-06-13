using System.Windows.Forms;

namespace Marc.CS
{
	partial class ModelCtrl
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ModelCtrl));
			this.clmnKey = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.clmnDesc = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.clmnType = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.clmnValue = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.btnRead = new System.Windows.Forms.Button();
			this.btnWrite = new System.Windows.Forms.Button();
			this.label1 = new System.Windows.Forms.Label();
			this.cbType = new System.Windows.Forms.ComboBox();
			this.dataGrid = new System.Windows.Forms.DataGridView();
			((System.ComponentModel.ISupportInitialize)(this.dataGrid)).BeginInit();
			this.SuspendLayout();
			// 
			// clmnKey
			// 
			this.clmnKey.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
			this.clmnKey.DataPropertyName = "Name";
			resources.ApplyResources(this.clmnKey, "clmnKey");
			this.clmnKey.Name = "clmnKey";
			this.clmnKey.ReadOnly = true;
			// 
			// clmnDesc
			// 
			this.clmnDesc.DataPropertyName = "Description";
			resources.ApplyResources(this.clmnDesc, "clmnDesc");
			this.clmnDesc.Name = "clmnDesc";
			// 
			// clmnType
			// 
			this.clmnType.DataPropertyName = "Model";
			resources.ApplyResources(this.clmnType, "clmnType");
			this.clmnType.Name = "clmnType";
			// 
			// clmnValue
			// 
			this.clmnValue.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
			this.clmnValue.DataPropertyName = "Value";
			resources.ApplyResources(this.clmnValue, "clmnValue");
			this.clmnValue.Name = "clmnValue";
			// 
			// btnRead
			// 
			resources.ApplyResources(this.btnRead, "btnRead");
			this.btnRead.Name = "btnRead";
			this.btnRead.UseVisualStyleBackColor = true;
			this.btnRead.Click += new System.EventHandler(this.btnRead_Click);
			// 
			// btnWrite
			// 
			resources.ApplyResources(this.btnWrite, "btnWrite");
			this.btnWrite.Name = "btnWrite";
			this.btnWrite.UseVisualStyleBackColor = true;
			this.btnWrite.Click += new System.EventHandler(this.btnWrite_Click);
			// 
			// label1
			// 
			resources.ApplyResources(this.label1, "label1");
			this.label1.Name = "label1";
			// 
			// cbType
			// 
			resources.ApplyResources(this.cbType, "cbType");
			this.cbType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cbType.FormattingEnabled = true;
			this.cbType.Name = "cbType";
			this.cbType.SelectedIndexChanged += new System.EventHandler(this.cbType_SelectedIndexChanged);
			// 
			// dataGrid
			// 
			this.dataGrid.AllowUserToAddRows = false;
			this.dataGrid.AllowUserToDeleteRows = false;
			this.dataGrid.AllowUserToResizeRows = false;
			resources.ApplyResources(this.dataGrid, "dataGrid");
			this.dataGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dataGrid.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.clmnKey,
            this.clmnDesc,
            this.clmnType,
            this.clmnValue});
			this.dataGrid.MultiSelect = false;
			this.dataGrid.Name = "dataGrid";
			this.dataGrid.RowHeadersVisible = false;
			this.dataGrid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
			// 
			// ModelCtrl
			// 
			resources.ApplyResources(this, "$this");
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.Controls.Add(this.label1);
			this.Controls.Add(this.cbType);
			this.Controls.Add(this.btnWrite);
			this.Controls.Add(this.btnRead);
			this.Controls.Add(this.dataGrid);
			this.Name = "ModelCtrl";
			((System.ComponentModel.ISupportInitialize)(this.dataGrid)).EndInit();
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.DataGridViewTextBoxColumn clmnKey;
		private System.Windows.Forms.DataGridViewTextBoxColumn clmnDesc;
		private System.Windows.Forms.DataGridViewTextBoxColumn clmnType;
		private System.Windows.Forms.DataGridViewTextBoxColumn clmnValue;
		private System.Windows.Forms.Button btnRead;
		private System.Windows.Forms.Button btnWrite;
		private Label label1;
		private ComboBox cbType;
		private DataGridView dataGrid;

	}
}
