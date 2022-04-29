using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GarageLogic
{
    public class VehicleManufacturer
    {
        public enum eVehicleType
        {
            Car,
            Motorcycle,
            Truck
        }

        public void CreateCar(eVehicleType i_VehicleType)
        {
            if (i_VehicleType == eVehicleType.Car)
            {
                new Car()
            }

        }
    }
}
