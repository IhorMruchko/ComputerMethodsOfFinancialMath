using ComputerMethodsOfFinancialMath.LIB.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ComputerMethodsOfFinancialMath.LIB.Entities
{
    public class WiennerProcess
    {
        public int Years { get; protected set; }

        public int Slices { get; protected set; }

        public double Delta { get; protected set; }

        public double Mu { get; protected set; }

        public double Sigma { get; protected set; }

        public List<double> Time { get; protected set; } = new List<double>();

        public List<double> WiennerValues { get; protected set; } = new List<double>();
        
        public WiennerProcess(int years=1, int slices=1000, double mu=0, double sigma=1) 
        { 
            Years = years;
            Slices = slices;
            Delta = years / (double)slices;
            Mu = mu; 
            Sigma = sigma;
            EvaluateTime();
            EvaluateWienner();
        }

        private void EvaluateWienner()
        {
            var random = new Random();
            var squareDelta = Math.Sqrt(Delta);
            WiennerValues = random.NextNormals(Slices, Mu, Sigma).Select(n => n * squareDelta).ToList().CumulativeSum();
            WiennerValues.Insert(0, 0d);
        }

        private void EvaluateTime()
        {
            Time.Clear();
            for(var i = 0d; i <= Years; i += Delta)
                Time.Add(i);
        }
    }
}
