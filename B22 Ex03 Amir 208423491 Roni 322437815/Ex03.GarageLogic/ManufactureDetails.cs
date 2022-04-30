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
        private Car.eDoorsNumber m_DoorsNumberInCar;
        private Motorcycle.eMotorcycleLicenceType m_MotorcycleLicenceType;
        private float m_MotorcycleEngineCapacity;
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

        public VehicleManufacturer.eVehicleType VehicleType
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

        public Energy.eEnergyType EnergyType
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

        public Car.eColor CarColor
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

        public Car.eDoorsNumber DoorsNumberInCar
        {
            get
            {
                return m_DoorsNumberInCar;
            }

            set
            {
                m_DoorsNumberInCar = value;
            }
        }

        public Motorcycle.eMotorcycleLicenceType MotorcycleLicenceType
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

        public float MotorcycleEngineCapacity
        {
            get
            {
                return m_MotorcycleEngineCapacity;
            }

            set
            {
                m_MotorcycleEngineCapacity = value;
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
