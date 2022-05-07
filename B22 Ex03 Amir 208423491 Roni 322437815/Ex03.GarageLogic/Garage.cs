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
                        garageVehiclesIDByStatus.Add("Licence ID: " + vehicleInGarage.Key);
                    }
                }
            }

            return garageVehiclesIDByStatus;
        }

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

        public void ChargeVehicleBattery(string i_LicenceID, float i_TimeToChargeInMinutes)
        {
            Electric electricEnergyOfCurrentVehicle;

            if (!LicenceIDExist(i_LicenceID))
            {
                throw new ArgumentException(s_LicenceIDNotFound);
            }

            electricEnergyOfCurrentVehicle = r_GarageVehicles[i_LicenceID].Vehicle.VehicleEnergy as Electric;
            if (electricEnergyOfCurrentVehicle == null)
            {
                throw new ArgumentException("The vehicle does not have electric energy.");
            }

            electricEnergyOfCurrentVehicle.ChargeBattery(i_TimeToChargeInMinutes);
        }

        public void RefuelVehicle(string i_LicenceID, int i_FuelTypeChoice, float i_FuelAmount)
        {
            Fuel fuelEnergyOfCurrentVehicle;
            Fuel.eFuelType fuelType;

            if (!LicenceIDExist(i_LicenceID))
            {
                throw new ArgumentException(s_LicenceIDNotFound);
            }

            fuelEnergyOfCurrentVehicle = r_GarageVehicles[i_LicenceID].Vehicle.VehicleEnergy as Fuel;
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

        public string GetBasicInfoBeforeOperation(string i_VehicleLicenseID)
        {
            StringBuilder licenceIDAndVehicleTypeMessage = new StringBuilder();

            if (!LicenceIDExist(i_VehicleLicenseID))
            {
                throw new ArgumentException(s_LicenceIDNotFound);
            }

            licenceIDAndVehicleTypeMessage.AppendLine("Vehicle licnese ID: " + i_VehicleLicenseID);
            licenceIDAndVehicleTypeMessage.AppendLine("Vehicle type: " + r_GarageVehicles[i_VehicleLicenseID].Vehicle.GetType().Name);
            licenceIDAndVehicleTypeMessage.Append("Energy source type: " + r_GarageVehicles[i_VehicleLicenseID].Vehicle.VehicleEnergy.GetType().Name);
            return licenceIDAndVehicleTypeMessage.ToString();
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