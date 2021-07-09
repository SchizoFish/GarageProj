using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GarageProject.Entities.Vehicles
{
    class Motorcycle : Vehicle
    {
        public string Brand
        {
            get { return Brand; }
            set { Brand = value; }
        }
        public double MaxSpeed
        {
            get { return MaxSpeed; }
            set { MaxSpeed = value; }
        }
        public bool HasSidecar { get; set; }
        public Motorcycle(string regnr, string colour, int wheels, double passengers, string brand, double maxspeed, bool hassidecar) : base(regnr, colour, wheels, passengers)
        {
            this.Brand = brand;
            this.MaxSpeed = maxspeed;
            this.HasSidecar = hassidecar;
        }
    }
}
