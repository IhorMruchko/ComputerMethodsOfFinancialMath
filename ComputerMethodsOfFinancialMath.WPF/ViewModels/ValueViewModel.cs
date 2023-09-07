using Common.WPF;
using ComputerMethodsOfFinancialMath.LIB.Entities;
using ComputerMethodsOfFinancialMath.LIB.Helpers;
using System;
using System.Windows;

namespace ComputerMethodsOfFinancialMath.WPF.ViewModels;

public class ValueViewModel : ViewModel
{
    private readonly Value _value = new();

    private int _years = 1;

    public RelayedCommand ContinousApproachCommand => new (EvaluateContinousBlock);

    public RelayedCommand DiscreteApproachCommand => new(EvaluateDiscreteBlock);

    public int Years
    {
        get => _years;
        set
        {
            _years = value;
            OnPropertyChanged();
        }
    }


    public double MoneySum
    {
        get => _value.MoneySum;
        set
        {
            _value.ChangeMoneySum(value);
            OnPropertyChanged();
        }
    }

    public float InterestRate
    {
        get => _value.InterestRate;
        set
        {
            _value.ChangeRate(value);
            OnPropertyChanged();
        }
    }

    public DateTime CurrentDate
    {
        get => _value.CurrentDate;
        set
        {
            _value.ChangeCurrentDate(value);
            OnPropertyChanged();
        }
    }

    private void EvaluateContinousBlock(object? parameter)
    {
        if (parameter is not DateTime date)
            return;

        EvaluateContinous(date);
    }

    private void EvaluateDiscreteBlock(object? parameter) 
    {
        if (_years > 0)
        {
            Update(_value + _years);
            return;
        }

        Update(_value - Math.Abs(_years));
    }

    private void EvaluateContinous(DateTime date)
    {
        if (TimeHelper.IsCurrentDate(_value.CurrentDate, date))
        {
            MessageBox.Show("Change date first", "Invalid date.", MessageBoxButton.OK, MessageBoxImage.Hand);
            return;
        }

        if (TimeHelper.IsFutureDate(_value.CurrentDate, date))
        {
            Update(_value + date);
            return;
        }

        Update(_value - date);
    }

    private void Update(Value newValue)
    {
        MoneySum = newValue.MoneySum;
        CurrentDate = newValue.CurrentDate;
    }
}
