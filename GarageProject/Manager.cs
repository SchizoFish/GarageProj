using System;
using System.Collections.Generic;
using GarageProject.UIs;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GarageProject.Garages;

namespace GarageProject
{
    public class Manager
    {
        public IUI newUI = new ConsoleUI();
        public IGarageHandler handler = new GarageHandler();
        public static bool show = true;

        public void RunProgram()
        {
            do
            {
                newUI.Menu();

            } while (show);
        }

        public void ListVehicles()
        {
            List<string> list = handler.ListVehicles();

            foreach (var vehicleInfo in list)
            {
                Console.WriteLine(vehicleInfo);
            }
        }
    }
}
