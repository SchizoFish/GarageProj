using GarageProject.Garages;
using GarageProject.Entities.Vehicles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GarageProject.UIs
{
    public class ConsoleUI : IUI
    {
        // Necessary
        public static Manager manager = new Manager();
        //public static bool show = true;
        public static bool contSort = true;
        public static bool hasGarage = false;

        // Starts the menu and asks the user for input
        public void Menu()
        {
            {
                Console.WriteLine();
                Console.WriteLine("Main menu\n");
                Console.WriteLine("Type the number of what you want to do\n\n");
                Console.WriteLine("0. Exit");
                Console.WriteLine("1. Create garage");
                Console.WriteLine("2. Park vehicle");
                Console.WriteLine("3. Remove vehicle from garage");
                Console.WriteLine("4. List vehicles in garage");
                Console.WriteLine("5. List types of vehicles in garage");
                Console.WriteLine("6. Find vehicle based on reg. number");
                Console.WriteLine("7. Find vehicles based on values");
                UserInput();

            }
        }

        // Read the user ipnut (key) and runs the chosen function
        public void UserInput()
        {
            ConsoleKeyInfo input = Console.ReadKey(true);

            switch (input.Key)
            {
                case ConsoleKey.NumPad0:
                    //show = false;
                    Console.Clear();
                    break;
                case ConsoleKey.NumPad1:
                    Console.Clear();
                    CreateGarage();
                    break;
                case ConsoleKey.NumPad2:
                    Console.Clear();
                    AddVehicle();
                    break;
                case ConsoleKey.NumPad3:
                    Console.Clear();
                    RemoveVehicle();
                    break;
                case ConsoleKey.NumPad4:
                    Console.Clear();
                    manager.ListVehicles();
                    break;
                case ConsoleKey.NumPad5:
                    Console.Clear();
                    manager.handler.ListVTypes();
                    break;
                case ConsoleKey.NumPad6:
                    Console.Clear();
                    FindVehicle();
                    break;
                case ConsoleKey.NumPad7:
                    Console.Clear();
                    SortByValue();
                    break;
                default:
                    Console.Clear();
                    Console.WriteLine("Ogiltig inmatning");
                    break;
            }

        }

        // Checks that garage does not already exist- and, if not, creates garage
        public void CreateGarage()
        {
            if (!hasGarage)
            {
                try
                {
                    Console.WriteLine("Add garage capacity: ");
                    int capacity = int.Parse(Console.ReadLine());
                    manager.handler.CreateGarage(capacity);
                    hasGarage = true;
                    Console.WriteLine("Garage created succesfully");
                }
                catch (Exception e)
                {
                    Console.WriteLine($"ERROR: {e.Message}");
                }
            }
            else
            {
                Console.WriteLine("Garage already created");
            }
        }

        // Checks if there's space in the garage, and then asks user for input on what vehicles to add
        public void AddVehicle()
        {
            if (hasGarage)
            {
                if (!manager.handler.IsGarageFull())
                {
                    try
                    {
                        Console.WriteLine("How many vehicles would you like to park? ");
                        int numToAdd = int.Parse(Console.ReadLine());
                        if (numToAdd > 0)
                        {
                            for (int i = 0; i < numToAdd; i++)
                            {
                                int pickedVehicle = manager.handler.PickVehicle();
                                Console.WriteLine("What is the vehicles reg. number? ");
                                string regnr = Console.ReadLine().ToUpper();
                                bool newReg = manager.handler.CheckRegNrIsNew(regnr);

                                // Checks that the reg nr is both correct and unique
                                if (regnr.Length != 6 || !newReg)
                                {
                                    do
                                    {
                                        Console.WriteLine("Reg. number must be 6 characters and unique. Please add the correct reg. number: ");
                                        regnr = Console.ReadLine().ToUpper();
                                        newReg = manager.handler.CheckRegNrIsNew(regnr);

                                    } while (regnr.Length != 6 || !newReg);
                                }

                                Console.WriteLine("What is the vehicles colour? ");
                                string colour = Console.ReadLine().ToUpper();
                                Console.WriteLine("How many wheels on the vehicle? ");
                                int wheels = int.Parse(Console.ReadLine());
                                Console.WriteLine("How many passengers does the vehicle hold? ");
                                double passengers = double.Parse(Console.ReadLine());

                                IVehicle vehicle = null;
                                if (pickedVehicle == 1)

                                {
                                    Console.WriteLine("What brand is the vehicle?");
                                    string brand = Console.ReadLine().ToUpper();
                                    Console.WriteLine("What is the vehicles max speed?");
                                    double maxSpeed = double.Parse(Console.ReadLine());
                                    vehicle = new Car(regnr, colour, wheels, passengers, brand, maxSpeed);
                                }
                                else if (pickedVehicle == 2)
                                {
                                    Console.WriteLine("What is the vehicles max speed?");
                                    double maxSpeed = double.Parse(Console.ReadLine());
                                    vehicle = new Boat(regnr, colour, wheels, passengers, maxSpeed);
                                }
                                else if (pickedVehicle == 3)
                                {
                                    Console.WriteLine("Is it a double decker - yes or no?");
                                    bool doubleDecker = false;
                                    string yOrNo = Console.ReadLine();
                                    if (yOrNo.ToLower() == "yes")
                                    {
                                        doubleDecker = true;
                                    }
                                    vehicle = new Bus(regnr, colour, wheels, passengers, doubleDecker);
                                }
                                else if (pickedVehicle == 4)
                                {
                                    Console.WriteLine("How many motors on the airplane?");
                                    int motors = int.Parse(Console.ReadLine());
                                    vehicle = new Airplane(regnr, colour, wheels, passengers, motors);
                                }
                                else if (pickedVehicle == 5)
                                {
                                    Console.WriteLine("What brand is the vehicle?");
                                    string brand = Console.ReadLine().ToUpper();
                                    Console.WriteLine("What is the vehicles max speed?");
                                    double maxSpeed = double.Parse(Console.ReadLine());
                                    Console.WriteLine("Is it a double decker - yes or no?");
                                    bool sideCar = false;
                                    string yOrNo = Console.ReadLine();
                                    if (yOrNo.ToLower() == "yes")
                                    {
                                        sideCar = true;
                                    }
                                    vehicle = new Motorcycle(regnr, colour, wheels, passengers, brand, maxSpeed, sideCar);
                                }

                                manager.handler.AddVehicle(vehicle);
                            }
                        }
                        else
                        {
                            Console.WriteLine("Number must be higher than 0");
                        }

                    }
                    catch (Exception e)
                    {
                        Console.WriteLine($"ERROR: {e.Message}");
                    }
                }
                else
                {
                    Console.WriteLine("Garage is full!");
                }
            }
            else
            {
                Console.WriteLine("Garage does not exist");
            }
            

        }

        // Asks user for vehicle reg. nr and calls method to remove
        public void RemoveVehicle()
        {
            try
            {
                Console.WriteLine("Please add the registration number of the vehicle you would like to remove: ");
                string input = Console.ReadLine();

                string result = manager.handler.RemoveVehicle(input.ToUpper());

                Console.WriteLine($"{result}");
            }
            catch (Exception e)
            {
                Console.WriteLine($"ERROR: {e.Message}");
            }
        }

        // Asks user for vehicle reg. nr and calls method to find vehicle
        public void FindVehicle()
        {
            try
            {
                Console.WriteLine("What is the reg. number of the vehicle? ");
                string input = Console.ReadLine();
                Console.Clear();
                string result = manager.handler.FindReg(input.ToUpper());
                Console.WriteLine($"{result}");
            }
            catch (Exception e)
            {
                Console.WriteLine($"ERROR: {e.Message}");
            }
        }

        // Asks user for sorting values through key input, and passes bools to sorting method based on what they've chosen
        public void SortByValue()
        {
            try
            {
                bool addValue = true;
                bool vehicSort = false;
                bool colSort = false;
                bool wheelSort = false;
                bool passSort = false;

                do
                {
                    Console.WriteLine("Pick what do you want to sort by?");
                    Console.WriteLine("1. Vehicle");
                    Console.WriteLine("2. Colour");
                    Console.WriteLine("3. Wheels");
                    Console.WriteLine("4. Passengers\n");
                    Console.WriteLine("When done picking values - press to sort:");
                    Console.WriteLine("5. Sort");

                    ConsoleKeyInfo input = Console.ReadKey(true);

                    switch (input.Key)
                    {
                        case ConsoleKey.NumPad1:
                            Console.Clear();
                            vehicSort = true;
                            break;
                        case ConsoleKey.NumPad2:
                            Console.Clear();
                            colSort = true;
                            break;
                        case ConsoleKey.NumPad3:
                            Console.Clear();
                            wheelSort = true;
                            break;
                        case ConsoleKey.NumPad4:
                            Console.Clear();
                            passSort = true;
                            break;
                        case ConsoleKey.NumPad5:
                            Console.Clear();
                            addValue = false;
                            break;
                        default:
                            Console.Clear();
                            Console.WriteLine("Ogiltig inmatning");
                            break;
                    }

                } while (addValue);

                manager.handler.SortByValue(vehicSort, colSort, wheelSort, passSort);
            }
            catch (Exception e)
            {
                Console.WriteLine($"ERROR: {e.Message}");
            }

                //sortedVehicles = new Vehicle[handler.SortByVehicle(garage.Vehicles, PickVehicle()).Count()];
                //handler.ListVehicles(sortedVehicles);
        }

    }
}
