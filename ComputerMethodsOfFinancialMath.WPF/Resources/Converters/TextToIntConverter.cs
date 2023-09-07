using System;
using System.Globalization;
using System.Windows.Controls;
using System.Windows.Data;

namespace ComputerMethodsOfFinancialMath.WPF.Resources.Converters;

[ValueConversion(typeof(int), typeof(string))]
public class TextToIntConverter : IValueConverter
{
    public object Convert(object value, Type targetType, object parameter, CultureInfo culture) 
        => value is int val ? val.ToString() : "1";

    public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        => value is string text && int.TryParse(text, out var data)
            ? data
            : 0;
}