using System;
using Financial_Calculator.Abstract_Classes;

namespace Financial_Calculator.Formulas
{
    public class FVIntrestRateMoreThanOnceAYear : PVAndFVFormulas
    {
        
        public override decimal Result()
        {
            return base.PresentValueOrFutureValue * (decimal)Math.Pow(1 + ((base.RateOfReturn / 100) / base.NumberOfCompoundingPeriods), base.NumberOfCompoundingPeriods * base.NumOfPeriods);
        }
    }
}
