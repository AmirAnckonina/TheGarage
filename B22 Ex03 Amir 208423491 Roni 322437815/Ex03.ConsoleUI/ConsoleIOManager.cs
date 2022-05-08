using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ex03.GarageLogic;

namespace Ex03.ConsoleUI
{
    public class ConsoleIOManager
    {
        private const int k_MaximumOwnerNameLength = 20;
        private const int k_PhoneNumberLength = 10;
        private const int k_MaximumModelNameLength = 20;
        private const int k_MaximumWheelManufacturerNameLength = 20;

        public void Welcome()
        {
            StringBuilder welcomeMessage = new StringBuilder();

            welcomeMessage.Append("Welcome to the Garage!");
            Console.WriteLine(welcomeMessage);
        }
        
        public void Goodbye()
        {
            StringBuilder welcomeMessage = new StringBuilder();

            welcomeMessage.Append("Thanks!");
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

        public string GetVehicleLicenseID()
        {
            StringBuilder vehicleLicenseNumber = new StringBuilder();

            PrintRequesOfVehicleLicenseNumber();
            vehicleLicenseNumber.Append(Console.ReadLine());
            while (!LicenseIDFormatValidation(vehicleLicenseNumber))
            {
                PrintInvalidInputMessage();
                PrintRequesOfVehicleLicenseNumber();
                vehicleLicenseNumber.Clear();
                vehicleLicenseNumber.Append(Console.ReadLine());
            }

            return vehicleLicenseNumber.ToString();
        }

        public string GetSingleDetail(string i_RequestMessageValue)
        {
            string insertedInput;

            Console.WriteLine(i_RequestMessageValue);
            insertedInput = Console.ReadLine();

            return insertedInput;
        }

        public int GetVehicleGarageOperation()
        {
            int garageOperationChoice;
            bool inputIsValid;

            PrintGarageVehicleOperationsMenu();
            inputIsValid = int.TryParse(Console.ReadLine(), out garageOperationChoice);
            while (!inputIsValid || garageOperationChoice < 1 || garageOperationChoice > 5)
            {
                PrintInvalidInputMessage();
                PrintGarageVehicleOperationsMenu();
                inputIsValid = int.TryParse(Console.ReadLine(), out garageOperationChoice);
            }

            return garageOperationChoice;
        }

        public void VehicleAllReadyInTheGarageMessage()
        {
            StringBuilder vehicleInTheGarageMessage = new StringBuilder();

            vehicleInTheGarageMessage.Append("The vehicle is currently repairing in the garage.");
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

        public int GetGarageActionMainMenu()
        {
            int actionInTheGarage;
            bool isInputValid;

            PrintRequestForGarageActionMainMenu();
            isInputValid = int.TryParse(Console.ReadLine(), out actionInTheGarage);
            while (!isInputValid || actionInTheGarage < 1 || actionInTheGarage > 4)
            {
                PrintInvalidInputMessage();
                PrintRequestForGarageActionMainMenu();
                isInputValid = int.TryParse(Console.ReadLine(), out actionInTheGarage);
            }

            return actionInTheGarage;
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

        public int GetFuelType()
        {
            int fuelType;
            bool inputIsValid;

            PrintFuelTypeMessage();
            inputIsValid = int.TryParse(Console.ReadLine(), out fuelType);
            while (!inputIsValid || !FuelTypeValidation(fuelType))
            {
                PrintInvalidInputMessage();
                PrintFuelTypeMessage();
                inputIsValid = int.TryParse(Console.ReadLine(), out fuelType);
            }

            return fuelType;
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

        public void OperationCompletedMessage()
        {
            StringBuilder operationSucceedMessage = new StringBuilder();

            operationSucceedMessage.Append("The operation completed successfully.");
            Console.WriteLine(operationSucceedMessage);
        }

        public void PrintAllGarageVehiclesID(List<string> i_GarageVehiclesID)
        {
            foreach (string currLicenseID in i_GarageVehiclesID)
            { 
                Console.WriteLine(currLicenseID);
            }
        }

        private static void PrintRequestForGarageActionMainMenu()
        {
            StringBuilder actionInTheGarageMessage = new StringBuilder();

            actionInTheGarageMessage.AppendLine("Choose which garage action you need: ");
            actionInTheGarageMessage.AppendLine("1 - Add new vehicle to the garage");
            actionInTheGarageMessage.AppendLine("2 - Do some vehicle operation in the garage");
            actionInTheGarageMessage.AppendLine("3 - Get garage vehicles by status");
            actionInTheGarageMessage.Append("4 - Go home");
            Console.WriteLine(actionInTheGarageMessage);
        }

        private static void PrintAnotherOperationMessage()
        {
            StringBuilder anotherOperationMessage = new StringBuilder();

            anotherOperationMessage.AppendLine("Do you want another operation for this vehicle?");
            anotherOperationMessage.AppendLine("1 - Yes");
            anotherOperationMessage.Append("2 - No");
            Console.WriteLine(anotherOperationMessage);
        }

        private static void PrintInvalidInputMessage()
        {
            StringBuilder invalidInputMessage = new StringBuilder();

            invalidInputMessage.Append("The input is not valid!");
            Console.WriteLine(invalidInputMessage);
        }

        private static void PrintFuelTypeMessage()
        {
            StringBuilder fuelTypeMessage = new StringBuilder();

            fuelTypeMessage.AppendLine("Please enter the fuel type of your vehicle");
            fuelTypeMessage.AppendLine("1 - Soler");
            fuelTypeMessage.AppendLine("2 - Octan95");
            fuelTypeMessage.AppendLine("3 - Octan96");
            fuelTypeMessage.Append("4 - Octan98");
            Console.WriteLine(fuelTypeMessage);
        }

        private static void PrintRequestForTimeToCharge()
        {
            StringBuilder TimeToChargeMessage = new StringBuilder();

            TimeToChargeMessage.Append("Please enter the number of minutes to charge your vehicle");
            Console.WriteLine(TimeToChargeMessage);
        }

        private static void PrintRequestForFuelAmount()
        {
            StringBuilder fuelAmountMessage = new StringBuilder();

            fuelAmountMessage.Append("Please enter the fuel amount, in liters: ");
            Console.WriteLine(fuelAmountMessage);
        }

        private static void PrintRequestForVehicleStatus()
        {
            StringBuilder vehicleStatusMessage = new StringBuilder();

            vehicleStatusMessage.AppendLine("Pleae enter the new status for the vehicle");
            vehicleStatusMessage.AppendLine("1 - In repair");
            vehicleStatusMessage.AppendLine("2 - Already repaired");
            vehicleStatusMessage.Append("3 - Finished and paid");
            Console.WriteLine(vehicleStatusMessage);
        }

        private static void PrintRequestOfVehicleType()
        {
            StringBuilder vehicleTypeMessage = new StringBuilder();

            vehicleTypeMessage.AppendLine("Enter the type of your vehicle:");
            vehicleTypeMessage.AppendLine("1 - Fuel Car");
            vehicleTypeMessage.AppendLine("2 - Fuel Motorcycle");
            vehicleTypeMessage.AppendLine("3 - Fuel Truck");
            vehicleTypeMessage.AppendLine("4 - Electric Car");
            vehicleTypeMessage.Append("5 - Electric Motorcycle");
            Console.WriteLine(vehicleTypeMessage);
        }

        private static void PrintRequesOfVehicleLicenseNumber()
        {
            StringBuilder vehicleLicenseNumberMessage = new StringBuilder();

            vehicleLicenseNumberMessage.Append("Please enter the license number of the vehicle:");
            Console.WriteLine(vehicleLicenseNumberMessage);
        }

        private static void PrintGarageVehicleOperationsMenu()
        {
            StringBuilder vehicleTreatmentMessage = new StringBuilder();

            vehicleTreatmentMessage.AppendLine("Enter the garage operation you need:");
            vehicleTreatmentMessage.AppendLine("1 - Refuel");
            vehicleTreatmentMessage.AppendLine("2 - Charge battery");
            vehicleTreatmentMessage.AppendLine("3 - Inflate wheels");
            vehicleTreatmentMessage.AppendLine("4 - Get full vehicle info");
            vehicleTreatmentMessage.Append("5 - Change vehicle status");
            Console.WriteLine(vehicleTreatmentMessage);
        }

        private bool FuelTypeValidation(int i_FuelType)
        {
            bool isfuelTypeValid;

            if (i_FuelType >= 1 && i_FuelType <= 4)
            {
                isfuelTypeValid = true;
            }

            else
            {
                isfuelTypeValid = false;
            }

            return isfuelTypeValid;
        }

        private bool LicenseIDFormatValidation(StringBuilder i_LicenseID)
        {
            bool LicenseIDIsValid;

            if (i_LicenseID.Length >= 5 && i_LicenseID.Length <= 8 && i_LicenseID.ToString().All(char.IsDigit))
            {
                LicenseIDIsValid = true;
            }

            else
            {
                LicenseIDIsValid = false;
            }

            return LicenseIDIsValid;
        }

        private bool VehicleStatusValidation(int i_VehicleStatus)
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

        private bool VehicleTypeChoiceValidation(string i_VehicleTypeChoice)
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
    }
}


