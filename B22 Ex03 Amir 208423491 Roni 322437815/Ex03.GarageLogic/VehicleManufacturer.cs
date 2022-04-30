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

        public Vehicle ManufactureNewVehicle(ManufactureDetails i_ManufactureDetails)
        {
            Vehicle newVehicle = null;
            

            switch (i_ManufactureDetails.VehicleType)
            {
                case eVehicleType.Car:
                    newVehicle = ManufactureNewCar(i_ManufactureDetails);
                    break;

                case eVehicleType.Motorcycle:
                    newVehicle = ManufactureNewMotorcycle(i_ManufactureDetails);
                    break;
                case eVehicleType.Truck:
                    newVehicle = ManufactureNewTruck(i_ManufactureDetails);
                    break;

                default:
                    newVehicle = null;
                    break;
            }

            if (i_ManufactureDetails.VehicleType == eVehicleType.Car)
            {
                newVehicle = ManufactureNewCar(i_ManufactureDetails);
            }

            

            return newVehicle;
        }

        public Car ManufactureNewCar(ManufactureDetails i_ManufactureDetails)
        {
            Car newCar = new Car(
                i_ManufactureDetails.ModelName,
                i_ManufactureDetails.LicenceID,
                i_ManufactureDetails.EnergyType,
                i_ManufactureDetails.WheelManufacturerName,
                i_ManufactureDetails.CarColor,
                i_ManufactureDetails.DoorsNumberInCar);

            return newCar;
        }
        
        public Motorcycle ManufactureNewMotorcycle(ManufactureDetails i_ManufactureDetails)
        {
            Motorcycle newMotorcycle = null;
            ///Car newCar = new Car(i_ManufactureDetails.LicenceID, i_ManufactureDetails.)

            return newMotorcycle;
        }
        
        public Truck ManufactureNewTruck(ManufactureDetails i_ManufactureDetails)
        {
            Truck newTruck = null;
            ///Car newCar = new Car(i_ManufactureDetails.LicenceID, i_ManufactureDetails.)

            return newTruck;
        }


    }
}
