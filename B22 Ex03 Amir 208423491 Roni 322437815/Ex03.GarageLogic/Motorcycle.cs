using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ex03.GarageLogic
{
    public class Motorcycle : Vehicle
    {

        public enum eMotorcycleLicenceType
        {
            A,
            A1,
            B1,
            BB
        }

        private readonly eMotorcycleLicenceType r_LicenceType;
        private readonly int r_EngineCapacity;

        public Motorcycle(
            StringBuilder i_ModelName,
            StringBuilder i_LicenceID,
            Energy.eEnergyType i_EnergyType,
            StringBuilder i_WheelManufacturerName,
            eMotorcycleLicenceType i_MCLicenceType,
            int i_EngineCapacity)
            : base(
                  i_ModelName,
                  i_LicenceID
                  , i_EnergyType,
                  i_WheelManufacturerName,
                  0,
                  0)
        {
            r_LicenceType = i_MCLicenceType;
            r_EngineCapacity = i_EngineCapacity;
        }

        /*public override void InflateAllWheelsToMax()
        {
            foreach (Wheel wheel in VehicleWheels)
            {
                wheel.InflateWheelToMax()
            }
        }*/


    }
}
