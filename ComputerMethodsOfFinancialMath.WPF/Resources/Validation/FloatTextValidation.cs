using System.Globalization;
using System.Windows.Controls;

namespace ComputerMethodsOfFinancialMath.WPF.Resources.Validation;

public class FloatTextValidation : ValidationRule
{
    public override ValidationResult Validate(object value, CultureInfo cultureInfo) 
        =>value is string text && float.TryParse(text.Replace('.', ','), out var data) && data > 0 && data < 1
            ? ValidationResult.ValidResult
            : new ValidationResult(false, "Value must be float and between 0 and 1.");
}
