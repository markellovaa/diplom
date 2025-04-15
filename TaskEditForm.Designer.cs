using System;

namespace ProjectForecastingApp
{
    partial class TaskEditForm
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
            this.txtName = new System.Windows.Forms.TextBox();
            this.lblName = new System.Windows.Forms.Label();
            this.lblOptimistic = new System.Windows.Forms.Label();
            this.nudOptimistic = new System.Windows.Forms.NumericUpDown();
            this.lblLikely = new System.Windows.Forms.Label();
            this.nudLikely = new System.Windows.Forms.NumericUpDown();
            this.lblPessimistic = new System.Windows.Forms.Label();
            this.nudPessimistic = new System.Windows.Forms.NumericUpDown();
            this.rbTriangular = new System.Windows.Forms.RadioButton();
            this.rbNormal = new System.Windows.Forms.RadioButton();
            this.lblStdDev = new System.Windows.Forms.Label();
            this.nudStdDev = new System.Windows.Forms.NumericUpDown();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.panelDistribution = new System.Windows.Forms.Panel();
            this.panelButtons = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.nudOptimistic)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudLikely)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudPessimistic)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudStdDev)).BeginInit();
            this.tableLayoutPanel1.SuspendLayout();
            this.panelDistribution.SuspendLayout();
            this.panelButtons.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtName
            // 
            this.txtName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtName.Location = new System.Drawing.Point(3, 23);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(378, 20);
            this.txtName.TabIndex = 0;
            // 
            // lblName
            // 
            this.lblName.AutoSize = true;
            this.lblName.Location = new System.Drawing.Point(3, 0);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(86, 13);
            this.lblName.TabIndex = 1;
            this.lblName.Text = "Название задачи:";
            // 
            // lblOptimistic
            // 
            this.lblOptimistic.AutoSize = true;
            this.lblOptimistic.Location = new System.Drawing.Point(3, 50);
            this.lblOptimistic.Name = "lblOptimistic";
            this.lblOptimistic.Size = new System.Drawing.Size(150, 13);
            this.lblOptimistic.TabIndex = 2;
            this.lblOptimistic.Text = "Оптимистичная оценка (дн):";
            // 
            // nudOptimistic
            // 
            this.nudOptimistic.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.nudOptimistic.Location = new System.Drawing.Point(3, 73);
            this.nudOptimistic.Maximum = new decimal(new int[] {
            365,
            0,
            0,
            0});
            this.nudOptimistic.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudOptimistic.Name = "nudOptimistic";
            this.nudOptimistic.Size = new System.Drawing.Size(378, 20);
            this.nudOptimistic.TabIndex = 1;
            this.nudOptimistic.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // lblLikely
            // 
            this.lblLikely.AutoSize = true;
            this.lblLikely.Location = new System.Drawing.Point(3, 100);
            this.lblLikely.Name = "lblLikely";
            this.lblLikely.Size = new System.Drawing.Size(119, 13);
            this.lblLikely.TabIndex = 4;
            this.lblLikely.Text = "Наиболее вероятная (дн):";
            // 
            // nudLikely
            // 
            this.nudLikely.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.nudLikely.Location = new System.Drawing.Point(3, 123);
            this.nudLikely.Maximum = new decimal(new int[] {
            365,
            0,
            0,
            0});
            this.nudLikely.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudLikely.Name = "nudLikely";
            this.nudLikely.Size = new System.Drawing.Size(378, 20);
            this.nudLikely.TabIndex = 2;
            this.nudLikely.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // lblPessimistic
            // 
            this.lblPessimistic.AutoSize = true;
            this.lblPessimistic.Location = new System.Drawing.Point(3, 150);
            this.lblPessimistic.Name = "lblPessimistic";
            this.lblPessimistic.Size = new System.Drawing.Size(141, 13);
            this.lblPessimistic.TabIndex = 6;
            this.lblPessimistic.Text = "Пессимистичная оценка (дн):";
            // 
            // nudPessimistic
            // 
            this.nudPessimistic.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.nudPessimistic.Location = new System.Drawing.Point(3, 173);
            this.nudPessimistic.Maximum = new decimal(new int[] {
            365,
            0,
            0,
            0});
            this.nudPessimistic.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudPessimistic.Name = "nudPessimistic";
            this.nudPessimistic.Size = new System.Drawing.Size(378, 20);
            this.nudPessimistic.TabIndex = 3;
            this.nudPessimistic.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // rbTriangular
            // 
            this.rbTriangular.AutoSize = true;
            this.rbTriangular.Checked = true;
            this.rbTriangular.Location = new System.Drawing.Point(3, 3);
            this.rbTriangular.Name = "rbTriangular";
            this.rbTriangular.Size = new System.Drawing.Size(152, 17);
            this.rbTriangular.TabIndex = 0;
            this.rbTriangular.TabStop = true;
            this.rbTriangular.Text = "Треугольное распределение";
            this.rbTriangular.UseVisualStyleBackColor = true;
            // 
            // rbNormal
            // 
            this.rbNormal.AutoSize = true;
            this.rbNormal.Location = new System.Drawing.Point(3, 26);
            this.rbNormal.Name = "rbNormal";
            this.rbNormal.Size = new System.Drawing.Size(142, 17);
            this.rbNormal.TabIndex = 1;
            this.rbNormal.Text = "Нормальное распределение";
            this.rbNormal.UseVisualStyleBackColor = true;
            // 
            // lblStdDev
            // 
            this.lblStdDev.AutoSize = true;
            this.lblStdDev.Location = new System.Drawing.Point(3, 200);
            this.lblStdDev.Name = "lblStdDev";
            this.lblStdDev.Size = new System.Drawing.Size(118, 13);
            this.lblStdDev.TabIndex = 9;
            this.lblStdDev.Text = "Стандартное отклонение:";
            // 
            // nudStdDev
            // 
            this.nudStdDev.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.nudStdDev.DecimalPlaces = 1;
            this.nudStdDev.Increment = new decimal(new int[] {
            5,
            0,
            0,
            65536});
            this.nudStdDev.Location = new System.Drawing.Point(3, 223);
            this.nudStdDev.Maximum = new decimal(new int[] {
            50,
            0,
            0,
            0});
            this.nudStdDev.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.nudStdDev.Name = "nudStdDev";
            this.nudStdDev.Size = new System.Drawing.Size(378, 20);
            this.nudStdDev.TabIndex = 5;
            this.nudStdDev.Value = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            // 
            // btnSave
            // 
            this.btnSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSave.Location = new System.Drawing.Point(226, 10);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 0;
            this.btnSave.Text = "Сохранить";
            this.btnSave.UseVisualStyleBackColor = true;
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(307, 10);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 1;
            this.btnCancel.Text = "Отмена";
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.lblName, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.txtName, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.lblOptimistic, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.nudOptimistic, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.lblLikely, 0, 4);
            this.tableLayoutPanel1.Controls.Add(this.nudLikely, 0, 5);
            this.tableLayoutPanel1.Controls.Add(this.lblPessimistic, 0, 6);
            this.tableLayoutPanel1.Controls.Add(this.nudPessimistic, 0, 7);
            this.tableLayoutPanel1.Controls.Add(this.panelDistribution, 0, 8);
            this.tableLayoutPanel1.Controls.Add(this.lblStdDev, 0, 9);
            this.tableLayoutPanel1.Controls.Add(this.nudStdDev, 0, 10);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 11;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 60F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(384, 293);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // panelDistribution
            // 
            this.panelDistribution.Controls.Add(this.rbTriangular);
            this.panelDistribution.Controls.Add(this.rbNormal);
            this.panelDistribution.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelDistribution.Location = new System.Drawing.Point(3, 203);
            this.panelDistribution.Name = "panelDistribution";
            this.panelDistribution.Size = new System.Drawing.Size(378, 54);
            this.panelDistribution.TabIndex = 4;
            // 
            // panelButtons
            // 
            this.panelButtons.Controls.Add(this.btnCancel);
            this.panelButtons.Controls.Add(this.btnSave);
            this.panelButtons.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelButtons.Location = new System.Drawing.Point(0, 293);
            this.panelButtons.Name = "panelButtons";
            this.panelButtons.Size = new System.Drawing.Size(384, 45);
            this.panelButtons.TabIndex = 1;
            // 
            // TaskEditForm
            // 
            this.AcceptButton = this.btnSave;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(384, 338);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.panelButtons);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(400, 377);
            this.Name = "TaskEditForm";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Добавление задачи";
            ((System.ComponentModel.ISupportInitialize)(this.nudOptimistic)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudLikely)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudPessimistic)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudStdDev)).EndInit();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.panelDistribution.ResumeLayout(false);
            this.panelDistribution.PerformLayout();
            this.panelButtons.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.Label lblOptimistic;
        private System.Windows.Forms.NumericUpDown nudOptimistic;
        private System.Windows.Forms.Label lblLikely;
        private System.Windows.Forms.NumericUpDown nudLikely;
        private System.Windows.Forms.Label lblPessimistic;
        private System.Windows.Forms.NumericUpDown nudPessimistic;
        private System.Windows.Forms.RadioButton rbTriangular;
        private System.Windows.Forms.RadioButton rbNormal;
        private System.Windows.Forms.Label lblStdDev;
        private System.Windows.Forms.NumericUpDown nudStdDev;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Panel panelDistribution;
        private System.Windows.Forms.Panel panelButtons;
    }
}