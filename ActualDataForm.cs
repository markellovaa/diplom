using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Windows.Forms;
using BayesianForecastingApp.Models;

namespace ProjectForecastingApp
{
    public partial class ActualDataForm : Form
    {
        public Dictionary<int, double> CompletedTasksActuals { get; private set; }
        private readonly List<ProjectTask> _tasks;
        private bool _isInitialized = false; // Флаг инициализации

        public ActualDataForm(List<ProjectTask> tasks)
        {
            _tasks = tasks ?? throw new ArgumentNullException(nameof(tasks));
            InitializeComponent();
            ConfigureDataGridView();
            LoadData();
        }

        private void ConfigureDataGridView()
        {
            // Убедимся, что события не подписаны дважды
            dgvActuals.EditingControlShowing -= dgvActuals_EditingControlShowing;
            dgvActuals.EditingControlShowing += dgvActuals_EditingControlShowing;

            dgvActuals.CellValidating -= dgvActuals_CellValidating;
            dgvActuals.CellValidating += dgvActuals_CellValidating;

            dgvActuals.AutoGenerateColumns = false;
            dgvActuals.AllowUserToAddRows = false;
            dgvActuals.AllowUserToDeleteRows = false;
            dgvActuals.EditMode = DataGridViewEditMode.EditOnEnter;

            dgvActuals.Columns.Clear();

            // Добавление колонок
            dgvActuals.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "TaskId",
                DataPropertyName = "Id",
                Visible = false,
                ReadOnly = true
            });

            dgvActuals.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "TaskName",
                HeaderText = "Задача",
                DataPropertyName = "Name",
                ReadOnly = true,
                Width = 250
            });

            dgvActuals.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "ActualDuration",
                HeaderText = "Фактическая длительность",
                DataPropertyName = "ActualDuration",
                ReadOnly = false,
                Width = 200
            });
        }

        private void LoadData()
        {
            if (_isInitialized) return;

            var displayData = _tasks.Select(t => new TaskDisplayModel
            {
                Id = t.Id,
                Name = t.Name,
                ActualDuration = t.ActualDuration
            }).ToList();

            dgvActuals.DataSource = displayData;
            _isInitialized = true;
        }

        public class TaskDisplayModel
        {
            public int Id { get; set; }
            public string Name { get; set; }
            public double? ActualDuration { get; set; }
        }

        private void dgvActuals_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            if (dgvActuals.CurrentCell.ColumnIndex == dgvActuals.Columns["ActualDuration"].Index)
            {
                if (e.Control is TextBox tb)
                {
                    tb.KeyPress -= Tb_KeyPress_NumbersOnly;
                    tb.KeyPress += Tb_KeyPress_NumbersOnly;
                }
            }
        }

        private void dgvActuals_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {
            if (e.ColumnIndex == dgvActuals.Columns["ActualDuration"].Index)
            {
                var cell = dgvActuals.Rows[e.RowIndex].Cells[e.ColumnIndex];
                var value = e.FormattedValue?.ToString();

                if (string.IsNullOrWhiteSpace(value))
                {
                    cell.ErrorText = "Введите значение";
                    e.Cancel = true;
                }
                else if (!double.TryParse(value.Replace(',', '.'), NumberStyles.Any, CultureInfo.InvariantCulture, out double result) || result <= 0)
                {
                    cell.ErrorText = "Некорректное значение";
                    e.Cancel = true;
                }
                else
                {
                    cell.ErrorText = null;
                }
            }
        }

        private void Tb_KeyPress_NumbersOnly(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && e.KeyChar != '.' && e.KeyChar != ',')
            {
                e.Handled = true;
                return;
            }

            if ((e.KeyChar == '.' || e.KeyChar == ',') && sender is TextBox tb)
            {
                string currentText = tb.Text;
                if (currentText.Contains('.') || currentText.Contains(','))
                {
                    e.Handled = true;
                }
                else
                {
                    e.KeyChar = '.'; // Ставит точку, независимо от запятой
                }
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        private void btnApply_Click_1(object sender, EventArgs e)
        {
            try
            {
                CompletedTasksActuals = new Dictionary<int, double>();
                bool hasErrors = false;

                foreach (DataGridViewRow row in dgvActuals.Rows)
                {
                    if (row.IsNewRow) continue;

                    var taskId = (int)row.Cells["TaskId"].Value;
                    var durationValue = row.Cells["ActualDuration"].Value?.ToString();

                    if (string.IsNullOrWhiteSpace(durationValue))
                    {
                        row.Cells["ActualDuration"].ErrorText = "Введите значение";
                        hasErrors = true;
                        continue;
                    }

                    if (!double.TryParse(durationValue.Replace(',', '.'), NumberStyles.Any, CultureInfo.InvariantCulture, out double duration) || duration <= 0)
                    {
                        row.Cells["ActualDuration"].ErrorText = "Некорректное значение";
                        hasErrors = true;
                        continue;
                    }

                    CompletedTasksActuals[taskId] = duration;
                }

                if (hasErrors)
                {
                    MessageBox.Show("Имеются некорректные данные. Пожалуйста, исправьте ошибки.",
                                    "Ошибки в данных",
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Warning);
                    return;
                }

                // Обновляем фактическую длительность в оригинальных задачах
                foreach (var task in _tasks)
                {
                    if (CompletedTasksActuals.TryGetValue(task.Id, out double actualDuration))
                    {
                        task.ActualDuration = actualDuration;
                    }
                }

                DialogResult = DialogResult.OK;
                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при сохранении данных: {ex.Message}",
                                "Ошибка",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Error);
            }
        }
    }
}
