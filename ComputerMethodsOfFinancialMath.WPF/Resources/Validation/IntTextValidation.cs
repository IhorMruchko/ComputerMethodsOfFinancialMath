using System;
using System.Globalization;
using System.Windows.Controls;

namespace ComputerMethodsOfFinancialMath.WPF.Resources.Validation;

class IntTextValidation : ValidationRule
{
    public override ValidationResult Validate(object value, CultureInfo cultureInfo)
         => value is string text && int.TryParse(text, out var data) && data != 0
             ? ValidationResult.ValidResult
             : new ValidationResult(false, "Cannot set int value");
}
