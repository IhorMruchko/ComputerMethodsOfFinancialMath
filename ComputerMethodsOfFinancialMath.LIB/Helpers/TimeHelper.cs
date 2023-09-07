using System;

namespace ComputerMethodsOfFinancialMath.LIB.Helpers
{
    public static class TimeHelper
    {
        public static float FromDateTime(DateTime first, DateTime second)
           => FromDateTime(new DateTime(Math.Abs(first.Year - second.Year),
                                        Math.Abs(first.Month - second.Month),
                                        Math.Abs(first.Day - second.Day)));
        public static float FromDateTime(DateTime deltaTime)
            => deltaTime.Year + deltaTime.Month / 12f + deltaTime.Day / 365f;

        public static bool IsFutureDate(DateTime present, DateTime future) 
            => present.Year <= future.Year || present.Month <= future.Month || present.Day <= future.Day;

        public static bool IsPastDate(DateTime present, DateTime past)
            => present.Year >= past.Year || present.Month >= past.Month || present.Day >= past.Day;
    }
}
