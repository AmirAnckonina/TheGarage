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
            Truck = 3
        }

        private eVehicleType m_VehicleType;
        private Energy.eEnergyType m_EnergyType;

        public Vehicle ManufactureNewVehicle(string i_LicenceID, string i_VehicleType, string i_EnergyType)
        {
            Vehicle newVehicle;

            VehicleTypeSetup(i_VehicleType);
            EnergyTypeSetup(i_EnergyType);           
            switch (m_VehicleType)
            {
                case eVehicleType.Car:
                    newVehicle = ManufactureNewCar(i_LicenceID, m_EnergyType);
                    break;

                case eVehicleType.Motorcycle:
                    newVehicle = ManufactureNewMotorcycle(i_LicenceID, m_EnergyType);
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

        private void VehicleTypeSetup(string i_InsertedValue)
        {
            bool parseValueSucceed;
            eVehicleType vehicleTypeChoice;
            int numOfVehicleTypes = Enum.GetValues(typeof(eVehicleType)).Length;

            parseValueSucceed = Enum.TryParse(i_InsertedValue, out vehicleTypeChoice);
            if (!parseValueSucceed || !Parser.EnumRangeValidation(1, numOfVehicleTypes, (int)vehicleTypeChoice))
            {
                throw new ArgumentException("Vehicle not supported in our vehicles factory");
            }

            m_VehicleType = vehicleTypeChoice;
        }

        private void EnergyTypeSetup(string i_InsertedValue)
        {
            bool parseValueSucceed;
            Energy.eEnergyType energyTypeChoice;
            int numOfEnergySources = Enum.GetValues(typeof(eVehicleType)).Length;

            parseValueSucceed = Enum.TryParse(i_InsertedValue, out energyTypeChoice);
            if (!parseValueSucceed || !Parser.EnumRangeValidation(1, numOfEnergySources, (int)energyTypeChoice))
            {
                throw new ArgumentException("This energy source not manufactured in our vehicles factory");
            }

            m_EnergyType = energyTypeChoice;
        }
    }
}
