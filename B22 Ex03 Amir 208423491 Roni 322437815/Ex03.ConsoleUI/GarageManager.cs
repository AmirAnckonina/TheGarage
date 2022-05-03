using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ex03.GarageLogic;

namespace Ex03.ConsoleUI
{
    public class GarageManager
    {
        private readonly Garage r_Garage;
        private readonly ConsoleIOManager r_ConsoleIOManager;
        private ManufactureDetails m_ManufactureDetails;

        public GarageManager()
        {
            r_Garage = new Garage();
            r_ConsoleIOManager = new ConsoleIOManager();
            m_ManufactureDetails = new ManufactureDetails();
        }

        public void Run()
        {
            ManufactureVehiclesAndAddingToGarageProcedure();
            GarageWorkDay();
        }
        /// <summary>
        /// Ask the user for Vehicle type,  LicenceID
        /// Check if licenceID is Exist 
        /// -> If yes, so ignore and get the next vehicle
        /// -> If no, Crease basic vehicle with LicenceID, string VehicleType 
        ///     -> AddVehicleToGarage (store in the dictionary)
        ///     -> Complete manufacturing
        ///     Continue with basic VehicleDetails 
        ///     -> Specific manufacture details according to the vehicle type
        ///     -> update GarageCard details
        /// 
        /// </summary>
        public void addNewVehiclesToTheGarageProcedure()
        {
            
        }

        public void ManufactureVehiclesAndAddingToGarageProcedure()
        {
            VehicleManufacturer.eVehicleType vehicleTypeChoice;
            bool endOfAddingVehiclesToGarage;

            do
            {
                m_ManufactureDetails.LicenceID = r_ConsoleIOManager.GetVehicleLicenceID();
                if (!r_Garage.LicenceIDExist(m_ManufactureDetails.LicenceID))
                {
                    /// m_ManufactureDetails.VehicleType = r_ConsoleIOManager.GetVehicleType();
                    /// r_Garage.ManufactureNewVehicleAndAddToGarage(m_ManufactureDetails);
                    BasicDetailsInputsProcedure();
                    vehicleTypeChoice = m_ManufactureDetails.VehicleType;
                    switch (vehicleTypeChoice)
                    {
                        case VehicleManufacturer.eVehicleType.Car:
                            CarDetailsInputsProcedure();
                            break;

                        case VehicleManufacturer.eVehicleType.Motorcycle:
                            MotorcycleDetailsInputsProcedure();
                            break;

                        case VehicleManufacturer.eVehicleType.Truck:
                        default:
                            TruckDetailsInputsProcedure();
                            break;
                    }
                }

                r_Garage.AddVehicleToGarage(m_ManufactureDetails);
                m_ManufactureDetails.ClearForm();
                endOfAddingVehiclesToGarage = r_ConsoleIOManager.AskToEndAddingVehiclesToGarage();

            } while (!endOfAddingVehiclesToGarage);
        }

        public void BasicDetailsInputsProcedure()
        {
            m_ManufactureDetails.VehicleType = r_ConsoleIOManager.GetVehicleType();
            m_ManufactureDetails.ModelName = r_ConsoleIOManager.GetVehicleModelName();
            m_ManufactureDetails.VehicleOwnerName = r_ConsoleIOManager.GetOwnerName();
            m_ManufactureDetails.VehicleOwnerPhoneNumber = r_ConsoleIOManager.GetVehicleOwnerPhoneNumber();
            m_ManufactureDetails.WheelManufacturerName = r_ConsoleIOManager.GetWheelManufacturerName();
        }

        public void CarDetailsInputsProcedure()
        {
            m_ManufactureDetails.EnergyType = r_ConsoleIOManager.GetEnergyType();
            m_ManufactureDetails.CarColor = r_ConsoleIOManager.GetCarColor();
            m_ManufactureDetails.DoorsNumberInCar = r_ConsoleIOManager.GetDoorsNumberInCar();
        }

