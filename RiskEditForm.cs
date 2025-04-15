using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using BayesianForecastingApp.Models;
using MathNet.Numerics.Distributions;


namespace ProjectForecastingApp
{
    public partial class RiskEditForm : Form
    {
        public RiskFactor Risk { get; private set; }
        private List<ProjectTask> _tasks;
        private List<ProjectTask> projectTasks;

        public RiskEditForm(List<ProjectTask> tasks, RiskFactor selectedRisk)
        {
            InitializeComponent();
            _tasks = tasks;
            InitializeComponents();
            Risk = new RiskFactor();
        }

        public RiskEditForm(List<ProjectTask> projectTasks)
        {
            this.projectTasks = projectTasks;
        }

        private void InitializeComponents()
        {
            this.Text = "Добавление риска";
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.StartPosition = FormStartPosition.CenterParent;

            // Настройка ComboBox
            cmbTask.DataSource = _tasks;
            cmbTask.DisplayMember = "Name";
            cmbTask.ValueMember = "Id";

            // Настройка других элементов
            lblTask.Text = "Задача:";
            lblDescription.Text = "Описание риска:";
            lblProbability.Text = "Вероятность:";
            lblImpact.Text = "Влияние (дней):";

            nudProbability.Minimum = 0.01m;
            nudProbability.Maximum = 1;
            nudProbability.DecimalPlaces = 2;
            nudProbability.Increment = 0.05m;

            nudImpact.Minimum = 1;
            nudImpact.Maximum = 100;

            btnSave.Text = "Сохранить";
            btnCancel.Text = "Отмена";

            // Обработчики событий
            btnSave.Click += BtnSave_Click;
            btnCancel.Click += (s, e) => this.DialogResult = DialogResult.Cancel;
        }

        private void BtnSave_Click(object sender, EventArgs e)
        {
            if (!ValidateInputs()) return;

            Risk.TaskId = (int)cmbTask.SelectedValue;
            Risk.Description = txtDescription.Text;
            Risk.Probability = (double)nudProbability.Value;
            Risk.ImpactDays = (int)(double)nudImpact.Value;

            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private bool ValidateInputs()
        {
            if (string.IsNullOrWhiteSpace(txtDescription.Text))
            {
                MessageBox.Show("Введите описание риска");
                return false;
            }

            return true;
        }
    }
}