using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GarageProject.Entities.Vehicles
{
    class Airplane : Vehicle 
    {
        public int Motors
        {
            get { return Motors; }
            set { Motors = value; }
        }
        public Airplane(string regnr, string colour, int wheels, double passengers, int motors) : base(regnr, colour, wheels, passengers)
        {
            this.Motors = motors;
        }
    }
}
