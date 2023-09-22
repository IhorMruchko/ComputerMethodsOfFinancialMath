using System;

namespace ComputerMethodsOfFinancialMath.LIB.Helpers
{
    public static class TimeHelper
    {
        public static float FromDateTime(DateTime first, DateTime second)
           => FromDateTime(Math.Abs(first.Year - second.Year),
                           Math.Abs(first.Month - second.Month),
                           Math.Abs(first.Day - second.Day));

        public static (int years, int month, int days) FromFloat(float value)
        {
            var years = (int)Math.Floor(value);
            var reminder = value - years;
            var month = (int)Math.Floor(reminder * 12);
            reminder -= month / 12f;
            var days = (int)Math.Round(reminder * 365.25);
            return (years, month, days);
        }

        public static float FromDateTime(DateTime deltaTime)
            => deltaTime.Year + deltaTime.Month / 12f + deltaTime.Day / 365.25f;

        public static float FromDateTime(int year, int month, int day)
          => year + month / 12f + day / 365.25f;

        public static bool IsFutureDate(DateTime present, DateTime future) 
            => present < future;

        public static bool IsPastDate(DateTime present, DateTime past)
            => present > past; 

        public static bool IsCurrentDate(DateTime present, DateTime current) 
            => present.Year == current.Year && present.Month == current.Month && present.Day == current.Day;
    }
}
