using Accord.Statistics.Distributions.Univariate;
using MathNet.Numerics.Distributions;
using MathNet.Numerics.Random;
using MathNet.Numerics.Statistics;
using BayesianForecastingApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Diagnostics;

namespace BayesianForecastingApp
{
    public class ForecastingEngine
    {
        private BayesianParameters _bayesianParams = new BayesianParameters();
        private readonly MersenneTwister _random = new MersenneTwister();

        public ForecastResult RunCombinedForecast(List<ProjectTask> tasks, List<RiskFactor> risks, int iterations)
        {
            var results = new List<ScenarioResult>();

            for (int i = 0; i < iterations; i++)
            {
                var scenario = new ScenarioResult();

                foreach (var task in tasks)
                {
                    double duration = SampleTaskDuration(task);
                    scenario.TaskDurations[task.Id] = duration;
                }

                ApplyRiskImpacts(scenario, tasks, risks);
                CalculateCriticalPath(scenario, tasks);
                results.Add(scenario);
            }

            return AnalyzeResults(results, tasks);
        }

        private double SampleTaskDuration(ProjectTask task)
        {
            try
            {
                if (task == null)
                {
                    Debug.WriteLine("Задача не может быть null");
                    return 0;
                }

                Debug.WriteLine($"Задача: {task.Name}, Оптимистичная: {task.OptimisticDuration}, Наиболее вероятная: {task.MostLikelyDuration}, Пессимистичная: {task.PessimisticDuration}");

                if (task.UseTriangular)
                {
                    Debug.WriteLine($"Используется треугольное распределение для задачи {task.Name}");

                    // Убедимся, что значения правильные
                    if (task.OptimisticDuration >= task.PessimisticDuration || task.MostLikelyDuration < task.OptimisticDuration || task.MostLikelyDuration > task.PessimisticDuration)
                    {
                        Debug.WriteLine($"Некорректные параметры для задачи {task.Name}. Автокорректируем MostLikelyDuration.");
                        task.MostLikelyDuration = (task.OptimisticDuration + task.PessimisticDuration) / 2;
                    }

                    return SampleTriangularDistribution(
                        task.OptimisticDuration,
                        task.PessimisticDuration,
                        task.MostLikelyDuration);
                }
                else
                {
                    Debug.WriteLine($"Используется нормальное распределение для задачи {task.Name}");

                    // Проверим стандартное отклонение
                    if (task.StdDev <= 0)
                    {
                        Debug.WriteLine($"Некорректное стандартное отклонение для задачи {task.Name}. Используем значение по умолчанию.");
                        task.StdDev = 1;
                    }

                    return SampleNormalDistribution(
                        task.MostLikelyDuration,
                        task.StdDev,
                        task.OptimisticDuration,
                        task.PessimisticDuration);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"Ошибка в методе SampleTaskDuration: {ex.Message}");
                return 0; // Возвращаем значение по умолчанию при ошибке
            }
        }

        private double SampleTriangularDistribution(double a, double b, double c)
        {
            try
            {
                Debug.WriteLine($"Triangular Distribution: a = {a}, b = {b}, c = {c}");

                if (c <= a || c >= b)
                {
                    c = (a + b) / 2;
                    Debug.WriteLine($"Автокоррекция MostLikelyDuration: a={a}, b={b}, c={c}");
                }

                double u = _random.NextDouble();
                return u < (c - a) / (b - a)
                    ? a + Math.Sqrt(u * (b - a) * (c - a))
                    : b - Math.Sqrt((1 - u) * (b - a) * (b - c));
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"Ошибка в SampleTriangularDistribution: {ex.Message}");
                return 0; // Возвращаем значение по умолчанию при ошибке
            }
        }

