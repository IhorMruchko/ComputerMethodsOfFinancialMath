using Common.WPF.ViewModels;
using Common.WPF.Commands;
using ComputerMethodsOfFinancialMath.LIB.Entities;
using ComputerMethodsOfFinancialMath.LIB.Helpers;
using System;
using System.Windows;
using System.Windows.Controls;

namespace ComputerMethodsOfFinancialMath.WPF.ViewModels;

public class ValueViewModel : ViewModel
{
    private readonly Value _value = new();

    private int _years = 1;

    private float _continousYears = 1;

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

    public float YearsForContinous
    {
        get => _continousYears;
        set
        {
            _continousYears = value;
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
        if (parameter is not object[] array || 
            array.Length != 3 ||
            array[0] is not bool isChecked || 
            array[1] is not DateTime date || 
            array[2] is not string yearsStr ||
            float.TryParse(yearsStr, out var years) == false)

            return;

        if (isChecked)
            EvaluateContinous(date);
        else
            EvaluateContinous(years);
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

    private void EvaluateContinous(float date)
    {
        if (date > 0)
        {
            Update(_value + date);
            return;
        }

        Update(_value - Math.Abs(date));
    }

    private void Update(Value newValue)
    {
        MoneySum = newValue.MoneySum;
        CurrentDate = newValue.CurrentDate;
    }
}
