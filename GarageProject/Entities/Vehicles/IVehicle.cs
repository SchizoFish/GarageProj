using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GarageProject.Entities.Vehicles
{
    public interface IVehicle
    {
        public string RegNr { get; set; }
        public string Colour { get; set; }
        public int Wheels { get; set; }
        public double Passengers { get; set; }
    }
}
