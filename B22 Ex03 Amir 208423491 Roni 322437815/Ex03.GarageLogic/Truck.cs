using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ex03.GarageLogic
{
    public class Truck : Vehicle
    {
        private readonly bool r_HasCoolingCargo;
        private readonly float r_CargoCapcity;

        public Truck(
            StringBuilder i_ModelName,
            StringBuilder i_LicenceID,
            Energy.eEnergyType i_EnergyType,
            StringBuilder i_WheelManufacturerName,
            bool i_HasCoolingCargo,
            float i_CargoCapacity)
            : base(
                  i_ModelName,
                  i_LicenceID
                  , i_EnergyType,
                  i_WheelManufacturerName,
                  0,
                  0)
        {
            r_HasCoolingCargo = i_HasCoolingCargo;
            r_CargoCapcity = i_CargoCapacity;
        }
    }
}
