using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ex03.GarageLogic
{
    public abstract class Energy
    {
        public enum eEnergyType
        {
            Fuel,
            Electric
        }

        private float m_EnergyLeftInHours;
        private readonly float r_MaxEnergyCapacityInHours;

        public Energy(float i_EnergyLeft, float i_MaxEnergyCapacity)
        {
            m_EnergyLeftInHours = i_EnergyLeft;
            r_MaxEnergyCapacityInHours = i_MaxEnergyCapacity;
        }

        public void LoadEnergy(float i_EnergyAmountInHours)
        {
            m_EnergyLeftInHours += i_EnergyAmountInHours;
        }

    }
}
