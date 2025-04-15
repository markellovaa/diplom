using BayesianForecastingApp.Models;
using System;
using System.Windows.Forms;

namespace ProjectForecastingApp
{
    public partial class BayesianSettingsForm : Form
    {
        public BayesianParameters Parameters { get; private set; }

        public BayesianSettingsForm()
        {
            InitializeComponent();
            Parameters = new BayesianParameters();
        }

        public BayesianParameters GetParameters()
        {
            return new BayesianParameters
            {
                PriorAlpha = (double)numericAlpha.Value,
                PriorBeta = (double)numericBeta.Value,
         
                Threshold = (double)numericThreshold.Value,
                UseConjugatePrior = chkConjugatePrior.Checked
            };
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            Parameters = GetParameters();
            DialogResult = DialogResult.OK;
            Close();
        }
    }
}