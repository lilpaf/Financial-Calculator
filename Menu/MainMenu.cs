using System;

namespace Financial_Calculator
{
    class MainMenu
    {
        public static int MenuText()
        {
            Console.WriteLine("Welcome to the financial calculator that takes values from a text and solve the equation");
            Console.WriteLine("READ THE INSTRUCTION CAREFULLY BEFORE USE!!!");
            Console.WriteLine();
            Console.WriteLine("Enter the number corresponding to the value you want to get");
            Console.WriteLine();
            Console.WriteLine("Enter 1 for Future value when accruing interest is only once in a year");
            //Console.WriteLine("Enter 2 for Future value when accruing interest is more than once in a year"); // in development
            Console.WriteLine("Enter 3 for Present value");
            // Console.WriteLine("Enter 4 Zero-Coupon Bond value ");


            int functonToeqecute = int.Parse(Console.ReadLine());
            return functonToeqecute;
        }

        public static void BackToMenu()
        {
            Console.WriteLine($"Press any button to get back to the menu");
            Console.ReadKey();
            Console.WriteLine();
        }
    }
}
