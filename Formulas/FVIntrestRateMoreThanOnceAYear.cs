using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Financial_Calculator.Abstract_Classes;
using Financial_Calculator.RegexCheck;

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
