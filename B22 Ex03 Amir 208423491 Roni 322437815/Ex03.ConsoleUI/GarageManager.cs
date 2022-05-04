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
            int vehicleStatus;
            List<string> garageVehiclesByStatus = new List<string>();
            int actionInTheGarage;
            bool goHome;
            do
            {
                actionInTheGarage = r_ConsoleIOManager.GetActionInTheGarage();
                switch (actionInTheGarage)
                {
                    case 1:
                        AddVehicleToTheGarageProcedure();
                        goHome = false;
                        break;
                    case 2:
                        SingleVehicleOperationsSession();
                        goHome = false;
                        break;
                    case 3:
                        vehicleStatus = r_ConsoleIOManager.GetVehicleStatus();
                        garageVehiclesByStatus = r_Garage.GetAllGarageVehiclesIDByStatus(vehicleStatus);
                        r_ConsoleIOManager.PrintAllGarageVehiclesID(garageVehiclesByStatus);
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
        public void AddVehicleToTheGarageProcedure()
        {
            string vehicleLicenceID, vehicleType, energyType;

            try
            {
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
                    r_Garage.ChangeVehicleStatus(vehicleLicenceID, (int)Garage.eVehicleStatus.InRepair);
                }
            }
            catch (Exception ex)
            {
                r_ConsoleIOManager.PrintErrorMessage(ex.Message);
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
                catch(FormatException formatEx)
                {
                    r_ConsoleIOManager.PrintErrorMessage(formatEx.Message);
                    insertedInput = r_ConsoleIOManager.GetSingleDetail(currVehicleDetail.Value);
                    currVehicle.SetSingleDetail(currVehicleDetail.Key, insertedInput);
                }
                catch (Exception ex)
                {
                    r_ConsoleIOManager.PrintErrorMessage(ex.Message);
                    break;
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

                catch(FormatException formatEx)
                {
                    r_ConsoleIOManager.PrintErrorMessage(formatEx.Message);
                    insertedInput = r_ConsoleIOManager.GetSingleDetail(currGarageCardDetail.Value);
                    currGarageCard.SetSingleDetail(currGarageCardDetail.Key, insertedInput);
                }
                catch (Exception ex)
                {
                    r_ConsoleIOManager.PrintErrorMessage(ex.Message);
                    break;
                }
            }

        }

        public void SingleVehicleOperationsSession()
        {
            string vehicleLicenseID;
            int garageOperationNumber;
            bool anotherOperation = true;

            vehicleLicenseID = r_ConsoleIOManager.GetVehicleLicenseID();
            if (r_Garage.LicenceIDExist(vehicleLicenseID))
            {
                do
                {
                    garageOperationNumber = r_ConsoleIOManager.GetVehicleGarageOperation();
                    try
                    {
                        SingleOperationForVehicle(vehicleLicenseID, garageOperationNumber);
                    }
                    catch (ArgumentException argumentEx)
                    {
                       /// Case: trying to fill fuel in electric car, so a new operation will be suggested
                       r_ConsoleIOManager.PrintErrorMessage(argumentEx.Message);
                       garageOperationNumber = r_ConsoleIOManager.GetVehicleGarageOperation();
                       SingleOperationForVehicle(vehicleLicenseID, garageOperationNumber);
                    }
                    catch (ValueOutOfRangeException valueRangeEx)
                    {
                       r_ConsoleIOManager.PrintErrorMessage(valueRangeEx.Message);
                       SingleOperationForVehicle(vehicleLicenseID, garageOperationNumber);
                    }
    /*                catch (FormatException formatEx)
                    {
                        r_ConsoleIOManager.PrintErrorMessage(formatEx.Message);
                    }*/
                    catch (Exception ex)
                    {
                        r_ConsoleIOManager.PrintErrorMessage(ex.Message);
                    }
                    finally
                    {
                        anotherOperation = r_ConsoleIOManager.AskForAnotherOperationForVehicle();
                    }

                } while (anotherOperation);
            }

            else
            {
                r_ConsoleIOManager.PrintErrorMessage(string.Format("Vehicle with license ID: {0} doesn't found in the garage", vehicleLicenseID));
            }

        }

        public void SingleOperationForVehicle(string i_LicenceID, int i_OperationNumber)
        {
            string vehicleInfo;

            switch (i_OperationNumber)
            {
                case 1:
                    r_Garage.RefuelVehicle(i_LicenceID, r_ConsoleIOManager.GetFuelAmount(), r_ConsoleIOManager.GetFuelType());
                    break;

                case 2:
                    r_Garage.ChargeVehicleBattery(i_LicenceID, r_ConsoleIOManager.GetTimeToChargeInMinutes());
                    break;

                case 3:
                    r_Garage.InflateVehicleWheels(i_LicenceID);
                    break;

               case 4:
                    vehicleInfo = r_Garage.GetFullVehicleInformation(i_LicenceID);
                    r_ConsoleIOManager.PrintFullVehicleInfo(vehicleInfo); 
                    break;

                case 5:
                    r_Garage.ChangeVehicleStatus(i_LicenceID, r_ConsoleIOManager.GetVehicleStatus());
                    break;

                default:
                    break;
            }

            r_ConsoleIOManager.OperationCompletedMessage();
        }


    } 
}
