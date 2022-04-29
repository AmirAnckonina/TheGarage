using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GarageLogic
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

        public FuelEnergy(float i_FuelLeft, float i_MaxFuelCapacity)
            : base(i_FuelLeft, i_MaxFuelCapacity)
        { }
    }
}
