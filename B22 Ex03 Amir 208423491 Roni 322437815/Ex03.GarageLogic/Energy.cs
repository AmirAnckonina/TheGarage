using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ex03.GarageLogic
{
    public abstract class Energy
    {
        private float m_EnergyLeft;
        private float m_EnergyLeftPercentage;
        private readonly float r_MaxEnergyCapacity;

        public Energy(float i_MaxEnergyCapacity, float i_EnergyLeft)
        {
            r_MaxEnergyCapacity = i_MaxEnergyCapacity;
            m_EnergyLeft = i_EnergyLeft;
            /// -> Percentage representaion calculation.
            m_EnergyLeftPercentage = (i_EnergyLeft / r_MaxEnergyCapacity) * 100;
        }

        public float EnergyLeft
        {
            get
            {
                return m_EnergyLeft;
            }

            set
            {
                m_EnergyLeft = value;
            }
        }

        public float MaxEnergyCapacity
        {
            get
            {
                return r_MaxEnergyCapacity;
            }
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

        public abstract StringBuilder GetEnergyInfo();

        public void LoadEnergy(float i_EnergyAmountInHours)
        {
            float newEnergyAmount = m_EnergyLeft + i_EnergyAmountInHours;
            if (newEnergyAmount > r_MaxEnergyCapacity)
            {
                float currentMaxAmountToFill = r_MaxEnergyCapacity - m_EnergyLeft;
                string errMessage = string.Format("You've reached the maximum energy, please enter valid amount between {0} - {1}", 0f, currentMaxAmountToFill);
                throw new ValueOutOfRangeException(errMessage, currentMaxAmountToFill, 0f);
            }

            m_EnergyLeft = newEnergyAmount;
            m_EnergyLeftPercentage = (m_EnergyLeft / r_MaxEnergyCapacity) * 100;  
        }
    }
}
