using System;
using System.Text.RegularExpressions;
using Financial_Calculator.Abstract_Classes;
using Financial_Calculator.RegexCheck;

namespace Financial_Calculator.Formulas
{
    public class PresentValue : PVAndFVFormulas
    {
        
        public override decimal Result()
        {
            return base.PresentValueOrFutureValue / (decimal) Math.Pow(1 + (base.RateOfReturn / 100), base.NumOfPeriods);
        }
    }
}
