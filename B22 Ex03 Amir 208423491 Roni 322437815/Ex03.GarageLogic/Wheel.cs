using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ex03.GarageLogic
{
    public class Wheel
    {
        private string m_WheelManufacturerName;
        private float m_currentPSI;
        private readonly float r_MaxPSI;
        private const int k_MaxWheelManufacturerNameLength = 30;

        public Wheel(string i_WheelManufacturerName, float i_WheelMaxPSI, float i_WheelPSIAfterManufacture)
        {
            WheelManufacturerNameSetup(i_WheelManufacturerName);
            r_MaxPSI = i_WheelMaxPSI;
            m_currentPSI = i_WheelPSIAfterManufacture;
        }

        public string WheelManufacturerName
        {
            get
            {
                return m_WheelManufacturerName;
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

        private void WheelManufacturerNameSetup(string i_WheelManufacturerName)
        {
            if (i_WheelManufacturerName.Length > k_MaxWheelManufacturerNameLength)
            {
                throw new FormatException("Invalid Wheel manfacturer name.");
            }

            m_WheelManufacturerName = i_WheelManufacturerName;
        }
        
        public StringBuilder GetWheelDetails()
        {
            StringBuilder infoOutput = new StringBuilder();

            infoOutput.AppendLine("Wheel manufacturer: " + m_WheelManufacturerName);
            infoOutput.AppendLine("Current PSI: " + m_currentPSI);
            infoOutput.Append("Max manufacturer PSI: " + r_MaxPSI);

            return infoOutput;
        }
    }
}
