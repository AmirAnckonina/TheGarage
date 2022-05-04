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
            int actionInTheGarage;
            bool goHome;
            do
            {
                actionInTheGarage = r_ConsoleIOManager.GetActionInTheGarage();
                switch (actionInTheGarage)
                {
                    case 1:
                        AddNewVehiclesToTheGarageProcedure();
                        goHome = false;
                        break;
                    case 2:
                        GarageWorkDay();
                        goHome = false;
                        break;
                    case 3:
                        // r_Garage.GetAllGarageVehiclesIDByStatus();
                        goHome = false;
                        break;
                    case 4:
                    default:
                        goHome = true;
                        break;
                }

            } while (!goHome);        
          
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
            string vehicleLicenceID, vehicleType, energyType;

                vehicleType = r_ConsoleIOManager.GetVehicleType();
                energyType = r_ConsoleIOManager.GetEnergyType();
                vehicleLicenceID = r_ConsoleIOManager.GetVehicleLicenseID();    
            if (!r_Garage.LicenceIDExist(vehicleLicenceID))
            {
                r_Garage.AddNewVehicleToTheGarage(vehicleLicenceID, vehicleType, energyType);
                CompleteVehicleDetailsProcedure(vehicleLicenceID);
            }

            else
            {
                r_ConsoleIOManager.VehicleAllReadyInTheGarageMessage();
                r_Garage.ChangeVehicleStatus(vehicleLicenceID, 1);
            }
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
                catch(FormatException ex)
                {
                    /// ex.Message;
                    ///r_ConsoleIOManager(ex.Message());
                    insertedInput = r_ConsoleIOManager.GetSingleDetail(currVehicleDetail.Value);
                    currVehicle.SetSingleDetail(currVehicleDetail.Key, insertedInput);
                }
            }

            currGarageCard = r_Garage.GetVehicleGarageCardByLicenceID(i_VehicleLicenceID);
            foreach (KeyValuePair<string, string> currGarageCardDetail in currGarageCard.GarageCardDetails)
            {
                try
                {
                   insertedInput = r_ConsoleIOManager.GetSingleDetail(currGarageCardDetail.Value);
                   currGarageCard.SetSingleDetail(currGarageCardDetail.Key, insertedInput);
                }

                catch(FormatException ex)
                {
                    insertedInput = r_ConsoleIOManager.GetSingleDetail(currGarageCardDetail.Value);
                    currGarageCard.SetSingleDetail(currGarageCardDetail.Key, insertedInput);
                }
            }

        }

        public void GarageWorkDay()
        {
            bool endOfWorkDay;

            do
            {
                SingleVehicleOperationsSession();
                r_ConsoleIOManager.OperationCompletedMessage();
                endOfWorkDay = r_ConsoleIOManager.AsxIfAnotherOperationNeeded();

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
            bool anothetOperation = false;

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
                    anothetOperation = r_ConsoleIOManager.AsxIfAnotherOperationNeeded();
                }

            } while (anothetOperation);
            /// <====================================?

            /// After the loop:
           
            r_Garage.ChangeVehicleStatus(vehicleLicenseID, 2);

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
            r_ConsoleIOManager.OperationCompletedMessage();
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
