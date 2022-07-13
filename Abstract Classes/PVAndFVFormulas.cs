using System;
using System.Text.RegularExpressions;
using Financial_Calculator.Checks;

namespace Financial_Calculator.Abstract_Classes
{
    public abstract class PVAndFVFormulas : IFormula
    {
        private decimal PresentValueOrFutureValueOrFutureValueOrFutureValue;
        private double rateOfReturn;
        private int numOfPeriods;
        private int numberOfCompoundingPeriods;

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
        protected decimal PresentValueOrFutureValue
        {
            get => this.PresentValueOrFutureValueOrFutureValueOrFutureValue;
            set
            {
                if (value <= 0)
                {
                    throw new ArgumentOutOfRangeException("Value can not be less than 1");
                }

                this.PresentValueOrFutureValueOrFutureValueOrFutureValue = value;
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
        
        protected int NumberOfCompoundingPeriods
        {
            get => this.numberOfCompoundingPeriods;
            set
            {
                if (value <= 0)
                {
                    throw new ArgumentOutOfRangeException("Value can not be less than 1");
                }

                this.numberOfCompoundingPeriods = value;
            }
        }

        public void InputValues(string text)
        {
            text = text.Replace("percent", "%");

            string patternForFVAndPV = @"[$||€][ ]?[0-9]*[.||,]*[0-9]*";
            string patternForRateOfReturn = @"[0-9]*[.||,]*[0-9]*[ ]?%";
            string patternForYears = @"[0-9||a-z]* years";

            Regex rgFVAndPV = new Regex(patternForFVAndPV);
            Regex rgR = new Regex(patternForRateOfReturn);
            Regex rgN = new Regex(patternForYears);

            
            Match fvAndPVMatch = rgFVAndPV.Match(text);
            Match rMatch = rgR.Match(text);
            Match nMatch = rgN.Match(text);

            // Checks if the match succeded and returns the match to string
            string fvAndPVString = RegexCheck.RegexSuccess(fvAndPVMatch, "future value or present value");
            string rString = RegexCheck.RegexSuccess(rMatch, "rate of return");
            string nString = RegexCheck.RegexSuccess(nMatch, "number of periods");

            // Preparing the string to be parsed
            fvAndPVString = fvAndPVString.Replace(",", ""); // problem with Culture
            rString = rString.Replace(",", ".");
            rString = rString.Replace("%", "");
            nString = nString.Replace(" years", "");

            PresentValueOrFutureValue = decimal.Parse(fvAndPVString.Substring(1, fvAndPVString.Length - 1));
            RateOfReturn = double.Parse(rString);

            // Checks
            // returns a number if the num is written it max value to return is 20
            NumOfPeriods = LetterNumbersToNumbers.CheckIfStringIsNumber(nString);

            // Returns a fraction of a year based on the compound period
            NumberOfCompoundingPeriods = CompoundInterestIdentifier.Identifier(text);  // for FV Compound Interest
        }

        public abstract decimal Result();

    }
}
