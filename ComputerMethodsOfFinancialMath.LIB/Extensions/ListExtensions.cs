using System.Collections.Generic;

namespace ComputerMethodsOfFinancialMath.LIB.Extensions
{
    public static class ListExtensions
    {
        public static List<double> CumulativeSum(this List<double> soure)
        {
            for(var i = 1; i < soure.Count; ++i)
                soure[i] += soure[i - 1];

            return soure;
        }
    }
}
