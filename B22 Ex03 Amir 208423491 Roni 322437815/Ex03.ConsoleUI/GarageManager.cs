using System;
using System.Collections.Generic;
using Ex03.GarageLogic;

namespace Ex03.ConsoleUI
{
    public class GarageManager
    {
        private readonly Garage r_Garage;
        private readonly ConsoleIOManager r_ConsoleIOManager;

        public GarageManager()
        {
            r_Garage = new Garage();
            r_ConsoleIOManager = new ConsoleIOManager();
        }

        public void Run()
        {
            int vehicleStatus;
            List<string> garageVehiclesByStatus; 
            int garageOperationChoice;
            bool goHome = false;

            r_ConsoleIOManager.Welcome();
            do
            {
                garageOperationChoice = r_ConsoleIOManager.GetGarageActionMainMenu();
                Console.Clear();
                switch (garageOperationChoice)
                {
                    case 1:
                        AddVehicleToTheGarageProcedure();
                        break;

                    case 2:
                        SingleVehicleOperationsSession();
                        break;

                    case 3:
                        vehicleStatus = r_ConsoleIOManager.GetVehicleStatus();
                        garageVehiclesByStatus = r_Garage.GetAllGarageVehiclesIDByStatus(vehicleStatus);
                        r_ConsoleIOManager.PrintAllGarageVehiclesID(garageVehiclesByStatus);
                        break;

                    case 4:
                        goHome = true;
                        break;

                    default:
                        break;
                }

            } while (!goHome);

            r_ConsoleIOManager.Goodbye();   
        }

        public void AddVehicleToTheGarageProcedure()
        {
            string vehicleLicenceID, vehicleType;

            try
            {
                vehicleType = r_ConsoleIOManager.GetVehicleType();
                vehicleLicenceID = r_ConsoleIOManager.GetVehicleLicenseID();    
                if (!r_Garage.LicenceIDExist(vehicleLicenceID))
                {
                    r_Garage.AddNewVehicleToTheGarage(vehicleLicenceID, vehicleType);
                    CompleteVehicleDetailsProcedure(vehicleLicenceID);
                    CompleteGarageCardDetailsProcedure(vehicleLicenceID);
                }

                else
                {
                    r_ConsoleIOManager.VehicleAllReadyInTheGarageMessage();
                    r_Garage.ChangeVehicleStatus(vehicleLicenceID, (int)Garage.eVehicleStatus.InRepair);
                }
            }
            catch (Exception ex)
            {
                r_ConsoleIOManager.PrintGeneralMessage(ex.Message);
            }
        }

        public void CompleteVehicleDetailsProcedure(string i_VehicleLicenceID)
        {
            Vehicle currVehicle;
            string insertedInput;

            currVehicle = r_Garage.GetVehicleByLicenceID(i_VehicleLicenceID);
            foreach (KeyValuePair<string, string> currVehicleDetail in currVehicle.AdditionalVehicleDetails)
            {
                try
                {
                    insertedInput = r_ConsoleIOManager.GetSingleDetail(currVehicleDetail.Value);
                    currVehicle.SetSingleDetail(currVehicleDetail.Key, insertedInput);
                }
                catch(FormatException formatEx)
                {
                    r_ConsoleIOManager.PrintGeneralMessage(formatEx.Message);
                    insertedInput = r_ConsoleIOManager.GetSingleDetail(currVehicleDetail.Value);
                    currVehicle.SetSingleDetail(currVehicleDetail.Key, insertedInput);
                }
                catch (Exception ex)
                {
                    r_ConsoleIOManager.PrintGeneralMessage(ex.Message);
                    break;
                }
            }
        }

        public void CompleteGarageCardDetailsProcedure(string i_VehicleLicenceID)
        {
            GarageCard currGarageCard;
            string insertedInput;

            currGarageCard = r_Garage.GetVehicleGarageCardByLicenceID(i_VehicleLicenceID);
            foreach (KeyValuePair<string, string> currGarageCardDetail in currGarageCard.GarageCardDetails)
            {
                try
                {
                    insertedInput = r_ConsoleIOManager.GetSingleDetail(currGarageCardDetail.Value);
                    currGarageCard.SetSingleDetail(currGarageCardDetail.Key, insertedInput);
                }

                catch (FormatException formatEx)
                {
                    r_ConsoleIOManager.PrintGeneralMessage(formatEx.Message);
                    insertedInput = r_ConsoleIOManager.GetSingleDetail(currGarageCardDetail.Value);
                    currGarageCard.SetSingleDetail(currGarageCardDetail.Key, insertedInput);
                }
                catch (Exception ex)
                {
                    r_ConsoleIOManager.PrintGeneralMessage(ex.Message);
                    break;
                }
            }
        }

        public void SingleVehicleOperationsSession()
        {
            string vehicleLicenseID;
            int garageVehicleOperationNumber;
            bool anotherOperation = true;

            vehicleLicenseID = r_ConsoleIOManager.GetVehicleLicenseID();
            if (r_Garage.LicenceIDExist(vehicleLicenseID))
            {
                r_ConsoleIOManager.PrintGeneralMessage(r_Garage.GetBasicInfoBeforeOperation(vehicleLicenseID));
                /// Give the user to do several operations for the vehicle one by one.
                do
                {
                    garageVehicleOperationNumber = r_ConsoleIOManager.GetVehicleGarageOperation();
                    try
                    {
                        SingleOperationForVehicle(vehicleLicenseID, garageVehicleOperationNumber);
                    }
                    catch (ValueOutOfRangeException valueRangeEx)
                    {
                           /// In case the amount exceeded the maximun.
                           r_ConsoleIOManager.PrintGeneralMessage(valueRangeEx.Message);
                           SingleOperationForVehicle(vehicleLicenseID, garageVehicleOperationNumber);
                    }
                    catch (Exception ex) /// Including Argument and Format Exceptions case.
                    {
                        /// In case user trying to refuel in electric car,
                        /// so a new operation will be suggested via Finally block.
                        r_ConsoleIOManager.PrintGeneralMessage(ex.Message);
                    }
                    finally
                    {
                        anotherOperation = r_ConsoleIOManager.AskForAnotherOperationForVehicle();
                        Console.Clear();
                    }

                } while (anotherOperation);
            }

            else
            {
                r_ConsoleIOManager.PrintGeneralMessage(string.Format("Vehicle with license ID: {0} doesn't found in the garage", vehicleLicenseID));
            }

        }

        public void SingleOperationForVehicle(string i_LicenceID, int i_OperationNumber)
        {
            string vehicleInfo;

            switch (i_OperationNumber)
            {
                case 1:
                    r_Garage.RefuelVehicle(i_LicenceID, r_ConsoleIOManager.GetFuelType(), r_ConsoleIOManager.GetFuelAmount());
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
