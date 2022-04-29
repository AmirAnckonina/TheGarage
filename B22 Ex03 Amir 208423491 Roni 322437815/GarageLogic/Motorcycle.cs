using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GarageLogic
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
        private readonly int r_EngineVolumeCC;

        public Motorcycle(StringBuilder i_ModelName, StringBuilder i_LicenceID, float i_EnergyPercentage, int i_NumOfWheels, eLicenceType i_LicenceType, int i_EngineVolumeCC)
            : base(i_ModelName,  i_LicenceID, i_EnergyPercentage, i_NumOfWheels)
        {
            r_LicenceType = i_LicenceType;
            r_EngineVolumeCC = i_EngineVolumeCC;
        }



    }
}
