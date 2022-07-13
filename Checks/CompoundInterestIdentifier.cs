
namespace Financial_Calculator.Checks
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
            else if (text.Contains("compounded semiannually"))
            {
                return 2;
            }

            return 1; // by default compounded Annually
        }
          
    }
}
