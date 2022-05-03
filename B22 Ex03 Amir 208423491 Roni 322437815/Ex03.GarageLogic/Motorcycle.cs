using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ex03.GarageLogic
{
    public class Motorcycle : Vehicle
    {

        public enum eMotorcycleLicenceType
        {
            A = 1,
            A1,
            B1,
            BB
        }

        internal static class MCFuelSpecifications
        {
            internal const FuelEnergy.eFuelType k_MCFuelType = FuelEnergy.eFuelType.Octan98;
            internal const float k_MCMaxFuelCapacity = 6.2f;
            internal const float k_MCFuelAfterManufacture = 2;
        }

        internal static class MCElectricSpecifications
        {
            internal const float k_MCMaxBatteryLoadInHours = 2.5f;
            internal const float k_MCBatteryInHoursAfterManufacture = 1.0f;
        }

        internal static class MCWheelSpecifications
        {
            internal const int k_MCNumOfWheels = 2;
            internal const float k_MCWheelMaxPSI = 31;
            internal const float k_MCWheelPSIAfterManufacture = 20;
        }

        public enum eMCManufactureDetails
        {
            MCLicenceType,
            EngineCapacity
        }

        private eMotorcycleLicenceType m_LicenceType;
        private int m_EngineCapacity;

        public Motorcycle(string i_LicenceID, Energy i_MCEnergy)
            : base(i_LicenceID, i_MCEnergy)
        {
            AddAddtionalDetailsToDictionary();
        }

     /*   public Motorcycle(
            string i_ModelName,
            string i_LicenceID,
            Energy i_MotorcycleEnergy,
            string i_WheelManufacturerName,
            eMotorcycleLicenceType i_MCLicenceType,
            int i_EngineCapacity)
            : base(
                  i_ModelName,
                  i_LicenceID,
                  i_MotorcycleEnergy,
                  i_WheelManufacturerName,
                  MCWheelSpecifications.k_MotorcycleNumOfWheels,
                  MCWheelSpecifications.k_MotorcycleWheelMaxPSI,
                  MCWheelSpecifications.k_MotorcycleWheelPSIAfterManufacture)
        {
            m_LicenceType = i_MCLicenceType;
            m_EngineCapacity = i_EngineCapacity;
        }*/

        private void AddAddtionalDetailsToDictionary()
        {
            m_AdditionalVehicleDetails.Add("MClicenseID", "Message");
            m_AdditionalVehicleDetails.Add("MCEngineCapacity", "Message");
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


            if (i_Key == "MClicenseID")
            {
                parseValueSucceed = Enum.TryParse(i_InsertedValue, out m_LicenceType);
            }

            else if (i_Key == "MCEngineCapacity")
            {
                parseValueSucceed = int.TryParse(i_InsertedValue, out m_EngineCapacity);
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
                    MCWheelSpecifications.k_MCNumOfWheels,
                    i_InsertedValue,
                    MCWheelSpecifications.k_MCWheelMaxPSI,
                    MCWheelSpecifications.k_MCWheelPSIAfterManufacture);
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
