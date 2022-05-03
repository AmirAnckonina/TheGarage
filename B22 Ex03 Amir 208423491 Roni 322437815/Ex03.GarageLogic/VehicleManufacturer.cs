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
            Car = 1,
            Motorcycle = 2,
            Truck = 3,
            None
        }

        public Vehicle ManufactureNewVehicle(string i_LicenceID, string i_VehicleType, string i_EnergyType)
        {
            Vehicle newVehicle;
            eVehicleType vehicleType;
            Energy.eEnergyType energyType;
            bool parseVehicleTypeSucceed;
            bool parseEnergyTypeSucceed;

            parseVehicleTypeSucceed = Enum.TryParse(i_VehicleType , out vehicleType);
            parseEnergyTypeSucceed = Enum.TryParse(i_EnergyType, out energyType);
            if (!parseVehicleTypeSucceed || !parseEnergyTypeSucceed)
            {
                /// throw new FromatException
            }

            switch (vehicleType)
            {
                case eVehicleType.Car:
                    newVehicle = ManufactureNewCar(i_LicenceID, energyType);
                    break;

                case eVehicleType.Motorcycle:
                    newVehicle = ManufactureNewMotorcycle(i_LicenceID, energyType);
                    break;

                case eVehicleType.Truck:
                    newVehicle = ManufactureNewTruck(i_LicenceID);
                    break;

                default:
                    newVehicle = null;
                    break;
            }

            return newVehicle;
        }

        public Car ManufactureNewCar(string i_LicenceID, Energy.eEnergyType i_EnergyType)
        {
            Car newCar;
            Energy newEnergySource;

            if (i_EnergyType == Energy.eEnergyType.Fuel)
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

            newCar = new Car(i_LicenceID, newEnergySource);

            return newCar;
        }
        
        public Motorcycle ManufactureNewMotorcycle(string i_LicenceID, Energy.eEnergyType i_EnergyType)
        {
            Motorcycle newMotorcycle;
            Energy newEnergySource;

            if (i_EnergyType == Energy.eEnergyType.Fuel)
            {
                newEnergySource = new FuelEnergy(
                Motorcycle.MCFuelSpecifications.k_MCFuelType,
                Motorcycle.MCFuelSpecifications.k_MCMaxFuelCapacity,
                Motorcycle.MCFuelSpecifications.k_MCFuelAfterManufacture);
            }

            else
            {
                newEnergySource = new ElectricEnergy(
                   Motorcycle.MCElectricSpecifications.k_MCMaxBatteryLoadInHours,
                   Motorcycle.MCElectricSpecifications.k_MCBatteryInHoursAfterManufacture);
            }

            newMotorcycle = new Motorcycle(i_LicenceID, newEnergySource);

            return newMotorcycle;
        }
        
        public Truck ManufactureNewTruck(string i_LicenceID)
        {
            Truck newTruck;
            Energy newEnergySource;
            
            newEnergySource = new FuelEnergy(
            Truck.TruckFuelSpecifications.k_TruckFuelType,
            Truck.TruckFuelSpecifications.k_TruckMaxFuelCapacity,
            Truck.TruckFuelSpecifications.k_TruckFuelAfterManufacture);

            newTruck = new Truck(i_LicenceID, newEnergySource);

            return newTruck;
        }

    }
}
