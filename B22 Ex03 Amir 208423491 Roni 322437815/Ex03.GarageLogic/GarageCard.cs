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
/*
        public GarageCard(string i_VehicleOwnerName, string i_VehicleOwnerPhone, Garage.eVehicleStatus i_VehicleStatus, Vehicle i_Vehicle)
        {
            m_VehicleOwnerName = i_VehicleOwnerName;
            m_VehicleOwnerPhone = i_VehicleOwnerPhone;
            m_VehicleStatus = i_VehicleStatus;
            m_Vehicle = i_Vehicle;
        }
*/
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
            bool parseSucceed = false;
            if (!m_GarageCardDetails.ContainsKey(i_Key))
            {
                /// throw exception 
            }

            /// <====================================================>
            /// <====================================================>

            if (i_Key == "OwnerName")
            {
                /// parseSucceed = OwnerNameParsing(i_InsertedValue);
                m_OwnerName = i_InsertedValue;
            }

            else if (i_Key == "OwnerPhone")
            {
                /// parseSucceed = OwnerPhoneParsing(i_InsertedValue);
                m_OwnerPhone = i_InsertedValue;
            }

            /// <====================================================>
            /// <====================================================>

            if (!parseSucceed)
            {
                /// throw exception
            }

        }

        public void InitGarageCardDictionary()
        {
            m_GarageCardDetails = new Dictionary<string, string>();
            m_GarageCardDetails.Add("OwnerName", "Message");
            m_GarageCardDetails.Add("OwnerPhone", "Message");
        }
    }
}
