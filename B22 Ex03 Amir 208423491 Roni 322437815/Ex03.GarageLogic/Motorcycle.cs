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
            BB,
            None
        }

        internal static class MCFuelSpecifications
        {
            internal const FuelEnergy.eFuelType k_MotorcycleFuelType = FuelEnergy.eFuelType.Octan98;
            internal const float k_MotorcycleMaxFuelCapacity = 6.2f;
            internal const float k_MotorcycleFuelAfterManufacture = 2;
        }

        internal static class MCElectricSpecifications
        {
            internal const float k_MotorcycleMaxBatteryLoadInHours = 2.5f;
            internal const float k_MotorcycleBatteryInHoursAfterManufacture = 1.0f;
        }

        internal static class MotorcycleWheelSpecifications
        {
            internal const int k_MotorcycleNumOfWheels = 2;
            internal const float k_MotorcycleWheelMaxPSI = 31;
            internal const float k_MotorcycleWheelPSIAfterManufacture = 20;
        }

        /*public enum eMotorcyclerManufactureDetails
        {
            MCLicenceType,
            EngineCapacity
        }*/

        private readonly eMotorcycleLicenceType r_LicenceType;
        private readonly int r_EngineCapacity;
        /*private readonly eMotorcyclerManufactureDetails[] sr_MCManufactureDetails;
        private Dictionary<string, string> m_RequestedMCManufactureDetails;
*/
        public Motorcycle(string i_LicenceID, Energy i_MCEnergy)
            : base(i_LicenceID, i_MCEnergy)
        {
           /* sr_MCManufactureDetails[0] = eMotorcyclerManufactureDetails.MCLicenceType;
            sr_MCManufactureDetails[1] = eMotorcyclerManufactureDetails.MCLicenceType;
            m_RequestedMCManufactureDetails.Add("Motorcycle licence type", "");
            m_RequestedMCManufactureDetails.Add("Motorcycle engine capacity", "");*/
        }

        public Motorcycle(
            string i_ModelName,
            string i_LicenceID,
            Energy i_MotorcycleEnergy,
            string i_WheelManufacturerName,
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

    }
}
