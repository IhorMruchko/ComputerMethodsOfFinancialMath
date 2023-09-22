using System;
using System.Collections.Generic;

namespace ComputerMethodsOfFinancialMath.LIB.Entities.Solutions
{
    public class MilsteinSolution : Solution
    {
        public MilsteinSolution(double startMoney, WiennerProcess process) : base(startMoney, process)
        {
        }

        public override List<double> Solve()
        {
            var result = new List<double>() { StartMoney };

            for (var i = 1; i < Process.WiennerValues.Count; ++i)
                result.Add(result[i - 1] + Process.Mu * result[i - 1] * Process.Delta +
                    Process.Sigma * result[i - 1] * (Process.WiennerValues[i] - Process.WiennerValues[i - 1]) +
                    0.5 * Process.Sigma * result[i - 1] * Process.Sigma * (Math.Pow(Process.WiennerValues[i] - Process.WiennerValues[i - 1], 2) - Process.Delta));

            return result;
        }
    }
}
