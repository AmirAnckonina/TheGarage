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

        private static readonly int sr_CarNumOfWheels = 4;
        private static readonly float sr_CarWheelMaxPSI = 4;
        private readonly eColor r_Color;
        private readonly eDoorsNumber r_DoorsNumber;

        public Car(
            StringBuilder i_ModelName,
            StringBuilder i_LicenceID,
            Energy.eEnergyType i_EnergyType,
            StringBuilder i_WheelManufacturerName,
            eColor i_Color,
            eDoorsNumber i_DoorsNumber)
            : base(
                  i_ModelName,
                  i_LicenceID
                  , i_EnergyType,
                  i_WheelManufacturerName,
                  sr_CarNumOfWheels,
                  sr_CarWheelMaxPSI)
        {
            r_Color = i_Color;
            r_DoorsNumber = i_DoorsNumber;
        }
    }
}
