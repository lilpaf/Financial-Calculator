using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Financial_Calculator.RegexCheck
{
    public class LetterNumbersToNumbers
    {
        private static Dictionary<string, int> letterNumbersToNumbers = new Dictionary<string, int>()
        {
            {"one", 1 },
            {"two", 2 },
            {"three", 3 },
            {"four", 4 },
            {"five", 5 },
            {"six", 6 },
            {"seven", 7 },
            {"eight", 8 },
            {"nine", 9 },
            {"ten", 10 },
            {"eleven", 11 },
            {"twelve", 12 },
            {"thirteen", 13 },
            {"fourteen", 14 },
            {"fifteen", 15 },
            {"sixteen", 16 },
            {"seventeen", 17 },
            {"eighteen", 18 },
            {"nineteen", 19 },
            {"twenty", 20 },
        };

        public static int CheckIfStringIsNumber (string stringToCheck)
        {
            if (letterNumbersToNumbers.ContainsKey(stringToCheck))
            {
                return letterNumbersToNumbers[stringToCheck];
            }

            return int.Parse(stringToCheck);
        }
    }
}
