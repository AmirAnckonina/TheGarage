using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ex03.GarageLogic
{
    public class Electric : Energy
    {
        public Electric(float i_MaxBatteryCapacity, float i_BatteryLeft)
            : base(i_MaxBatteryCapacity, i_BatteryLeft)
        { }

        public void ChargeBattery(float i_TimeToChargeInMinutes)
        {
            /// Convert minutes to hours calculation.
            base.LoadEnergy(i_TimeToChargeInMinutes / 60f);
        }

        public override StringBuilder GetEnergyInfo()
        {
            StringBuilder infoOutput = new StringBuilder();

            infoOutput.AppendLine("Battery left in hours: " + EnergyLeft + "h");
            infoOutput.AppendLine("Battery left in percentage: " + EnergyLeftPercentage + "%");
            infoOutput.Append("Full battery capacity in hours: " + MaxEnergyCapacity + "h");

            return infoOutput;
        }
    }
}