        private double SampleNormalDistribution(double mean, double stdDev, double min, double max)
        {
            try
            {
                Debug.WriteLine($"Normal Distribution: mean = {mean}, stdDev = {stdDev}, min = {min}, max = {max}");

                var normal = new Normal(mean, stdDev, _random);
                double duration = normal.Sample();
                return Math.Max(min, Math.Min(max, duration));
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"Ошибка в SampleNormalDistribution: {ex.Message}");
                return 0; // Возвращаем значение по умолчанию при ошибке
            }
        }







        private void CalculateCriticalPath(ScenarioResult scenario, List<ProjectTask> tasks)
        {
            var durations = scenario.TaskDurations;
            scenario.TotalDuration = durations.Values.Sum();
        }

        private ForecastResult AnalyzeResults(List<ScenarioResult> results, List<ProjectTask> tasks)
        {
            var distribution = new Dictionary<int, double>();
            var riskAnalysis = new List<RiskImpact>();

            if (results == null || !results.Any() || tasks == null)
            {
                return new ForecastResult
                {
                    DurationDistribution = distribution,
                    RiskAnalysis = riskAnalysis,
                    AverageDuration = 0,
                    ProbabilityOnTime = 0,
                    ConfidenceInterval = new ConfidenceInterval(0, 0)
                };
            }

            try
            {
                // Анализ длительности проекта
                var durations = results.Select(r => r.TotalDuration).Where(d => d >= 0).ToList();

                if (durations.Any())
                {
                    Debug.WriteLine($"durations count: {durations.Count}");
                    Debug.WriteLine($"durations: {string.Join(", ", durations)}");

                    // Безопасное создание гистограммы
                    int bucketCount = Math.Min(20, Math.Max(1, durations.Count));
                    var hist = new Histogram(durations, bucketCount);

                    for (int i = 0; i < hist.BucketCount; i++)
                    {
                        try
                        {
                            int min = (int)Math.Round(Math.Max(0, hist[i].LowerBound));
                            int max = (int)Math.Round(Math.Max(0, hist[i].UpperBound));
                            double prob = hist[i].Count / (double)results.Count;
                            distribution[(min + max) / 2] = prob;
                        }
                        catch { /* Пропускаем проблемные bucket'ы */ }
                    }
                }

                // Анализ рисков по задачам
                foreach (var task in tasks.Where(t => t != null))
                {
                    try
                    {
                        if (results.All(r => r.TaskDurations != null && r.TaskDurations.ContainsKey(task.Id)))
                        {
                            riskAnalysis.Add(new RiskImpact
                            {
                                TaskName = task.Name,
                                AvgDuration = results.Average(r => r.TaskDurations[task.Id]),
                                MaxDuration = results.Max(r => r.TaskDurations[task.Id]),
                                ProbabilityOverrun = results.Count(r => r.TaskDurations[task.Id] > task.MostLikelyDuration) / (double)results.Count
                            });
                        }
                    }
                    catch { /* Пропускаем проблемные задачи */ }
                }

                // Расчет метрик
                double baselineDuration = tasks.Where(t => t != null).Sum(t => t.MostLikelyDuration);
                double avgDuration = durations.DefaultIfEmpty(0).Average();
                double probOnTime = durations.Any() ? durations.Count(d => d <= baselineDuration) / (double)durations.Count : 0;

                int lowerBound = durations.Any() ? (int)durations.Percentile(2.5) : 0;
                int upperBound = durations.Any() ? (int)durations.Percentile(97.5) : 0;

                return new ForecastResult
                {
                    DurationDistribution = distribution,
                    RiskAnalysis = riskAnalysis,
                    AverageDuration = avgDuration,
                    ProbabilityOnTime = probOnTime,
                    ConfidenceInterval = new ConfidenceInterval(lowerBound, upperBound)
                };
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"Error in AnalyzeResults: {ex.Message}");
                return new ForecastResult
                {
                    DurationDistribution = distribution,
                    RiskAnalysis = riskAnalysis,
                    AverageDuration = 0,
                    ProbabilityOnTime = 0,
                    ConfidenceInterval = new ConfidenceInterval(0, 0)
                };
            }
        }

        public List<BayesianAnalysisResult> RunBayesianAnalysis(
    List<ProjectTask> tasks,
    List<RiskFactor> risks,
    Dictionary<int, double> actualDurations)
        {
            var results = new List<BayesianAnalysisResult>();

            if (tasks == null || !tasks.Any())
            {
                Debug.WriteLine("No tasks provided for Bayesian analysis");
                return results;
            }

            actualDurations = actualDurations ?? new Dictionary<int, double>();
            risks = risks ?? new List<RiskFactor>();

            foreach (var task in tasks.Where(t => t != null && t.Id > 0))
            {
                try
                {
                    // Безопасное получение фактической длительности
                    actualDurations.TryGetValue(task.Id, out double actual);

                    // Расчет вероятностей
                    double prior = CalculatePriorProbability(task);
                    double likelihood = CalculateLikelihood(task, risks.Where(r => r.TaskId == task.Id).ToList());
                    double posterior = UpdatePosterior(prior, likelihood);

                    results.Add(new BayesianAnalysisResult
                    {
                        TaskId = task.Id,
                        TaskName = task.Name,
                        PriorProbability = prior,
                        PosteriorProbability = posterior,
                        Likelihood = likelihood,
                        ActualDuration = actual,
                        ForecastError = actual > 0 ? Math.Abs(task.MostLikelyDuration - actual) : 0
                    });
                }
                catch (Exception ex)
                {
                    Debug.WriteLine($"Error processing task {task.Id}: {ex.Message}");
                }
            }

            return results;
        }



        private double CalculatePriorProbability(ProjectTask task)
        {
            try
            {
                double range = task.PessimisticDuration - task.OptimisticDuration;
                if (range <= 0) return 0.5;

                double normalizedDuration = (task.MostLikelyDuration - task.OptimisticDuration) / range;
                normalizedDuration = Math.Max(0, Math.Min(1, normalizedDuration)); // 🔒 ограничение диапазона

                var betaDist = new BetaDistribution(_bayesianParams.PriorAlpha, _bayesianParams.PriorBeta);
                return betaDist.ProbabilityDensityFunction(normalizedDuration);
            }
            catch
            {
                return 0.5;
            }
        }


        private double CalculateLikelihood(ProjectTask task, List<RiskFactor> taskRisks)
        {
            if (task == null || taskRisks == null || taskRisks.Count == 0)
                return 1.0; // Нейтральное значение при отсутствии рисков

            double riskImpact = taskRisks
                .Sum(r => r.Probability * r.ImpactDays);

            return Math.Exp(-riskImpact / task.MostLikelyDuration);
        }

        private double UpdatePosterior(double prior, double likelihood)
        {
            return (likelihood * prior) /
                  (likelihood * prior + (1 - likelihood) * (1 - prior));
        }

        private void ApplyRiskImpacts(ScenarioResult scenario, List<ProjectTask> tasks, List<RiskFactor> risks)
        {
            foreach (var risk in risks.Where(r => r.IsActive))
            {
                var affectedTask = tasks.FirstOrDefault(t => t.Id == risk.TaskId);
                if (affectedTask != null && scenario.TaskDurations.ContainsKey(affectedTask.Id))
                {
                    if (_random.NextDouble() < risk.Probability)
                    {
                        // Безопасное изменение длительности
                        if (scenario.TaskDurations.TryGetValue(affectedTask.Id, out double currentDuration))
                        {
                            scenario.TaskDurations[affectedTask.Id] = currentDuration + risk.ImpactDays;
                            Debug.WriteLine($"Применен риск {risk.Description} к задаче {affectedTask.Name}");
                        }
                    }
                }
            }
        }

        public void UpdateBayesianParameters(BayesianParameters parameters)
        {
            _bayesianParams = parameters;
        }
    }

    public static class Extensions
    {
        public static double Percentile(this IEnumerable<double> sequence, double percentile)
        {
            var sorted = sequence.OrderBy(x => x).ToArray();
            int n = sorted.Length;

            if (n == 0)
                return double.NaN; // Пустая последовательность, возвращаем NaN или любое другое значение по выбору

            // Проверка корректности значения percentile
            if (percentile < 0 || percentile > 100)
                throw new ArgumentOutOfRangeException(nameof(percentile), "Percentile должен быть в диапазоне от 0 до 100.");

            // Вычисление индекса
            double index = percentile / 100.0 * (n - 1);
            int lower = (int)Math.Floor(index);
            int upper = (int)Math.Ceiling(index);

            // Проверка границ индексов
            lower = Math.Max(0, Math.Min(lower, n - 1));
            upper = Math.Max(0, Math.Min(upper, n - 1));

            if (upper == lower)
                return sorted[lower];

            double fraction = index - lower;
            return sorted[lower] + fraction * (sorted[upper] - sorted[lower]);
        }

    }
}