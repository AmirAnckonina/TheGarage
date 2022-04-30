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
            InRepairProgress,
            Repaired,
            Paid
        }

        private Dictionary<StringBuilder, GarageCard> r_GarageVehicles;

        public Garage()
        {
            ///r_AllGarageVehicles = new Dictionary<Vehicle, OwnerDetails>();
        }

        ///1
        /// AddVehicleToGarage -> Waiting for guy answer

        /// 2
        /// Should give the consoleUI this List and she fill print it.
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
            bool licenceIDKeyExists = r_GarageVehicles.ContainsKey(i_LicenceID);

            if (licenceIDKeyExists)
            {
                r_GarageVehicles[i_LicenceID].VehicleStatus = i_NewVehicleStatus;
            }

            /// ArgumentException ?
        }

        /// 4
        public void InflateVehicleWheels(StringBuilder i_LicenceID)
        {
            bool licenceIDKeyExists = r_GarageVehicles.ContainsKey(i_LicenceID);

            if (licenceIDKeyExists)
            {
                r_GarageVehicles[i_LicenceID].Vehicle.InflateAllWheelsToMax();
            }

            /// ArgumentException ?
        }

        /// 5
        public void ChargeVehicle(StringBuilder i_LicenceID, float i_TimeToChargeInMinutes)
        {
            bool licenceIDKeyExists = r_GarageVehicles.ContainsKey(i_LicenceID);

            if (licenceIDKeyExists)
            {
                /// r_GarageVehicles[i_LicenceID].Vehicle.LoadEnergy(i_TimeToChargeInMinutes);
            }

            /// ArgumentException ?
        }

        /// 6 
        public void FuelVehicle(StringBuilder i_LicenceID, float i_FuelAmount, FuelEnergy.eFuelType i_FuelType)
        {
            bool licenceIDKeyExists = r_GarageVehicles.ContainsKey(i_LicenceID);

            if (licenceIDKeyExists)
            {
                /// ...
            }

            /// ArgumentException ?
        }

        public bool LicenceIDExistenceValidation(StringBuilder i_LicenceID)
        {
            bool licenceIDKeyExists;
            
            if (r_GarageVehicles.ContainsKey(i_LicenceID))
            {
                licenceIDKeyExists = true;
            }

            else
            {
                licenceIDKeyExists = false;
            }

            return licenceIDKeyExists;
        }


    }
}
