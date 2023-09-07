using System.Globalization;
using System.Windows.Controls;

namespace ComputerMethodsOfFinancialMath.WPF.Resources.Validation;

public class DoubleTextValidation : ValidationRule
{
    public override ValidationResult Validate(object value, CultureInfo cultureInfo) 
        => value is string text && double.TryParse(text.Replace('.', ','), out var data) && data > 0
            ? ValidationResult.ValidResult
            : new ValidationResult(false, "Cannot set double value");
}
