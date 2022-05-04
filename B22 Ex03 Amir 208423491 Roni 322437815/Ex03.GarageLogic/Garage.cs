using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ex03.GarageLogic
{
    public class Garage
    {
        public enum eVehicleStatus
        {
            InRepair = 1,
            Repaired,
            Paid,
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
        private static string s_LicenceIDNotFound;

        public Garage()
        {
            r_GarageVehicles = new Dictionary<string, GarageCard>();
            r_VehicleManufacturer = new VehicleManufacturer();
            s_LicenceIDNotFound = "LicenceID not found.";
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

            newVehicle = r_VehicleManufacturer.ManufactureNewVehicle(i_LicneseID, i_VehicleType, i_EnergyType);
            newGarageCard = new GarageCard(newVehicle, eVehicleStatus.InRepair);
            r_GarageVehicles.Add(i_LicneseID, newGarageCard);
        }

        /// 2 
        public List<string> GetAllGarageVehiclesIDByStatus(int i_VehicleStatusFilter)
        {
            eVehicleStatus vehicleStatusFilter;
            vehicleStatusFilter = VehicleStatusSetup(i_VehicleStatusFilter);
            List<string> garageVehiclesIDByStatus = new List<string>();

            if (r_GarageVehicles.Count == 0)
            {
                garageVehiclesIDByStatus.Add("No vehicles in the garage.");
            }

            else
            {
                foreach (KeyValuePair<string, GarageCard> vehicleInGarage in r_GarageVehicles)
                {
                    if (vehicleInGarage.Value.VehicleStatus == vehicleStatusFilter)
                    {
                        garageVehiclesIDByStatus.Add(vehicleInGarage.Key);
                    }
                }
            }

            return garageVehiclesIDByStatus;
        }

        /// 3
        public void ChangeVehicleStatus(string i_LicenceID, int i_NewVehicleStatus)
        {
            eVehicleStatus vehicleStatus;

            if (!LicenceIDExist(i_LicenceID))
            {
                throw new ArgumentException(s_LicenceIDNotFound);
            }

            vehicleStatus = VehicleStatusSetup(i_NewVehicleStatus);
            r_GarageVehicles[i_LicenceID].VehicleStatus = vehicleStatus;
        }

        /// 4
        public void InflateVehicleWheels(string i_LicenceID)
        {
            if (!LicenceIDExist(i_LicenceID))
            {
                throw new ArgumentException(s_LicenceIDNotFound);
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
                throw new ArgumentException(s_LicenceIDNotFound);
            }

            electricEnergyOfCurrentVehicle = r_GarageVehicles[i_LicenceID].Vehicle.VehicleEnergy as ElectricEnergy;
            if (electricEnergyOfCurrentVehicle == null)
            {
                throw new ArgumentException("The vehicle does not have electric energy.");
            }

            electricEnergyOfCurrentVehicle.ChargeBattery(i_TimeToChargeInMinutes);
        }

        /// 6 
        public void RefuelVehicle(string i_LicenceID, float i_FuelAmount, FuelEnergy.eFuelType i_FuelType)
        {
            FuelEnergy fuelEnergyOfCurrentVehicle;

            if (!LicenceIDExist(i_LicenceID))
            {
                throw new ArgumentException(s_LicenceIDNotFound);
            }

            fuelEnergyOfCurrentVehicle = r_GarageVehicles[i_LicenceID].Vehicle.VehicleEnergy as FuelEnergy;
            fuelEnergyOfCurrentVehicle.Refuel(i_FuelAmount, i_FuelType);
        }

        /// 7
        public string GetFullVehicleInformation(string i_LicneseID)
        {
            StringBuilder allVehicleInfo = new StringBuilder();

            if (!LicenceIDExist(i_LicneseID))
            {
                throw new ArgumentException(s_LicenceIDNotFound);
            }

            allVehicleInfo.Append(r_GarageVehicles[i_LicneseID].GetGarageCardInfo());

            return allVehicleInfo.ToString();
        }

        public bool LicenceIDExist(string i_LicenceID)
        {
            return r_GarageVehicles.ContainsKey(i_LicenceID);
        }

        public Vehicle GetVehicleByLicenceID(string i_LicenceID)
        {
            if (!LicenceIDExist(i_LicenceID))
            {
                throw new ArgumentException(s_LicenceIDNotFound);
            }

            return r_GarageVehicles[i_LicenceID].Vehicle;
        }

        public GarageCard GetVehicleGarageCardByLicenceID(string i_LicenceID)
        {
            if (!LicenceIDExist(i_LicenceID))
            {
                throw new ArgumentException(s_LicenceIDNotFound);
            }

            return r_GarageVehicles[i_LicenceID];
        }

        private eVehicleStatus VehicleStatusSetup(int i_VehicleStatusFilter)
        {
            eVehicleStatus vehicleStatus;

            if (i_VehicleStatusFilter == 1)
            {
                vehicleStatus = eVehicleStatus.InRepair;
            }

            else if (i_VehicleStatusFilter == 2)
            {
                vehicleStatus = eVehicleStatus.Repaired;
            }

            else /// (i_VehicleStatusFilter == 3)
            {
                vehicleStatus = eVehicleStatus.Paid;
            }

            return vehicleStatus;
        }
    }
}  