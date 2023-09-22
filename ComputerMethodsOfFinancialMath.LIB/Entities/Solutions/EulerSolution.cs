using System.Collections.Generic;

namespace ComputerMethodsOfFinancialMath.LIB.Entities.Solutions
{
    public class EulerSolution : Solution
    {
        public EulerSolution(double startMoney, WiennerProcess process) : base(startMoney, process)
        {
        }

        public override List<double> Solve()
        {
            var result = new List<double>() { StartMoney };

            for (var i = 1; i < Process.WiennerValues.Count; ++i)
                result.Add(result[i - 1] + Process.Mu * result[i - 1] * Process.Delta 
                    + Process.Sigma * result[i - 1] * (Process.WiennerValues[i] - Process.WiennerValues[i - 1]));

            return result;
        }
    }
}
