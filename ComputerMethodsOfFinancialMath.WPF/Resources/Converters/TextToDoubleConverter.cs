using System.Globalization;
using System;
using System.Windows.Data;

namespace ComputerMethodsOfFinancialMath.WPF.Resources.Converters;

[ValueConversion(typeof(string), typeof(double))]
class TextToDoubleConverter : IValueConverter
{
    public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
       => value is double val ? val.ToString().Replace('.', ',') : "500.0";

    public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        => value is string text && double.TryParse(text.Replace('.', ','), out var result)
        ? result
        : 500.0;
}
