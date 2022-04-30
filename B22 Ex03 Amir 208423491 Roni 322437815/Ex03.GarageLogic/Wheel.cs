using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ex03.GarageLogic
{
    public class Wheel
    {
        private readonly StringBuilder r_Manufacturer;
        private float m_currentPSI;
        private readonly float r_MaxPSI;

        public Wheel(StringBuilder i_Manufacturer, float i_CurrentPSI, float i_MaxPSI)
        {
            r_Manufacturer = i_Manufacturer;
            m_currentPSI = i_CurrentPSI;
            r_MaxPSI = i_MaxPSI;
        }

        public Wheel(Type vehicleType)
        {

            /*if(vehicleType == typeof(Motorcycle))
            {
                r_Manufacturer = i_Manufacturer;
                m_currentPSI = i_CurrentPSI;
                r_MaxPSI = i_MaxPSI;
            }

            else if (vehicleType == typeof(Car))
            {
                r_Manufacturer = i_Manufacturer;
                m_currentPSI = i_CurrentPSI;
                r_MaxPSI = i_MaxPSI;
            }

            else /// vehicleType == typeof(Truck)
            {
                r_Manufacturer = i_Manufacturer;
                m_currentPSI = 20; /// ?
                r_MaxPSI = 24;
            }*/
        }

        public void InflateWheelToMax()
        {
            m_currentPSI = r_MaxPSI;
        }

    }
}
