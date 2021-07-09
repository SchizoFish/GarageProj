using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GarageProject.Entities.Vehicles
{
    class Bus : Vehicle 
    {
        public bool IsDoubleDeck
        {
            get { return IsDoubleDeck; }
            set { IsDoubleDeck = value; }
        }
        public Bus(string regnr, string colour, int wheels, double passengers, bool isdouble) : base(regnr, colour, wheels, passengers)
        {
            this.IsDoubleDeck = isdouble;
        }
    }
}
