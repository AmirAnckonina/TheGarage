using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ex03.GarageLogic
{
    public class Motorcycle : Vehicle
    {
        private enum eMCLicenceType
        {
            A = 1,
            A1,
            B1,
            BB
        }

        internal static class MCFuelSpecifications
        {
            internal const Fuel.eFuelType k_MCFuelType = Fuel.eFuelType.Octan98;
            internal const float k_MCMaxFuelCapacity = 6.2f;
            internal const float k_MCFuelAfterManufacture = 2;
        }

        internal static class MCElectricSpecifications
        {
            internal const float k_MCMaxBatteryLoadInHours = 2.5f;
            internal const float k_MCBatteryInHoursAfterManufacture = 1.0f;
        }

        internal static class MCWheelSpecifications
        {
            internal const int k_MCNumOfWheels = 2;
            internal const float k_MCWheelMaxPSI = 31;
            internal const float k_MCWheelPSIAfterManufacture = 20;
        }

        private eMCLicenceType m_MCLicenseType;
        private int m_EngineCapacity;

        public Motorcycle(string i_LicenseID, Energy i_MCEnergy)
            : base(i_LicenseID, i_MCEnergy)
        {
            AddAddtionalDetailsToDictionary();
        }

        private void AddAddtionalDetailsToDictionary()
        {
            s_AdditionalVehicleDetails.Add(
                "MClicenseID", 
                "Please enter the motorcycle License type: \n 1 - A \n 2 - A1 \n 3 - B1 \n 4 - BB");
            s_AdditionalVehicleDetails.Add("MCEngineCapacity", "Please enter the motorcycle engine capacity: ");
        }

        public override void SetSingleDetail(string i_Key, string i_InsertedValue)
        {
            if (i_Key == "MClicenseID")
            {
                EMCLicenseTypeSetup(i_InsertedValue);
            }

            else if (i_Key == "MCEngineCapacity")
            {
                EngineCapacitySetup(i_InsertedValue);
            }

            else if (i_Key == "WheelManufcaturer")
            {
                InitVehicleWheels(
                    MCWheelSpecifications.k_MCNumOfWheels,
                    i_InsertedValue,
                    MCWheelSpecifications.k_MCWheelMaxPSI,
                    MCWheelSpecifications.k_MCWheelPSIAfterManufacture);
            }

            else
            {
                base.SetSingleDetail(i_Key, i_InsertedValue);
            }
        }

        private void EMCLicenseTypeSetup(string i_InsertedValue)
        {
            bool parseValueSucceed;
            eMCLicenceType MCLicenseTypeChoice;
            int numOfOptions = Enum.GetValues(typeof(eMCLicenceType)).Length;

            parseValueSucceed = Enum.TryParse(i_InsertedValue, out MCLicenseTypeChoice);
            if (!parseValueSucceed || !EnumValidator.EnumRangeValidation(1, numOfOptions, (int)MCLicenseTypeChoice))
            {
                throw new FormatException("Invalid car color selection.");
            }

            m_MCLicenseType = MCLicenseTypeChoice;
        }

        private void EngineCapacitySetup(string i_InsertedValue)
        {
            bool parseValueSucceed;

            parseValueSucceed = int.TryParse(i_InsertedValue, out m_EngineCapacity);
            if (!parseValueSucceed)
            {
                throw new FormatException("Invalid engine capacity selection.");
            }
        }

        public override StringBuilder GetVehicleInfo()
        {
            StringBuilder infoOutput = new StringBuilder();

            infoOutput.AppendLine("Vehicle type: " + this.GetType().Name);
            infoOutput.Append(base.GetVehicleInfo());
            infoOutput.AppendLine("Motorcycle license type: " + Enum.GetName(typeof(eMCLicenceType), m_MCLicenseType));
            infoOutput.AppendLine("Motorcycle engine capacity: " + m_EngineCapacity);

            return infoOutput;
        }
    }
}
