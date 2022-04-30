using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ex03.GarageLogic
{
    public class ElectricEnergy : Energy
    {
        public ElectricEnergy(float i_BatteryLeft, float i_MaxBatteryCapacity)
            : base(i_BatteryLeft, i_MaxBatteryCapacity)
        { }

       public void ChargeBattery(float i_TimeToChargeInMinutes)
        {
            /// Convert minutes to hours.
            base.LoadEnergy(i_TimeToChargeInMinutes / 60);
        }
    }
}
