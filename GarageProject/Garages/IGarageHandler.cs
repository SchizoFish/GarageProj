using GarageProject.Entities.Vehicles;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GarageProject.Garages
{
    public interface IGarageHandler
    {
        public IGarage Garage { get; set; }

        public void CreateGarage(int capacity);
        public bool IsGarageFull();
        List<string> ListVehicles();
        void ListVTypes();
        void AddVehicle(IVehicle vehicle);
        bool CheckRegNrIsNew(string regNr);
        string RemoveVehicle(string regToRemove);
        string FindReg(string regNr);
        int PickVehicle();
        void SortByValue(bool vehicleSort, bool colourSort, bool wheelSort, bool passSort);
    }
}
