using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ex03.GarageLogic;

namespace Ex03.ConsoleUI
{
    class ConsoleIOManager
    {
        public const int k_MaximumOwnerNameLength = 20;
        public const int k_PhoneNumberLength = 10;
        public const int k_MaximumModelNameLength = 20;
        public const int k_MaximumWheelManufacturerNameLength = 20;

        public void Welcome()
        {
            StringBuilder welcomeMessage = new StringBuilder();

            welcomeMessage.Append("Welcome to the Garage!");
            Console.WriteLine(welcomeMessage);
        }

        public string GetVehicleType()
        {
            string vehicleTypeChoice;

            PrintRequestOfVehicleType();
            vehicleTypeChoice = Console.ReadLine();
            while (!VehicleTypeChoiceValidation(vehicleTypeChoice))
            {
                PrintInvalidInputMessage();
                PrintRequestOfVehicleType();
                vehicleTypeChoice = Console.ReadLine();
            }

            return vehicleTypeChoice;
        }

        public bool VehicleTypeChoiceValidation(string i_VehicleTypeChoice)
        {
            bool inputIsValid;
            bool vehicleTypeChoiceIsValid;
            int vehicleTypeChoiceNumber;

            inputIsValid = int.TryParse(i_VehicleTypeChoice, out vehicleTypeChoiceNumber);
            if (!inputIsValid || vehicleTypeChoiceNumber < 1 || vehicleTypeChoiceNumber > 5)
            {
                vehicleTypeChoiceIsValid = false;
            }

            else
            {
                vehicleTypeChoiceIsValid = true;
            }

            return vehicleTypeChoiceIsValid;
        }

        public static void PrintRequestOfVehicleType()
        {
            StringBuilder vehicleTypeMessage = new StringBuilder();

            vehicleTypeMessage.AppendLine("Enter the type of your vehicle:");
            vehicleTypeMessage.AppendLine("1 - Car");
            vehicleTypeMessage.AppendLine("2 - Motorcycle");
            vehicleTypeMessage.AppendLine("3 - Truck");
            vehicleTypeMessage.AppendLine("4 - Tractor");
            vehicleTypeMessage.Append("5 - Mini-Bus");
            Console.WriteLine(vehicleTypeMessage);
        }

        public string GetEnergyType()
        {
            string energyTypeChoice;

            PrintRequestForEnergyType();
            energyTypeChoice = Console.ReadLine();
            while (!EnergyTypeChoiceValidation(energyTypeChoice))
            {
                PrintInvalidInputMessage();
                PrintRequestForEnergyType();
                energyTypeChoice = Console.ReadLine();
            }

            return energyTypeChoice;
        }

        public bool EnergyTypeChoiceValidation(string i_EnergyTypeChoice)
        {
            bool inputIsValid;
            bool energyTypeChoiceIsValid;
            int energyTypeChoiceNumber;

            inputIsValid = int.TryParse(i_EnergyTypeChoice, out energyTypeChoiceNumber);
            if (!inputIsValid || energyTypeChoiceNumber < 1 || energyTypeChoiceNumber > 3)
            {
                energyTypeChoiceIsValid = false;
            }

            else
            {
                energyTypeChoiceIsValid = true;
            }

            return energyTypeChoiceIsValid;
        }

        public static void PrintRequestForEnergyType()
        {
            StringBuilder EnergyTypeMessage = new StringBuilder();

            EnergyTypeMessage.AppendLine("Please specify the energy source type of your vehicle");
            EnergyTypeMessage.AppendLine("1 - Fuel");
            EnergyTypeMessage.AppendLine("2 - Electric");
            EnergyTypeMessage.Append("3 - Natural Gas");
            Console.WriteLine(EnergyTypeMessage);
        }

        public string GetVehicleLicenseID()
        {
            StringBuilder vehicleLicenseNumber = new StringBuilder();

            PrintRequesOfVehicleLicenseNumber();
            vehicleLicenseNumber.Append(Console.ReadLine());

             while (!LicenceIDFormatValidation(vehicleLicenseNumber))
             {
                 PrintInvalidInputMessage();
                 PrintRequesOfVehicleLicenseNumber();
                 vehicleLicenseNumber.Clear();
                 vehicleLicenseNumber.Append(Console.ReadLine());
             }

            return vehicleLicenseNumber.ToString();
        }

