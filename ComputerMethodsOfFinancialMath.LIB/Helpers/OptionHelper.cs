using System.Runtime.InteropServices;
using static System.Math;

namespace ComputerMethodsOfFinancialMath.LIB.Helpers
{
    public static class OptionHelper
    {
        [DllImport("ucrtbase.dll", EntryPoint = "erf")]
        static extern double Erf(double x);

        public static double N(double x) 
            => (Erf(x / Sqrt(2)) - Erf(double.NegativeInfinity / 2)) / 2;

    }
}
