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

        /*public enum eCarManufactureDetails
        {
            Color,
            DoorsNumber
        }*/

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



        private readonly eColor r_Color;
        private readonly eDoorsNumber r_DoorsNumber;
        /// private readonly eCarManufactureDetails[] sr_CarManufactureDetails;
        /// private Dictionary<string, string> m_RequestedCarManufactureDetails;

        public Car(string i_LicenceID, Energy i_CarEnergy)
            : base(i_LicenceID, i_CarEnergy)
        {
            /*sr_CarManufactureDetails[0] = eCarManufactureDetails.Color;
            sr_CarManufactureDetails[1] = eCarManufactureDetails.DoorsNumber;
            m_RequestedCarManufactureDetails.Add("Car color", "");
            m_RequestedCarManufactureDetails.Add("Car doors number", "");*/
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
            r_Color = i_Color;
            r_DoorsNumber = i_DoorsNumber;
        }


    }
}
