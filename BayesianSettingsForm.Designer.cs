namespace ProjectForecastingApp
{
    partial class BayesianSettingsForm
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region
        // Код, автоматически созданный конструктором форм Windows

        private void InitializeComponent()
        {
            this.numericAlpha = new System.Windows.Forms.NumericUpDown();
            this.numericBeta = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.btnOk = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.numericIterations = new System.Windows.Forms.NumericUpDown();
            this.label3 = new System.Windows.Forms.Label();
            this.numericThreshold = new System.Windows.Forms.NumericUpDown();
            this.label4 = new System.Windows.Forms.Label();
            this.chkConjugatePrior = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.numericAlpha)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericBeta)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericIterations)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericThreshold)).BeginInit();
            this.SuspendLayout();
            // 
            // numericAlpha
            // 
            this.numericAlpha.DecimalPlaces = 2;
            this.numericAlpha.Increment = new decimal(new int[] {
            1,
            0,
            0,
            131072});
            this.numericAlpha.Location = new System.Drawing.Point(120, 20);
            this.numericAlpha.Maximum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.numericAlpha.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            131072});
            this.numericAlpha.Name = "numericAlpha";
            this.numericAlpha.Size = new System.Drawing.Size(120, 22);
            this.numericAlpha.TabIndex = 0;
            this.numericAlpha.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // numericBeta
            // 
            this.numericBeta.DecimalPlaces = 2;
            this.numericBeta.Increment = new decimal(new int[] {
            1,
            0,
            0,
            131072});
            this.numericBeta.Location = new System.Drawing.Point(120, 50);
            this.numericBeta.Maximum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.numericBeta.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            131072});
            this.numericBeta.Name = "numericBeta";
            this.numericBeta.Size = new System.Drawing.Size(120, 22);
            this.numericBeta.TabIndex = 1;
            this.numericBeta.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(20, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(45, 16);
            this.label1.TabIndex = 2;
            this.label1.Text = "Alpha:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(20, 52);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(38, 16);
            this.label2.TabIndex = 3;
            this.label2.Text = "Beta:";
            // 
            // btnOk
            // 
            this.btnOk.Location = new System.Drawing.Point(80, 180);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(75, 23);
            this.btnOk.TabIndex = 4;
            this.btnOk.Text = "OK";
            this.btnOk.UseVisualStyleBackColor = true;
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(165, 180);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 5;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // numericIterations
            // 
            this.numericIterations.Location = new System.Drawing.Point(120, 80);
            this.numericIterations.Maximum = new decimal(new int[] {
            100000,
            0,
            0,
            0});
            this.numericIterations.Minimum = new decimal(new int[] {
            100,
            0,
            0,
            0});
            this.numericIterations.Name = "numericIterations";
            this.numericIterations.Size = new System.Drawing.Size(120, 22);
            this.numericIterations.TabIndex = 6;
            this.numericIterations.Value = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(20, 82);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(64, 16);
            this.label3.TabIndex = 7;
            this.label3.Text = "Iterations:";
            // 
            // numericThreshold
            // 
            this.numericThreshold.DecimalPlaces = 2;
            this.numericThreshold.Location = new System.Drawing.Point(120, 110);
            this.numericThreshold.Maximum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericThreshold.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            131072});
            this.numericThreshold.Name = "numericThreshold";
            this.numericThreshold.Size = new System.Drawing.Size(120, 22);
            this.numericThreshold.TabIndex = 8;
            this.numericThreshold.Value = new decimal(new int[] {
            5,
            0,
            0,
            131072});
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(20, 112);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(50, 16);
            this.label4.TabIndex = 9;
            this.label4.Text = "Порог:";
            // 
            // chkConjugatePrior
            // 
            this.chkConjugatePrior.AutoSize = true;
            this.chkConjugatePrior.Checked = true;
            this.chkConjugatePrior.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkConjugatePrior.Location = new System.Drawing.Point(120, 140);
            this.chkConjugatePrior.Name = "chkConjugatePrior";
            this.chkConjugatePrior.Size = new System.Drawing.Size(121, 20);
            this.chkConjugatePrior.TabIndex = 10;
            this.chkConjugatePrior.Text = "Conjugate Prior";
            this.chkConjugatePrior.UseVisualStyleBackColor = true;
            // 
            // BayesianSettingsForm
            // 
            this.AcceptButton = this.btnOk;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(260, 220);
            this.Controls.Add(this.chkConjugatePrior);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.numericThreshold);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.numericIterations);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOk);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.numericBeta);
            this.Controls.Add(this.numericAlpha);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "BayesianSettingsForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Bayesian Settings";
            ((System.ComponentModel.ISupportInitialize)(this.numericAlpha)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericBeta)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericIterations)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericThreshold)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.NumericUpDown numericAlpha;
        private System.Windows.Forms.NumericUpDown numericBeta;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnOk;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.NumericUpDown numericIterations;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.NumericUpDown numericThreshold;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.CheckBox chkConjugatePrior;
    }
}