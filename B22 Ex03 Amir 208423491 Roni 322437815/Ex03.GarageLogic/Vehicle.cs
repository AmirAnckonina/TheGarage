using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ex03.GarageLogic
{
    public abstract class Vehicle
    {
        
        private readonly StringBuilder r_LicenceID;
        private readonly StringBuilder r_ModelName;
        private Energy r_VehicleEnergy;
        private List<Wheel> m_VehicleWheels;


    /*            i_ModelName,
                  i_LicenceID,
                  i_CarEnergy,
                  i_WheelManufacturerName,
                  i_NumOfWheels,
                  i_CarWheelMaxPSI,
                  i_CarWheelPSIAfterManufacture*/

        public Vehicle(
            StringBuilder i_ModelName,
            StringBuilder i_LicenceID,
            Energy i_VehicleEnergy,
            StringBuilder i_WheelManufacturerName,
            int i_NumOfWheels,
            float i_WheelMaxPSI,
            float i_WheelPSIAfterManufacture)
        {
            r_ModelName = i_ModelName;
            r_LicenceID = i_LicenceID;
            r_VehicleEnergy = i_VehicleEnergy;
            m_VehicleWheels = new List<Wheel>(i_NumOfWheels);
            for (int idx = 0; idx < i_NumOfWheels; idx++)
            {
                m_VehicleWheels[idx] = new Wheel(i_WheelManufacturerName, i_WheelMaxPSI, i_WheelPSIAfterManufacture);
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
