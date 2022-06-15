using System;
using System.Text.RegularExpressions;
using Financial_Calculator.RegexCheck;

namespace Financial_Calculator
{
    public class FVInterestOnceAYear : IFormula
    {
        protected decimal presentValue;
        protected double interestRate;
        private int years;

        protected double InterestRate
        {
            get => this.interestRate;
            set
            {
                if (value <= 0)
                {
                    throw new ArgumentOutOfRangeException("Value can not be less than 1");
                }

                this.interestRate = value;
            }
        }
        protected decimal PresentValue
        {
            get => this.presentValue;
            set
            {
                if (value <= 0)
                {
                    throw new ArgumentOutOfRangeException("Value can not be less than 1");
                }

                this.presentValue = value;
            }
        }

        protected int Years
        {
            get => this.years;
            set
            {
                if (value <= 0)
                {
                    throw new ArgumentOutOfRangeException("Value can not be less than 1");
                }

                this.years = value;
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

            fvString = fvString.Replace(",", ""); // problem with Culture
            //rString = rString.Replace(",", "");
            rString = rString.Replace("%", "");
            nString = nString.Replace(" years", "");
            PresentValue = decimal.Parse(fvString.Substring(1, fvString.Length - 1));
            InterestRate = double.Parse(rString);
            Years = LetterNumbersToNumbers.CheckIfStringIsNumber(nString);

        }

        public decimal Result()
        {
            return presentValue * (decimal) Math.Pow(1 + (interestRate / 100), years);
        }
    }
}
