namespace IS.RFID.CS
{
    partial class FieldsFrm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FieldsFrm));
            this.dataGrid = new System.Windows.Forms.DataGridView();
            this.clmnKey = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmnDesc = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmnType = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmnValue = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGrid)).BeginInit();
            this.SuspendLayout();
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
            // button1
            // 
            this.button1.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            resources.ApplyResources(this.button1, "button1");
            this.button1.Name = "button1";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // button2
            // 
            this.button2.DialogResult = System.Windows.Forms.DialogResult.OK;
            resources.ApplyResources(this.button2, "button2");
            this.button2.Name = "button2";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // FieldsFrm
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.dataGrid);
            this.Name = "FieldsFrm";
            ((System.ComponentModel.ISupportInitialize)(this.dataGrid)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGrid;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmnKey;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmnDesc;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmnType;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmnValue;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
    }
}