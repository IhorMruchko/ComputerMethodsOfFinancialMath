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

        public static Value FutureContinuous(Value source, float years)
         => years <= 0
         ? throw new ArgumentException($"{years} must be grater than 0.", nameof(years))
         : new Value()
         {
             MoneySum = source.MoneySum * Math.Pow(Math.E, source.InterestRate *  years),
             InterestRate = source.InterestRate,
             CurrentDate = Add(source.CurrentDate, TimeHelper.FromFloat(years))
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

        public static Value PresentContinuous(Value source, float years)
         => years <= 0
         ? throw new ArgumentException($"{years} must be grater than 0", nameof(years))
         : new Value()
         {
             MoneySum = source.MoneySum * Math.Pow(Math.E, -source.InterestRate * years),
             InterestRate = source.InterestRate,
             CurrentDate = Subtrack(source.CurrentDate, TimeHelper.FromFloat(years))
         };

        private static DateTime Add(DateTime date, (int years, int month, int days) convertedValues) 
            => date.AddYears(convertedValues.years)
                .AddMonths(convertedValues.month)
                .AddDays(convertedValues.days);

        private static DateTime Subtrack(DateTime date, (int years, int month, int days) convertedValues)
            => date.AddYears(-convertedValues.years)
                .AddMonths(-convertedValues.month)
                .AddDays(-convertedValues.days);
    }
}