        private bool LicenceIDFormatValidation(StringBuilder i_LicenseID)
        {
            bool licenceIDIsValid;

            if (i_LicenseID.Length >= 5 && i_LicenseID.Length <= 8 && i_LicenseID.ToString().All(char.IsDigit))
            {
                licenceIDIsValid = true;
            }

            else
            {
                licenceIDIsValid = false;
            }

            return licenceIDIsValid;
        }

        public static void PrintRequesOfVehicleLicenseNumber()
        {
            StringBuilder vehicleLicenseNumberMessage = new StringBuilder();

            vehicleLicenseNumberMessage.Append("Please enter the license number of the vehicle:");
            Console.WriteLine(vehicleLicenseNumberMessage);
        }

        public string GetSingleDetail(string i_RequestMessageValue)
        {
            /// StringBuilder getDetailMessage = new StringBuilder();
            string insertedInput;


            /* getDetailMessage.Append(string.Format("Please enter the {0} of your vehicle", i_RequestMessageValue));
             Console.WriteLine(getDetailMessage);*/

            Console.WriteLine(i_RequestMessageValue);
            insertedInput = Console.ReadLine();

            return insertedInput;
        }

        public static void PrintGarageOperationsMenu()
        {
            StringBuilder vehicleTreatmentMessage = new StringBuilder();

            vehicleTreatmentMessage.AppendLine("Enter the garage operation you need:");
            vehicleTreatmentMessage.AppendLine("1 - Refuel");
            vehicleTreatmentMessage.AppendLine("2 - Charge battery");
            vehicleTreatmentMessage.AppendLine("3 - Inflate wheels");
            vehicleTreatmentMessage.AppendLine("4 - Get full vehicle info");
            vehicleTreatmentMessage.AppendLine("5 - Change vehicle status");
            Console.WriteLine(vehicleTreatmentMessage);
        }

        public int GetVehicleGarageOperation()
        {
            int garageOperationChoice;
            bool inputIsValid;

            PrintGarageOperationsMenu();
            inputIsValid = int.TryParse(Console.ReadLine(), out garageOperationChoice);
            while (!inputIsValid || garageOperationChoice < 1 || garageOperationChoice > 5)
            {
                PrintInvalidInputMessage();
                PrintGarageOperationsMenu();
                inputIsValid = int.TryParse(Console.ReadLine(), out garageOperationChoice);
            }

            return garageOperationChoice;
        }

        public void VehicleAllReadyInTheGarageMessage()
        {
            StringBuilder vehicleInTheGarageMessage = new StringBuilder();

            vehicleInTheGarageMessage.Append("The vehicle is all ready in the garage.");
            Console.WriteLine(vehicleInTheGarageMessage);
        }

        public bool AskForAnotherOperationForVehicle()
        {
            bool anotherOperation;
            bool isInputValid;
            int anotherOperationChoice;

            PrintAnotherOperationMessage();
            isInputValid = int.TryParse(Console.ReadLine(), out anotherOperationChoice);

            while (!isInputValid || anotherOperationChoice < 1 || anotherOperationChoice > 2)
            {
                PrintInvalidInputMessage();
                PrintAnotherOperationMessage();
                isInputValid = int.TryParse(Console.ReadLine(), out anotherOperationChoice);
            }

            if (anotherOperationChoice == 1)
            {
                anotherOperation = true;
            }

            else
            {
                anotherOperation = false;
            }

            return anotherOperation;
        }

        public void PrintAnotherOperationMessage()
        {
            StringBuilder anotherOperationMessage = new StringBuilder();

            anotherOperationMessage.AppendLine("Do you want another operattion?");
            anotherOperationMessage.AppendLine("1 - Yes");
            anotherOperationMessage.Append("2 - No");
            Console.WriteLine(anotherOperationMessage);
        }

        public int GetGarageOperation()
        {
            int actionInTheGarage;
            bool isInputValid;

            PrintRequestForGarageOperation();
            isInputValid = int.TryParse(Console.ReadLine(), out actionInTheGarage);
            while (!isInputValid || actionInTheGarage < 1 || actionInTheGarage > 4)
            {
                PrintInvalidInputMessage();
                PrintRequestForGarageOperation();
                isInputValid = int.TryParse(Console.ReadLine(), out actionInTheGarage);
            }

            return actionInTheGarage;
        }

