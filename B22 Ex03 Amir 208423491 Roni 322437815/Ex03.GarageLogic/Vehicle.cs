using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ex03.GarageLogic
{
    public abstract class Vehicle
    {
        private readonly StringBuilder r_ModelName;
        private readonly StringBuilder r_LicenceID;
        private float m_EnergyPercentage;
        private Energy r_VehicleEnergy;
        private List<Wheel> m_VehicleWheels;

        public Vehicle(StringBuilder i_ModelName, StringBuilder i_LicenceID, float i_EnergyPercentage, int i_NumOfWheels)
        {
            r_ModelName = i_ModelName;
            r_LicenceID = i_LicenceID;
            m_EnergyPercentage = i_EnergyPercentage;
            m_VehicleWheels = new List<Wheel>(i_NumOfWheels);
            for (int idx = 0; idx < i_NumOfWheels; idx++)
            {
                ///r_VehicleWheels[idx] = new Wheel(r_ModelName, (float)(3.2), (float)(5.5));
                /// r_VehicleWheels[idx] = new Wheel));
            }

        }

        public StringBuilder ModelName
        {
            get
            {
                return r_ModelName;
            }
        }

        public StringBuilder LicenceID
        {
            get
            {
                return r_ModelName;
            }
        }

        public Energy VehicleEnergy
        {
            get
            {
                return r_VehicleEnergy;
            }

/*            set
            {
                r_VehicleEnergy = value;
            }*/
        }

        public float EnergyPercentage
        {
            get
            {
                return m_EnergyPercentage;
            }
        }

        public List<Wheel> VehicleWheels
        {
            get
            {
                return m_VehicleWheels;
            }

            set
            {

            }
        }

        public Wheel this[int wheelIdx]
        {
            get
            {
                return m_VehicleWheels[wheelIdx];
            }

            set
            {
                m_VehicleWheels[wheelIdx] = value;
            }
        }
        
        public void InflateAllWheelsToMax()
        {
            foreach (Wheel wheel in m_VehicleWheels)
            {
                wheel.InflateWheelToMax();
            }
        }

        

    }
}
