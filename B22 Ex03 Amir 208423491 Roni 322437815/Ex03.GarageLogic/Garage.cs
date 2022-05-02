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
            InRepair,
            Repaired,
            Paid,
            None
        }

        public enum eGarageOperations
        {
            Refuel,
            ChargeBattery,
            InflateWheels,
            ChangeStatus,
            ExistenceCheck,
            None
        }

        private readonly Dictionary<string, GarageCard> r_GarageVehicles;
        private readonly VehicleManufacturer r_VehicleManufacturer;

        public Garage()
        {
            r_GarageVehicles = new Dictionary<string, GarageCard>();
            r_VehicleManufacturer = new VehicleManufacturer();
        }

       /* public void ManufactureNewVehicleAndAddToGarage(ManufactureDetails i_ManufactureDetails)
        {
            Vehicle newVehicle;
            GarageCard newGarageCard;

            if (!LicenceIDExist(i_ManufactureDetails.LicenceID))
            {
                /// manufacturing.
                newVehicle = r_VehicleManufacturer.ManufactureNewVehicle(i_ManufactureDetails);
                /// creation of new GarageCard.
                newGarageCard = new GarageCard(
                    i_ManufactureDetails.VehicleOwnerName,
                    i_ManufactureDetails.VehicleOwnerPhoneNumber,
                    eVehicleStatus.InRepair,
                    newVehicle);
                r_GarageVehicles.Add(i_ManufactureDetails.LicenceID, newGarageCard);

            }
        }
*/
        ///1
        public void AddVehicleToGarage(ManufactureDetails i_ManufactureDetails)
        {
            Vehicle newVehicle;
            GarageCard newGarageCard;

            if (!LicenceIDExist(i_ManufactureDetails.LicenceID))
            {
                /// manufacturing.
                newVehicle = r_VehicleManufacturer.ManufactureNewVehicle(i_ManufactureDetails);
                /// creation of new GarageCard.
                newGarageCard = new GarageCard(
                    i_ManufactureDetails.VehicleOwnerName,
                    i_ManufactureDetails.VehicleOwnerPhoneNumber,
                    eVehicleStatus.InRepair,
                    newVehicle);
                r_GarageVehicles.Add(i_ManufactureDetails.LicenceID, newGarageCard);

            }

            else
            {
                /// Change status to InRepair
            }
        }

        /// 2 -> Should give the consoleUI this List and she fill print it.
        public List<string> GetAllGarageVehiclesIDByStatus(eVehicleStatus i_VehicleStatusFilter)
        {
            List<string> garageVehiclesIDByStatus = new List<string>();
            foreach (KeyValuePair<string, GarageCard> vehicleInGarage in r_GarageVehicles)
            {
                if (vehicleInGarage.Value.VehicleStatus == i_VehicleStatusFilter)
                {
                    garageVehiclesIDByStatus.Add(vehicleInGarage.Key);
                }
            }

            return garageVehiclesIDByStatus;
        }

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
        public void ChargeVehicle(string i_LicenceID, float i_TimeToChargeInMinutes)
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
    }
}
