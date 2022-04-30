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
            Paid
        }

        private readonly Dictionary<StringBuilder, GarageCard> r_GarageVehicles;
        private readonly VehicleManufacturer r_VehicleManufacturer;

        public Garage()
        {
            r_GarageVehicles = new Dictionary<StringBuilder, GarageCard>();
            r_VehicleManufacturer = new VehicleManufacturer();
        }

        ///1
        public void AddVehicleToGarage(ManufactureDetails i_ManufactureDetails)
        {
            Vehicle newVehicle;
            GarageCard newGarageCard;

            if (!LicenceIDExist(i_ManufactureDetails.LicenceID))
            {
                /// manufacturing.
                newVehicle = r_VehicleManufacturer.ManufactureNewVehicle(i_ManufactureDetails);
                /// creation of GarageCard.
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
        public List<StringBuilder> GetAllGarageVehiclesIDByStatus(eVehicleStatus i_VehicleStatusFilter)
        {
            List<StringBuilder> garageVehiclesIDByStatus = new List<StringBuilder>();
            foreach (KeyValuePair<StringBuilder, GarageCard> vehicleInGarage in r_GarageVehicles)
            {
                if (vehicleInGarage.Value.VehicleStatus == i_VehicleStatusFilter)
                {
                    garageVehiclesIDByStatus.Add(vehicleInGarage.Key);
                }
            }

            return garageVehiclesIDByStatus;
        }
        
        /// 3
        public void ChangeVehicleStatus(StringBuilder i_LicenceID, eVehicleStatus i_NewVehicleStatus)
        {

            /*f (LicenceIDExist(i_LicenceID)
            {
                r_GarageVehicles[i_LicenceID].VehicleStatus = i_NewVehicleStatus;
            }*/

            /// ArgumentException ?
        }

        /// 4
        public void InflateVehicleWheels(StringBuilder i_LicenceID)
        {
            /*if (LicenceIDExist(i_LicenceID)
            {
                r_GarageVehicles[i_LicenceID].Vehicle.InflateAllWheelsToMax();
            }
*/
            /// ArgumentException ?
        }

        /// 5
        public void ChargeVehicle(StringBuilder i_LicenceID, float i_TimeToChargeInMinutes)
        {
            ElectricEnergy electricEnergyOfCurrentVehicle;

            if (LicenceIDExist(i_LicenceID))
            {
                electricEnergyOfCurrentVehicle = r_GarageVehicles[i_LicenceID].Vehicle.VehicleEnergy as ElectricEnergy;
                electricEnergyOfCurrentVehicle.ChargeBattery(i_TimeToChargeInMinutes);
            }

            /// ArgumentException ?
        }

        /// 6 
        public void RefuelVehicle(StringBuilder i_LicenceID, float i_FuelAmount, FuelEnergy.eFuelType i_FuelType)
        {
            FuelEnergy fuelEnergyOfCurrentVehicle;

            if (LicenceIDExist(i_LicenceID))
            {
                fuelEnergyOfCurrentVehicle = r_GarageVehicles[i_LicenceID].Vehicle.VehicleEnergy as FuelEnergy;
                fuelEnergyOfCurrentVehicle.Refuel(i_FuelAmount, i_FuelType);  
            }

            /// ArgumentException ?
        }

        public bool LicenceIDExist(StringBuilder i_LicenceID)
        {    
            return r_GarageVehicles.ContainsKey(i_LicenceID);
        }
    }
}
