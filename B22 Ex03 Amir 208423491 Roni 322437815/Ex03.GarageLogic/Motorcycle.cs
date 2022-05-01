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

        internal static class MotorcycleWheelSpecifications
        {
            internal const int k_MotorcycleNumOfWheels = 2;
            internal const float k_MotorcycleWheelMaxPSI = 31;
            internal const float k_MotorcycleWheelPSIAfterManufacture = 20;
        }

        private readonly eMotorcycleLicenceType r_LicenceType;
        private readonly int r_EngineCapacity;

        public Motorcycle(
            StringBuilder i_ModelName,
            StringBuilder i_LicenceID,
            Energy i_MotorcycleEnergy,
            StringBuilder i_WheelManufacturerName,
            eMotorcycleLicenceType i_MCLicenceType,
            int i_EngineCapacity)
            : base(
                  i_ModelName,
                  i_LicenceID,
                  i_MotorcycleEnergy,
                  i_WheelManufacturerName,
                  MotorcycleWheelSpecifications.k_MotorcycleNumOfWheels,
                  MotorcycleWheelSpecifications.k_MotorcycleWheelMaxPSI,
                  MotorcycleWheelSpecifications.k_MotorcycleWheelPSIAfterManufacture)
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
