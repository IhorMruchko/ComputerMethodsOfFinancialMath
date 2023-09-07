using ComputerMethodsOfFinancialMath.LIB.Helpers;
using System;

namespace ComputerMethodsOfFinancialMath.LIB.Entities
{
    public class Value
    {
        public double MoneySum { get; protected set; }

        public float InterestRate { get; protected set; }

        public DateTime CurrentDate { get; protected set; } = DateTime.Now;


        public Value ChangeRate(float interestRate)
        {
            if (interestRate < 0 || interestRate > 1)
                throw new ArgumentException($"[{interestRate}] must be between 0 and 1.", nameof(interestRate));

            InterestRate = interestRate;
            return this;
        }

        public Value ChangeMoneySum(double moneySum)
        {
            if (moneySum <= 0)
                throw new ArgumentException($"[{moneySum}] must be grater than zero.", nameof(moneySum));

            return this;
        }

        public Value ChangeCurrentDate(DateTime date)
        {
            CurrentDate = date;
            return this;
        }

        public static Value operator +(Value value, int years) 
            => ValueHelpers.FutureDiscrete(value, years);

        public static Value operator +(Value value, DateTime timePeriod)
          => ValueHelpers.FutureContinuous(value, timePeriod);

        public static Value operator -(Value value, int year) 
            => ValueHelpers.PresentDiscrete(value, year);

        public static Value operator -(Value value, DateTime timePerion)
          => ValueHelpers.PresentContinuous(value, timePerion);


        public static implicit operator Value(double money) 
            => new Value()
               .ChangeMoneySum(money)
               .ChangeRate(0.1f);
    }
}
