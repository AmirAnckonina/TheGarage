using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GarageLogic
{
    public class Garage
    {
        /// private readonly VehicleManufacturer r_vehicleManufactor = new VehicleManufacturer();
        private Dictionary<StringBuilder, Vehicle> r_AllGarageVehicles;

        public Garage()
        {
            r_AllGarageVehicles = new Dictionary<Vehicle, OwnerDetails>();
        }

    }
}
