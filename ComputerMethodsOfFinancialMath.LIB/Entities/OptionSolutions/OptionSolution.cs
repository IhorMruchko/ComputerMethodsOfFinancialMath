using ComputerMethodsOfFinancialMath.LIB.Entities.Options;

namespace ComputerMethodsOfFinancialMath.LIB.Entities.OptionSolutions
{
    public abstract class OptionSolution
    {
        public double Sigma { get; protected set; }

        public Value Value { get; protected set; }

        public Option Option { get; protected set; }

        public abstract double Call();

        public abstract double Put();

        public OptionSolution(double sigma, Value value, Option option)
        {
            Sigma = sigma;
            Value = value;
            Option = option;
        }
    }
}
