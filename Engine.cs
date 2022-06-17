using System;
using Financial_Calculator.Abstract_Classes;
using Financial_Calculator.Formulas;

namespace Financial_Calculator
{
    class Engine
    {
        static void Main(string[] args)
        {
            while (true)
            {
                try
                {
                    int functonToExecute = MainMenu.MenuText();
                    Console.WriteLine();
                    Console.WriteLine("Enter your text:");
                    string text = Console.ReadLine();
                    Console.WriteLine();

                    if (functonToExecute == 1)
                    {
                        PVAndFVFormulas futureValueOnceAYear = new FVInterestOnceAYear();
                        futureValueOnceAYear.InputValues(text);
                        Console.WriteLine($"The future value is: {futureValueOnceAYear.Result():F2}");
                        Console.WriteLine();
                        MainMenu.BackToMenu();
                    }
                    else if (functonToExecute == 2)
                    {
                        PVAndFVFormulas futureValueMoreThanOnceAYear = new FVIntrestRateMoreThanOnceAYear();
                        futureValueMoreThanOnceAYear.InputValues(text);
                        Console.WriteLine($"The future value is: {futureValueMoreThanOnceAYear.Result():F2}");
                        Console.WriteLine();
                        MainMenu.BackToMenu();
                    }
                    else if (functonToExecute == 3)
                    {
                        PVAndFVFormulas presentValue = new PresentValue();
                        presentValue.InputValues(text);
                        Console.WriteLine($"The present value is: {presentValue.Result():F2}");
                        Console.WriteLine();
                        MainMenu.BackToMenu();
                    }

                }
                catch (Exception ex)
                {
                    Console.WriteLine();
                    Console.WriteLine(ex.Message);
                    Console.WriteLine();
                    MainMenu.BackToMenu();
                }
            }
        }
    }
}
