using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ex03.GarageLogic
{
    public class GarageCard
    {
        private const int k_MaxNameLength = 50;
        private const int k_MaxPhoneNumberLength = 12;
        private const int k_MinphoneNumberLength = 9;
        private static Dictionary<string, string> s_GarageCardDetails;
        private string m_OwnerName;
        private string m_OwnerPhone;
        private Garage.eVehicleStatus m_VehicleStatus;
        private Vehicle m_Vehicle;

        public GarageCard(Vehicle i_Vehicle, Garage.eVehicleStatus i_VehicleStatus)
        {
            m_Vehicle = i_Vehicle;
            m_VehicleStatus = i_VehicleStatus;
            InitGarageCardDictionary();
        }

        public string OwnerName
        {
            get
            {
                return m_OwnerName;
            }

            set
            {
                m_OwnerName = value;
            }
        }
        
        public string OwnerPhone
        {
            get
            {
                return m_OwnerPhone;
            }

            set
            {
                m_OwnerPhone = value;
            }
        }

        public Garage.eVehicleStatus VehicleStatus
        {
            get
            {
                return m_VehicleStatus;
            }

            set
            {
                m_VehicleStatus = value;
            }
        }

        public Vehicle Vehicle
        {
            get
            {
                return m_Vehicle;
            }

            set
            {
                m_Vehicle = value;
            }
        }

        public Dictionary<string, string> GarageCardDetails
        {
            get
            {
                return s_GarageCardDetails;
            }
        }

        public void SetSingleDetail(string i_Key, string i_InsertedValue)
        {
            if (!s_GarageCardDetails.ContainsKey(i_Key))
            {
                throw new Exception("Detail isn't recognized in the garage card details.");
            }

            if (i_Key == "OwnerName")
            {
                OwnerNameSetup(i_InsertedValue);
            }

            else if (i_Key == "OwnerPhone")
            {
                OwnerPhoneSetup(i_InsertedValue);  
            }
        }

        public void InitGarageCardDictionary()
        {
            s_GarageCardDetails = new Dictionary<string, string>();
            s_GarageCardDetails.Add("OwnerName", "Please enter the owner name of the vehicle:");
            s_GarageCardDetails.Add("OwnerPhone", "Please enter the phone number of the owner: ");
        }

        public StringBuilder GetGarageCardInfo()
        {
            StringBuilder garageCardInfo = new StringBuilder();

            garageCardInfo.Append(m_Vehicle.GetVehicleInfo());
            garageCardInfo.AppendLine("Vehicle owner name: " + m_OwnerName);
            garageCardInfo.AppendLine("Vehicle owner phone: " + m_OwnerPhone);
            garageCardInfo.AppendLine("Vehicle current status in the garage: " + Enum.GetName(typeof(Garage.eVehicleStatus), m_VehicleStatus));

            return garageCardInfo;
        }

        private bool OwnerNameContentValidation(string i_InsertedValue)
        {
            bool isOwnerNameValid;

            if(i_InsertedValue.Length <= k_MaxNameLength)
            {
                isOwnerNameValid = true;
                foreach (char ch in i_InsertedValue)
                {
                    if (!char.IsLetter(ch) && !char.IsWhiteSpace(ch))
                    {
                        isOwnerNameValid = false;
                        break;
                    }
                }
            }

            else
            {
                isOwnerNameValid = false;
            }

            return isOwnerNameValid;
        }

        private bool OwnerPhoneNumberContentValidation(string i_InsertedValue)
        {
            bool isOwnerPhoneNumberValid;

            if (i_InsertedValue.Length <= k_MaxPhoneNumberLength && i_InsertedValue.Length >= k_MinphoneNumberLength && i_InsertedValue.All(char.IsDigit))
            {
                isOwnerPhoneNumberValid = true;
            }

            else
            {
                isOwnerPhoneNumberValid = false;
            }

            return isOwnerPhoneNumberValid;
        }

        private void OwnerNameSetup(string i_InsertedValue)
        {
            if (!OwnerNameContentValidation(i_InsertedValue))
            {
                throw new FormatException("Invalid owner name");
            }

            m_OwnerName = i_InsertedValue;
        }

        private void OwnerPhoneSetup(string i_InsertedValue)
        {
            if (!OwnerPhoneNumberContentValidation(i_InsertedValue))
            {
                throw new FormatException("Invalid owner phone number");
            }

            m_OwnerPhone = i_InsertedValue;
        }
    }
}
