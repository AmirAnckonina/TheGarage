using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ex03.GarageLogic
{
    public abstract class Vehicle
    {
        private readonly StringBuilder r_ModelName;
        private readonly StringBuilder r_LicenceID;
        private readonly float r_Energyercentage;
        private readonly List<Wheel> r_VehicleWheels;
        private readonly Energy energy;

        public Vehicle(StringBuilder i_ModelName, StringBuilder i_LicenceID, float i_EnergyPercentage, int i_NumOfWheels)
        {
            r_ModelName = i_ModelName;
            r_LicenceID = i_LicenceID;
            r_Energyercentage = i_EnergyPercentage;
            r_VehicleWheels = new List<Wheel>(i_NumOfWheels);
            for (int idx = 0; idx < i_NumOfWheels; idx++)
            {
                ///r_VehicleWheels[idx] = new Wheel(r_ModelName, (float)(3.2), (float)(5.5));
                /// r_VehicleWheels[idx] = new Wheel));
            }
            
        }

    }
}
