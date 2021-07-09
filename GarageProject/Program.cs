using GarageProject.UIs;
using System;

namespace GarageProject.UI
{
    class Program
    {
        static void Main(string[] args)
        {
            // Instansiates a User Interface and runs the program
            IUI newUI = new ConsoleUI();
            newUI.Menu();

            Console.WriteLine("Thank you!");
            Console.ReadKey();
        }
    }
}
