using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GarageLogic
{
    public class Truck : Vehicle
    {
        private readonly bool r_HasCoolingCargo;
        private readonly float r_CargoCapcity;

        public Truck(StringBuilder i_ModelName, StringBuilder i_LicenceID, float i_EnergyPercentage, int i_NumOfWheels, bool i_HasCoolingCargo, float i_CargoCapacity)
            : base(i_ModelName, i_LicenceID, i_EnergyPercentage, i_NumOfWheels)
        {
            r_HasCoolingCargo = i_HasCoolingCargo;
            r_CargoCapcity = i_CargoCapacity;
        }
    }
}
