using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ex03.GarageLogic
{
    public class ManufactureDetails
    {
        private StringBuilder m_LicenceID;
        private VehicleManufacturer.eVehicleType m_VehicleTypeChoice;
        private StringBuilder m_VehicleModelName;
        private StringBuilder m_VehicleOwnerName;
        private StringBuilder m_VehicleOwnerPhoneNumber;
        private Energy.eEnergyType m_EnergyType;
        private Car.eColor m_CarColor;
        private Car.eDoorsNumber m_CarDoorsNumber;
        private Motorcycle.eLicenceType m_MotorcycleLicenceType;
        private float m_MotorcycleEngineCapacityCC;
        private bool m_HasCoolingCargo;
        private float m_CargoCapacity;
        private StringBuilder m_WheelManufacturerName;

        public ManufactureDetails()
        {
            m_LicenceID = new StringBuilder();
            m_VehicleModelName = new StringBuilder();
            m_VehicleOwnerName = new StringBuilder();
            m_VehicleOwnerPhoneNumber = new StringBuilder();
            m_WheelManufacturerName = new StringBuilder();
        }

        public VehicleManufacturer.eVehicleType VehicleTypeChoice
        {
            get
            {
                return m_VehicleTypeChoice;
            }

            set
            {
                m_VehicleTypeChoice = value;
            }
        }

        public StringBuilder LicenceID
        {
            get
            {
                return m_LicenceID;
            }

            set
            {
                m_LicenceID = value;
            }
        }

        public StringBuilder ModelName
        {
            get
            {
                return m_VehicleModelName;
            }

            set
            {
                m_VehicleModelName = value;
            }
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

        public StringBuilder VehicleOwnerPhoneNumber
        {
            get
            {
                return m_VehicleOwnerPhoneNumber;
            }

            set
            {
                m_VehicleOwnerPhoneNumber = value;
            }
        }

        public Energy.eEnergyType EnergyTypeChoice
        {
            get
            {
                return m_EnergyType;
            }

            set
            {
                m_EnergyType = value;
            }
        }

        public Car.eColor CarColorChioce
        {
            get
            {
                return m_CarColor;
            }

            set
            {
                m_CarColor = value;
            }
        }

        public Car.eDoorsNumber CarDoorsNumberChoice
        {
            get
            {
                return m_CarDoorsNumber;
            }

            set
            {
                m_CarDoorsNumber = value;
            }
        }

        public Motorcycle.eLicenceType MotorcycleLicenceTypeChoice
        {
            get
            {
                return m_MotorcycleLicenceType;
            }

            set
            {
                m_MotorcycleLicenceType = value;
            }
        }

        public float MotorcycleEngineVolume
        {
            get
            {
                return m_MotorcycleEngineCapacityCC;
            }

            set
            {
                m_MotorcycleEngineCapacityCC = value;
            }
        }

        public bool HasCoolingCargo
        {
            get
            {
                return m_HasCoolingCargo;
            }

            set
            {
                m_HasCoolingCargo = value;
            }
        }

        public float CargoCapacity
        {
            get
            {
                return m_CargoCapacity;
            }

            set
            {
                m_CargoCapacity = value;
            }
        }

        public StringBuilder WheelManufacturerName
        {
            get
            {
                return m_WheelManufacturerName;
            }

            set
            {
                m_WheelManufacturerName = value;
            }
        }
    }
}
