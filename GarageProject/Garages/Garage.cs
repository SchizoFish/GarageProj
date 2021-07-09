using GarageProject.Entities.Vehicles;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GarageProject.Garages
{
    class Garage<T> : IEnumerable, IGarage where T : Vehicle
    {
        // Properties and fields

        // List of vehicles in garage
        private IVehicle[] vehicles;
        public IVehicle[] Vehicles
        {
            get { return vehicles; }
            set { vehicles = value; }
        }

        // Chosen capacity by the user
        public int Capacity { get; set; }

        public Garage(int capacity)
        {
            this.Capacity = capacity;
            Vehicles = new Vehicle[capacity];
        }

        public IEnumerator GetEnumerator()
        {
            foreach (object o in Vehicles)
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
