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
            FuelCar = 1,
            FuelMotorcycle = 2,
            FuelTruck = 3,
            ElectricCar = 4,
            ElectricMotorcycle = 5
        }

        /// private eVehicleType m_VehicleType;
        /// private Energy.eEnergyType m_EnergyType;

        public Vehicle ManufactureNewVehicle(string i_LicenceID, string i_VehicleType)
        {
            eVehicleType vehicleType;
            Vehicle newVehicle;
            Energy newEnergySource;

            /// VehicleTypeSetup(i_VehicleType);
            /// EnergyTypeSetup(i_EnergyType);
            vehicleType = VehicleAndEnergyTypeSetup(i_VehicleType);
            newEnergySource = ProduceEnergyForVehicle(vehicleType);
            switch (vehicleType)
            {
                case eVehicleType.FuelCar:
                case eVehicleType.ElectricCar:
                    ///newVehicle = ManufactureNewCar(i_LicenceID, m_EnergyType);
                    /// newVehicle = new Car(licanseID, newEnergyForVehicle);
                    newVehicle = new Car(i_LicenceID, newEnergySource);
                    break;

                case eVehicleType.FuelMotorcycle:
                case eVehicleType.ElectricMotorcycle:
                    /// newVehicle = ManufactureNewMotorcycle(i_LicenceID, m_EnergyType);
                    newVehicle = new Motorcycle(i_LicenceID, newEnergySource);
                    break;

                case eVehicleType.FuelTruck:
                    /// newVehicle = ManufactureNewTruck(i_LicenceID, m_EnergyType);
                    newVehicle = new Truck(i_LicenceID, newEnergySource);
                    break;

                default:
                    newVehicle = null;
                    break;
            }

            return newVehicle;
        }

        /*public Car ManufactureNewCar(string i_LicenceID, Energy.eEnergyType i_EnergyType)
        {
            Car newCar;
            Energy newEnergySource;

            if (i_EnergyType == Energy.eEnergyType.Fuel)
            {
                    newEnergySource = new Fuel(
                    Car.CarFuelSpecifications.k_CarFuelType,
                    Car.CarFuelSpecifications.k_CarMaxFuelCapacity,
                    Car.CarFuelSpecifications.k_CarFuelAfterManufacture);
            }

            else /// Electric
            {
                newEnergySource = new Electric(
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
                newEnergySource = new Fuel(
                Motorcycle.MCFuelSpecifications.k_MCFuelType,
                Motorcycle.MCFuelSpecifications.k_MCMaxFuelCapacity,
                Motorcycle.MCFuelSpecifications.k_MCFuelAfterManufacture);
            }

            else
            {
                newEnergySource = new Electric(
                   Motorcycle.MCElectricSpecifications.k_MCMaxBatteryLoadInHours,
                   Motorcycle.MCElectricSpecifications.k_MCBatteryInHoursAfterManufacture);
            }

            newMotorcycle = new Motorcycle(i_LicenceID, newEnergySource);

            return newMotorcycle;
        }
        
        public Truck ManufactureNewTruck(string i_LicenceID, Energy.eEnergyType i_EnergyType)
        {
            Truck newTruck;
            Energy newEnergySource;
            
            if (i_EnergyType != Energy.eEnergyType.Fuel)
            {
                throw new ArgumentException("Truck doesn't support other energy source than fuel.");
            }

            newEnergySource = new Fuel(
            Truck.TruckFuelSpecifications.k_TruckFuelType,
            Truck.TruckFuelSpecifications.k_TruckMaxFuelCapacity,
            Truck.TruckFuelSpecifications.k_TruckFuelAfterManufacture);

            newTruck = new Truck(i_LicenceID, newEnergySource);

            return newTruck;
        }*/

     /*   private void VehicleTypeSetup(string i_InsertedValue)
        {
            bool parseValueSucceed;
            eVehicleType vehicleTypeChoice;
            int numOfVehicleTypes = Enum.GetValues(typeof(eVehicleType)).Length;

            parseValueSucceed = Enum.TryParse(i_InsertedValue, out vehicleTypeChoice);
            if (!parseValueSucceed || !Parser.EnumRangeValidation(1, numOfVehicleTypes, (int)vehicleTypeChoice))
            {
                throw new ArgumentException("This vehicle isn't manufactured in our vehicles factory");
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
        }*/

        private eVehicleType VehicleAndEnergyTypeSetup(string i_InsertedValue)
        {
            bool parseValueSucceed;
            eVehicleType vehicleType;
            int numOfVehicleTypes = Enum.GetValues(typeof(eVehicleType)).Length;

            parseValueSucceed = Enum.TryParse(i_InsertedValue, out vehicleType);
            if (!parseValueSucceed || !Parser.EnumRangeValidation(1, numOfVehicleTypes, (int)vehicleType))
            {
                throw new ArgumentException("This vehicle isn't manufactured in our vehicles factory");
            }

            return vehicleType;
        }

        private Energy ProduceEnergyForVehicle(eVehicleType i_VehicleType)
        {
            Energy newEnergySource;

            switch(i_VehicleType)
            {
                case eVehicleType.FuelCar:
                    newEnergySource = new Fuel(
                    Car.CarFuelSpecifications.k_CarFuelType,
                    Car.CarFuelSpecifications.k_CarMaxFuelCapacity,
                    Car.CarFuelSpecifications.k_CarFuelAfterManufacture);
                    break;

                case eVehicleType.FuelMotorcycle:
                        newEnergySource = new Fuel(
                    Motorcycle.MCFuelSpecifications.k_MCFuelType,
                    Motorcycle.MCFuelSpecifications.k_MCMaxFuelCapacity,
                    Motorcycle.MCFuelSpecifications.k_MCFuelAfterManufacture);
                    break;

                case eVehicleType.FuelTruck:
                            newEnergySource = new Fuel(
                    Truck.TruckFuelSpecifications.k_TruckFuelType,
                    Truck.TruckFuelSpecifications.k_TruckMaxFuelCapacity,
                    Truck.TruckFuelSpecifications.k_TruckFuelAfterManufacture);
                    break;

                case eVehicleType.ElectricCar:
                    newEnergySource = new Electric(
                    Car.CarElectricSpecifications.k_CarMaxBatteryLoadInHours,
                    Car.CarElectricSpecifications.k_CarBatteryInHoursAfterManufacture);
                    break;

                case eVehicleType.ElectricMotorcycle:
                    newEnergySource = new Electric(
                   Motorcycle.MCElectricSpecifications.k_MCMaxBatteryLoadInHours,
                   Motorcycle.MCElectricSpecifications.k_MCBatteryInHoursAfterManufacture);
                    break;

                default:
                    newEnergySource = null;
                    throw new ArgumentException("This vehicle isn't manufactured in our vehicles factory");
            }

            return newEnergySource;
        }
    }
}
