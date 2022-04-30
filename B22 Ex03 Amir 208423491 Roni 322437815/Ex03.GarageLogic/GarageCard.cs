using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ex03.GarageLogic
{
    public class GarageCard
    {
        private StringBuilder m_VehicleOwnerName;
        private StringBuilder m_VehicleOwnerPhone;
        private Garage.eVehicleStatus m_VehicleStatus;
        private Vehicle m_Vehicle;

        public GarageCard(StringBuilder i_VehicleOwnerName, StringBuilder i_VehicleOwnerPhone, Garage.eVehicleStatus i_VehicleStatus, Vehicle i_Vehicle)
        {
            m_VehicleOwnerName = new StringBuilder();
            m_VehicleOwnerPhone = new StringBuilder();
            m_VehicleOwnerName = i_VehicleOwnerName;
            m_VehicleOwnerPhone = i_VehicleOwnerPhone;
            m_VehicleStatus = i_VehicleStatus;
            m_Vehicle = i_Vehicle;
        }

        public StringBuilder VehicleOwnerName
        {
            get
            {
                return m_VehicleOwnerName;
            }

            set
            {
                m_VehicleOwnerName = value;
            }
        }
        
        public StringBuilder VehicleOwnerPhone
        {
            get
            {
                return m_VehicleOwnerPhone;
            }

            set
            {
                m_VehicleOwnerPhone = value;
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
    }
}
