using MathNet.Numerics.Distributions;
using System;
using System.Windows.Forms;
using System.Collections.Generic;
using System.Xml.Linq;
using BayesianForecastingApp.Models;

namespace ProjectForecastingApp
{
    public partial class TaskEditForm : Form
    {
        public ProjectTask Task { get; private set; }

        public TaskEditForm(ProjectTask existingTask = null)
        {
            InitializeComponents();
            Task = existingTask != null
                ? new ProjectTask
                {
                    Id = existingTask.Id,
                    Name = existingTask.Name,
                    OptimisticDuration = existingTask.OptimisticDuration,
                    MostLikelyDuration = existingTask.MostLikelyDuration,
                    PessimisticDuration = existingTask.PessimisticDuration,
                    StdDev = existingTask.StdDev,
                    UseTriangular = existingTask.UseTriangular
                }
                : new ProjectTask();

            if (existingTask != null)
            {
                txtName.Text = existingTask.Name;
                nudOptimistic.Value = (decimal)existingTask.OptimisticDuration;
                nudLikely.Value = (decimal)existingTask.MostLikelyDuration;
                nudPessimistic.Value = (decimal)existingTask.PessimisticDuration;
                nudStdDev.Value = (decimal)existingTask.StdDev;
                rbTriangular.Checked = existingTask.UseTriangular;
                rbNormal.Checked = !existingTask.UseTriangular;
            }
        }

        private void InitializeComponents()
        {
            // Настройка элементов формы
            this.Text = "Добавление задачи";
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.StartPosition = FormStartPosition.CenterParent;

            // Настройка контролов
            lblName.Text = "Название задачи:";
            lblOptimistic.Text = "Оптимистичная оценка (дн):";
            lblLikely.Text = "Наиболее вероятная (дн):";
            lblPessimistic.Text = "Пессимистичная оценка (дн):";
            lblStdDev.Text = "Стандартное отклонение:";

            rbTriangular.Text = "Треугольное распределение";
            rbNormal.Text = "Нормальное распределение";

            btnSave.Text = "Сохранить";
            btnCancel.Text = "Отмена";

            // Настройка NumericUpDown
            nudOptimistic.Minimum = 1;
            nudOptimistic.Maximum = 365;
            nudLikely.Minimum = 1;
            nudLikely.Maximum = 365;
            nudPessimistic.Minimum = 1;
            nudPessimistic.Maximum = 365;
            nudStdDev.Minimum = 0.1m;
            nudStdDev.Maximum = 50;
            nudStdDev.DecimalPlaces = 1;
            nudStdDev.Increment = 0.5m;

            // Обработчики событий
            btnSave.Click += BtnSave_Click;
            btnCancel.Click += (s, e) => this.DialogResult = DialogResult.Cancel;
            rbTriangular.CheckedChanged += DistributionTypeChanged;
            rbNormal.CheckedChanged += DistributionTypeChanged;
        }

        private void DistributionTypeChanged(object sender, EventArgs e)
        {
            nudStdDev.Enabled = rbNormal.Checked;
        }

        // В методе BtnSave_Click в TaskEditForm.cs
        private void BtnSave_Click(object sender, EventArgs e)
        {
            if (!ValidateInputs()) return;

            Task = new ProjectTask
            {
                Name = txtName.Text,
                OptimisticDuration = (double)nudOptimistic.Value,
                MostLikelyDuration = (double)nudLikely.Value,
                PessimisticDuration = (double)nudPessimistic.Value,
                StdDev = (double)nudStdDev.Value,
                UseTriangular = rbTriangular.Checked
            };

            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private bool ValidateInputs()
        {
            // Проверка треугольного распределения
            if (rbTriangular.Checked &&
                (nudOptimistic.Value >= nudLikely.Value || nudLikely.Value >= nudPessimistic.Value))
            {
                MessageBox.Show("Для треугольного распределения должно быть: Оптим. < Вероятн. < Пессим.",
                               "Ошибка ввода", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            // Проверка нормального распределения
            if (rbNormal.Checked && nudStdDev.Value <= 0)
            {
                MessageBox.Show("Стандартное отклонение должно быть больше 0",
                               "Ошибка ввода", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            return true;
        }
    }
}
