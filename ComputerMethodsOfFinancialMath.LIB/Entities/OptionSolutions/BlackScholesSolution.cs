using ComputerMethodsOfFinancialMath.LIB.Entities.Options;
using ComputerMethodsOfFinancialMath.LIB.Helpers;
using static System.Math;

namespace ComputerMethodsOfFinancialMath.LIB.Entities.OptionSolutions
{
    public class BlackScholesSolution : OptionSolution
    {
        public BlackScholesSolution(double sigma, Value value, Option option) : base(sigma, value, option) { }
        
        public override double Call()
        {
            var d1 = EvaluateD1();
            var d2 = EvaluateD2(d1);
            return Option.ActionPrice * OptionHelper.N(d1) - (Value - (float)Option.Years).MoneySum * OptionHelper.N(d2);
        }

        public override double Put()
        {
            var d1 = EvaluateD1();
            var d2 = EvaluateD2(d1);
            return -Option.ActionPrice * OptionHelper.N(-d1) + (Value - (float)Option.Years).MoneySum * OptionHelper.N(-d2);
        }

        protected virtual double EvaluateD1()
           => (Log(Option.ActionPrice / Option.StrikePrice) + (Value.InterestRate + (Pow(Sigma, 2) / 2)) * Option.Years) /
           (Sigma * Sqrt(Option.Years));

        protected double EvaluateD2(double d1)
            => d1 - (Sigma * Sqrt(Option.Years));
    }
}
