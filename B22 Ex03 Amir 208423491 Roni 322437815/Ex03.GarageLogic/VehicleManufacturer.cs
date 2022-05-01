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


        private static class MotorcycleFuelSpecifications
        {
            internal const FuelEnergy.eFuelType k_MotorcycleFuelType = FuelEnergy.eFuelType.Octan98;
            internal const float k_MotorcycleMaxFuelCapacity = 6.2f;
            internal const float k_MotorcycleFuelAfterManufacture = 2;
        }

        private static class MotorcycleElectricSpecifications
        {
            internal const float k_MotorcycleMaxBatteryLoadInHours = 2.5f;
            internal const float k_MotorcycleBatteryInHoursAfterManufacture = 1.0f;
        }

        private static class CarFuelSpecifications
        {
            internal const FuelEnergy.eFuelType k_CarFuelType = FuelEnergy.eFuelType.Octan95;
            internal const float k_CarMaxFuelCapacity = 38;
            internal const float k_CarFuelAfterManufacture = 20;
        }

        private static class CarElectricSpecifications
        {
            internal const float k_CarMaxBatteryLoadInHours = 3.3f;
            internal const float k_CarBatteryInHoursAfterManufacture = 1.0f;
        }


        private static class TruckFuelSpecifications
        {
            internal const FuelEnergy.eFuelType k_TruckFuelType = FuelEnergy.eFuelType.Soler;
            internal const float k_TruckMaxFuelCapacity = 120;
            internal const float k_TruckFuelAfterManufacture= 40;
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
            Car newCar;
            Energy energySource;

            if (i_ManufactureDetails.EnergyType == Energy.eEnergyType.Fuel)
            {
                    energySource = new FuelEnergy(
                    CarFuelSpecifications.k_CarFuelType,
                    CarFuelSpecifications.k_CarMaxFuelCapacity,
                    CarFuelSpecifications.k_CarFuelAfterManufacture);
            }

            else
            {
                energySource = new ElectricEnergy(
                    CarElectricSpecifications.k_CarMaxBatteryLoadInHours,
                    CarElectricSpecifications.k_CarBatteryInHoursAfterManufacture);
            }

            newCar = new Car(
                 i_ManufactureDetails.ModelName,
                 i_ManufactureDetails.LicenceID,
                 energySource,
                 i_ManufactureDetails.WheelManufacturerName,
                 i_ManufactureDetails.CarColor,
                 i_ManufactureDetails.DoorsNumberInCar);

            return newCar;
        }
        
        public Motorcycle ManufactureNewMotorcycle(ManufactureDetails i_ManufactureDetails)
        {
            Motorcycle newMotorcycle;
            Energy energySource;

            if (i_ManufactureDetails.EnergyType == Energy.eEnergyType.Fuel)
            {
                energySource = new FuelEnergy(
                MotorcycleFuelSpecifications.k_MotorcycleFuelType,
                MotorcycleFuelSpecifications.k_MotorcycleMaxFuelCapacity,
                MotorcycleFuelSpecifications.k_MotorcycleFuelAfterManufacture);
            }

            else
            {
                energySource = new ElectricEnergy(
                   MotorcycleElectricSpecifications.k_MotorcycleMaxBatteryLoadInHours,
                   MotorcycleElectricSpecifications.k_MotorcycleBatteryInHoursAfterManufacture);
            }

            newMotorcycle = new Motorcycle(
                 i_ManufactureDetails.ModelName,
                 i_ManufactureDetails.LicenceID,
                 energySource,
                 i_ManufactureDetails.WheelManufacturerName,
                 i_ManufactureDetails.MotorcycleLicenceType,
                 i_ManufactureDetails.MotorcycleEngineCapacity);

            return newMotorcycle;
        }
        
        public Truck ManufactureNewTruck(ManufactureDetails i_ManufactureDetails)
        {
            Truck newTruck;
            Energy energySource;

            energySource = new FuelEnergy(
            TruckFuelSpecifications.k_TruckFuelType,
            TruckFuelSpecifications.k_TruckMaxFuelCapacity,
            TruckFuelSpecifications.k_TruckFuelAfterManufacture);

            
            newTruck = new Truck(
                 i_ManufactureDetails.ModelName,
                 i_ManufactureDetails.LicenceID,
                 energySource,
                 i_ManufactureDetails.WheelManufacturerName,
                 i_ManufactureDetails.HasCoolingCargo,
                 i_ManufactureDetails.CargoCapacity);


            return newTruck;
        }

    }
}
