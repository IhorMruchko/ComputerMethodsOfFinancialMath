using Common.WPF.Commands;
using Common.WPF.ViewModels;
using ComputerMethodsOfFinancialMath.LIB.Entities;
using ComputerMethodsOfFinancialMath.LIB.Entities.Solutions;
using OxyPlot;
using OxyPlot.Series;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;

namespace ComputerMethodsOfFinancialMath.WPF.ViewModels;

public class SolutionViewModel : ViewModel
{
    private PlotModel _plotModel = new();

    private int _years = 1;
   
    private int _slices = 1000;

    private int _testsAmount = 50;

    private bool _displayAnalyticSolution = true;

    private bool _displayEulerSolution;

    private bool _displayMilsteinSolution;
    
    private double _startMoney = 100;

    private double _mu = 0.1d;

    private double _sigma = 0.05d;

    public RelayedCommand EvaluateCommand => new(Evaluate);

    public RelayedCommand TestifyCommand => new(Testify);

    public int Years
    {
        get => _years;
        set
        {
            _years = value;
            OnPropertyChanged();
        }
    }

    public int Slices
    {
        get => _slices;
        set
        {
            _slices = value;
            OnPropertyChanged();
        }
    }

    public int TestsAmount
    {
        get => _testsAmount;
        set
        {
            _testsAmount = value;
            OnPropertyChanged();
        }
    }

    public bool DisplayAnalyticSolution
    {
        get => _displayAnalyticSolution;
        set
        {
            _displayAnalyticSolution = value;
            OnPropertyChanged();
        }
    }

    public bool DisplayEulerSolution
    {
        get => _displayEulerSolution;
        set
        {
            _displayEulerSolution = value;
            OnPropertyChanged();
        }
    }

    public bool DisplayMilsteinSolution
    {
        get => _displayMilsteinSolution;
        set
        {
            _displayMilsteinSolution = value;
            OnPropertyChanged();
        }
    }

    public double StartMoney
    {
        get => _startMoney;
        set
        {
            _startMoney = value;
            OnPropertyChanged();
        }
    }

    public double Mu
    {
        get => _mu;
        set
        {
            _mu = value;
            OnPropertyChanged();
        }
    }

    public double Sigma
    {
        get => _sigma;
        set
        {
            _sigma = value;
            OnPropertyChanged();
        }
    }

    public PlotModel PlotModel 
    { 
        get => _plotModel;
        set
        {
            _plotModel = value;
            OnPropertyChanged();
        }
    }

    private void Evaluate(object? obj)
    {
        var plotModel = new PlotModel();

        var process = new WiennerProcess(Years, Slices, Mu, Sigma);

        if (DisplayAnalyticSolution)
            plotModel.Series.Add(GetSeries(new AnalyticSolution(StartMoney, process), OxyColors.Green));

        if(DisplayEulerSolution)
            plotModel.Series.Add(GetSeries(new EulerSolution(StartMoney, process), OxyColors.Orange));

        if (DisplayMilsteinSolution)
            plotModel.Series.Add(GetSeries(new MilsteinSolution(StartMoney, process), OxyColors.Aquamarine));

        PlotModel = plotModel;
    }

    private void Testify(object? obj)
    {
        if (TestsAmount <= 0)
            return;

        var eulerErrors = new List<double>(TestsAmount);
        var milsteinErros = new List<double>(TestsAmount);


        for(var i = 1; i <= TestsAmount; ++i)
        {
            var process = new WiennerProcess(Years, Slices, Mu, Sigma);
            var analyticSolution = new AnalyticSolution(StartMoney, process);
            var eulerSolution = new EulerSolution(StartMoney, process);
            var milsteinSolution = new MilsteinSolution(StartMoney, process);

            var xAnalytic = analyticSolution.Solve()[^1];
            var xEuler = eulerSolution.Solve()[^1];
            var xMilstein =  milsteinSolution.Solve()[^1];

            eulerErrors.Add(Math.Abs(xAnalytic - xEuler));
            milsteinErros.Add(Math.Abs(xAnalytic - xMilstein));
        }

        var eulerError = eulerErrors.Average();
        var milsteinError = milsteinErros.Average();

        MessageBox.Show($"Results for {TestsAmount} executions: \n\tEuler = {eulerError}.\n\tMilstein = {milsteinError}.", "Results", MessageBoxButton.OK, MessageBoxImage.Information);
    }

    private static LineSeries GetSeries(Solution solution, OxyColor? color = null)
    {
        var result = solution.Solve();
        var lineSeries = new LineSeries()
        {
            Title = solution.GetType().Name,
            Color = color ?? OxyColors.DarkViolet,
        };
        
        foreach (var (x, y) in solution.Process.Time.Zip(result))
            lineSeries.Points.Add(new DataPoint(x, y));

        return lineSeries;
    }

}
