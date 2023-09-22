using System.Collections.Generic;

namespace ComputerMethodsOfFinancialMath.LIB.Entities.Solutions
{
    public abstract class Solution
    {
        public double StartMoney { get; protected set; }

        public WiennerProcess Process { get; protected set; }

        public Solution(double startMoney, WiennerProcess process)
        {
            Process = process;
            StartMoney = startMoney;
        }

        public abstract List<double> Solve();
    }
}
