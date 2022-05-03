using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ex03.GarageLogic
{
    public abstract class Vehicle
    {

        private readonly string r_LicenceID;
        private string m_ModelName;
        private Energy r_VehicleEnergy;
        private List<Wheel> m_VehicleWheels;
        protected Dictionary<string, string> m_AdditionalVehicleDetails; /// Should be static

        public Vehicle(string i_LicenceID, Energy i_VehicleEnergy)
        {
            r_LicenceID = i_LicenceID;
            r_VehicleEnergy = i_VehicleEnergy;
            InitDictionary();
        }

       /* public Vehicle(
            string i_ModelName,
            string i_LicenceID,
            Energy i_VehicleEnergy,
            string i_WheelManufacturerName,
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
                m_VehicleWheels.Add(new Wheel(i_WheelManufacturerName, i_WheelMaxPSI, i_WheelPSIAfterManufacture));
            }

        }
*/
        public string ModelName
        {
            get
            {
                return m_ModelName;
            }

            set
            {
                m_ModelName = value;
            }
        }

        public string LicenceID
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

        public Dictionary<string, string> AdditionalVehicleDetails
        {
            get
            {
                return m_AdditionalVehicleDetails;
            }
            set
            {
                m_AdditionalVehicleDetails = value;
            }
        }

        public void InitDictionary()
        {
            m_AdditionalVehicleDetails.Add("ModelName", "Vehicle model name");
            m_AdditionalVehicleDetails.Add("WheelManufcaturer", "");
        }

        public abstract void SetSingleDetail(string i_Key, string i_InsertedValue);

        public void InitVehicleWheels(int i_NumOfWheels, string i_WheelManufacturerName, float i_WheelMaxPSI, float i_WheelPSIAfterManufacture)
        {
            m_VehicleWheels = new List<Wheel>(i_NumOfWheels);

            for (int idx = 0; idx < i_NumOfWheels; idx++)
            {
                m_VehicleWheels.Add(new Wheel(i_WheelManufacturerName, i_WheelMaxPSI, i_WheelPSIAfterManufacture));
            }

        }


    }
}
