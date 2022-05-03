using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ex03.GarageLogic
{
    public class Truck : Vehicle
    {
        internal static class TruckWheelSpecifications
        {
            internal const int k_TruckNumOfWheels = 16;
            internal const float k_TruckWheelMaxPSI = 24;
            internal const float k_TruckWheelPSIAfterManufacture = 20;
        }

        internal static class TruckFuelSpecifications
        {
            internal const FuelEnergy.eFuelType k_TruckFuelType = FuelEnergy.eFuelType.Soler;
            internal const float k_TruckMaxFuelCapacity = 120;
            internal const float k_TruckFuelAfterManufacture = 40;
        }

        private enum eTruckManufactureDetails
        {
            CoolingCargo,
            CargoCapacity
        }

        private enum eHasCoolingCargo
        {
            Yes = 1,
            No = 2
        }

        private eHasCoolingCargo m_HasCoolingCargo;
        private  float m_CargoCapcity;

        public Truck(string i_LicenceID, Energy i_TruckEnergy)
            : base(i_LicenceID, i_TruckEnergy)
        {
            AddAddtionalDetailsToDictionary();
        }

     /*   public Truck(
            string i_ModelName,
            string i_LicenceID,
            Energy i_TruckEnergy,
            string i_WheelManufacturerName,
            bool i_HasCoolingCargo,
            float i_CargoCapacity)
            : base(
                  i_ModelName,
                  i_LicenceID,
                  i_TruckEnergy,
                  i_WheelManufacturerName,
                  TruckWheelSpecifications.k_TruckNumOfWheels,
                  TruckWheelSpecifications.k_TruckWheelMaxPSI,
                  TruckWheelSpecifications.k_TruckWheelPSIAfterManufacture)
        {
            r_HasCoolingCargo = i_HasCoolingCargo;
            r_CargoCapcity = i_CargoCapacity;
        }*/

        private void AddAddtionalDetailsToDictionary()
        {
            m_AdditionalVehicleDetails.Add("CoolingCargo", "If the truck has cooling cargo option: ");
            m_AdditionalVehicleDetails.Add("CargoCapacity", "Truck Cargo Capacity");
        }

        public override void SetSingleDetail(string i_Key, string i_InsertedValue)
        {
            bool parseValueSucceed = false;
            if (!m_AdditionalVehicleDetails.ContainsKey(i_Key))
            {
                /// throw exception 
            }

            /// <==================================================================>
            /// <==================================================================>


            if (i_Key == "CoolingCargo")
            {
                parseValueSucceed = Enum.TryParse(i_InsertedValue, out m_HasCoolingCargo);
            }

            else if (i_Key == "CargoCapacity")
            {
                parseValueSucceed = float.TryParse(i_InsertedValue, out m_CargoCapcity);
            }

            else if (i_Key == "ModelName")
            {
                parseValueSucceed = true;
                ModelName = i_InsertedValue;
            }

            else if (i_Key == "WheelManufcaturer")
            {
                parseValueSucceed = true;
                InitVehicleWheels(
                    TruckWheelSpecifications.k_TruckNumOfWheels,
                    i_InsertedValue,
                    TruckWheelSpecifications.k_TruckWheelMaxPSI,
                    TruckWheelSpecifications.k_TruckWheelPSIAfterManufacture);
            }

            /// <==================================================================>
            /// <==================================================================>

            if (!parseValueSucceed)
            {
                /// throw
            }


        }
    }
}
