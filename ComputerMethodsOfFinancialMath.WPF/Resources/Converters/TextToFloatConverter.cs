using System;
using System.Globalization;
using System.Windows.Data;

namespace ComputerMethodsOfFinancialMath.WPF.Resources.Converters;

[ValueConversion(typeof(string), typeof(float))]
public class TextToFloatConverter : IValueConverter
{
    public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        => value is float val ? val.ToString().Replace('.', ',') : "0,1";

    public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture) 
        => value is string text && float.TryParse(text.Replace('.', ','), out var result)
        ? result
        : 0.1f;
}
