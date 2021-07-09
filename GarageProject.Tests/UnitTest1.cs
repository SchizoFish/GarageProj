using Microsoft.VisualStudio.TestTools.UnitTesting;
using GarageProject.Garages;
using GarageProject.Entities.Vehicles;
using Moq;

namespace GarageProject.Tests
{
    [TestClass]
    public class UnitTest1
    {
        private IGarageHandler gHandler;

        [TestInitialize]
        public void Init()
        {
            gHandler = new GarageHandler();
        }

        [TestMethod]
        public void CreatesGarageWithGivenCapacity()
        {
            gHandler.CreateGarage(5);

            int expected = 5;

            Assert.AreEqual(expected, gHandler.Garage.Vehicles.Length);

        }

        [TestMethod]
        public void AddsVehicleToGarage()
        {
            gHandler.CreateGarage(1);

            IVehicle vehicleToAdd = new Car("HJK234", "Red", 4, 5, "Ford", 110);

            gHandler.AddVehicle(vehicleToAdd);

            Assert.AreEqual(vehicleToAdd.RegNr, gHandler.Garage.Vehicles[0].RegNr);

        }

        [TestMethod]
        public void RemovesVehicleFromGarage()
        {
            gHandler.CreateGarage(3);

            IVehicle vehicle1 = new Car("HJK234", "Red", 4, 5, "Ford", 110);
            IVehicle vehicle2 = new Car("YUI123", "Blue", 4, 5, "Volvo", 110);
            IVehicle vehicle3 = new Car("KLO567", "red", 4, 5, "Toyota", 110);

            gHandler.AddVehicle(vehicle1);
            gHandler.AddVehicle(vehicle2);
            gHandler.AddVehicle(vehicle3);

            gHandler.RemoveVehicle("YUI123");

            string expected = "HJK234 KLO567";
            string result = $"{gHandler.Garage.Vehicles[0].RegNr} {gHandler.Garage.Vehicles[1].RegNr}";

            Assert.AreEqual(expected, result);
            // Referensen (handle) är felaktig ?

        }

        [TestMethod]
        public void FindsBasedOnReg()
        {
            gHandler.CreateGarage(3);

            IVehicle vehicle1 = new Car("HJK234", "Red", 4, 5, "Ford", 110);
            IVehicle vehicle2 = new Car("YUI123", "Blue", 4, 5, "Volvo", 110);
            IVehicle vehicle3 = new Car("KLO567", "red", 4, 5, "Toyota", 110);

            gHandler.AddVehicle(vehicle1);
            gHandler.AddVehicle(vehicle2);
            gHandler.AddVehicle(vehicle3);

            string expected = $"Vehicle: \n{ vehicle2.RegNr}\n{ vehicle2.Colour}\n";
            string result = gHandler.FindReg("YUI123");

            Assert.AreEqual(expected, result);

        }

        [TestMethod]
        public void CorrectlyTellsIfGarageIsFull()
        {
            gHandler.CreateGarage(3);

            IVehicle vehicle1 = new Car("HJK234", "Red", 4, 5, "Ford", 110);
            IVehicle vehicle2 = new Car("YUI123", "Blue", 4, 5, "Volvo", 110);
            IVehicle vehicle3 = new Car("KLO567", "red", 4, 5, "Toyota", 110);

            gHandler.AddVehicle(vehicle1);
            gHandler.AddVehicle(vehicle2);
            gHandler.AddVehicle(vehicle3);

            bool expected = true;
            bool result = gHandler.IsGarageFull();

            Assert.AreEqual(expected, result);

        }

        [TestMethod]
        public void ReadsInputKeyCorrectly()
        {
            int result = gHandler.PickVehicle();
            int expected = 1;

            Assert.AreEqual(expected, result);

        }

        [TestCleanup]
        public void CleanUp()
        {
            gHandler = null;
        } 

    }
}
