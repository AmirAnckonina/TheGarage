using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ex03.GarageLogic
{
    public class Motorcycle : Vehicle
    {

        public enum eLicenceType
        {
            A,
            A1,
            B1,
            BB
        }

        private readonly eLicenceType r_LicenceType;
        private readonly int r_EngineCapacityCC;

        public Motorcycle(
            StringBuilder i_ModelName,
            StringBuilder i_LicenceID,
            float i_EnergyPercentage,
            int i_NumOfWheels,
            eLicenceType i_LicenceType,
            int i_EngineCapacityCC)
            : base(i_ModelName, i_LicenceID, i_EnergyPercentage, i_NumOfWheels)
        {
            r_LicenceType = i_LicenceType;
            r_EngineCapacityCC = i_EngineCapacityCC;
        }

        /*public override void InflateAllWheelsToMax()
        {
            foreach (Wheel wheel in VehicleWheels)
            {
                wheel.
            }
        }*/


    }
}
