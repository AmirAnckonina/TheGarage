using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ex03.GarageLogic
{
    public enum eEnergyType
    {
        Fuel,
        Electric
    }

    public abstract class Energy
    {
        private float m_EnergyLeft;
        private readonly float r_MaxEnergyCapacity;

        public Energy(float i_EnergyLeft, float i_MaxEnergyCapacity)
        {
            m_EnergyLeft = i_EnergyLeft;
            r_MaxEnergyCapacity = i_MaxEnergyCapacity;
        }

    }

    /*public void LoadEnergy(float i_EnergyAmount)
    {
        m_EnergyLeft += i_EnergyAmount;
    }*/
}
