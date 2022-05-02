using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ex03.GarageLogic
{
    public class Wheel
    {
        private readonly StringBuilder r_WheelManufacturerName;
        private float m_currentPSI;
        private readonly float r_MaxPSI;

        public Wheel(StringBuilder i_WheelManufacturerName, float i_WheelMaxPSI, float i_WheelPSIAfterManufacture)
        {
            r_WheelManufacturerName = i_WheelManufacturerName;
            r_MaxPSI = i_WheelMaxPSI;
            m_currentPSI = i_WheelPSIAfterManufacture;
        }

        public StringBuilder WheelManufacturerName
        {
            get
            {
                return r_WheelManufacturerName;
            }
        }

        public float CurrentPSI
        {
            get
            {
                return m_currentPSI;
            }

            set
            {
                m_currentPSI = value;
            }
        }

        public void InflateWheelToMax()
        {
            m_currentPSI = r_MaxPSI;
        }

    }
}
