using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Financial_Calculator.RegexCheck;

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

            string fvAndPVString = Check.RegexSuccess(fvAndPVMatch, "future value or present value");
            string rString = Check.RegexSuccess(rMatch, "rate of return");
            string nString = Check.RegexSuccess(nMatch, "number of periods");

            fvAndPVString = fvAndPVString.Replace(",", ""); // problem with Culture
            rString = rString.Replace(",", ".");
            rString = rString.Replace("%", "");
            nString = nString.Replace(" years", "");
            PresentValueOrFutureValue = decimal.Parse(fvAndPVString.Substring(1, fvAndPVString.Length - 1));
            RateOfReturn = double.Parse(rString);
            NumOfPeriods = LetterNumbersToNumbers.CheckIfStringIsNumber(nString);
            NumberOfCompoundingPeriods = CompoundInterestIdentifier.Identifier(text);  // for FV Compound Interest
        }

        public abstract decimal Result();

    }
}
