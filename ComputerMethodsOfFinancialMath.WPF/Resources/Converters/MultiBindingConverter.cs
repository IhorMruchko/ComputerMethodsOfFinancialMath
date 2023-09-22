using System;
using System.Globalization;
using System.Windows.Data;

namespace ComputerMethodsOfFinancialMath.WPF.Resources.Converters;

public class MultiBindingConverter : IMultiValueConverter
{
    public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture) => values.Clone();

    public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture) => Array.Empty<object>();
}
