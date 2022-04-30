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

        public GarageManager()
        {
            r_Garage = new Garage();
            ///r_VehicleRawDetails = new VehicleRawDetails();
            r_ConsoleIoManager = new ConsoleIOManager();
        }

        public void Run()
        { 

            /// Manufacturer vehicles ()
            /// 
        }
        public void VehcilesManufactureringProcedure()
        {
            StringBuilder vehicleLicenseNumber = new StringBuilder();
            vehicleLicenseNumber = r_ConsoleIoManager.GetVehicleLicenseNumber();
            //if(!IsAlreadyInTheGarage(vehicleLicenseNumber))
            //{
            //   r_ConsoleIoManager.GetVehicleType();
            //}


            /// Get input of vehchiles details.
            /// 1. Vehcile type
            /// 2. EnergyType (in case of Car, Motorcycle)
            /// For each vehicle we want to get the special details for each type

            //while (!Dont wantto create vehicle)
            /// r_VehicleRawDetails.VehicleType = r_ConsoleIoManager.GetVehicleType();
            /// r_VehicleRawDetails.LicenceID = r_ConsoleIoManager.GetLicenceID();
            /// EnergyType
            /// Switch (userChoice == 

           /// r_VehicleManufacturer.CreateCar();

        }
    }
}
