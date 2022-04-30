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
        private readonly ConsoleIOManager r_ConsoleIoManager;
        private ManufactureDetails m_ManufactureDetails;

        public GarageManager()
        {
            r_Garage = new Garage();
            r_ConsoleIoManager = new ConsoleIOManager();
            m_ManufactureDetails = new ManufactureDetails();
        }

        public void Run()
        { 

            /// Manufacturer vehicles ()
            /// 
        }
        public void VehcilesManufactureringProcedure()
        {
            VehicleManufacturer.eVehicleType vehicleTypeChoice;

            m_ManufactureDetails.LicenceID = r_ConsoleIoManager.GetVehicleLicenseNumber();
            if (!r_Garage.LicenceIDExist(m_ManufactureDetails.LicenceID))
            {
                BasicDetailsInputsProcedure();
                vehicleTypeChoice = m_ManufactureDetails.VehicleTypeChoice;
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
            /// m_ManufactureDetails.VehicleTypeChoice = r_ConsoleIoManager.GetVehicleType();
            /// m_ManufactureDetails.ModelName= r_ConsoleIoManager.getModelName();
            m_ManufactureDetails.VehicleOwnerName = r_ConsoleIoManager.GetOwnerName();
            m_ManufactureDetails.VehicleOwnerPhoneNumber = r_ConsoleIoManager.GetVehicleOwnerPhoneNumber();
            /// m_ManufactureDetails.EnergyTypeChoice = r_ConsoleIoManager.GetEnergyType();
           /// m_ManufactureDetails.WheelManufacturerName = r_ConsoleIoManager.GetWheel();
        }

        public void CarDetailsInputsProcedure()
        {
            m_ManufactureDetails.CarColorChioce = r_ConsoleIoManager.GetCarColor();
            m_ManufactureDetails.CarDoorsNumberChoice = r_ConsoleIoManager.GetDoorsCar();
        }

        public void MotorcycleDetailsInputsProcedure()
        {
            ///m_ManufactureDetails.MotorcycleLicenceTypeChoice = r_ConsoleIoManager.GetMotorcycleLicenceType();
            ///m_ManufactureDetails.MotorcycleEngineVolume = r_ConsoleIoManager.GetEngineVolume();          
        }

        public void TruckDetailsInputsProcedure()
        {
            ///m_ManufactureDetails.HasCoolingCargo = r_ConsoleIoManager.GetHasCoolingCargo();
            ///m_ManufactureDetails.CargoCapacity = r_ConsoleIoManager.GetCargoCapacity();
        }
    }
}
