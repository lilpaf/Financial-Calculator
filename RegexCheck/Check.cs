using System;
using System.Text.RegularExpressions;

namespace Financial_Calculator.RegexCheck
{
    public class Check
    {
        public static string RegexSuccess (Match match, string value)
        {
            if (!match.Success)
            {
                throw new Exception($"Match for {value} failed");
            }

            return match.ToString();
        }

    }
}
