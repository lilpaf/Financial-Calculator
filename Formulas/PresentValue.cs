using System;
using System.Text.RegularExpressions;
using Financial_Calculator.RegexCheck;

namespace Financial_Calculator.Formulas
{
    class PresentValue : IFormula
    {
        private decimal futureValue;
        private double rateOfReturn;
        private int numOfPeriods;

        protected decimal FutureValue
        {
            get => this.futureValue;
            set
            {
                if (value <= 0)
                {
                    throw new ArgumentOutOfRangeException("Value can not be less than 1");
                }

                this.futureValue = value;
            }
        }
        protected double RateOfReturn
        {
            get => this.rateOfReturn;
            set
            {
                if (value <= 0)
                {
                    throw new ArgumentOutOfRangeException("Value can not be less than 1");
                }

                this.rateOfReturn = value;
            }
        }

        protected int NumOfPeriods
        {
            get => this.numOfPeriods;
            set
            {
                if (value <= 0)
                {
                    throw new ArgumentOutOfRangeException("Value can not be less than 1");
                }

                this.numOfPeriods = value;
            }
        }

        public void InputValues()
        {
            Console.WriteLine("Enter your text:");
            string text = Console.ReadLine();
            text = text.Replace(" percent", "%");

            string patternForFV = @"[$||€][0-9]*[.||,]*[0-9]*";
            string patternForRateOfReturn = @"[0-9]*[.||,]*[0-9]*%";
            string patternForYears = @"[0-9||a-z]* years";
            
            Regex rgFV = new Regex(patternForFV);
            Regex rgR = new Regex(patternForRateOfReturn);
            Regex rgN = new Regex(patternForYears);

            Match fvMatch = rgFV.Match(text);
            Match rMatch = rgR.Match(text);
            Match nMatch = rgN.Match(text);

            string fvString = Check.RegexSuccess(fvMatch, "future value");
            string rString = Check.RegexSuccess(rMatch, "rate of return");
            string nString = Check.RegexSuccess(nMatch, "number of periods");

            fvString = fvString.Replace("," , ""); // problem with Culture
            rString = rString.Replace("," , ".");
            rString = rString.Replace("%" , "");
            nString = nString.Replace(" years", "");
            FutureValue = decimal.Parse(fvString.Substring(1, fvString.Length - 1));
            RateOfReturn = double.Parse(rString); 
            NumOfPeriods = LetterNumbersToNumbers.CheckIfStringIsNumber(nString);
        }

        public decimal Result()
        {
            return futureValue / (decimal) Math.Pow(1 + (rateOfReturn / 100), numOfPeriods);
        }
    }
}
