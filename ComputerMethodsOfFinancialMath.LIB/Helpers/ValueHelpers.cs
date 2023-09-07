using ComputerMethodsOfFinancialMath.LIB.Entities;
using System;

namespace ComputerMethodsOfFinancialMath.LIB.Helpers
{
    internal static class ValueHelpers
    {
        public static Value FutureDiscrete(Value source, int years) 
            => years <= 0
            ? throw new ArgumentException($"{years} can not be less than zero.", nameof(years))
            : new Value()
            {
                MoneySum = source.MoneySum * Math.Pow(1 + source.InterestRate, years),
                InterestRate = source.InterestRate,
                CurrentDate = source.CurrentDate.AddYears(years),
            };

        public static Value FutureContinuous(Value source, DateTime years)
           => TimeHelper.IsPastDate(source.CurrentDate, years)
           ? throw new ArgumentException($"{years} must be future date.", nameof(years))
           : new Value()
           {
               MoneySum = source.MoneySum * Math.Pow(Math.E, source.InterestRate*TimeHelper.FromDateTime(source.CurrentDate, years)),
               InterestRate = source.InterestRate,
               CurrentDate = years
           };

        public static Value PresentDiscrete(Value source, int years)
          => years <= 0
          ? throw new ArgumentException($"{years} can not be less than zero.", nameof(years))
          : new Value()
          {
              MoneySum = source.MoneySum / Math.Pow(1 + source.InterestRate, years),
              InterestRate = source.InterestRate,
              CurrentDate = source.CurrentDate.AddYears(-years),
          };

        public static Value PresentContinuous(Value source, DateTime years)
          => TimeHelper.IsFutureDate(source.CurrentDate, years)
          ? throw new ArgumentException($"{years} must be past date.", nameof(years))
          : new Value()
          {
              MoneySum = source.MoneySum * Math.Pow(Math.E, -source.InterestRate * TimeHelper.FromDateTime(source.CurrentDate, years)),
              InterestRate = source.InterestRate,
              CurrentDate = years
          };
    }
}
