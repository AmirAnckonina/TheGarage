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
            initDictionaries();
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

        /*public override Dictionary<dynamic, string> DetailMessagePairs
        {
            get
            {
                return sr_DetailMessagePairs;
            }
        }

        public override Dictionary<dynamic, Type> DetailTypePairs
        {
            get
            {
                return sr_DetailTypePairs;
            }
        }*/

        private void InitDictionary()
        {
            m_AdditionalVehicleDetails.Add("Car color", "");
            m_AdditionalVehicleDetails.Add("Car doors number", "");
        }

    }
}
