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
            string vehicleLicenseID, vehicleType;

            try
            {
                vehicleType = r_ConsoleIOManager.GetVehicleType();
                vehicleLicenseID = r_ConsoleIOManager.GetVehicleLicenseID();    
                if (!r_Garage.LicenseIDExist(vehicleLicenseID))
                {
                    r_Garage.AddNewVehicleToTheGarage(vehicleLicenseID, vehicleType);
                    CompleteVehicleDetailsProcedure(vehicleLicenseID);
                    CompleteGarageCardDetailsProcedure(vehicleLicenseID);
                }

                else
                {
                    r_ConsoleIOManager.VehicleAllReadyInTheGarageMessage();
                    r_Garage.ChangeVehicleStatus(vehicleLicenseID, (int)Garage.eVehicleStatus.InRepair);
                }
            }
            catch (Exception ex)
            {
                r_ConsoleIOManager.PrintGeneralMessage(ex.Message);
            }
        }

        public void CompleteVehicleDetailsProcedure(string i_VehicleLicenseID)
        {
            Vehicle currVehicle;
            string insertedInput;
            bool invalidInput;

            currVehicle = r_Garage.GetVehicleByLicenseID(i_VehicleLicenseID);
            foreach (KeyValuePair<string, string> currVehicleDetail in currVehicle.AdditionalVehicleDetails)
            {
                invalidInput = false;
                while(!invalidInput)
                {
                    try
                    {
                        insertedInput = r_ConsoleIOManager.GetSingleDetail(currVehicleDetail.Value);
                        currVehicle.SetSingleDetail(currVehicleDetail.Key, insertedInput);
                        invalidInput = true;
                    }
                    catch(FormatException formatEx)
                    {
                        r_ConsoleIOManager.PrintGeneralMessage(formatEx.Message);
                        invalidInput = false;
                    }
                }
            }
        }

        public void CompleteGarageCardDetailsProcedure(string i_VehicleLicenseID)
        {
            GarageCard currGarageCard;
            string insertedInput;
            bool invalidInput;

            currGarageCard = r_Garage.GetVehicleGarageCardByLicenseID(i_VehicleLicenseID);
            foreach (KeyValuePair<string, string> currGarageCardDetail in currGarageCard.GarageCardDetails)
            {
                invalidInput = false;
                while (!invalidInput)
                {
                    try
                    {
                        insertedInput = r_ConsoleIOManager.GetSingleDetail(currGarageCardDetail.Value);
                        currGarageCard.SetSingleDetail(currGarageCardDetail.Key, insertedInput);
                        invalidInput = true;
                    }
                    catch (FormatException formatEx)
                    {
                        r_ConsoleIOManager.PrintGeneralMessage(formatEx.Message);
                        invalidInput = false;
                    }
                }
            }
        }

        public void SingleVehicleOperationsSession()
        {
            string vehicleLicenseID;
            int garageVehicleOperationNumber;
            bool anotherOperation;

            vehicleLicenseID = r_ConsoleIOManager.GetVehicleLicenseID();
            if (r_Garage.LicenseIDExist(vehicleLicenseID))
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
                    catch (Exception ex) /// Including Argument, OutOfRange and Format Exceptions cases.
                    {
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

        public void SingleOperationForVehicle(string i_LicenseID, int i_OperationNumber)
        {
            string vehicleInfo;

            switch (i_OperationNumber)
            {
                case 1:
                    r_Garage.RefuelVehicle(i_LicenseID, r_ConsoleIOManager.GetFuelType(), r_ConsoleIOManager.GetFuelAmount());
                    break;

                case 2:
                    r_Garage.ChargeVehicleBattery(i_LicenseID, r_ConsoleIOManager.GetTimeToChargeInMinutes());
                    break;

                case 3:
                    r_Garage.InflateVehicleWheels(i_LicenseID);
                    break;

               case 4:
                    vehicleInfo = r_Garage.GetFullVehicleInformation(i_LicenseID);
                    r_ConsoleIOManager.PrintFullVehicleInfo(vehicleInfo); 
                    break;

               case 5:
                    r_Garage.ChangeVehicleStatus(i_LicenseID, r_ConsoleIOManager.GetVehicleStatus());
                    break;

                default:
                    break;
            }

            r_ConsoleIOManager.OperationCompletedMessage();
        }
    } 
}
