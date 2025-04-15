using System.Windows.Forms;

namespace ProjectForecastingApp
{
    partial class Main
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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.dgvTasks = new System.Windows.Forms.DataGridView();
            this.dgvRisks = new System.Windows.Forms.DataGridView();
            this.btnLoadDemoData = new System.Windows.Forms.Button();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.chart1 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.dgvRiskAnalysis = new System.Windows.Forms.DataGridView();
            this.txtSummary = new System.Windows.Forms.TextBox();
            this.tabPage4 = new System.Windows.Forms.TabPage();
            this.dgvBayesian = new System.Windows.Forms.DataGridView();
            this.bayesianChart = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.txtBayesianSummary = new System.Windows.Forms.TextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnImportFromExcel = new System.Windows.Forms.Button();
            this.btnExportToExcel = new System.Windows.Forms.Button();
            this.btnBayesianSettings = new System.Windows.Forms.Button();
            this.nudIterations = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.btnRunForecast = new System.Windows.Forms.Button();
            this.btnAddTask = new System.Windows.Forms.Button();
            this.btnAddRisk = new System.Windows.Forms.Button();
            this.btnAddActuals = new System.Windows.Forms.Button();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.lblStatus = new System.Windows.Forms.Label();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTasks)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvRisks)).BeginInit();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).BeginInit();
            this.tabPage3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvRiskAnalysis)).BeginInit();
            this.tabPage4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvBayesian)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bayesianChart)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudIterations)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvTasks
            // 
            this.dgvTasks.AllowUserToAddRows = true;
            this.dgvTasks.AllowUserToDeleteRows = true;
            this.dgvTasks.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvTasks.BackgroundColor = System.Drawing.SystemColors.Window;
            this.dgvTasks.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvTasks.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvTasks.Location = new System.Drawing.Point(0, 0);
            this.dgvTasks.Margin = new System.Windows.Forms.Padding(4);
            this.dgvTasks.Name = "dgvTasks";
            this.dgvTasks.RowHeadersWidth = 51;
            this.dgvTasks.Size = new System.Drawing.Size(1163, 309);
            this.dgvTasks.TabIndex = 0;
            this.dgvTasks.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.DgvTasks_CellEndEdit);
            this.dgvTasks.DataError += new System.Windows.Forms.DataGridViewDataErrorEventHandler(this.DgvTasks_DataError);
            // 
            // dgvRisks
            // 
            this.dgvRisks.AllowUserToAddRows = true;
            this.dgvRisks.AllowUserToDeleteRows = true;
            this.dgvRisks.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvRisks.BackgroundColor = System.Drawing.SystemColors.Window;
            this.dgvRisks.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvRisks.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvRisks.Location = new System.Drawing.Point(0, 0);
            this.dgvRisks.Margin = new System.Windows.Forms.Padding(4);
            this.dgvRisks.Name = "dgvRisks";
            this.dgvRisks.RowHeadersWidth = 51;
            this.dgvRisks.Size = new System.Drawing.Size(1163, 340);
            this.dgvRisks.TabIndex = 0;
            this.dgvRisks.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.DgvRisks_CellEndEdit);
            this.dgvRisks.DataError += new System.Windows.Forms.DataGridViewDataErrorEventHandler(this.DgvRisks_DataError);
            // 
            // btnLoadDemoData
            // 
            this.btnLoadDemoData.Location = new System.Drawing.Point(533, 12);
            this.btnLoadDemoData.Margin = new System.Windows.Forms.Padding(4);
            this.btnLoadDemoData.Name = "btnLoadDemoData";
            this.btnLoadDemoData.Size = new System.Drawing.Size(200, 37);
            this.btnLoadDemoData.TabIndex = 8;
            this.btnLoadDemoData.Text = "Загрузить демо-данные";
            this.btnLoadDemoData.UseVisualStyleBackColor = true;
            this.btnLoadDemoData.Click += new System.EventHandler(this.BtnLoadDemoData_Click);
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Controls.Add(this.tabPage4);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Margin = new System.Windows.Forms.Padding(4);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1179, 691);
            this.tabControl1.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.splitContainer1);
            this.tabPage1.Location = new System.Drawing.Point(4, 25);
            this.tabPage1.Margin = new System.Windows.Forms.Padding(4);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(4);
            this.tabPage1.Size = new System.Drawing.Size(1171, 662);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Данные проекта";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(4, 4);
            this.splitContainer1.Margin = new System.Windows.Forms.Padding(4);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.dgvTasks);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.dgvRisks);
            this.splitContainer1.Size = new System.Drawing.Size(1163, 654);
            this.splitContainer1.SplitterDistance = 309;
            this.splitContainer1.SplitterWidth = 5;
            this.splitContainer1.TabIndex = 0;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.chart1);
            this.tabPage2.Location = new System.Drawing.Point(4, 25);
            this.tabPage2.Margin = new System.Windows.Forms.Padding(4);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(4);
            this.tabPage2.Size = new System.Drawing.Size(1171, 661);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Прогноз";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // chart1
            // 
            chartArea1.Name = "MainArea";
            this.chart1.ChartAreas.Add(chartArea1);
            this.chart1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.chart1.Location = new System.Drawing.Point(4, 4);
            this.chart1.Margin = new System.Windows.Forms.Padding(4);
            this.chart1.Name = "chart1";
            series1.ChartArea = "MainArea";
            series1.Name = "DurationDistribution";
            this.chart1.Series.Add(series1);
            this.chart1.Size = new System.Drawing.Size(1163, 653);
            this.chart1.TabIndex = 0;
            this.chart1.Text = "chart1";
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.dgvRiskAnalysis);
            this.tabPage3.Controls.Add(this.txtSummary);
            this.tabPage3.Location = new System.Drawing.Point(4, 25);
            this.tabPage3.Margin = new System.Windows.Forms.Padding(4);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Size = new System.Drawing.Size(1171, 661);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "Анализ";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // dgvRiskAnalysis
            // 
            this.dgvRiskAnalysis.AllowUserToAddRows = false;
            this.dgvRiskAnalysis.AllowUserToDeleteRows = false;
            this.dgvRiskAnalysis.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvRiskAnalysis.BackgroundColor = System.Drawing.SystemColors.Window;
            this.dgvRiskAnalysis.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvRiskAnalysis.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvRiskAnalysis.Location = new System.Drawing.Point(0, 0);
            this.dgvRiskAnalysis.Margin = new System.Windows.Forms.Padding(4);
            this.dgvRiskAnalysis.Name = "dgvRiskAnalysis";
            this.dgvRiskAnalysis.ReadOnly = true;
            this.dgvRiskAnalysis.RowHeadersWidth = 51;
            this.dgvRiskAnalysis.Size = new System.Drawing.Size(1171, 496);
            this.dgvRiskAnalysis.TabIndex = 0;
            // 
            // txtSummary
            // 
            this.txtSummary.BackColor = System.Drawing.SystemColors.Window;
            this.txtSummary.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.txtSummary.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.txtSummary.Location = new System.Drawing.Point(0, 496);
            this.txtSummary.Margin = new System.Windows.Forms.Padding(4);
            this.txtSummary.Multiline = true;
            this.txtSummary.Name = "txtSummary";
            this.txtSummary.ReadOnly = true;
            this.txtSummary.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtSummary.Size = new System.Drawing.Size(1171, 165);
            this.txtSummary.TabIndex = 1;
            // 
            // tabPage4
            // 
            this.tabPage4.Controls.Add(this.bayesianChart);
            this.tabPage4.Controls.Add(this.dgvBayesian);
            this.tabPage4.Controls.Add(this.txtBayesianSummary);
            this.tabPage4.Location = new System.Drawing.Point(4, 25);
            this.tabPage4.Name = "tabPage4";
            this.tabPage4.Size = new System.Drawing.Size(1171, 661);
            this.tabPage4.TabIndex = 3;
            this.tabPage4.Text = "Байесовский анализ";
            this.tabPage4.UseVisualStyleBackColor = true;
            // 
            // dgvBayesian
            // 
            this.dgvBayesian.AllowUserToAddRows = false;
            this.dgvBayesian.AllowUserToDeleteRows = false;
            this.dgvBayesian.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvBayesian.BackgroundColor = System.Drawing.SystemColors.Window;
            this.dgvBayesian.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvBayesian.Dock = System.Windows.Forms.DockStyle.Top;
            this.dgvBayesian.Location = new System.Drawing.Point(0, 0);
            this.dgvBayesian.Name = "dgvBayesian";
            this.dgvBayesian.ReadOnly = true;
            this.dgvBayesian.RowHeadersWidth = 51;
            this.dgvBayesian.Size = new System.Drawing.Size(1171, 200);
            this.dgvBayesian.TabIndex = 0;
            // 
            // bayesianChart
            // 
            this.bayesianChart.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.bayesianChart.Location = new System.Drawing.Point(0, 200);
            this.bayesianChart.Name = "bayesianChart";
            this.bayesianChart.Size = new System.Drawing.Size(1171, 300);
            this.bayesianChart.TabIndex = 2;
            this.bayesianChart.Text = "chart2";
            // 
            // txtBayesianSummary
            // 
            this.txtBayesianSummary.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.txtBayesianSummary.Location = new System.Drawing.Point(0, 500);
            this.txtBayesianSummary.Multiline = true;
            this.txtBayesianSummary.Name = "txtBayesianSummary";
            this.txtBayesianSummary.ReadOnly = true;
            this.txtBayesianSummary.Size = new System.Drawing.Size(1171, 161);
            this.txtBayesianSummary.TabIndex = 1;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btnBayesianSettings);
            this.panel1.Controls.Add(this.btnImportFromExcel);
            this.panel1.Controls.Add(this.btnExportToExcel);
            this.panel1.Controls.Add(this.btnLoadDemoData);
            this.panel1.Controls.Add(this.nudIterations);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.btnRunForecast);
            this.panel1.Controls.Add(this.btnAddTask);
            this.panel1.Controls.Add(this.btnAddRisk);
            this.panel1.Controls.Add(this.btnAddActuals);
            this.panel1.Controls.Add(this.progressBar1);
            this.panel1.Controls.Add(this.lblStatus);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 691);
            this.panel1.Margin = new System.Windows.Forms.Padding(4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1179, 123);
            this.panel1.TabIndex = 1;
            // 
            // btnImportFromExcel
            // 
            this.btnImportFromExcel.Location = new System.Drawing.Point(533, 62);
            this.btnImportFromExcel.Margin = new System.Windows.Forms.Padding(4);
            this.btnImportFromExcel.Name = "btnImportFromExcel";
            this.btnImportFromExcel.Size = new System.Drawing.Size(200, 37);
            this.btnImportFromExcel.TabIndex = 12;
            this.btnImportFromExcel.Text = "Импорт из Excel";
            this.btnImportFromExcel.UseVisualStyleBackColor = true;
            this.btnImportFromExcel.Click += new System.EventHandler(this.ImportFromExcel_Click);
            // 
            // btnExportToExcel
            // 
            this.btnExportToExcel.Location = new System.Drawing.Point(741, 62);
            this.btnExportToExcel.Margin = new System.Windows.Forms.Padding(4);
            this.btnExportToExcel.Name = "btnExportToExcel";
            this.btnExportToExcel.Size = new System.Drawing.Size(177, 37);
            this.btnExportToExcel.TabIndex = 11;
            this.btnExportToExcel.Text = "Экспорт в Excel";
            this.btnExportToExcel.UseVisualStyleBackColor = true;
            this.btnExportToExcel.Click += new System.EventHandler(this.ExportToExcel_Click);
            // 
            // btnBayesianSettings
            // 
            this.btnBayesianSettings.Location = new System.Drawing.Point(741, 12);
            this.btnBayesianSettings.Margin = new System.Windows.Forms.Padding(4);
            this.btnBayesianSettings.Name = "btnBayesianSettings";
            this.btnBayesianSettings.Size = new System.Drawing.Size(177, 37);
            this.btnBayesianSettings.TabIndex = 13;
            this.btnBayesianSettings.Text = "Настройки Байеса";
            this.btnBayesianSettings.UseVisualStyleBackColor = true;
            this.btnBayesianSettings.Click += new System.EventHandler(this.BtnBayesianSettings_Click);
            // 
            // nudIterations
            // 
            this.nudIterations.Location = new System.Drawing.Point(933, 18);
            this.nudIterations.Margin = new System.Windows.Forms.Padding(4);
            this.nudIterations.Maximum = new decimal(new int[] {
            100000,
            0,
            0,
            0});
            this.nudIterations.Minimum = new decimal(new int[] {
            100,
            0,
            0,
            0});
            this.nudIterations.Name = "nudIterations";
            this.nudIterations.Size = new System.Drawing.Size(160, 22);
            this.nudIterations.TabIndex = 7;
            this.nudIterations.Value = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(800, 21);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(116, 16);
            this.label1.TabIndex = 6;
            this.label1.Text = "Число итераций:";
            // 
            // btnRunForecast
            // 
            this.btnRunForecast.Location = new System.Drawing.Point(926, 62);
            this.btnRunForecast.Margin = new System.Windows.Forms.Padding(4);
            this.btnRunForecast.Name = "btnRunForecast";
            this.btnRunForecast.Size = new System.Drawing.Size(240, 37);
            this.btnRunForecast.TabIndex = 5;
            this.btnRunForecast.Text = "Запустить прогнозирование";
            this.btnRunForecast.UseVisualStyleBackColor = true;
            this.btnRunForecast.Click += new System.EventHandler(this.BtnRunForecast_Click);
            // 
            // btnAddTask
            // 
            this.btnAddTask.Location = new System.Drawing.Point(13, 12);
            this.btnAddTask.Margin = new System.Windows.Forms.Padding(4);
            this.btnAddTask.Name = "btnAddTask";
            this.btnAddTask.Size = new System.Drawing.Size(160, 37);
            this.btnAddTask.TabIndex = 0;
            this.btnAddTask.Text = "Добавить задачу";
            this.btnAddTask.UseVisualStyleBackColor = true;
            this.btnAddTask.Click += new System.EventHandler(this.BtnAddTask_Click);
            // 
            // btnAddRisk
            // 
            this.btnAddRisk.Location = new System.Drawing.Point(187, 12);
            this.btnAddRisk.Margin = new System.Windows.Forms.Padding(4);
            this.btnAddRisk.Name = "btnAddRisk";
            this.btnAddRisk.Size = new System.Drawing.Size(160, 37);
            this.btnAddRisk.TabIndex = 1;
            this.btnAddRisk.Text = "Добавить риск";
            this.btnAddRisk.UseVisualStyleBackColor = true;
            this.btnAddRisk.Click += new System.EventHandler(this.BtnAddRisk_Click);
            // 
            // btnAddActuals
            // 
            this.btnAddActuals.Location = new System.Drawing.Point(360, 12);
            this.btnAddActuals.Margin = new System.Windows.Forms.Padding(4);
            this.btnAddActuals.Name = "btnAddActuals";
            this.btnAddActuals.Size = new System.Drawing.Size(160, 37);
            this.btnAddActuals.TabIndex = 2;
            this.btnAddActuals.Text = "Ввести факт. данные";
            this.btnAddActuals.UseVisualStyleBackColor = true;
            this.btnAddActuals.Click += new System.EventHandler(this.BtnAddActuals_Click);
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(13, 74);
            this.progressBar1.Margin = new System.Windows.Forms.Padding(4);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(667, 25);
            this.progressBar1.TabIndex = 3;
            this.progressBar1.Visible = false;
            // 
            // lblStatus
            // 
            this.lblStatus.AutoSize = true;
            this.lblStatus.Location = new System.Drawing.Point(693, 80);
            this.lblStatus.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(0, 16);
            this.lblStatus.TabIndex = 4;
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1179, 814);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.panel1);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MinimumSize = new System.Drawing.Size(1194, 851);
            this.Name = "Main";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Прогнозирование длительности проекта";
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvTasks)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvRisks)).EndInit();
            this.tabPage2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).EndInit();
            this.tabPage3.ResumeLayout(false);
            this.tabPage3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvRiskAnalysis)).EndInit();
            this.tabPage4.ResumeLayout(false);
            this.tabPage4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvBayesian)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bayesianChart)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudIterations)).EndInit();
            this.ResumeLayout(false);
            this.dgvBayesianResults = new System.Windows.Forms.DataGridView();
            this.btnOpenActualDataForm = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvBayesianResults)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvBayesianResults
            // 
            this.dgvBayesianResults.AllowUserToAddRows = false;
            this.dgvBayesianResults.AllowUserToDeleteRows = false;
            this.dgvBayesianResults.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvBayesianResults.Location = new System.Drawing.Point(12, 12);
            this.dgvBayesianResults.Name = "dgvBayesianResults";
            this.dgvBayesianResults.ReadOnly = true;
            this.dgvBayesianResults.Size = new System.Drawing.Size(760, 150);
            this.dgvBayesianResults.TabIndex = 0;
            this.btnOpenActualDataForm = new System.Windows.Forms.Button();
            this.btnOpenActualDataForm.Location = new System.Drawing.Point(12, 180);
            this.btnOpenActualDataForm.Name = "btnOpenActualDataForm";
            this.btnOpenActualDataForm.Size = new System.Drawing.Size(160, 23);
            this.btnOpenActualDataForm.TabIndex = 1;
            this.btnOpenActualDataForm.Text = "Ввести фактические данные";
            this.btnOpenActualDataForm.UseVisualStyleBackColor = true;
            this.btnOpenActualDataForm.Click += new System.EventHandler(this.btnOpenActualDataForm_Click);

            // 
            // btnOpenActualDataForm
            // 
            this.btnOpenActualDataForm.Location = new System.Drawing.Point(12, 180);
            this.btnOpenActualDataForm.Name = "btnOpenActualDataForm";
            this.btnOpenActualDataForm.Size = new System.Drawing.Size(160, 23);
            this.btnOpenActualDataForm.TabIndex = 1;
            this.btnOpenActualDataForm.Text = "Ввести фактические данные";
            this.btnOpenActualDataForm.UseVisualStyleBackColor = true;
            this.btnOpenActualDataForm.Click += new System.EventHandler(
            this.btnOpenActualDataForm_Click);
            this.Controls.Add(this.btnOpenActualDataForm);

            // 
            // MainForm
            // 
            this.ClientSize = new System.Drawing.Size(784, 261);
            this.Controls.Add(this.btnOpenActualDataForm);
            this.Controls.Add(this.dgvBayesianResults);
            this.Name = "MainForm";
            this.Text = "Байесовский анализ";
            ((System.ComponentModel.ISupportInitialize)(this.dgvBayesianResults)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnLoadDemoData;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.DataGridView dgvTasks;
        private System.Windows.Forms.DataGridView dgvRisks;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.DataVisualization.Charting.Chart chart1;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.DataGridView dgvRiskAnalysis;
        private System.Windows.Forms.TextBox txtSummary;
        private System.Windows.Forms.TabPage tabPage4;
        private System.Windows.Forms.DataGridView dgvBayesian;
        private System.Windows.Forms.DataVisualization.Charting.Chart bayesianChart;
        private System.Windows.Forms.TextBox txtBayesianSummary;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnBayesianSettings;
        private System.Windows.Forms.Button btnImportFromExcel;
        private System.Windows.Forms.Button btnExportToExcel;
        private System.Windows.Forms.NumericUpDown nudIterations;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnRunForecast;
        private System.Windows.Forms.Button btnAddTask;
        private System.Windows.Forms.Button btnAddRisk;
        private System.Windows.Forms.Button btnAddActuals;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.Label lblStatus;
    }
}