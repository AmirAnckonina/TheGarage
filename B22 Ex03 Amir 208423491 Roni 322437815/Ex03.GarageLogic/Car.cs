using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ex03.GarageLogic
{
    public class Car : Vehicle
    {
        public enum eColor
        {
            Red,
            White,
            Green,
            Blue,
            None
        }

        public enum eDoorsNumber
        {
            Two = 2,
            Three = 3,
            Four = 4,
            Five = 5,
            None
        }

        public enum eCarManufactureDetails
        {
            Color,
            DoorsNumber
        }

        internal static class CarFuelSpecifications
        {
            internal const FuelEnergy.eFuelType k_CarFuelType = FuelEnergy.eFuelType.Octan95;
            internal const float k_CarMaxFuelCapacity = 38;
            internal const float k_CarFuelAfterManufacture = 20;
        }

        internal static class CarElectricSpecifications
        {
            internal const float k_CarMaxBatteryLoadInHours = 3.3f;
            internal const float k_CarBatteryInHoursAfterManufacture = 1.0f;
        }

        internal static class CarWheelSpecifications
        {
            internal const int k_CarNumOfWheels = 4;
            internal const float k_CarWheelMaxPSI = 29;
            internal const float k_CarWheelPSIAfterManufacture = 20;
        }

        private eColor m_CarColor;
        private eDoorsNumber m_DoorsNumber;

        public Car(string i_LicenceID, Energy i_CarEnergy)
            : base(i_LicenceID, i_CarEnergy)
        {
            AddAddtionalDetailsToDictionary();
        }

        public Car(
            string i_ModelName,
            string i_LicenceID,
            Energy i_CarEnergy,
            string i_WheelManufacturerName,
            eColor i_Color,
            eDoorsNumber i_DoorsNumber)
            : base(
                  i_ModelName,
                  i_LicenceID,
                  i_CarEnergy,
                  i_WheelManufacturerName,
                  CarWheelSpecifications.k_CarNumOfWheels,
                  CarWheelSpecifications.k_CarWheelMaxPSI,
                  CarWheelSpecifications.k_CarWheelPSIAfterManufacture)
        {
            m_CarColor = i_Color;
            m_DoorsNumber = i_DoorsNumber;
        }

        private void AddAddtionalDetailsToDictionary()
        {
            m_AdditionalVehicleDetails.Add("CarColor", "Message");
            m_AdditionalVehicleDetails.Add("CarDoorsNumber", "Message");
        }

        public override void SetSingleDetail(string i_Key, string i_InsertedValue)
        {
            bool parseValueSucceed = false;
            if (!m_AdditionalVehicleDetails.ContainsKey(i_Key))
            {
                /// throw exception 
            }

            if (i_Key == "CarColor")
            {
                parseValueSucceed = Enum.TryParse(i_InsertedValue, out m_CarColor);
            }

            else if (i_Key == "CarDoorsNumber")
            {
                parseValueSucceed = Enum.TryParse(i_InsertedValue, out m_DoorsNumber);
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
                    CarWheelSpecifications.k_CarNumOfWheels,
                    i_InsertedValue,
                    CarWheelSpecifications.k_CarWheelMaxPSI,
                    CarWheelSpecifications.k_CarWheelPSIAfterManufacture);
            }

            if (!parseValueSucceed)
            {
                /// throw
            }

            
        }

    }
}
