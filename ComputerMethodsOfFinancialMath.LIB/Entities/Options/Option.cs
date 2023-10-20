namespace ComputerMethodsOfFinancialMath.LIB.Entities.Options
{
    public class Option
    {
        // S
        public double StrikePrice {get; protected set;}

        // E
        public double ActionPrice { get; protected set;} 

        public int Years { get; protected set;}

        public Option(double s, double k, int t) 
        {
            ActionPrice = s;
            StrikePrice = k;
            Years = t;
        }
    }
}
