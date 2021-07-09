using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GarageProject.Entities.Vehicles
{
    class Boat : Vehicle
    {
        public double MaxSpeed
        {
            get { return MaxSpeed; }
            set { MaxSpeed = value; }
        }
        public Boat(string regnr, string colour, int wheels, double passengers, double maxspeed) : base(regnr, colour, wheels, passengers)
        {
            this.MaxSpeed = maxspeed;
        }
    }
}
