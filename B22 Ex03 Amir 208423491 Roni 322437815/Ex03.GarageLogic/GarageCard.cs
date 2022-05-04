using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ex03.GarageLogic
{
    public class GarageCard
    {
        private string m_OwnerName;
        private string m_OwnerPhone;
        private Garage.eVehicleStatus m_VehicleStatus;
        private Vehicle m_Vehicle;
        private static Dictionary<string, string> m_GarageCardDetails;
        public const int k_MaximumNameLength= 20;
        public const int k_MaximumphoneNumberLength = 10;

        public GarageCard()
        { 
            /// empty C'tor
        }

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
                return m_GarageCardDetails;
            }

            set
            {
                m_GarageCardDetails = value;
            }
        }

        public void SetSingleDetail(string i_Key, string i_InsertedValue)
        {
            if (!m_GarageCardDetails.ContainsKey(i_Key))
            {
                throw new Exception("Detail isn't recognized in the garage card details.");
            }

            /// <====================================================>

            if (i_Key == "OwnerName")
            {
                
            }

            else if (i_Key == "OwnerPhone")
            {
                           
            }
        }

        public void InitGarageCardDictionary()
        {
            m_GarageCardDetails = new Dictionary<string, string>();
            m_GarageCardDetails.Add("OwnerName", "Please enter the owner name of the vehicle");
            m_GarageCardDetails.Add("OwnerPhone", "Plese enter the phone number of the owner");
        }

        public StringBuilder GetGarageCardInfo()
        {
            StringBuilder garageCardInfo = new StringBuilder();

            garageCardInfo.AppendLine("Vehicle owner name: " + m_OwnerName);
            garageCardInfo.AppendLine("Vehicle owner phone: " + m_OwnerPhone);
            garageCardInfo.AppendLine("Vehicle current status in the garage: " + Enum.GetName(typeof(Garage.eVehicleStatus), m_VehicleStatus));
            garageCardInfo.Append(m_Vehicle.GetVehicleInfo());

            return garageCardInfo;
        }

        public bool OwnerNameContentValidation(string i_InsertedValue)
        {
            bool isOwnerNameValid;

            if(i_InsertedValue.Length <= k_MaximumNameLength && i_InsertedValue.All(char.IsLetter))
            {
                isOwnerNameValid = true;
            }

            else
            {
                isOwnerNameValid = false;
            }

            return isOwnerNameValid;
        }

        public bool OwnerPhoneNumberContentValidation(string i_InsertedValue)
        {
            bool isOwnerPhoneNumberValid;

            if (i_InsertedValue.Length <= k_MaximumphoneNumberLength && i_InsertedValue.All(char.IsDigit))
            {
                isOwnerPhoneNumberValid = true;
            }

            else
            {
                isOwnerPhoneNumberValid = false;
            }

            return isOwnerPhoneNumberValid;
        }

        public void OwnerNameSetup(string i_InsertedValue)
        {
            bool parseSucceed;

            parseSucceed = OwnerNameContentValidation(i_InsertedValue);
            if (!parseSucceed)
            {
                throw new FormatException("Invalid owner name");
            }

            m_OwnerName = i_InsertedValue;
        }

        public void OwnerPhoneSetup(string i_InsertedValue)
        {
            bool parseSucceed;

            parseSucceed = OwnerPhoneNumberContentValidation(i_InsertedValue);
            if (!parseSucceed)
            {
                throw new FormatException("Invalid owner phone number");
            }

            m_OwnerPhone = i_InsertedValue;
        }
    }
}
