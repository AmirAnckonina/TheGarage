using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ex03.GarageLogic
{
    public class Garage
    {
        public struct OperationMessages
        {
            string requestMessage;
            string completeMessage;
        }

        public enum eVehicleStatus
        {
            InRepair = 1,
            Repaired,
            Paid,
            None
        }

        public enum eGarageOperations
        {
            Refuel = 1,
            ChargeBattery,
            InflateWheels,
            ChangeStatus,
            ExistenceCheck,
            None
        }

        private readonly Dictionary<string, GarageCard> r_GarageVehicles;
        private readonly VehicleManufacturer r_VehicleManufacturer;
        private static OperationMessages[] s_OperationsMessages;
        private static string s_GarageMenu;
        

        public Garage()
        {
            r_GarageVehicles = new Dictionary<string, GarageCard>();
            r_VehicleManufacturer = new VehicleManufacturer();
            InitGarageMenu();
            /// InitOperationsMessages();
        }

        public string GarageMenu
        {
            get
            {
                return s_GarageMenu;
            }
        }

        public Dictionary<string, GarageCard> GarageVehicles
        {
            get
            {
                return r_GarageVehicles;
            }
        }

        public GarageCard this[string i_LicenseID]
        {
            get
            {
                return r_GarageVehicles[i_LicenseID];
            }
            set 
            {
                r_GarageVehicles[i_LicenseID] = value;
            }
        }
        
        /// 1
        public void AddNewVehicleToTheGarage(string i_LicneseID, string i_VehicleType, string i_EnergyType)
        {
            Vehicle newVehicle;
            GarageCard newGarageCard;

            if (!LicenceIDExist(i_LicneseID))
            {
                newVehicle = r_VehicleManufacturer.ManufactureNewVehicle(i_LicneseID, i_VehicleType, i_EnergyType);
                newGarageCard = new GarageCard(newVehicle, eVehicleStatus.InRepair);
                r_GarageVehicles.Add(i_LicneseID, newGarageCard);
            }

            else
            {

            }

        }

        /// 2 
       /* public List<string> GetAllGarageVehiclesIDByStatus(string i_VehicleStatusFilter)
        {
            eVehicleStatus vehicleStatus;

            VehicleStatusSetup(ref vehicleStatus ,i_VehicleStatusFilter);
            List<string> garageVehiclesIDByStatus = new List<string>();
            foreach (KeyValuePair<string, GarageCard> vehicleInGarage in r_GarageVehicles)
            {
                if (vehicleInGarage.Value.VehicleStatus == i_VehicleStatusFilter)
                {
                    garageVehiclesIDByStatus.Add(vehicleInGarage.Key);
                }
            }

            return garageVehiclesIDByStatus;
        }*/

        /// 3
        public void ChangeVehicleStatus(string i_LicenceID, eVehicleStatus i_NewVehicleStatus)
        {

            if(!LicenceIDExist(i_LicenceID))
            {
                /// throw new ArgumentException LicenceID not found.
            }

            r_GarageVehicles[i_LicenceID].VehicleStatus = i_NewVehicleStatus;
        }

        /// 4
        public void InflateVehicleWheels(string i_LicenceID)
        {
            if (!LicenceIDExist(i_LicenceID))
            {
                /// throw new ArgumentException LicenceID not found.
            }

            foreach (Wheel wheel in r_GarageVehicles[i_LicenceID].Vehicle.VehicleWheels)
            {
                wheel.InflateWheelToMax();
            }
        }

        /// 5
        public void ChargeVehicleBattery(string i_LicenceID, float i_TimeToChargeInMinutes)
        {
            ElectricEnergy electricEnergyOfCurrentVehicle;

            if (!LicenceIDExist(i_LicenceID))
            {
                /// throw new ArgumentException LicenceID not found.
            }

            electricEnergyOfCurrentVehicle = r_GarageVehicles[i_LicenceID].Vehicle.VehicleEnergy as ElectricEnergy;
            if (electricEnergyOfCurrentVehicle == null)
            {
                /// throw new ArgumentException(); EnergyType
            }

            electricEnergyOfCurrentVehicle.ChargeBattery(i_TimeToChargeInMinutes);
        }

        /// 6 
        public void RefuelVehicle(string i_LicenceID, float i_FuelAmount, FuelEnergy.eFuelType i_FuelType)
        {
            FuelEnergy fuelEnergyOfCurrentVehicle;

            if (!LicenceIDExist(i_LicenceID))
            {
                /// throw new ArgumentException LicenceID not found.
            }

            fuelEnergyOfCurrentVehicle = r_GarageVehicles[i_LicenceID].Vehicle.VehicleEnergy as FuelEnergy;
            fuelEnergyOfCurrentVehicle.Refuel(i_FuelAmount, i_FuelType);
        }

        public GarageCard GetVehicleGargaeCardByLicenceID(string i_LicenceID)
        {
            GarageCard vehicleGarageCard = null;

            if(!LicenceIDExist(i_LicenceID))
            {
                /// throw new ArgumentException LicenceID not found.
            }

            vehicleGarageCard = r_GarageVehicles[i_LicenceID];

            return vehicleGarageCard;
        }

        public bool LicenceIDExist(string i_LicenceID)
        {    
            return r_GarageVehicles.ContainsKey(i_LicenceID);
        }

        public Vehicle GetVehicleByLicenceID(string i_LicenceID)
        {
            if (!LicenceIDExist(i_LicenceID))
            {
                /// throw
            }

            return r_GarageVehicles[i_LicenceID].Vehicle;
        }

        public GarageCard GetVehicleGarageCardByLicenceID(string i_LicenceID)
        {
            if (!LicenceIDExist(i_LicenceID))
            {
                /// throw
            }

            return r_GarageVehicles[i_LicenceID];
        }

        private void VehicleStatusSetup(ref eVehicleStatus o_VehicleStatus, string i_InsertedValue)
        {
            bool parseValueSucceed;
            int numOfEnergySources = Enum.GetValues(typeof(eVehicleStatus)).Length;

            parseValueSucceed = Enum.TryParse(i_InsertedValue, out o_VehicleStatus);
            if (!parseValueSucceed || !Parser.EnumRangeValidation(1, numOfEnergySources, (int)o_VehicleStatus))
            {
                throw new FormatException("Invalid car color selection.");
            }
        }

        private static void InitGarageMenu()
        {
            StringBuilder garageMenu = new StringBuilder();

            garageMenu.AppendLine("Please Enter the garage operation you want:");
            garageMenu.AppendLine("1 - Refuel");
            garageMenu.AppendLine("2 - Charge battery");
            garageMenu.AppendLine("3 - Inflate wheels");
            garageMenu.AppendLine("4 - Change status");
            garageMenu.AppendLine("5 - Existence check");

            s_GarageMenu = garageMenu.ToString();
        }
    }

    /*private void InitOperationsMessages()
    {

    }*/

   
}
