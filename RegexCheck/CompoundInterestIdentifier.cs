using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Financial_Calculator.RegexCheck
{
    public class CompoundInterestIdentifier
    {
        public static int Identifier(string text)
        {
            if (text.Contains("compounded monthly"))
            {
                return 12;
            }
            else if (text.Contains("compounded quarterly"))
            {
                return 4;
            }

            return 1; // by default compounded Annually
        }
          
    }
}