        public void MotorcycleDetailsInputsProcedure()
        {
            m_ManufactureDetails.EnergyType = r_ConsoleIOManager.GetEnergyType();
            m_ManufactureDetails.MotorcycleLicenceType = r_ConsoleIOManager.GetMotorcycleLicenceType();
            m_ManufactureDetails.MotorcycleEngineCapacity = r_ConsoleIOManager.GetMotorcycleEngineCapacity();
        }

        public void TruckDetailsInputsProcedure()
        {
            m_ManufactureDetails.HasCoolingCargo = r_ConsoleIOManager.GetIfTruckHasCoolingCargo();
            m_ManufactureDetails.CargoCapacity = r_ConsoleIOManager.GetTruckCargoCapacity();
        }

        public void GarageWorkDay()
        {
            bool endOfWorkDay;
            bool printAllVehicleID;
            string vehicleLicenceID;
            Garage.eVehicleStatus vehicleStatusFilter;
            Garage.eGarageOperations vehicleTreatment;

            do
            {
                VehicleTreatmentsSession();
                endOfWorkDay = r_ConsoleIOManager.AskToEndWorkday();

            } while (!endOfWorkDay);

            vehicleStatusFilter = r_ConsoleIOManager.GetVehicleStatus();
            r_ConsoleIOManager.PrintAllGarageVehiclesID(r_Garage.GetAllGarageVehiclesIDByStatus(vehicleStatusFilter));
        }

        /// <summary>
        /// Add here do-While loop for a single LicenceID execute operations until he don't want to
        /// Then, After we finish the loop, change the VehicleStatus in the garage
        /// </summary>
        public void VehicleTreatmentsSession()
        {
            string vehicleLicenceID;
            Garage.eGarageOperations vehicleOperation;
            bool currentVehicleFinishAllOperations;

            vehicleLicenceID = r_ConsoleIOManager.GetVehicleLicenceID();
            vehicleOperation = r_ConsoleIOManager.GetVehicleGarageOperation();

            /// do {
            try
            {
                SingleOperationForVehicle(vehicleLicenceID, vehicleOperation);
            }
            catch (ArgumentException Argumentex)
            {
                Console.WriteLine(Argumentex.Message);
            }
            catch (FormatException formatEx)
            {
                Console.WriteLine(formatEx.Message);
            }
            catch (ValueOutOfRangeException valueRangeEx)
            {
                Console.WriteLine(valueRangeEx.Message);
            }
            finally
            {
                /// Ask the user if another operation needed
                /// currentVehicleFinishAllOperations = function in ConsoleIO that return wheter finish or not.
            }
            /// While condition (do-While Loop)
            /// <====================================?
            
            /// After the loop:
            r_Garage.ChangeVehicleStatus(vehicleLicenceID, Garage.eVehicleStatus.Repaired);

            /// Ask for payment (Do you eant to pay now?)
            /// Change status to paid is owner paid.
        }

        public void SingleOperationForVehicle(string i_LicenceID, Garage.eGarageOperations i_GarageOperation)
        {
            switch (i_GarageOperation)
            {
                case Garage.eGarageOperations.Refuel:
                    r_Garage.RefuelVehicle(i_LicenceID, r_ConsoleIOManager.GetFuelAmount(), r_ConsoleIOManager.GetFuelType());
                    r_ConsoleIOManager.TreatmentComplitedMessage();
                    break;

                case Garage.eGarageOperations.ChargeBattery:
                    r_Garage.ChargeVehicle(i_LicenceID, r_ConsoleIOManager.GetTimeToChargeInMinutes());
                    r_ConsoleIOManager.TreatmentComplitedMessage();
                    break;

                case Garage.eGarageOperations.InflateWheels:
                    r_Garage.InflateVehicleWheels(i_LicenceID);
                    r_ConsoleIOManager.TreatmentComplitedMessage();
                    break;

                case Garage.eGarageOperations.ExistenceCheck:
                    r_Garage.LicenceIDExist(i_LicenceID);
                    r_ConsoleIOManager.TreatmentComplitedMessage();
                    break;

                case Garage.eGarageOperations.None:
                default:
                    break;
            }
        }

        public void AdditionalVehicleDetailsProcedure()
        {
           /* foreach ()*/
        }
    } 
}
