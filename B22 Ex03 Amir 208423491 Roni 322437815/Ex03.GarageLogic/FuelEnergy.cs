using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ex03.GarageLogic
{
    public class FuelEnergy : Energy
    {
        public enum eFuelType
        {
            Soler,
            Octan95,
            Octan96,
            Octan98
        }

        private readonly eFuelType r_FuelType;

        public FuelEnergy(eFuelType i_FuelType, float i_MaxFuelCapacity, float i_FuelLeft)
            : base(i_MaxFuelCapacity, i_FuelLeft)
        {
            r_FuelType = i_FuelType;
        }

        public void Refuel(float i_FuelAmount, eFuelType i_FuelType)
        {
            if (i_FuelType != r_FuelType)
            {

            }

            else
            {

            }
        }
    }
}
