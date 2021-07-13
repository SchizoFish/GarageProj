using Microsoft.VisualStudio.TestTools.UnitTesting;
using GarageProject.Garages;
using GarageProject.Entities.Vehicles;
using Moq;
using GarageProject.UIs;

namespace GarageProject.Tests
{
    [TestClass]
    public class UnitTest1
    {
        private IGarageHandler testHandler;
        private IUI testUI;

        [TestInitialize]
        public void Init()
        {
            testHandler = new GarageHandler();
            testUI = new ConsoleUI();
        }

        [TestMethod]
        public void CreatesGarageWithGivenCapacity()
        {
            testHandler.CreateGarage(5);

            int expected = 5;

            Assert.AreEqual(expected, testHandler.Garage.Vehicles.Length);

        }

        [TestMethod]
        public void AddsVehicleToGarage()
        {
            testHandler.CreateGarage(1);

            string reg = "HJK234";
            string colour = "Red";
            int wheels = 4;
            double passengers = 5;
            string brand = "Ford";
            double maxSpeed = 110;

            IVehicle vehicle = new Car(reg, colour, wheels, passengers, brand, maxSpeed);

            testHandler.AddVehicle(vehicle);

            Assert.AreEqual(reg, testHandler.Garage.Vehicles[0].RegNr);

        }

        [TestMethod]
        public void RemovesVehicleFromGarage()
        {
            testHandler.CreateGarage(3);

            IVehicle vehicle1 = new Car("HJK234", "Red", 4, 5, "Ford", 110);
            IVehicle vehicle2 = new Car("YUI123", "Blue", 4, 5, "Volvo", 110);
            IVehicle vehicle3 = new Car("KLO567", "red", 4, 5, "Toyota", 110);

            testHandler.AddVehicle(vehicle1);
            testHandler.AddVehicle(vehicle2);
            testHandler.AddVehicle(vehicle3);

            testHandler.RemoveVehicle("YUI123");

            string expected = "HJK234 KLO567";
            string result = $"{testHandler.Garage.Vehicles[0].RegNr} {testHandler.Garage.Vehicles[1].RegNr}";

            Assert.AreEqual(expected, result);
            // Referensen (handle) är felaktig ?

        }

        [TestMethod]
        public void FindsBasedOnReg()
        {
            testHandler.CreateGarage(3);

            IVehicle vehicle1 = new Car("HJK234", "Red", 4, 5, "Ford", 110);
            IVehicle vehicle2 = new Car("YUI123", "Blue", 4, 5, "Volvo", 110);
            IVehicle vehicle3 = new Car("KLO567", "red", 4, 5, "Toyota", 110);

            testHandler.AddVehicle(vehicle1);
            testHandler.AddVehicle(vehicle2);
            testHandler.AddVehicle(vehicle3);

            string expected = $"Vehicle: \n{ vehicle2.RegNr}\n{ vehicle2.Colour}\n";
            string result = testHandler.FindReg("YUI123");

            Assert.AreEqual(expected, result);

        }

        [TestMethod]
        public void CorrectlyTellsIfGarageIsFull()
        {
            testHandler.CreateGarage(3);

            IVehicle vehicle1 = new Car("HJK234", "Red", 4, 5, "Ford", 110);
            IVehicle vehicle2 = new Car("YUI123", "Blue", 4, 5, "Volvo", 110);
            IVehicle vehicle3 = new Car("KLO567", "red", 4, 5, "Toyota", 110);

            testHandler.AddVehicle(vehicle1);
            testHandler.AddVehicle(vehicle2);
            testHandler.AddVehicle(vehicle3);

            bool expected = true;
            bool result = testHandler.IsGarageFull();

            Assert.AreEqual(expected, result);

        }

        [TestMethod]
        public void IdentifiesExistingReg()
        {
            testHandler.CreateGarage(4);

            IVehicle vehicle1 = new Car("HJK234", "Red", 4, 5, "Ford", 110);
            IVehicle vehicle2 = new Car("YUI123", "Blue", 4, 5, "Volvo", 110);
            IVehicle vehicle3 = new Car("KLO567", "red", 4, 5, "Toyota", 110);
            IVehicle vehicle4 = vehicle1;

            // Cars with regs
            testHandler.AddVehicle(vehicle1);
            testHandler.AddVehicle(vehicle2);
            testHandler.AddVehicle(vehicle3);

            bool expected = false;
            bool result = testHandler.CheckRegNrIsNew("KLO567"); 

            Assert.AreEqual(expected, result);

        }

        [TestCleanup]
        public void CleanUp()
        {
            testHandler = null;
        } 

    }
}
