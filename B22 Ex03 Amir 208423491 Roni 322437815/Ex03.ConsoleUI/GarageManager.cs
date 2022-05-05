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

        public GarageManager()
        {
            r_Garage = new Garage();
            r_ConsoleIOManager = new ConsoleIOManager();
        }

        public void Run()
        {
            int vehicleStatus;
            List<string> garageVehiclesByStatus; // = new List<string>();
            int garageOperationChoice;
            bool goHome = false;

            r_ConsoleIOManager.Welcome();
            do
            {
                garageOperationChoice = r_ConsoleIOManager.GetGarageActionMainMenu();
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
                r_ConsoleIOManager.PrintGeneralMessage(ex.Message);
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
                do
                {
                    garageVehicleOperationNumber = r_ConsoleIOManager.GetVehicleGarageOperation();
                    try
                    {
                        SingleOperationForVehicle(vehicleLicenseID, garageVehicleOperationNumber);
                    }
                    catch (ArgumentException argumentEx)
                    {
                       /// Case: trying to fill fuel in electric car, so a new operation will be suggested
                       r_ConsoleIOManager.PrintGeneralMessage(argumentEx.Message);
                       /*garageVehicleOperationNumber = r_ConsoleIOManager.GetVehicleGarageOperation();
                       SingleOperationForVehicle(vehicleLicenseID, garageVehicleOperationNumber);*/
                    }
                    catch (ValueOutOfRangeException valueRangeEx)
                    {
                       r_ConsoleIOManager.PrintGeneralMessage(valueRangeEx.Message);
                       SingleOperationForVehicle(vehicleLicenseID, garageVehicleOperationNumber);
                    }
                    catch (Exception ex)
                    {
                        r_ConsoleIOManager.PrintGeneralMessage(ex.Message);
                    }
                    finally
                    {
                        anotherOperation = r_ConsoleIOManager.AskForAnotherOperationForVehicle();
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
