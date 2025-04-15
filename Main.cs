using BayesianForecastingApp.Models;
using BayesianForecastingApp;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using OfficeOpenXml;
using OfficeOpenXml.Style;
using System.IO;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using ExcelDataReader;
using System.Globalization;
using CsvHelper;
using System.Linq;
using System.Text;
using System.ComponentModel;
using LicenseContext = OfficeOpenXml.LicenseContext;
using OfficeOpenXml.Table;


namespace ProjectForecastingApp
{
    public partial class Main : Form
    {
        private List<ProjectTask> _tasks = new List<ProjectTask>();
        private List<RiskFactor> _risks = new List<RiskFactor>();
        private ForecastingEngine _engine = new ForecastingEngine();

        public Main()
        {
            InitializeComponent();

            // Явно создаем и настраиваем элементы управления
            this.Load += Main_Load;
            this.ClientSize = new System.Drawing.Size(884, 661);
        }

        private void Main_Load(object sender, EventArgs e)
        {
            // Проверка, инициализированы ли компоненты
            if (components == null)
                components = new System.ComponentModel.Container();

            InitializeComponents();
            InitializeChart();
        }

        private void InitializeBayesianComponents()
        {
            // Убедимся, что вкладка существует
            if (!tabControl1.TabPages.Contains(tabPage4))
            {
                tabControl1.TabPages.Add(tabPage4);
            }

            // Инициализация DataGridView
            dgvBayesian.AutoGenerateColumns = true;

            // Инициализация Chart
            bayesianChart.ChartAreas.Add(new ChartArea());
            bayesianChart.ChartAreas[0].AxisY.LabelStyle.Format = "P0";
        }
        private void ImportFromExcel_Click(object sender, EventArgs e)
        {
            using (var openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Filter = "Excel Files|*.xls;*.xlsx;*.xlsm";
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        // Регистрируем провайдер кодировок
                        Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);

                        using (var stream = File.Open(openFileDialog.FileName, FileMode.Open, FileAccess.Read))
                        {
                            using (var reader = ExcelReaderFactory.CreateReader(stream))
                            {
                                // Конфигурация для чтения данных
                                var config = new ExcelDataSetConfiguration
                                {
                                    ConfigureDataTable = _ => new ExcelDataTableConfiguration
                                    {
                                        UseHeaderRow = true // Используем первую строку как заголовки
                                    }
                                };

                                var dataSet = reader.AsDataSet(config);

                                // Обработка задач
                                if (dataSet.Tables.Count > 0 && dataSet.Tables[0].Rows.Count > 0)
                                {
                                    _tasks.Clear();
                                    foreach (DataRow row in dataSet.Tables[0].Rows)
                                    {
                                        _tasks.Add(new ProjectTask
                                        {
                                            Id = Convert.ToInt32(row["Id"]),
                                            Name = row["Name"].ToString(),
                                            OptimisticDuration = Convert.ToDouble(row["Optimistic"]),
                                            MostLikelyDuration = Convert.ToDouble(row["MostLikely"]),
                                            PessimisticDuration = Convert.ToDouble(row["Pessimistic"]),
                                            StdDev = Convert.ToDouble(row["StdDev"]),
                                            UseTriangular = Convert.ToBoolean(row["UseTriangular"])
                                        });
                                    }
                                }

                                // Обработка рисков (если есть второй лист)
                                if (dataSet.Tables.Count > 1 && dataSet.Tables[1].Rows.Count > 0)
                                {
                                    _risks.Clear();
                                    foreach (DataRow row in dataSet.Tables[1].Rows)
                                    {
                                        _risks.Add(new RiskFactor
                                        {
                                            TaskId = Convert.ToInt32(row["TaskId"]),
                                            Description = row["Description"].ToString(),
                                            Probability = Convert.ToDouble(row["Probability"]),
                                            ImpactDays = Convert.ToInt32(row["ImpactDays"])
                                        });
                                    }
                                }

                                RefreshTasksGrid();
                                RefreshRisksGrid();
                                MessageBox.Show("Данные успешно загружены из Excel", "Успех",
                                              MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Ошибка при загрузке из Excel: {ex.Message}", "Ошибка",
                                      MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void btnBayesianSettings_Click(object sender, EventArgs e)
        {
            using (var settingsForm = new BayesianSettingsForm())
            {
                if (settingsForm.ShowDialog() == DialogResult.OK)
                {
                    var parameters = settingsForm.GetParameters();
                    _engine.UpdateBayesianParameters(parameters);
                }
            }
        }
        private void ExportToExcel_Click(object sender, EventArgs e)
        {
            try
            {
                ExcelPackage.LicenseContext = LicenseContext.NonCommercial;

                using (var saveFileDialog = new SaveFileDialog())
                {
                    saveFileDialog.Filter = "Excel Files|*.xlsx";
                    saveFileDialog.Title = "Экспорт данных проекта";

                    if (saveFileDialog.ShowDialog() == DialogResult.OK)
                    {
                        using (var package = new ExcelPackage())
                        {
                            // 1. Лист с задачами
                            var wsTasks = package.Workbook.Worksheets.Add("Задачи");
                            wsTasks.Cells["A1"].LoadFromCollection(_tasks, true, TableStyles.Medium9);
                            FormatWorksheet(wsTasks, "Список задач проекта");

                            // 2. Лист с рисками
                            if (_risks.Any())
                            {
                                var wsRisks = package.Workbook.Worksheets.Add("Риски");
                                wsRisks.Cells["A1"].LoadFromCollection(_risks, true, TableStyles.Medium9);
                                FormatWorksheet(wsRisks, "Анализ рисков проекта");
                            }

                            // 3. Лист с анализом (если данные есть)
                            if (dgvRiskAnalysis.DataSource != null)
                            {
                                var wsAnalysis = package.Workbook.Worksheets.Add("Анализ");
                                ExportDataGridViewToWorksheet(dgvRiskAnalysis, wsAnalysis);
                                FormatWorksheet(wsAnalysis, "Анализ влияния рисков");
                            }

                            // 4. Лист с прогнозом (если есть данные графика)
                            if (chart1.Series[0].Points.Count > 0)
                            {
                                var wsForecast = package.Workbook.Worksheets.Add("Прогноз");
                                ExportChartToWorksheet(chart1, wsForecast);
                                FormatWorksheet(wsForecast, "Прогноз длительности проекта");

                                // Добавляем сводку
                                wsForecast.Cells["E1"].Value = "Сводка прогноза";
                                wsForecast.Cells["E2"].Value = txtSummary.Text.Replace("\r\n", "\n");
                                wsForecast.Cells["E2"].Style.WrapText = true;
                            }
                            var bayesianEngine = new BayesianUpdateEngine();
                            var bayesianResults = bayesianEngine.UpdateProbabilities(_tasks, _risks);

                            if (bayesianResults.Any())
                            {
                                var wsBayesian = package.Workbook.Worksheets.Add("Байесовский анализ");
                                wsBayesian.Cells["A1"].LoadFromCollection(bayesianResults, true, TableStyles.Medium9);

                                // Добавляем формулу Байеса в Excel
                                wsBayesian.Cells["F1"].Value = "Формула Байеса";
                                wsBayesian.Cells["F2"].Formula = "=(D2*C2)/(D2*C2 + (1-D2)*(1-C2))";
                                wsBayesian.Cells["F2"].Style.Numberformat.Format = "0.00%";

                                FormatWorksheet(wsBayesian, "Байесовский анализ длительностей");
                            }
                            // Автоподбор ширины столбцов для всех листов
                            foreach (var worksheet in package.Workbook.Worksheets)
                            {
                                worksheet.Cells[worksheet.Dimension.Address].AutoFitColumns();
                            }

                            package.SaveAs(new FileInfo(saveFileDialog.FileName));
                        }

                        MessageBox.Show("Все данные успешно экспортированы в Excel", "Экспорт завершён",
                                      MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка экспорта:\n{ex.Message}", "Ошибка",
                              MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Вспомогательные методы для форматирования
        private void FormatWorksheet(ExcelWorksheet ws, string title)
        {
            // Заголовок
            ws.Cells["A1"].Value = title;
            ws.Cells["A1"].Style.Font.Bold = true;
            ws.Cells["A1"].Style.Font.Size = 14;

            // Форматирование заголовков таблицы
            using (var range = ws.Cells[2, 1, 2, ws.Dimension.End.Column])
            {
                range.Style.Font.Bold = true;
                range.Style.Fill.PatternType = ExcelFillStyle.Solid;
                range.Style.Fill.BackgroundColor.SetColor(Color.LightGray);
            }
        }

        private void ExportDataGridViewToWorksheet(DataGridView dgv, ExcelWorksheet ws)
        {
            // Экспорт заголовков
            for (int i = 0; i < dgv.Columns.Count; i++)
            {
                ws.Cells[1, i + 1].Value = dgv.Columns[i].HeaderText;
            }

            // Экспорт данных
            for (int row = 0; row < dgv.Rows.Count; row++)
            {
                for (int col = 0; col < dgv.Columns.Count; col++)
                {
                    ws.Cells[row + 2, col + 1].Value = dgv.Rows[row].Cells[col].Value?.ToString();
                }
            }
        }

        private void ExportChartToWorksheet(Chart chart, ExcelWorksheet ws)
        {
            // Экспорт данных графика
            ws.Cells["A1"].Value = "Длительность (дни)";
            ws.Cells["B1"].Value = "Вероятность";

            var series = chart.Series[0];
            for (int i = 0; i < series.Points.Count; i++)
            {
                ws.Cells[i + 2, 1].Value = series.Points[i].XValue;
                ws.Cells[i + 2, 2].Value = series.Points[i].YValues[0];
            }

            // Добавляем график в Excel
            var excelChart = ws.Drawings.AddChart("Прогноз", OfficeOpenXml.Drawing.Chart.eChartType.ColumnClustered);
            excelChart.SetPosition(3, 0, 3, 0);
            excelChart.SetSize(800, 400);

            var rangeX = ws.Cells[2, 1, series.Points.Count + 1, 1];
            var rangeY = ws.Cells[2, 2, series.Points.Count + 1, 2];
            excelChart.Series.Add(rangeY, rangeX);
        }





        // В Main.cs
        private void InitializeDataGrids()
        {
            // Настройка DataGridView для задач
            dgvTasks.DataSource = new BindingList<ProjectTask>(_tasks);
            dgvTasks.CellEndEdit += DgvTasks_CellEndEdit;
            dgvTasks.DataError += DgvTasks_DataError;

            // Настройка DataGridView для рисков
            dgvRisks.DataSource = new BindingList<RiskFactor>(_risks);
            dgvRisks.CellEndEdit += DgvRisks_CellEndEdit;
            dgvRisks.DataError += DgvRisks_DataError;

            // Включение редактирования
            dgvTasks.ReadOnly = false;
            dgvRisks.ReadOnly = false;
        }

        private void DgvTasks_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            // Можно добавить дополнительную валидацию при необходимости
        }

        private void DgvRisks_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            // Можно добавить дополнительную валидацию при необходимости
        }

        private void DgvTasks_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            MessageBox.Show($"Некорректное значение: {e.Exception.Message}", "Ошибка ввода",
                          MessageBoxButtons.OK, MessageBoxIcon.Error);
            e.ThrowException = false;
        }

        private void DgvRisks_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            MessageBox.Show($"Некорректное значение: {e.Exception.Message}", "Ошибка ввода",
                          MessageBoxButtons.OK, MessageBoxIcon.Error);
            e.ThrowException = false;
        }

        private void RefreshTasksGrid()
        {
            dgvTasks.DataSource = null;
            dgvTasks.DataSource = new BindingList<ProjectTask>(_tasks);
        }

        private void RefreshRisksGrid()
        {
            dgvRisks.DataSource = null;
            dgvRisks.DataSource = new BindingList<RiskFactor>(_risks);
        }

       

        private void DeleteSelectedTask()
        {
            if (dgvTasks.SelectedRows.Count == 0) return;

            var task = (ProjectTask)dgvTasks.SelectedRows[0].DataBoundItem;
            if (MessageBox.Show($"Удалить задачу '{task.Name}'?", "Подтверждение",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                _tasks.Remove(task);
                RefreshTasksGrid();
            }
        }

        private void DeleteSelectedRisk()
        {
            if (dgvRisks.SelectedRows.Count == 0) return;

            var risk = (RiskFactor)dgvRisks.SelectedRows[0].DataBoundItem;
            if (MessageBox.Show($"Удалить риск '{risk.Description}'?", "Подтверждение",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                _risks.Remove(risk);
                RefreshRisksGrid();
            }
        }


        private void UpdateBayesianChart(List<BayesianAnalysisResult> results)
        {
            bayesianChart.Series.Clear();

            var priorSeries = new Series("Априорная вероятность")
            {
                ChartType = SeriesChartType.Column,
                Color = Color.Blue
            };

            var posteriorSeries = new Series("Апостериорная вероятность")
            {
                ChartType = SeriesChartType.Column,
                Color = Color.Green
            };

            foreach (var result in results)
            {
                priorSeries.Points.AddXY(result.TaskName, result.PriorProbability);
                posteriorSeries.Points.AddXY(result.TaskName, result.PosteriorProbability);
            }

            bayesianChart.Series.Add(priorSeries);
            bayesianChart.Series.Add(posteriorSeries);
            bayesianChart.ChartAreas[0].AxisY.LabelStyle.Format = "P0";
        }

        
        public class DataImporter
        {
            public static List<ProjectTask> LoadTasksFromCsv(string filePath)
            {
                var tasks = new List<ProjectTask>();

                using (var reader = new StreamReader(filePath))
                using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
                {
                    csv.Context.RegisterClassMap<TaskMap>();
                    tasks = csv.GetRecords<ProjectTask>().ToList();
                }

                return tasks;
            }

        }

        private void btnOpenActualDataForm_Click(object sender, EventArgs e)
        {
            // Открываем форму для ввода фактических данных
            var actualDataForm = new ActualDataForm(_tasks);
            var result = actualDataForm.ShowDialog();

            if (result == DialogResult.OK)
            {
                // Данные успешно введены, запускаем байесовский анализ
                var forecastingEngine = new ForecastingEngine();
                var analysisResults = forecastingEngine.RunBayesianAnalysis(_tasks, _risks, actualDataForm.CompletedTasksActuals);
                // Заполняем таблицу с результатами
                FillBayesianResults(analysisResults);
            }
        }
        // Метод, который будет заполнять CompletedTasksActuals с введёнными данными
        public Dictionary<int, double> CompletedTasksActuals { get; private set; }

        private void FillBayesianResults(List<BayesianAnalysisResult> results)
        {
            dgvBayesianResults.Rows.Clear();

            foreach (var result in results)
            {
                dgvBayesianResults.Rows.Add(result.TaskId, result.TaskName, result.PriorProbability, result.PosteriorProbability, result.ActualDuration, result.ForecastError);
            }
        }
        private void AddContextMenus()
        {
            // Меню для таблицы задач
            var taskMenu = new ContextMenuStrip();
          
            taskMenu.Items.Add("Удалить", null, (s, e) => DeleteSelectedTask());
            taskMenu.Items.Add("-"); // Разделитель
            taskMenu.Items.Add("Добавить задачу", null, (s, e) => BtnAddTask_Click(s, e));
            dgvTasks.ContextMenuStrip = taskMenu;

            // Меню для таблицы рисков
            var riskMenu = new ContextMenuStrip();
            riskMenu.Items.Add("Удалить", null, (s, e) => DeleteSelectedRisk());
            riskMenu.Items.Add("-"); // Разделитель
            riskMenu.Items.Add("Добавить риск", null, (s, e) => BtnAddRisk_Click(s, e));
            dgvRisks.ContextMenuStrip = riskMenu;
        }




      
        private void InitializeComponents()
        {
            // Настройка DataGridView для задач
            dgvTasks.AutoGenerateColumns = false;
            dgvTasks.Columns.Add(new DataGridViewTextBoxColumn()
            {
                HeaderText = "ID",
                DataPropertyName = "Id",
                Width = 50
            });
            dgvTasks.Columns.Add(new DataGridViewTextBoxColumn()
            {
                HeaderText = "Название",
                DataPropertyName = "Name",
                Width = 150
            });
            dgvTasks.Columns.Add(new DataGridViewTextBoxColumn()
            {
                HeaderText = "Оптим.",
                DataPropertyName = "OptimisticDuration",
                Width = 60
            });
            dgvTasks.Columns.Add(new DataGridViewTextBoxColumn()
            {
                HeaderText = "Вероятн.",
                DataPropertyName = "MostLikelyDuration",
                Width = 60
            });
            dgvTasks.Columns.Add(new DataGridViewTextBoxColumn()
            {
                HeaderText = "Пессим.",
                DataPropertyName = "PessimisticDuration",
                Width = 60
            });

            // Настройка DataGridView для рисков
            dgvRisks.AutoGenerateColumns = false;
            dgvRisks.Columns.Add(new DataGridViewTextBoxColumn()
            {
                HeaderText = "Задача ID",
                DataPropertyName = "TaskId",
                Width = 70
            });
            dgvRisks.Columns.Add(new DataGridViewTextBoxColumn()
            {
                HeaderText = "Описание",
                DataPropertyName = "Description",
                Width = 200
            });
            dgvRisks.Columns.Add(new DataGridViewTextBoxColumn()
            {
                HeaderText = "Вероятность",
                DataPropertyName = "Probability",
                Width = 80
            });
            dgvRisks.Columns.Add(new DataGridViewTextBoxColumn()
            {
                HeaderText = "Влияние (дн)",
                DataPropertyName = "ImpactDays",
                Width = 80
            });

            // Настройка элементов управления
            nudIterations.Value = 1000;
            btnRunForecast.Text = "Запустить прогнозирование";
            btnAddTask.Text = "Добавить задачу";
            btnAddRisk.Text = "Добавить риск";
            btnAddActuals.Text = "Ввести факт. данные";

            // Привязка обработчиков событий
            btnRunForecast.Click += BtnRunForecast_Click;
            btnAddTask.Click += BtnAddTask_Click;
            btnAddRisk.Click += BtnAddRisk_Click;
            btnAddActuals.Click += BtnAddActuals_Click;
        }

        private void InitializeChart()
        {
            chart1.Series.Clear();
            chart1.ChartAreas.Clear();

            var area = new ChartArea("MainArea");
            area.AxisX.Title = "Дни";
            area.AxisY.Title = "Вероятность";
            area.AxisY.LabelStyle.Format = "P0";
            chart1.ChartAreas.Add(area);

            var series = new Series("DurationDistribution")
            {
                ChartType = SeriesChartType.Column,
                Color = Color.SteelBlue,
                BorderWidth = 2,
                IsValueShownAsLabel = true,
                LabelFormat = "P1"
            };
            chart1.Series.Add(series);
        }

        private void BtnAddTask_Click(object sender, EventArgs e)
        {
            var form = new TaskEditForm();
            if (form.ShowDialog() == DialogResult.OK)
            {
                _tasks.Add(form.Task);
                RefreshTasksGrid();
            }
        }

        private void BtnAddRisk_Click(object sender, EventArgs e)
        {
            if (_tasks.Count == 0)
            {
                MessageBox.Show("Сначала добавьте задачи проекта");
                return;
            }

            var form = new RiskEditForm(_tasks);
            if (form.ShowDialog() == DialogResult.OK)
            {
                _risks.Add(form.Risk);
                RefreshRisksGrid();
            }
        }

        private void BtnAddActuals_Click(object sender, EventArgs e)
        {
            using (var form = new ActualDataForm(_tasks))
            {
                if (form.ShowDialog() == DialogResult.OK)
                {
                    var actuals = form.CompletedTasksActuals;

                    // Сохраняем обратно в _tasks
                    foreach (var task in _tasks)
                    {
                        if (actuals.TryGetValue(task.Id, out var value))
                        {
                            task.ActualDuration = value;
                        }
                    }

                    // (опционально) можно перерисовать таблицу задач, если она это отображает
                    RefreshTasksGrid();
                }
            }
        }


        private void RunBayesianAnalysis()
        {
            try
            {
                // Получаем фактические данные
                var actuals = _tasks.Where(t => t.ActualDuration > 0)
                                  .ToDictionary(t => t.Id, t => t.ActualDuration);

                // Выполняем анализ
                var results = _engine.RunBayesianAnalysis(_tasks, _risks, actuals);

                // Обновляем UI
                UpdateBayesianAnalysis(results);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при выполнении байесовского анализа: {ex.Message}",
                              "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnBayesianSettings_Click(object sender, EventArgs e)
        {
            // Создаем и показываем форму настроек байесовского анализа
            using (var settingsForm = new BayesianSettingsForm())
            {
                if (settingsForm.ShowDialog() == DialogResult.OK)
                {
                    // Применяем настройки
                    _engine.UpdateBayesianParameters(settingsForm.GetParameters());
                    // Обновляем анализ
                    RunBayesianAnalysis();
                }
            }
        }


        private async void BtnRunForecast_Click(object sender, EventArgs e)
        {
            if (_tasks.Count == 0)
            {
                MessageBox.Show("Добавьте задачи проекта");
                return;
            }

            btnRunForecast.Enabled = false;
            progressBar1.Visible = true;
            lblStatus.Text = "Выполняется прогнозирование...";

            try
            {
                var iterations = (int)nudIterations.Value;

                // Получаем фактические данные (если есть)
                var actuals = _tasks
                    .Where(t => t.ActualDuration > 0)
                    .ToDictionary(t => t.Id, t => t.ActualDuration);

                var result = await Task.Run(() =>
                    _engine.RunCombinedForecast(_tasks, _risks, iterations));

                var bayesianResults = await Task.Run(() =>
                    _engine.RunBayesianAnalysis(_tasks, _risks, actuals));

                UpdateBayesianAnalysis(bayesianResults);
                UpdateChart(result.DurationDistribution);
                UpdateRiskAnalysis(result.RiskAnalysis);
                UpdateSummary(result);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка: {ex.Message}");
            }
            finally
            {
                btnRunForecast.Enabled = true;
                progressBar1.Visible = false;
                lblStatus.Text = "Готово";
            }
        }

        private void UpdateBayesianAnalysis(List<BayesianAnalysisResult> results)
        {
            if (dgvBayesian.InvokeRequired)
            {
                dgvBayesian.Invoke(new Action(() => UpdateBayesianAnalysis(results)));
                return;
            }

            dgvBayesian.DataSource = results;

            // Обновление графика
            bayesianChart.Series.Clear();

            var priorSeries = new Series("Prior")
            {
                ChartType = SeriesChartType.Column,
                Color = Color.Blue
            };

            var posteriorSeries = new Series("Posterior")
            {
                ChartType = SeriesChartType.Column,
                Color = Color.Green
            };

            foreach (var result in results)
            {
                priorSeries.Points.AddXY(result.TaskName, result.PriorProbability);
                posteriorSeries.Points.AddXY(result.TaskName, result.PosteriorProbability);
            }

            bayesianChart.Series.Add(priorSeries);
            bayesianChart.Series.Add(posteriorSeries);
            bayesianChart.ChartAreas[0].AxisY.LabelStyle.Format = "P0";

            // Обновление сводки
            txtBayesianSummary.Text = $"Средняя априорная вероятность: {results.Average(r => r.PriorProbability):P2}\n" +
                                     $"Средняя апостериорная вероятность: {results.Average(r => r.PosteriorProbability):P2}";
        }

        private void UpdateChart(Dictionary<int, double> distribution)
        {
            chart1.Series["DurationDistribution"].Points.Clear();

            foreach (var item in distribution)
            {
                chart1.Series["DurationDistribution"].Points.AddXY(item.Key, item.Value);
            }

            chart1.ChartAreas[0].RecalculateAxesScale();
        }
        private void BtnLoadDemoData_Click(object sender, EventArgs e)
        {
            try
            {
                // 1. Загрузка демо-задач
                _tasks = new List<ProjectTask>
        {
            new ProjectTask {
                Id = 1,
                Name = "Проектирование",
                OptimisticDuration = 10,
                MostLikelyDuration = 14,
                PessimisticDuration = 18,
                UseTriangular = true
            },
            new ProjectTask {
                Id = 2,
                Name = "Разработка",
                OptimisticDuration = 20,
                MostLikelyDuration = 25,
                PessimisticDuration = 35,
                StdDev = 3.5,
                UseTriangular = false
            }
        };

                // 2. Загрузка демо-рисков
                _risks = new List<RiskFactor>
        {
            new RiskFactor {
                TaskId = 1,
                Description = "Изменение требований",
                Probability = 0.3,
                ImpactDays = 3
            },
            new RiskFactor {
                TaskId = 2,
                Description = "Проблемы с интеграцией",
                Probability = 0.2,
                ImpactDays = 5
            }
        };

                // 3. Обновление интерфейса
                RefreshTasksGrid();
                RefreshRisksGrid();

                MessageBox.Show("Демо-данные успешно загружены!", "Успех",
                               MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка загрузки данных: {ex.Message}", "Ошибка",
                               MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void UpdateRiskAnalysis(List<RiskImpact> risks)
        {
            dgvRiskAnalysis.DataSource = risks;
            dgvRiskAnalysis.AutoResizeColumns();
        }

        private System.Windows.Forms.DataGridView dgvBayesianResults;
        private System.Windows.Forms.Button btnOpenActualDataForm;


        private void UpdateSummary(ForecastResult result)
        {
            txtSummary.Text = $"Вероятность завершения в срок: {result.ProbabilityOnTime:P2}\r\n" +
                             $"Средняя длительность: {result.AverageDuration} дней\r\n" +
                             $"95% доверительный интервал: {result.ConfidenceInterval.Min}-{result.ConfidenceInterval.Max} дней";
        }
    }
}