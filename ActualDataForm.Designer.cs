namespace ProjectForecastingApp
{
    partial class ActualDataForm
    {
        private System.ComponentModel.IContainer components = null;

       

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            this.dgvActuals = new System.Windows.Forms.DataGridView();
            this.btnApply = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.panelButtons = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.dgvActuals)).BeginInit();
            this.panelButtons.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgvActuals
            // 
            this.dgvActuals.AllowDrop = true;
            this.dgvActuals.AllowUserToDeleteRows = false;
            this.dgvActuals.AllowUserToResizeColumns = false;
            this.dgvActuals.AllowUserToResizeRows = false;
            this.dgvActuals.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvActuals.Location = new System.Drawing.Point(0, 0);
            this.dgvActuals.Margin = new System.Windows.Forms.Padding(4);
            this.dgvActuals.MultiSelect = false;
            this.dgvActuals.Name = "dgvActuals";
            this.dgvActuals.RowHeadersWidth = 51;
            this.dgvActuals.Size = new System.Drawing.Size(474, 221);
            this.dgvActuals.TabIndex = 0;
            // 
            // btnApply
            // 
            this.btnApply.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnApply.Location = new System.Drawing.Point(587, 10);
            this.btnApply.Margin = new System.Windows.Forms.Padding(4);
            this.btnApply.Name = "btnApply";
            this.btnApply.Size = new System.Drawing.Size(100, 28);
            this.btnApply.TabIndex = 1;
            this.btnApply.Text = "Применить";
            this.btnApply.UseVisualStyleBackColor = true;
            this.btnApply.Click += new System.EventHandler(this.btnApply_Click_1);
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.Location = new System.Drawing.Point(693, 10);
            this.btnCancel.Margin = new System.Windows.Forms.Padding(4);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(100, 28);
            this.btnCancel.TabIndex = 2;
            this.btnCancel.Text = "Отмена";
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // panelButtons
            // 
            this.panelButtons.Controls.Add(this.btnCancel);
            this.panelButtons.Controls.Add(this.btnApply);
            this.panelButtons.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelButtons.Location = new System.Drawing.Point(0, 443);
            this.panelButtons.Margin = new System.Windows.Forms.Padding(4);
            this.panelButtons.Name = "panelButtons";
            this.panelButtons.Size = new System.Drawing.Size(800, 49);
            this.panelButtons.TabIndex = 3;
            // 
            // ActualDataForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 492);
            this.Controls.Add(this.dgvActuals);
            this.Controls.Add(this.panelButtons);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "ActualDataForm";
            this.Text = "Ввод фактических данных";
            ((System.ComponentModel.ISupportInitialize)(this.dgvActuals)).EndInit();
            this.panelButtons.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button btnApply;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Panel panelButtons;
        private System.Windows.Forms.DataGridView dgvActuals;
    }
}
