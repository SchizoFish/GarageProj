using GarageProject.Entities.Vehicles;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GarageProject.Garages
{
    public class GarageHandler : IEnumerable, IGarageHandler
    {
        // Properties and fields
        public IGarage Garage { get; set; }
        
        // Sets the garage capacity based on user input (parameter)
        public void CreateGarage(int capacity)
        {
            try
            {
                Garage = new Garage<Vehicle>(capacity);
                Console.Clear();
            }
            catch (Exception e)
            {
                Console.WriteLine($"ERROR: {e.Message}");
            }

        }

        // Checks if the garage (vehicles) is full or not
        public bool IsGarageFull()
        {
            return (Garage.Vehicles[Garage.Vehicles.Length - 1]) != null ? true : false;
        }

        // Writes out all of the vehicles in the garage
        public void ListVehicles()
        {
            try
            {
                // If the garage is not epmty
                if (Garage.Vehicles.Length > 0)
                {
                    for (int i = 0; i < Garage.Vehicles.Length; i++)
                    {
                        if (Garage.Vehicles[i] != null)
                        {
                            Console.WriteLine($"Reg Nr: {Garage.Vehicles[i].RegNr}\nColour: {Garage.Vehicles[i].Colour}\n\n");
                        }
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine($"ERROR: {e.Message}");
            }
        }

        // Counts all the types of vehicles in the garage, and then lists ammount
        public void ListVTypes()
        {
            var carNum = Garage.Vehicles.Where(x => x is Car).Count();
            var boatNum = Garage.Vehicles.Where(x => x is Boat).Count();
            var planeNum = Garage.Vehicles.Where(x => x is Airplane).Count();
            var busNum = Garage.Vehicles.Where(x => x is Bus).Count();
            var mcNum = Garage.Vehicles.Where(x => x is Motorcycle).Count();

            Console.WriteLine($"Cars: {carNum}\nBoats: {boatNum}\nBuses: {busNum}\nAirplanes: {planeNum}\nMtorocycles: {mcNum}");

        }

        // Takes in a vehicle sent by the user, and adds it to the garage
        public void AddVehicle(IVehicle vehicleToAdd)
        {
            try
            {
                for (int i = 0; i < Garage.Vehicles.Length; i++)
                {
                    if (Garage.Vehicles[i] == null)
                    {
                        Garage.Vehicles[i] = vehicleToAdd;
                        Console.Clear();
                        Console.WriteLine("Vehicle successfully added!");
                        break;
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine($"ERROR: {e.Message}");
            }
        }

        // Removes a vehicle from the garage based on input reg. nr
        public void RemoveVehicle(string regToRemove)
        {
            try
            {
                // Compares input reg. nr to vehicle reg. nr and removes if it matches
                Garage.Vehicles = Garage.Vehicles
                    .Where(x => x != null)
                    .Where(x => !x.RegNr.Equals(regToRemove.ToUpper())).ToArray();


                Console.Clear();
                Console.WriteLine("Vehicle successfully removed!");
            }
            catch (Exception e)
            {
                Console.WriteLine($"ERROR: {e.Message}");
                throw;
            }
        }

        // Finds a car based on reg. nr chosen by user
        public string FindReg(string regNr)
        {
            try
            {
                var foundV = from vehicle in Garage.Vehicles
                             .Where(x => x != null)
                             .Where(x => x.RegNr.Equals(regNr.ToUpper()))
                             select vehicle;

                string result = "";

                // Prints out the found vehicle
                foreach (var v in foundV)
                {
                    result = $"Vehicle: \n{v.RegNr}\n{v.Colour}\n";
                }

                return result;
            }
            catch (Exception e)
            {
                return $"ERROR: {e.Message}";
            }
        }

        // Asks user to chose which vehicle it wants to sort by
        public int PickVehicle()
        {
            int choice = 0;
            Console.WriteLine("Please choose type of vehicle\n");
            Console.WriteLine();
            Console.WriteLine("1. Car");
            Console.WriteLine("2. Boat");
            Console.WriteLine("3. Bus");
            Console.WriteLine("4. Airplane");
            Console.WriteLine("5. Motorcycle");
            ConsoleKeyInfo input = Console.ReadKey(true);

            switch (input.Key)
            {
                case ConsoleKey.NumPad1:
                    Console.Clear();
                    choice = 1;
                    break;
                case ConsoleKey.NumPad2:
                    Console.Clear();
                    choice = 2;
                    break;
                case ConsoleKey.NumPad3:
                    Console.Clear();
                    choice = 3;
                    break;
                case ConsoleKey.NumPad4:
                    Console.Clear();
                    choice = 4;
                    break;
                case ConsoleKey.NumPad5:
                    Console.Clear();
                    choice = 5;
                    break;
                default:
                    Console.Clear();
                    Console.WriteLine("Ogiltig inmatning");
                    break;
            }

            return choice;

        }

        // Based on bools, it picks values to sort vehicles by, and then lists them
        public void SortByValue(bool vehicleSort, bool colourSort, bool wheelSort, bool passSort)
        {
            var result = from vehicle in Garage.Vehicles
                         .Where(x => x is Vehicle)
                         select vehicle;

            // If user has chosen to sort by vehicle, read input and sort
            if (vehicleSort)
            {
                Console.WriteLine("Vehicle to search for: ");
                string input = Console.ReadLine().ToLower();

                if (input == "car")
                {
                    result = from vehicle in Garage.Vehicles
                             .Where(x => x != null)
                             .Where(x => x is Car)
                             select vehicle;
                }
                else if (input == "boat")
                {
                    result = from vehicle in Garage.Vehicles
                             .Where(x => x != null)
                             .Where(x => x is Boat)
                             select vehicle;
                }
                else if (input == "bus")
                {
                    result = from vehicle in Garage.Vehicles
                             .Where(x => x != null)
                             .Where(x => x is Bus)
                             select vehicle;
                }
                else if (input == "airplane")
                {
                    result = from vehicle in Garage.Vehicles
                             .Where(x => x != null)
                             .Where(x => x is Airplane)
                             select vehicle;
                }
                else if (input == "motorcycle")
                {
                    result = from vehicle in Garage.Vehicles
                             .Where(x => x != null)
                             .Where(x => x is Motorcycle)
                             select vehicle;
                }
            }

            // If user has chosen to sort by colour, read input and sort
            if (colourSort)
            {
                Console.WriteLine("Colour to search for: ");
                string input = Console.ReadLine().ToUpper();

                if (!String.IsNullOrEmpty(input))
                {
                    result = from vehicle in Garage.Vehicles
                             .Where(x => x != null)
                             .Where(x => x.Colour == input)
                             select vehicle;
                }
            }

            // If user has chosen to sort by wheels, read input and sort
            if (wheelSort)
            {
                Console.WriteLine("Number of wheels: ");
                int input = int.Parse(Console.ReadLine());

                if (input != 0)
                {
                    result = from vehicle in Garage.Vehicles
                             .Where(x => x != null)
                             .Where(x => x.Wheels == input)
                             select vehicle;
                }
            }

            // If user has chosen to sort by passengers, read input and sort
            if (passSort)
            {
                Console.WriteLine("Number of wheels: ");
                double input = double.Parse(Console.ReadLine());

                if (input != 0)
                {
                    result = from vehicle in Garage.Vehicles
                             .Where(x => x != null)
                             .Where(x => x.Passengers == input)
                             select vehicle;
                }
            }

            Console.Clear();

            // Based on chosen sorts, loop through result and print
            foreach (var v in result)
            {
                Console.WriteLine($"Vehicle: \n{v.RegNr}\n{v.Colour}\n");
            }

        }

        public IEnumerator GetEnumerator()
        {
            foreach (object o in Garage.Vehicles)
            {
                if (o == null)
                {
                    break;
                }
                yield return o;
            }
        }
    }
}