        public void PrintRequestForGarageOperation()
        {
            StringBuilder actionInTheGarageMessage = new StringBuilder();

            actionInTheGarageMessage.AppendLine("Choose which garage operation you need: ");
            actionInTheGarageMessage.AppendLine("1 - Add new vehicle to the garage");
            actionInTheGarageMessage.AppendLine("2 - Do some vehicle operation in the garage");
            actionInTheGarageMessage.AppendLine("3 - Get garage vehicles by status");
            actionInTheGarageMessage.AppendLine("4 - Go home");
            Console.WriteLine(actionInTheGarageMessage);
        }

        public void PrintFullVehicleInfo(string i_VehicleInfo)
        {
            StringBuilder fullVehicleInfoMessage = new StringBuilder();

            fullVehicleInfoMessage.Append(string.Format("{0}", i_VehicleInfo));
            Console.WriteLine(fullVehicleInfoMessage);
        }

        public void PrintGeneralMessage(string i_GeneralMessage)
        {
            Console.WriteLine(i_GeneralMessage);
        }

        public static void PrintInvalidInputMessage()
        {
            StringBuilder invalidInputMessage = new StringBuilder();

            invalidInputMessage.Append("The input is not valid!");
            Console.WriteLine(invalidInputMessage);
        }
        /// < ================================================================= >
        
        public int GetFuelType()
        {
            int fuelType;
            bool inputIsValid;

            PrintfuelTypeMessage();
            inputIsValid = int.TryParse(Console.ReadLine(), out fuelType);
            while (!inputIsValid || !fuelTypeValidation(fuelType))
            {
                PrintInvalidInputMessage();
                PrintfuelTypeMessage();
                inputIsValid = int.TryParse(Console.ReadLine(), out fuelType);
            }

            return fuelType;
        }

        public static void PrintfuelTypeMessage()
        {
            StringBuilder fuelTypeMessage = new StringBuilder();

            fuelTypeMessage.AppendLine("Please enter the fuel type of your vehicle");
            fuelTypeMessage.AppendLine("1 - Soler");
            fuelTypeMessage.AppendLine("2 - Octan95");
            fuelTypeMessage.AppendLine("3 - Octan96");
            fuelTypeMessage.Append("4 - Octan98");
            Console.WriteLine(fuelTypeMessage);
        }

        public bool fuelTypeValidation(int i_fuelTyoe)
        {
            bool isfuelTypeValid;

            if (i_fuelTyoe >= 1 && i_fuelTyoe <= 4)
            {
                isfuelTypeValid = true;
            }

            else
            {
                isfuelTypeValid = false;
            }

            return isfuelTypeValid;
        }

        public FuelEnergy.eFuelType fuelTypeConvertToEnum(int i_fuelType)
        {
            FuelEnergy.eFuelType fuelTypeEnum;

            switch (i_fuelType)
            {
                case 1:
                    fuelTypeEnum = FuelEnergy.eFuelType.Soler;
                    break;
                case 2:
                    fuelTypeEnum = FuelEnergy.eFuelType.Octan95;
                    break;
                case 3:
                    fuelTypeEnum = FuelEnergy.eFuelType.Octan96;
                    break;
                case 4:
                default:
                    fuelTypeEnum = FuelEnergy.eFuelType.Octan98;
                    break;
            }

            return fuelTypeEnum;
        }

        public int GetTimeToChargeInMinutes()
        {
            int timeToChargeInMinutes;
            bool inputIsValid;

            PrintRequestForTimeToCharge();
            inputIsValid = int.TryParse(Console.ReadLine(), out timeToChargeInMinutes);
            while (!inputIsValid)
            {
                PrintInvalidInputMessage();
                PrintRequestForTimeToCharge();
                inputIsValid = int.TryParse(Console.ReadLine(), out timeToChargeInMinutes);
            }

            return timeToChargeInMinutes;
        }

        public static void PrintRequestForTimeToCharge()
        {
            StringBuilder TimeToChargeMessage = new StringBuilder();

            TimeToChargeMessage.Append("Please enter the number of minutes to charge your vehicle");
            Console.WriteLine(TimeToChargeMessage);
        }

        public float GetFuelAmount()
        {
            float fuelAmount;
            bool isInputValid;

            PrintRequestForFuelAmount();
            isInputValid = float.TryParse(Console.ReadLine(), out fuelAmount);
            while (!isInputValid)
            {
                PrintInvalidInputMessage();
                PrintRequestForFuelAmount();
                isInputValid = float.TryParse(Console.ReadLine(), out fuelAmount);
            }

            return fuelAmount;
        }

