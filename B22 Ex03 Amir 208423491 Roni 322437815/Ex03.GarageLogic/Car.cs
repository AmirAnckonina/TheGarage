using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ex03.GarageLogic
{
    public class Car : Vehicle
    {
        public enum eCarColor
        {
            Red = 1,
            White,
            Green,
            Blue,
            None
        }

        public enum eDoorsNumber
        {
            Two = 1,
            Three,
            Four,
            Five,
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

        private eCarColor m_CarColor;
        private eDoorsNumber m_DoorsNumber;

        public Car(string i_LicenceID, Energy i_CarEnergy)
            : base(i_LicenceID, i_CarEnergy)
        {
            AddAddtionalDetailsToDictionary();
        }

        private void AddAddtionalDetailsToDictionary()
        {
            m_AdditionalVehicleDetails.Add("CarColor", "Please enter the Car Color:\n 1 - Red \n 2 - White \n 3 - Green \n 4 - Blue ");
            m_AdditionalVehicleDetails.Add("CarDoorsNumber", "Please enter the Doors numbers in car:\n 2 - Two \n 3 - Three \n 4 - For \n 5 - Five ");
        }

        public override void SetSingleDetail(string i_Key, string i_InsertedValue)
        {
            if (i_Key == "CarColor")
            {
                EcolorSetup(i_InsertedValue);
            }

            else if (i_Key == "CarDoorsNumber")
            {
                EDoorsNumberSetup(i_InsertedValue);
            }

            else if (i_Key == "WheelManufcaturer")
            {
                InitVehicleWheels(
                    CarWheelSpecifications.k_CarNumOfWheels,
                    i_InsertedValue,
                    CarWheelSpecifications.k_CarWheelMaxPSI,
                    CarWheelSpecifications.k_CarWheelPSIAfterManufacture);
            }

            else 
            {
                base.SetSingleDetail(i_Key, i_InsertedValue);
            }
        }

        private void EcolorSetup(string i_InsertedValue)
        {
            bool parseValueSucceed;
            eCarColor colorChoice;
            int numOfColors = Enum.GetValues(typeof(eCarColor)).Length;

            parseValueSucceed = Enum.TryParse(i_InsertedValue, out colorChoice);
            if (!parseValueSucceed || !EnumRangeValidation(1, numOfColors, (int)colorChoice)) /// To Check Parser
            {
                throw new FormatException("Invalid car color selection.");
            }

            m_CarColor = colorChoice;
        }
        
        private void EDoorsNumberSetup(string i_InsertedValue)
        {
            bool parseValueSucceed;
            eDoorsNumber doorsNumberChoice;
            int numOfDoorsNumberOptions = Enum.GetValues(typeof(eDoorsNumber)).Length;

            parseValueSucceed = Enum.TryParse(i_InsertedValue, out doorsNumberChoice);
            if (!parseValueSucceed || !EnumRangeValidation(1, numOfDoorsNumberOptions, (int)doorsNumberChoice))
            {
                throw new FormatException("Invalid car doors number selection.");
            }

            m_DoorsNumber = doorsNumberChoice;
        }

        public override StringBuilder GetVehicleInfo()
        {
            StringBuilder infoOutput = new StringBuilder();

            infoOutput.AppendLine("Vehicle type: " + this.GetType().Name);
            infoOutput.AppendLine(GetBasicVehcileDetails().ToString());
            infoOutput.AppendLine("Car color: " + Enum.GetName(typeof(eCarColor), m_CarColor));
            infoOutput.AppendLine("Car doors number: " + Enum.GetName(typeof(eDoorsNumber), m_DoorsNumber));

            return infoOutput;
        }





    }
}
