using System;
using System.Text.RegularExpressions;

namespace Financial_Calculator.Checks
{
    public class RegexCheck
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
