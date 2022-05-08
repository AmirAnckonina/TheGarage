using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ex03.GarageLogic
{
    public class Truck : Vehicle
    {
        internal static class TruckWheelSpecifications
        {
            internal const int k_TruckNumOfWheels = 16;
            internal const float k_TruckWheelMaxPSI = 24;
            internal const float k_TruckWheelPSIAfterManufacture = 20;
        }

        internal static class TruckFuelSpecifications
        {
            internal const Fuel.eFuelType k_TruckFuelType = Fuel.eFuelType.Soler;
            internal const float k_TruckMaxFuelCapacity = 120;
            internal const float k_TruckFuelAfterManufacture = 40;
        }

        private enum eHasCoolingCargo
        {
            Yes = 1,
            No = 2
        }

        private eHasCoolingCargo m_HasCoolingCargo;
        private  float m_CargoCapcity;

        public Truck(string i_LicenseID, Energy i_TruckEnergy)
            : base(i_LicenseID, i_TruckEnergy)
        {
            AddAddtionalDetailsToDictionary();
        }

        private void AddAddtionalDetailsToDictionary()
        {
            s_AdditionalVehicleDetails.Add("CoolingCargo", "Please enter if the truck has cooling cargo: \n 1. Yes \n 2. No");
            s_AdditionalVehicleDetails.Add("CargoCapacity", "Please enter the truck cargo capacity: ");
        }

        public override void SetSingleDetail(string i_Key, string i_InsertedValue)
        {
            if (i_Key == "CoolingCargo")
            {
                EHasCoolingCargoSetup(i_InsertedValue);
            }

            else if (i_Key == "CargoCapacity")
            {
                CargoCapacitySetup(i_InsertedValue);
            }

            else if (i_Key == "WheelManufcaturer")
            {
                InitVehicleWheels(
                    TruckWheelSpecifications.k_TruckNumOfWheels,
                    i_InsertedValue,
                    TruckWheelSpecifications.k_TruckWheelMaxPSI,
                    TruckWheelSpecifications.k_TruckWheelPSIAfterManufacture);
            }

            else 
            {
                base.SetSingleDetail(i_Key, i_InsertedValue);
            }
        }

        private void EHasCoolingCargoSetup(string i_InsertedValue)
        {
            bool parseValueSucceed;
            eHasCoolingCargo coolinCargoChoice;
            int numOfOptions = Enum.GetValues(typeof(eHasCoolingCargo)).Length;

            parseValueSucceed = Enum.TryParse(i_InsertedValue, out coolinCargoChoice);
            if (!parseValueSucceed || !EnumValidator.EnumRangeValidation(1, numOfOptions, (int)coolinCargoChoice))
            {
                throw new FormatException("Invalid cooling cargo option selection.");
            }

            m_HasCoolingCargo = coolinCargoChoice;
        }

        private void CargoCapacitySetup(string i_InsertedValue)
        {
            bool parseValueSucceed;

            parseValueSucceed = float.TryParse(i_InsertedValue, out m_CargoCapcity);
            if (!parseValueSucceed)
            {
                throw new FormatException("Invalid cargo capacity selection.");
            }

        }

        public override StringBuilder GetVehicleInfo()
        {
            StringBuilder infoOutput = new StringBuilder();

            infoOutput.AppendLine("Vehicle type: " + this.GetType().Name);
            infoOutput.Append(base.GetVehicleInfo());
            infoOutput.AppendLine("Truck has cooling cargo: " + Enum.GetName(typeof(eHasCoolingCargo), m_HasCoolingCargo));
            infoOutput.AppendLine("Truck cargo capacity: " + m_CargoCapcity);

            return infoOutput;
        }
    }
}
