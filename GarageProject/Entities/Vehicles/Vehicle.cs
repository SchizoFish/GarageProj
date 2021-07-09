using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GarageProject.Entities.Vehicles
{
    public abstract class Vehicle : IVehicle
    {
        private string regNr;
        public string RegNr
        {
            get { return regNr; }
            set { regNr = value; }
        }

        private string colour;
        public string Colour
        {
            get { return colour; }
            set { colour = value; }
        }
        private int wheels;
        public int Wheels
        {
            get { return wheels; }
            set { wheels = value; }
        }
        private double passengers;
        public double Passengers
        {
            get { return passengers; }
            set { passengers = value; }
        }

        public Vehicle(string regnr, string colour, int wheels, double passengers)
        {
            this.RegNr = regnr.ToUpper();
            this.Colour = colour.ToUpper();
            this.Wheels = wheels;
            this.Passengers = passengers;
        }
    }
}
