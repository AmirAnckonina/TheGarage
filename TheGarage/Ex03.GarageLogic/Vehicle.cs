using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ex03.GarageLogic
{
    public abstract class Vehicle
    {
        private const int k_MaxModelNameLength = 30;
        private readonly string r_LicenseID;
        private string m_ModelName;
        private readonly Energy r_VehicleEnergy;
        private List<Wheel> m_VehicleWheels;
        protected static Dictionary<string, string> s_AdditionalVehicleDetails;

        public Vehicle(string i_LicenseID, Energy i_VehicleEnergy)
        {
            r_LicenseID = i_LicenseID;
            r_VehicleEnergy = i_VehicleEnergy;
            InitDictionary();
        }

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

        public string LicenseID
        {
            get
            {
                return m_ModelName;
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
                m_VehicleWheels = value;
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
                return s_AdditionalVehicleDetails;
            }
            set
            {
                s_AdditionalVehicleDetails = value;
            }
        }

        public void InitDictionary()
        {
            s_AdditionalVehicleDetails = new Dictionary<string, string>();
            s_AdditionalVehicleDetails.Add("ModelName", "Please enter the vehicle model name: ");
            s_AdditionalVehicleDetails.Add("WheelManufcaturer", "Please enter the wheel manufacturer name: ");
        }

        public virtual void SetSingleDetail(string i_Key, string i_InsertedValue)
        {
            if (!s_AdditionalVehicleDetails.ContainsKey(i_Key))
            {
                throw new FormatException("Detail not found in car manufacture required details.");
            }

            if (i_Key == "ModelName")
            {
                ModelNameSetup(i_InsertedValue);
            }
        }

        private void ModelNameSetup(string i_InsertedValue)
        {
            if (i_InsertedValue.Length > k_MaxModelNameLength)
            {
                throw new FormatException("Invalid Model name");
            }

            m_ModelName = i_InsertedValue;
        }

        public void InitVehicleWheels(int i_NumOfWheels, string i_WheelManufacturerName, float i_WheelMaxPSI, float i_WheelPSIAfterManufacture)
        {
            m_VehicleWheels = new List<Wheel>(i_NumOfWheels);

            for (int idx = 0; idx < i_NumOfWheels; idx++)
            {
                m_VehicleWheels.Add(new Wheel(i_WheelManufacturerName, i_WheelMaxPSI, i_WheelPSIAfterManufacture));
            }
        }

        public virtual StringBuilder GetVehicleInfo()
        {
            StringBuilder infoOutput = new StringBuilder();

            infoOutput.AppendLine("Vehicle license ID: " + r_LicenseID);
            infoOutput.AppendLine("Vehicle model name: " + m_ModelName);
            infoOutput.AppendLine("Wheels information: " + m_VehicleWheels[0].GetWheelDetails());
            infoOutput.AppendLine("Energy source: " + r_VehicleEnergy.GetType().Name);
            infoOutput.Append(r_VehicleEnergy.GetEnergyInfo());
            infoOutput.AppendLine();

            return infoOutput;
        }   
    }
}
