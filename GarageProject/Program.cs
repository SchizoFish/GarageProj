using GarageProject.UIs;
using System;

namespace GarageProject.UI
{
    class Program
    {
        static void Main(string[] args)
        {
            // Instansiates the Manager and runs the program
            Manager manager = new Manager();
            manager.RunProgram();

            Console.WriteLine("Thank you!");
            Console.ReadKey();
        }
    }
}