        public static void PrintRequestForFuelAmount()
        {
            StringBuilder fuelAmountMessage = new StringBuilder();

            fuelAmountMessage.Append("Please enter the fuel amount: ");
            Console.WriteLine(fuelAmountMessage);
        }

        public void PrintAllGarageVehiclesID(List<string> i_GarageVehiclesID)
        {
            StringBuilder vehicleLicenceIDSingleEntityMessage = new StringBuilder();

            foreach (string currLicenceID in i_GarageVehiclesID)
            {
                vehicleLicenceIDSingleEntityMessage.AppendFormat("LicenceID: {0}", currLicenceID);
                Console.WriteLine(vehicleLicenceIDSingleEntityMessage);
                vehicleLicenceIDSingleEntityMessage.Clear();
            }
        }

        public int GetVehicleStatus()
        {
            int vehicleStatusChoice;
            bool isInputValid;

            PrintRequestForVehicleStatus();
            isInputValid = int.TryParse(Console.ReadLine(), out vehicleStatusChoice);
            while (!isInputValid || !VehicleStatusValidation(vehicleStatusChoice))
            {
                PrintInvalidInputMessage();
                PrintRequestForVehicleStatus();
                isInputValid = int.TryParse(Console.ReadLine(), out vehicleStatusChoice);
            }

            return vehicleStatusChoice;
        }

        public static void PrintRequestForVehicleStatus()
        {
            StringBuilder vehicleStatusMessage = new StringBuilder();

            vehicleStatusMessage.AppendLine("Pleae enter the requested status of the vehicle");
            vehicleStatusMessage.AppendLine("1 - InRepair");
            vehicleStatusMessage.AppendLine("2 - Repaired");
            vehicleStatusMessage.Append("3 - Paid");
            Console.WriteLine(vehicleStatusMessage);
        }

        public bool VehicleStatusValidation(int i_VehicleStatus)
        {
            bool isVehicleStatusValid;

            if (i_VehicleStatus >= 1 && i_VehicleStatus <= 3)
            {
                isVehicleStatusValid = true;
            }

            else
            {
                isVehicleStatusValid = false;
            }

            return isVehicleStatusValid;
        }

        public bool AskToEndWorkday()
        {
            bool endWorkDay;
            bool inputIsValid;
            int endWorkDayChoice;

            PrintRequestForEndWorkDay();
            inputIsValid = int.TryParse(Console.ReadLine(), out endWorkDayChoice);
            while (!inputIsValid || !EndWorkDayChoiceValidaition(endWorkDayChoice))
            {
                PrintInvalidInputMessage();
                PrintRequestForEndWorkDay();
                inputIsValid = int.TryParse(Console.ReadLine(), out endWorkDayChoice);
            }

            if (endWorkDayChoice == 1)
            {
                endWorkDay = true;
            }

            else // == 2
            {
                endWorkDay = false;
            }

            return endWorkDay;
        }

        public static void PrintRequestForEndWorkDay()
        {
            StringBuilder endWorkDayMessage = new StringBuilder();

            endWorkDayMessage.AppendLine("Do you want to finish your work day in the garage?");
            endWorkDayMessage.AppendLine("1 - Yes, I want to go home.");
            endWorkDayMessage.Append("2 - No - I have more vehicles to fix.");
            Console.WriteLine(endWorkDayMessage);
        }

        public bool EndWorkDayChoiceValidaition(int i_FinishWorkDayChoice)
        {
            bool endWorkDayChoiceIsValid;

            if (i_FinishWorkDayChoice == 1 || i_FinishWorkDayChoice == 2)
            {
                endWorkDayChoiceIsValid = true;
            }

            else
            {
                endWorkDayChoiceIsValid = false;
            }

            return endWorkDayChoiceIsValid;
        }

