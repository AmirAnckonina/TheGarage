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
            Blue
        }

        public enum eDoorsNumber
        {
            Two = 2,
            Three = 3,
            Four = 4,
            Five = 5
        }

        internal static class CarWheelSpecifications
        {
            internal const int k_CarNumOfWheels = 4;
            internal const float k_CarWheelMaxPSI = 29;
            internal const float k_CarWheelPSIAfterManufacture = 20;
        }

        
        private readonly eColor r_Color;
        private readonly eDoorsNumber r_DoorsNumber;

        public Car(
            StringBuilder i_ModelName,
            StringBuilder i_LicenceID,
            Energy i_CarEnergy,
            StringBuilder i_WheelManufacturerName,
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
