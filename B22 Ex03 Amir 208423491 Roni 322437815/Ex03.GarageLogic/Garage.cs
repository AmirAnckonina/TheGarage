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

        private readonly Dictionary<string, GarageCard> r_GarageVehicles;
        private readonly VehicleManufacturer r_VehicleManufacturer;
        private static string s_LicenseIDNotFound;

        public Garage()
        {
            r_GarageVehicles = new Dictionary<string, GarageCard>();
            r_VehicleManufacturer = new VehicleManufacturer();
            s_LicenseIDNotFound = "LicenseID not found.";
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

        public void AddNewVehicleToTheGarage(string i_LicneseID, string i_VehicleType)
        {
            Vehicle newVehicle;
            GarageCard newGarageCard;

            newVehicle = r_VehicleManufacturer.ManufactureNewVehicle(i_LicneseID, i_VehicleType);
            newGarageCard = new GarageCard(newVehicle, eVehicleStatus.InRepair);
            r_GarageVehicles.Add(i_LicneseID, newGarageCard);
        }

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
                        garageVehiclesIDByStatus.Add("License ID: " + vehicleInGarage.Key);
                    }
                }
            }

            return garageVehiclesIDByStatus;
        }

        public void ChangeVehicleStatus(string i_LicenseID, int i_NewVehicleStatus)
        {
            eVehicleStatus vehicleStatus;

            if (!LicenseIDExist(i_LicenseID))
            {
                throw new ArgumentException(s_LicenseIDNotFound);
            }

            vehicleStatus = VehicleStatusSetup(i_NewVehicleStatus);
            r_GarageVehicles[i_LicenseID].VehicleStatus = vehicleStatus;
        }

        public void InflateVehicleWheels(string i_LicenseID)
        {
            if (!LicenseIDExist(i_LicenseID))
            {
                throw new ArgumentException(s_LicenseIDNotFound);
            }

            foreach (Wheel wheel in r_GarageVehicles[i_LicenseID].Vehicle.VehicleWheels)
            {
                wheel.InflateWheelToMax();
            }
        }

        public void ChargeVehicleBattery(string i_LicenseID, float i_TimeToChargeInMinutes)
        {
            Electric electricEnergyOfCurrentVehicle;

            if (!LicenseIDExist(i_LicenseID))
            {
                throw new ArgumentException(s_LicenseIDNotFound);
            }

            electricEnergyOfCurrentVehicle = r_GarageVehicles[i_LicenseID].Vehicle.VehicleEnergy as Electric;
            if (electricEnergyOfCurrentVehicle == null)
            {
                throw new ArgumentException("The vehicle does not have electric energy.");
            }

            electricEnergyOfCurrentVehicle.ChargeBattery(i_TimeToChargeInMinutes);
        }

        public void RefuelVehicle(string i_LicenseID, int i_FuelTypeChoice, float i_FuelAmount)
        {
            Fuel fuelEnergyOfCurrentVehicle;
            Fuel.eFuelType fuelType;

            if (!LicenseIDExist(i_LicenseID))
            {
                throw new ArgumentException(s_LicenseIDNotFound);
            }

            fuelEnergyOfCurrentVehicle = r_GarageVehicles[i_LicenseID].Vehicle.VehicleEnergy as Fuel;
            if (fuelEnergyOfCurrentVehicle == null)
            {
                throw new ArgumentException("The vehicle does not have fuel energy source.");
            }

            fuelType = FuelTypeSetup(i_FuelTypeChoice);
            fuelEnergyOfCurrentVehicle.Refuel(i_FuelAmount, fuelType);
        }

        public string GetFullVehicleInformation(string i_LicneseID)
        {
            StringBuilder allVehicleInfo = new StringBuilder();

            if (!LicenseIDExist(i_LicneseID))
            {
                throw new ArgumentException(s_LicenseIDNotFound);
            }

            allVehicleInfo.Append(r_GarageVehicles[i_LicneseID].GetGarageCardInfo());

            return allVehicleInfo.ToString();
        }

        public bool LicenseIDExist(string i_LicenseID)
        {
            return r_GarageVehicles.ContainsKey(i_LicenseID);
        }

        public Vehicle GetVehicleByLicenseID(string i_LicenseID)
        {
            if (!LicenseIDExist(i_LicenseID))
            {
                throw new ArgumentException(s_LicenseIDNotFound);
            }

            return r_GarageVehicles[i_LicenseID].Vehicle;
        }

        public GarageCard GetVehicleGarageCardByLicenseID(string i_LicenseID)
        {
            if (!LicenseIDExist(i_LicenseID))
            {
                throw new ArgumentException(s_LicenseIDNotFound);
            }

            return r_GarageVehicles[i_LicenseID];
        }

        public string GetBasicInfoBeforeOperation(string i_VehicleLicenseID)
        {
            StringBuilder LicenseIDAndVehicleTypeMessage = new StringBuilder();

            if (!LicenseIDExist(i_VehicleLicenseID))
            {
                throw new ArgumentException(s_LicenseIDNotFound);
            }

            LicenseIDAndVehicleTypeMessage.AppendLine("Vehicle licnese ID: " + i_VehicleLicenseID);
            LicenseIDAndVehicleTypeMessage.AppendLine("Vehicle type: " + r_GarageVehicles[i_VehicleLicenseID].Vehicle.GetType().Name);
            LicenseIDAndVehicleTypeMessage.Append("Energy source type: " + r_GarageVehicles[i_VehicleLicenseID].Vehicle.VehicleEnergy.GetType().Name);
            return LicenseIDAndVehicleTypeMessage.ToString();
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

        private Fuel.eFuelType FuelTypeSetup(int i_FuelTypeChoice)
        {
            Fuel.eFuelType fuelType;

            if (i_FuelTypeChoice == 1)
            {
                fuelType = Fuel.eFuelType.Soler;
            }

            else if (i_FuelTypeChoice == 2)
            {
                fuelType = Fuel.eFuelType.Octan95;
            }

            else if (i_FuelTypeChoice == 3)
            {
                fuelType = Fuel.eFuelType.Octan96;
            }

            else
            {
                fuelType = Fuel.eFuelType.Octan98;
            }

            return fuelType;
        }
    }
}  