        public bool AskToEndAddingVehiclesToGarage()
        {
            bool endAddingVehiclesToGarage;
            bool inputIsValid;
            int endAddingToGarageChoice;

            PrintRequestForEndAddingToGarage();
            inputIsValid = int.TryParse(Console.ReadLine(), out endAddingToGarageChoice);
            while (!inputIsValid || !EndAddingToGarageChoiceValidaition(endAddingToGarageChoice))
            {
                PrintInvalidInputMessage();
                PrintRequestForEndAddingToGarage();
                inputIsValid = int.TryParse(Console.ReadLine(), out endAddingToGarageChoice);
            }

            if (endAddingToGarageChoice == 1)
            {
                endAddingVehiclesToGarage = true;
            }

            else // == 2
            {
                endAddingVehiclesToGarage = false;
            }

            return endAddingVehiclesToGarage;
        }

        public static void PrintRequestForEndAddingToGarage()
        {
            StringBuilder endAddingToGarageMessage = new StringBuilder();

            endAddingToGarageMessage.AppendLine("Do you want to finish to add vehicles to the garage?");
            endAddingToGarageMessage.AppendLine("1 - Yes, full capacity for today");
            endAddingToGarageMessage.Append("2 - No - I have more places for today");
            Console.WriteLine(endAddingToGarageMessage);
        }

        public bool EndAddingToGarageChoiceValidaition(int i_EndAddingToGarageChoice)
        {
            bool endAddingToGarageChoiceIsValid;

            if (i_EndAddingToGarageChoice == 1 || i_EndAddingToGarageChoice == 2)
            {
                endAddingToGarageChoiceIsValid = true;
            }

            else
            {
                endAddingToGarageChoiceIsValid = false;
            }

            return endAddingToGarageChoiceIsValid;
        }

        public bool VehicleTreeatmentValidation(int i_VehicleTreatment)
        {
            bool isVehicleTreatmentValid;

            if (i_VehicleTreatment >= 1 && i_VehicleTreatment <= 5)
            {
                isVehicleTreatmentValid = true;
            }

            else
            {
                isVehicleTreatmentValid = false;
            }

            return isVehicleTreatmentValid;
        }

        public Garage.eGarageOperations VehicleTreatmentConvertToEnum(int i_VehicleTreatment)
        {
            Garage.eGarageOperations VehicleTreatmentEnum;

            switch (i_VehicleTreatment)
            {
                case 1:
                    VehicleTreatmentEnum = Garage.eGarageOperations.Refuel;
                    break;
                case 2:
                    VehicleTreatmentEnum = Garage.eGarageOperations.ChargeBattery;
                    break;
                case 3:
                    VehicleTreatmentEnum = Garage.eGarageOperations.InflateWheels;
                    break;
                case 4:
                    VehicleTreatmentEnum = Garage.eGarageOperations.ChangeStatus;
                    break;
                case 5:
                    VehicleTreatmentEnum = Garage.eGarageOperations.ExistenceCheck;
                    break;
                case 6:
                default:
                    VehicleTreatmentEnum = Garage.eGarageOperations.None;
                    break;
            }

            return VehicleTreatmentEnum;
        }

        public bool AskForPrintAllVehicleID()
        {
            bool isInputValid;
            bool PrintAllVehicle;
            int printAllVehicleChoice;

            PrintRequestForPrintAllVehicle();
            isInputValid = int.TryParse(Console.ReadLine(), out printAllVehicleChoice);
            while (!isInputValid || !PrintAllVehicleValidation(printAllVehicleChoice))
            {
                PrintInvalidInputMessage();
                PrintRequestForPrintAllVehicle();
                isInputValid = int.TryParse(Console.ReadLine(), out printAllVehicleChoice);
            }

            if (printAllVehicleChoice == 1)
            {
                PrintAllVehicle = true;
            }

            else
            {
                PrintAllVehicle = false;
            }

            return PrintAllVehicle;
        }

        public void PrintRequestForPrintAllVehicle()
        {
            StringBuilder printAllVehicleIDMessage = new StringBuilder();

            printAllVehicleIDMessage.AppendLine("Do you want to print the all vehicle ID taht in the garage?");
            printAllVehicleIDMessage.AppendLine("press 1 - to print");
            printAllVehicleIDMessage.AppendLine("press 2 - not print");
            Console.WriteLine(printAllVehicleIDMessage);
        }

        public bool PrintAllVehicleValidation(int i_PrintAllVehicleChois)
        {
            bool isPrintAllVehicleChoisValid;

            if (i_PrintAllVehicleChois == 1 || i_PrintAllVehicleChois == 2)
            {
                isPrintAllVehicleChoisValid = true;
            }

            else
            {
                isPrintAllVehicleChoisValid = false;
            }

            return isPrintAllVehicleChoisValid;
        }

