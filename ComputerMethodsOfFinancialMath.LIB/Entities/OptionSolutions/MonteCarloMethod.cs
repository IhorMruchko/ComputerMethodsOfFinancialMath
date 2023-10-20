using ComputerMethodsOfFinancialMath.LIB.Entities.Options;
using ComputerMethodsOfFinancialMath.LIB.Entities.Solutions;
using System.Linq;
using static System.Math;

namespace ComputerMethodsOfFinancialMath.LIB.Entities.OptionSolutions
{
    public class MonteCarloMethod : OptionSolution
    {
        public uint Iterations { get; protected set; }

        public MonteCarloMethod(double sigma, Value value, Option option, uint n = 10_000) : base(sigma, value, option) 
            => Iterations = n < 10_000 ? 10_000 : n;

        public override double Call()
        {
            var call = new double[Iterations];
            
            for(var i = 0; i < Iterations; ++i)
            {
                var solution = new AnalyticSolution(Option.ActionPrice, new WiennerProcess(Option.Years, mu:Value.InterestRate, sigma:Sigma));
                var S = solution.Solve().Last();
                call[i] = Max(S - Option.StrikePrice, 0);
            }
            
            return Exp(-Value.InterestRate * Option.Years) * call.Average();
        }

        public override double Put()
        {
            var put = new double[Iterations];

            for (var i = 0; i < Iterations; ++i)
            {
                var solution = new AnalyticSolution(Option.ActionPrice, new WiennerProcess(Option.Years, mu:Value.InterestRate, sigma:Sigma));
                var S = solution.Solve().Last();
                put[i] = Max(Option.StrikePrice - S, 0);
            }

            return Exp(-Value.InterestRate * Option.Years) * put.Average();
        }
    }
}
