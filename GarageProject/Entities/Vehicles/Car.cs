using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GarageProject.Entities.Vehicles
{
    public class Car : Vehicle
    {
        public string Brand
        {
            get { return Brand; }
            set { }
        }
        public double MaxSpeed
        {
            get { return MaxSpeed; }
            set { }
        }
        public Car(string regnr, string colour, int wheels, double passengers, string brand, double maxspeed) : base(regnr, colour, wheels, passengers)
        {
            this.Brand = brand;
            this.MaxSpeed = maxspeed;
        }
    }
}
