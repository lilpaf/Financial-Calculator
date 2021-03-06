using System;
using Financial_Calculator.Abstract_Classes;

namespace Financial_Calculator
{
    public class FVInterestOnceAYear : PVAndFVFormulas
    {
        
        public override decimal Result()
        {
            return base.PresentValueOrFutureValue * (decimal) Math.Pow(1 + (base.RateOfReturn / 100), base.NumOfPeriods);
        }
    }
}
