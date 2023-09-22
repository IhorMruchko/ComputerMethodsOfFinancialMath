using System;
using System.Collections.Generic;
using System.Linq;

namespace ComputerMethodsOfFinancialMath.LIB.Entities.Solutions
{
    public class AnalyticSolution : Solution
    {
        public AnalyticSolution(double startMoney, WiennerProcess process) : base(startMoney, process) { }

        public override List<double> Solve() 
            => Process.Time.Zip(Process.WiennerValues, (time, w) => (time, w))
                           .Select(data => Math.Exp((Process.Mu - 0.5d * Math.Pow(Process.Sigma, 2)) * data.time + (Process.Sigma * data.w)) * StartMoney)
                           .ToList();
    }
}
