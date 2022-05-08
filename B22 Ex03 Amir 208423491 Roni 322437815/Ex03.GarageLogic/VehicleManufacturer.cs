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

        public Vehicle ManufactureNewVehicle(string i_LicenseID, string i_VehicleType)
        {
            eVehicleType vehicleType;
            Vehicle newVehicle;
            Energy newEnergySource;

            vehicleType = VehicleAndEnergyTypeSetup(i_VehicleType);
            newEnergySource = ProduceEnergyForVehicle(vehicleType);
            switch (vehicleType)
            {
                case eVehicleType.FuelCar:
                case eVehicleType.ElectricCar:
                    newVehicle = new Car(i_LicenseID, newEnergySource);
                    break;

                case eVehicleType.FuelMotorcycle:
                case eVehicleType.ElectricMotorcycle:
                    newVehicle = new Motorcycle(i_LicenseID, newEnergySource);
                    break;

                case eVehicleType.FuelTruck:
                    newVehicle = new Truck(i_LicenseID, newEnergySource);
                    break;

                default:
                    newVehicle = null;
                    break;
            }

            return newVehicle;
        }

        private eVehicleType VehicleAndEnergyTypeSetup(string i_InsertedValue)
        {
            bool parseValueSucceed;
            eVehicleType vehicleType;
            int numOfVehicleTypes = Enum.GetValues(typeof(eVehicleType)).Length;

            parseValueSucceed = Enum.TryParse(i_InsertedValue, out vehicleType);
            if (!parseValueSucceed || !EnumValidator.EnumRangeValidation(1, numOfVehicleTypes, (int)vehicleType))
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
