using System;
using System.Collections.Generic;
using System.Linq;

namespace ComputerMethodsOfFinancialMath.LIB.Extensions
{
    public static class RandomExtensions
    {
        public static double NextNormal(this Random random, double mu=0, double sigma = 1)
        {
            var u1 = 1 - random.NextDouble();
            var u2 = 1 - random.NextDouble();

            var normal = Math.Sqrt(-2 * Math.Log(u1))
                * Math.Sin(2 * Math.PI * u2);

            return mu + sigma * normal;
        }

        public static IEnumerable<double> NextNormals(this Random random, int amount, double mu = 0, double sigma = 1) 
            => Enumerable.Range(0, amount-1).Select(_ => random.NextNormal(mu, sigma));
    }
}
