using System;
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
                    int functonToeqecute = MainMenu.MenuText();
                    Console.WriteLine();
                    
                    if (functonToeqecute == 1)
                    {
                        FVInterestOnceAYear formula = new FVInterestOnceAYear();
                        formula.InputValues();
                        Console.WriteLine($"The future value is: {formula.Result():F2}");
                        MainMenu.BackToMenu();
                    }
                    /*else if (functonToeqecute == 2)
                    {
                        FVIntrestRateMoreThanOnceAYear formula = new FVIntrestRateMoreThanOnceAYear();
                        formula.InputValues();
                        Console.WriteLine($"The future value is: {formula.Result():F2}");
                        MainMenu.BackToMenu();
                    }*/
                    else if (functonToeqecute == 3)
                    {
                        PresentValue formula = new PresentValue();
                        formula.InputValues();
                        Console.WriteLine($"The present value is: {formula.Result():F2}");
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
