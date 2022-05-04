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
            AddNewVehiclesToTheGarageProcedure();
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
        public void AddNewVehiclesToTheGarageProcedure()
        {
            bool endOfAddingVehiclesToGarage;
            string vehicleLicenceID, vehicleType, energyType;

            do
            {
                vehicleType = r_ConsoleIOManager.GetVehicleType();
                energyType = r_ConsoleIOManager.GetEnergyType();
                vehicleLicenceID = r_ConsoleIOManager.GetVehicleLicenseID();
                r_Garage.AddNewVehicleToTheGarage(vehicleLicenceID, vehicleType, energyType); 
                if (!r_Garage.LicenceIDExist(vehicleLicenceID))
                {
                    CompleteVehicleDetailsProcedure(vehicleLicenceID);
                }
                else
                {
                   /// r_ConsoleIOManager.VehicleAlreadyInGarage()
                }

                endOfAddingVehiclesToGarage = r_ConsoleIOManager.AskToEndAddingVehiclesToGarage();

            } while (!endOfAddingVehiclesToGarage);
        }

        public void CompleteVehicleDetailsProcedure(string i_VehicleLicenceID)
        {
            Vehicle currVehicle;
            GarageCard currGarageCard;
            string insertedInput;

            currVehicle = r_Garage.GetVehicleByLicenceID(i_VehicleLicenceID);
            /// currVehicle = r_Garage[i_VehicleLicenceID].Vehicle;
            foreach (KeyValuePair<string, string> currVehicleDetail in currVehicle.AdditionalVehicleDetails)
            {
                try
                {
                    insertedInput = r_ConsoleIOManager.GetSingleDetail(currVehicleDetail.Value);
                    currVehicle.SetSingleDetail(currVehicleDetail.Key, insertedInput);
                }
                catch
                {
                    /// ex.Message;
                    /// r_ConsoleIOManager(ex.Message());
                    insertedInput = r_ConsoleIOManager.GetSingleDetail(currVehicleDetail.Value);
                    currVehicle.SetSingleDetail(currVehicleDetail.Key, insertedInput);
                }
            }

            currGarageCard = r_Garage.GetVehicleGarageCardByLicenceID(i_VehicleLicenceID);
            foreach (KeyValuePair<string, string> currGarageCardDetail in currGarageCard.GarageCardDetails)
            {
                insertedInput = r_ConsoleIOManager.GetSingleDetail(currGarageCardDetail.Value);
                currGarageCard.SetSingleDetail(currGarageCardDetail.Key, insertedInput);
            }

        }

        public void GarageWorkDay()
        {
            bool endOfWorkDay;

            do
            {
                SingleVehicleOperationsSession();
                endOfWorkDay = r_ConsoleIOManager.AskToEndWorkday();

            } while (!endOfWorkDay);

          /*  vehicleStatusFilter = r_ConsoleIOManager.GetVehicleStatus();
            r_ConsoleIOManager.PrintAllGarageVehiclesID(r_Garage.GetAllGarageVehiclesIDByStatus(vehicleStatusFilter));*/
        }

        /// <summary>
        /// Add here do-While loop for a single LicenceID execute operations until he don't want to
        /// Then, After we finish the loop, change the VehicleStatus in the garage
        /// </summary>
        public void SingleVehicleOperationsSession()
        {
            string vehicleLicenseID;
            int garageOperationNumber;
            bool vehicleFinished = false;

            vehicleLicenseID = r_ConsoleIOManager.GetVehicleLicenseID();
            do
            {
                try
                {
                    garageOperationNumber = r_ConsoleIOManager.GetVehicleGarageOperation();
                    SingleOperationForVehicle(vehicleLicenseID, garageOperationNumber);
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
                    /// vehicleFinished = Ask the user if another operation needed;
                }

            } while (!vehicleFinished);
            /// <====================================?

            /// After the loop:
           /// r_Garage.ChangeVehicleStatus(vehicleLicenseID, Garage.eVehicleStatus.Repaired);

            /// Ask for payment (Do you eant to pay now?)
            /// Change status to paid is owner paid.
        }

        public void SingleOperationForVehicle(string i_LicenceID, int i_OperationNumber)
        {
            switch (i_OperationNumber)
            {
                case 1:
                    r_Garage.RefuelVehicle(i_LicenceID, r_ConsoleIOManager.GetFuelAmount(), r_ConsoleIOManager.GetFuelType());
                    r_ConsoleIOManager.OperationCompletedMessage();
                    break;

                case 2:
                    r_Garage.ChargeVehicleBattery(i_LicenceID, r_ConsoleIOManager.GetTimeToChargeInMinutes());
                    r_ConsoleIOManager.OperationCompletedMessage();
                    break;

                case 3:
                    r_Garage.InflateVehicleWheels(i_LicenceID);
                    r_ConsoleIOManager.OperationCompletedMessage();
                    break;

                case 4:
                    r_Garage.LicenceIDExist(i_LicenceID);
                    r_ConsoleIOManager.OperationCompletedMessage();
                    break;

               /*case 5:
                    r_Garage.ChangeVehicleStatus();*/

                default:
                    break;
            }
        }

       /* public int ExtractVehicleGarageOperation(string i_RawOperationChoice)
        {
            int garageOperationNumber;
            bool inputIsValid;

            inputIsValid = int.TryParse(, out garageOperationNumber);
            if(!inputIsValid || garageOperationNumber < 1 || garageOperationNumber > 5)
            {
                throw new FormatException("Invalid garage operation choice.");
            }
          
            return garageOperationNumber;
        }*/

       /* public void AdditionalVehicleDetailsProcedure()
        {
           *//* foreach ()*//*
        }*/
    } 
}
