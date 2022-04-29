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
    }
}
