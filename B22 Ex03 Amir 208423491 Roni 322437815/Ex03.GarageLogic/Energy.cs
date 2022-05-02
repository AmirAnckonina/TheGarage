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
            Electric,
            None
        }

        private float m_EnergyLeft;
        private float m_EnergyLeftPercentage;
        private readonly float r_MaxEnergyCapacity;

        public Energy(float i_MaxEnergyCapacity, float i_EnergyLeft)
        {
            r_MaxEnergyCapacity = i_MaxEnergyCapacity;
            m_EnergyLeft = i_EnergyLeft;
            m_EnergyLeftPercentage = (i_EnergyLeft / r_MaxEnergyCapacity) * 100;
        }

        public float EnergyLeftPercentage
        {
            get
            {
                return m_EnergyLeftPercentage;
            }
            set
            {
                m_EnergyLeftPercentage = value;
            }
        }

        public void LoadEnergy(float i_EnergyAmountInHours)
        {
            float newEnergyAmount = m_EnergyLeft + i_EnergyAmountInHours;
            if (newEnergyAmount <= r_MaxEnergyCapacity)
            {
                m_EnergyLeft = newEnergyAmount;
                m_EnergyLeftPercentage = (m_EnergyLeft / r_MaxEnergyCapacity) * 100;
            }

            ///ValueOutOfRangeException
        }

    }
}
