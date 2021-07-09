using GarageProject.Entities.Vehicles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GarageProject.Garages
{
    public interface IGarage
    {
        public IVehicle[] Vehicles { get; set; }
        public int Capacity { get; set; }

    }
}
