using EnergyManager.Presentation.Views;
using System;

namespace EnergyManager.Presentation
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var userInterface = new UserInterface();
            bool continueProgram = true;

            while (continueProgram)
            {
                int continueInterface = userInterface.ShowOptionsAsync().Result;
                if (continueInterface == 6) continueProgram = false;
            }

            Console.WriteLine("Have a good day.");
        }
    }
}
