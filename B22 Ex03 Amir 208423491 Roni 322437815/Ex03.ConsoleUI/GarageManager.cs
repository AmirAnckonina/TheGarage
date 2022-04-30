using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ex03.GarageLogic;

namespace Ex03.ConsoleUI
{
    public class GarageManager
    {
        private readonly Garage r_Garage;
        private readonly ConsoleIOManager r_ConsoleIOManager;
        private ManufactureDetails m_ManufactureDetails;

        public GarageManager()
        {
            r_Garage = new Garage();
            r_ConsoleIOManager = new ConsoleIOManager();
            m_ManufactureDetails = new ManufactureDetails();
        }

        public void Run()
        {
            ManufactureVehiclesAndAddingToGarageProcedure();
        }
        public void ManufactureVehiclesAndAddingToGarageProcedure()
        {
            VehicleManufacturer.eVehicleType vehicleTypeChoice;

            m_ManufactureDetails.LicenceID = r_ConsoleIOManager.GetVehicleLicenseNumber();
            if (!r_Garage.LicenceIDExist(m_ManufactureDetails.LicenceID))
            {
                BasicDetailsInputsProcedure();
                vehicleTypeChoice = m_ManufactureDetails.VehicleType;
                switch(vehicleTypeChoice)
                {
                    case VehicleManufacturer.eVehicleType.Car:
                        CarDetailsInputsProcedure();
                        break;
                    case VehicleManufacturer.eVehicleType.Motorcycle:
                        MotorcycleDetailsInputsProcedure();
                        break;
                    case VehicleManufacturer.eVehicleType.Truck:
                    default:
                        TruckDetailsInputsProcedure();
                        break;
                }
            }

            r_Garage.AddVehicleToGarage(m_ManufactureDetails);
        }

        public void BasicDetailsInputsProcedure()
        {
            m_ManufactureDetails.VehicleType = r_ConsoleIOManager.GetVehicleType();
            m_ManufactureDetails.ModelName = r_ConsoleIOManager.GetVehicleModelName();
            m_ManufactureDetails.VehicleOwnerName = r_ConsoleIOManager.GetOwnerName();
            m_ManufactureDetails.VehicleOwnerPhoneNumber = r_ConsoleIOManager.GetVehicleOwnerPhoneNumber();
            m_ManufactureDetails.EnergyType = r_ConsoleIOManager.GetEnergyType();
            m_ManufactureDetails.WheelManufacturerName = r_ConsoleIOManager.GetWheelManufacturerName();
        }

        public void CarDetailsInputsProcedure()
        {
            m_ManufactureDetails.CarColor = r_ConsoleIOManager.GetCarColor();
            m_ManufactureDetails.DoorsNumberInCar = r_ConsoleIOManager.GetDoorsNumberInCar();
        }

        public void MotorcycleDetailsInputsProcedure()
        {
            m_ManufactureDetails.MotorcycleLicenceType = r_ConsoleIOManager.GetMotorcycleLicenceType();
            m_ManufactureDetails.MotorcycleEngineCapacity = r_ConsoleIOManager.GetMotorcycleEngineCapacity();       
        }

        public void TruckDetailsInputsProcedure()
        {
            m_ManufactureDetails.HasCoolingCargo = r_ConsoleIOManager.GetIfTruckHasCoolingCargo();
            m_ManufactureDetails.CargoCapacity = r_ConsoleIOManager.GetTruckCargoCapacity();
        }
    }
}