        public void OperationCompletedMessage()
        {
            StringBuilder operationSucceedMessage = new StringBuilder();

            operationSucceedMessage.Append("The operation completed succuessfully.");
            Console.WriteLine(operationSucceedMessage);
        }

        public void PrintAllVehicleGarageCardDetails(GarageCard i_VehicleGarageCard)
        {
            StringBuilder vehicleGarageCardDetails = new StringBuilder();

            vehicleGarageCardDetails.AppendFormat("The garage is currently holding {0} vehicle", i_VehicleGarageCard.Vehicle.LicenceID).AppendLine();
            vehicleGarageCardDetails.AppendFormat("Vehicle model name: {0}", i_VehicleGarageCard.Vehicle.ModelName).AppendLine();
            vehicleGarageCardDetails.AppendFormat("Vehicle owner name: {0}", i_VehicleGarageCard.OwnerName).AppendLine();
            vehicleGarageCardDetails.AppendFormat("Vehicle owner phone: {0}", i_VehicleGarageCard.OwnerPhone).AppendLine();
            vehicleGarageCardDetails.AppendFormat("Vehicle status: {0}", ConvertVehicleStatusToString(i_VehicleGarageCard.VehicleStatus)).AppendLine();
            vehicleGarageCardDetails.AppendFormat("Vehicle wheels manufacturer name {0}", i_VehicleGarageCard.Vehicle.VehicleWheels[0].WheelManufacturerName).AppendLine();
            vehicleGarageCardDetails.Append(AllWheelsCurrentPSI(i_VehicleGarageCard.Vehicle.VehicleWheels));
            vehicleGarageCardDetails.AppendFormat("Vehicle energy status: {0}", i_VehicleGarageCard.Vehicle.VehicleEnergy.EnergyLeftPercentage).AppendLine();
            FuelEnergy fEnergy = i_VehicleGarageCard.Vehicle.VehicleEnergy as FuelEnergy;
            if (fEnergy != null)
            {
                vehicleGarageCardDetails.AppendFormat("Vehicle fuel type: {0}", ConvertFuelTypeToString(fEnergy.FuelType)).AppendLine();
            }



            Console.WriteLine(vehicleGarageCardDetails);
        }

        public StringBuilder ConvertVehicleStatusToString(Garage.eVehicleStatus i_VehicleStatus)
        {
            StringBuilder vehicleStatus = new StringBuilder();

            switch (i_VehicleStatus)
            {
                case Garage.eVehicleStatus.InRepair:
                    vehicleStatus.Append("Currently in repair.");
                    break;

                case Garage.eVehicleStatus.Repaired:
                    vehicleStatus.Append("Vehicle Already repaired, waiting for the owner payment.");
                    break;

                case Garage.eVehicleStatus.Paid:
                    vehicleStatus.Append("Vehicle Already repaired and paid, waiting for the owner pick-up.");
                    break;

                default:
                    vehicleStatus.Append("Unknown");
                    break;
            }

            return vehicleStatus;
        }

        public StringBuilder AllWheelsCurrentPSI(List<Wheel> i_AllVehicleWheels)
        {
            StringBuilder vehicleWheelsCurrentPSI = new StringBuilder();
            int wheelNum = 1;

            foreach (Wheel wheel in i_AllVehicleWheels)
            {
                vehicleWheelsCurrentPSI.AppendFormat("Wheel number {0} current PSI: ", wheel.CurrentPSI).AppendLine();
                wheelNum++;
            }

            return vehicleWheelsCurrentPSI;
        }

        public StringBuilder ConvertFuelTypeToString(FuelEnergy.eFuelType i_FuelType)
        {
            StringBuilder fuelType = new StringBuilder();

            switch (i_FuelType)
            {
                case FuelEnergy.eFuelType.Octan95:
                    fuelType.AppendLine("Octan95");
                    break;

                case FuelEnergy.eFuelType.Octan96:
                    fuelType.AppendLine("Octan96");
                    break;

                case FuelEnergy.eFuelType.Octan98:
                    fuelType.AppendLine("Octan98");
                    break;

                case FuelEnergy.eFuelType.Soler:
                    fuelType.AppendLine("Soler");
                    break;

                default:
                    fuelType.AppendLine("Unkown");
                    break;
            }

            return fuelType;
        }

    }

}
