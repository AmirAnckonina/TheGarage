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
            Truck,
            None
        }

        public Vehicle ManufactureNewVehicle(ManufactureDetails i_ManufactureDetails)
        {
            Vehicle newVehicle;

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

            return newVehicle;
        }

        public Car ManufactureNewCar(ManufactureDetails i_ManufactureDetails)
        {
            Car newCar;
            Energy newEnergySource;

            if (i_ManufactureDetails.EnergyType == Energy.eEnergyType.Fuel)
            {
                    newEnergySource = new FuelEnergy(
                    Car.CarFuelSpecifications.k_CarFuelType,
                    Car.CarFuelSpecifications.k_CarMaxFuelCapacity,
                    Car.CarFuelSpecifications.k_CarFuelAfterManufacture);
            }

            else /// Electric
            {
                newEnergySource = new ElectricEnergy(
                    Car.CarElectricSpecifications.k_CarMaxBatteryLoadInHours,
                    Car.CarElectricSpecifications.k_CarBatteryInHoursAfterManufacture);
            }

           // newCar = new Car(i_ManufactureDetails.LicenceID, newEnergySource);

            newCar = new Car(
                 i_ManufactureDetails.ModelName,
                 i_ManufactureDetails.LicenceID,
                 newEnergySource,
                 i_ManufactureDetails.WheelManufacturerName,
                 i_ManufactureDetails.CarColor,
                 i_ManufactureDetails.DoorsNumberInCar);

            return newCar;
        }
        
        public Motorcycle ManufactureNewMotorcycle(ManufactureDetails i_ManufactureDetails)
        {
            Motorcycle newMotorcycle;
            Energy newEnergySource;

            if (i_ManufactureDetails.EnergyType == Energy.eEnergyType.Fuel)
            {
                newEnergySource = new FuelEnergy(
                Motorcycle.MCFuelSpecifications.k_MotorcycleFuelType,
                Motorcycle.MCFuelSpecifications.k_MotorcycleMaxFuelCapacity,
                Motorcycle.MCFuelSpecifications.k_MotorcycleFuelAfterManufacture);
            }

            else
            {
                newEnergySource = new ElectricEnergy(
                   Motorcycle.MCElectricSpecifications.k_MotorcycleMaxBatteryLoadInHours,
                   Motorcycle.MCElectricSpecifications.k_MotorcycleBatteryInHoursAfterManufacture);
            }

            /// newMotorcycle = new Motorcycle(i_ManufactureDetails.LicenceID, newEnergySource);

            newMotorcycle = new Motorcycle(
                 i_ManufactureDetails.ModelName,
                 i_ManufactureDetails.LicenceID,
                 newEnergySource,
                 i_ManufactureDetails.WheelManufacturerName,
                 i_ManufactureDetails.MotorcycleLicenceType,
                 i_ManufactureDetails.MotorcycleEngineCapacity);

            return newMotorcycle;
        }
        
        public Truck ManufactureNewTruck(ManufactureDetails i_ManufactureDetails)
        {
            Truck newTruck;
            Energy newEnergySource;

            newEnergySource = new FuelEnergy(
            Truck.TruckFuelSpecifications.k_TruckFuelType,
            Truck.TruckFuelSpecifications.k_TruckMaxFuelCapacity,
            Truck.TruckFuelSpecifications.k_TruckFuelAfterManufacture);

            /// newTruck = new Truck(i_ManufactureDetails.LicenceID, newEnergySource);

            newTruck = new Truck(
                 i_ManufactureDetails.ModelName,
                 i_ManufactureDetails.LicenceID,
                 newEnergySource,
                 i_ManufactureDetails.WheelManufacturerName,
                 i_ManufactureDetails.HasCoolingCargo,
                 i_ManufactureDetails.CargoCapacity);


            return newTruck;
        }

    }
}
