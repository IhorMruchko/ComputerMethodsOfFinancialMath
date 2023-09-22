using System.Globalization;
using System.Windows.Controls;

namespace ComputerMethodsOfFinancialMath.WPF.Resources.Validation;

internal class FloatTextValidationClear : ValidationRule
{
    public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        => value is string text && float.TryParse(text.Replace('.', ','), out _)
            ? ValidationResult.ValidResult
            : new ValidationResult(false, "Value must be float.");
}
