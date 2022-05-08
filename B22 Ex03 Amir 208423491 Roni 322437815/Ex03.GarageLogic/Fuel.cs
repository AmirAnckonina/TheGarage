using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ex03.GarageLogic
{
    public class Fuel : Energy
    {
        public enum eFuelType
        {
            Soler,
            Octan95,
            Octan96,
            Octan98,
        }
        
        private readonly eFuelType r_FuelType;

        public Fuel(eFuelType i_FuelType, float i_MaxFuelCapacity, float i_FuelLeft)
            : base(i_MaxFuelCapacity, i_FuelLeft)
        {
            r_FuelType = i_FuelType;
        }

        public eFuelType FuelType
        {
            get
            {
                return r_FuelType;
            }
        }

        public void Refuel(float i_FuelAmount, eFuelType i_FuelType)
        {
            if (i_FuelType != r_FuelType)
            {
                throw new ArgumentException("The inserted fuel type isn't matching with vehicle fuel type.");
            }

            base.LoadEnergy(i_FuelAmount);
        }

        public override StringBuilder GetEnergyInfo()
        {
            StringBuilder infoOutput = new StringBuilder();

            infoOutput.AppendLine("Fuel type: " + Enum.GetName(typeof(eFuelType), r_FuelType));
            infoOutput.AppendLine("Fuel left: " + EnergyLeft + "Liter");
            infoOutput.AppendLine("Fuel left in percentage: " + EnergyLeftPercentage + "%");
            infoOutput.Append("Max fuel tank: " + MaxEnergyCapacity + "Liter");

            return infoOutput;
        }
    }
}
