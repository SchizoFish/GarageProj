using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GarageProject.UIs
{
    public interface IUI
    {
        void Menu();
        void UserInput();
        void CreateGarage();

        void AddVehicle();

        void RemoveVehicle();

        void FindVehicle();

        void SortByValue();
    }
}       