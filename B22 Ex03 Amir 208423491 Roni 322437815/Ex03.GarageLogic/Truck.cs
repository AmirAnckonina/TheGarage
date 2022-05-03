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
            internal const FuelEnergy.eFuelType k_TruckFuelType = FuelEnergy.eFuelType.Soler;
            internal const float k_TruckMaxFuelCapacity = 120;
            internal const float k_TruckFuelAfterManufacture = 40;
        }

        private enum eTruckManufactureDetails
        {
            CoolingCargo,
            CargoCapacity
        }

        private readonly bool r_HasCoolingCargo;
        private readonly float r_CargoCapcity;

        public Truck(string i_LicenceID, Energy i_TruckEnergy)
            : base(i_LicenceID, i_TruckEnergy)
        {
            initDictionaries();
        }

        public Truck(
            string i_ModelName,
            string i_LicenceID,
            Energy i_TruckEnergy,
            string i_WheelManufacturerName,
            bool i_HasCoolingCargo,
            float i_CargoCapacity)
            : base(
                  i_ModelName,
                  i_LicenceID,
                  i_TruckEnergy,
                  i_WheelManufacturerName,
                  TruckWheelSpecifications.k_TruckNumOfWheels,
                  TruckWheelSpecifications.k_TruckWheelMaxPSI,
                  TruckWheelSpecifications.k_TruckWheelPSIAfterManufacture)
        {
            r_HasCoolingCargo = i_HasCoolingCargo;
            r_CargoCapcity = i_CargoCapacity;
        }

        private void InitDictionary()
        {
            m_AdditionalVehicleDetails.Add("Has Cooling cargo", "");
            m_AdditionalVehicleDetails.Add("Cargo capacity", "");
        }
    }
}
