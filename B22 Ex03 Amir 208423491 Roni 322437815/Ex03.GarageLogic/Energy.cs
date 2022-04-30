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

        private float m_EnergyLeft;
        private float m_EnergyLeftPercentage;
        private readonly float r_MaxEnergyCapacity;

        public Energy(float i_EnergyLeft, float i_MaxEnergyCapacity)
        {
            m_EnergyLeft = i_EnergyLeft;
            r_MaxEnergyCapacity = i_MaxEnergyCapacity;
        }


        public void LoadEnergy(float i_EnergyAmountInHours)
        {
            m_EnergyLeft += i_EnergyAmountInHours;
        }

    }
}
