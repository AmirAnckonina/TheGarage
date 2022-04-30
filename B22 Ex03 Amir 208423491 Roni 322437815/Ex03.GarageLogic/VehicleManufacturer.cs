using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ex03.GarageLogic
{
    public class VehicleManufacturer
    {
        public enum eVehicleType
        {
            Car,
            Motorcycle,
            Truck
        }

/*        public VehicleManufacturer()
        {
            
        }*/

        public Vehicle ManufactureNewVehicle(ManufactureDetails i_ManufactureDetails)
        {
            Vehicle newVehicle;

            if (i_ManufactureDetails.VehicleType == eVehicleType.Car)
            {
                newVehicle = ManufactureNewCar(i_ManufactureDetails);
            }

            else if (i_ManufactureDetails.VehicleType == eVehicleType.Motorcycle)
            {

            }

            else if (i_ManufactureDetails.VehicleType == eVehicleType.Truck)
            {

            }

            else
            {
                /// Throw Exception (Argument?)
            }
        }

        public Car ManufactureNewCar(ManufactureDetails i_ManufactureDetails)
        {
            ///Car newCar = new Car(i_ManufactureDetails.LicenceID, i_ManufactureDetails.)
        }


    }
}
