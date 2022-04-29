using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleUI
{
    class ConsoleIOManager
    {
        public const int k_MaximumNameLength = 20;

        public void Welcome()
        {
            StringBuilder welcomeMessage = new StringBuilder();

            welcomeMessage.Append("Welcome to the Gerage!");
            Console.WriteLine(welcomeMessage);
        }

        public int GetVehicleType()
        {
            int vehicleType;
            bool vehicleTypeIsValid;

            PrintRequestOfVehicleType();
            vehicleTypeIsValid = int.TryParse(Console.ReadLine(), out vehicleType);
            while (!vehicleTypeIsValid || !VehicleTypeValidation(vehicleType))
            {
                PrintInvalidInputMessage();
                PrintRequestOfVehicleType();
                vehicleTypeIsValid = int.TryParse(Console.ReadLine(), out vehicleType);
            }

            return vehicleType;
        }

        public void PrintRequestOfVehicleType()
        {
            StringBuilder vehicleTypeMessage = new StringBuilder();

            vehicleTypeMessage.AppendLine("Enter the type of your vehicle:");
            vehicleTypeMessage.AppendLine("1 - Car");
            vehicleTypeMessage.AppendLine("2 - Motorcycle");
            vehicleTypeMessage.Append("3 - Truck");
            Console.WriteLine(vehicleTypeMessage);
        }

        public void PrintInvalidInputMessage()
        {
            StringBuilder invalidInputMessage = new StringBuilder();

            invalidInputMessage.Append("The input is not valid!");
            Console.WriteLine(invalidInputMessage);
        }

        public bool VehicleTypeValidation(int i_VehicleType)
        {
            bool IsVehicleTypeValid;

            if (i_VehicleType == 1 || i_VehicleType == 2 || i_VehicleType == 3)
            {
                IsVehicleTypeValid = true;
            }

            else
            {
                IsVehicleTypeValid = false;
            }

            return IsVehicleTypeValid;
        }

        public string GetVehicleLicenseNumber()
        {
            string vehicleLicenseNumber;

            PrintRequesOfVehicleLicenseNumber();
            vehicleLicenseNumber = Console.ReadLine();

            while (!VehicleLicenseNumberValidation(vehicleLicenseNumber))
            {
                PrintInvalidInputMessage();
                PrintRequesOfVehicleLicenseNumber();
                vehicleLicenseNumber = Console.ReadLine();
            }

            return vehicleLicenseNumber;
        }

        public void PrintRequesOfVehicleLicenseNumber()
        {
            StringBuilder vehicleLicenseNumberMessage = new StringBuilder();

            vehicleLicenseNumberMessage.Append("Pleas enter the license number of your vehicle");
            Console.WriteLine(vehicleLicenseNumberMessage);
        }

        public bool VehicleLicenseNumberValidation(string i_VehicleLicenseNumber) ///check if the chars are numbers?
        {
            bool IsLicenseNumberValid;

            if (i_VehicleLicenseNumber.Length == 7 || i_VehicleLicenseNumber.Length == 8)
            {
                IsLicenseNumberValid = true;
            }

            else
            {
                IsLicenseNumberValid = false;
            }

            return IsLicenseNumberValid;
        }

        public string GetOwnerName()
        {
            String ownerName;

            PrintRequestForTheOwnerName();
            ownerName = Console.ReadLine();

            while (!NameValidation(ownerName))
            {
                PrintInvalidInputMessage();
                PrintRequestForTheOwnerName();
                ownerName = Console.ReadLine();
            }

            return ownerName;
        }

        public void PrintRequestForTheOwnerName()
        {
            StringBuilder ownerNameMessage = new StringBuilder();

            ownerNameMessage.Append("Please enter the owner of the vehicle");
            Console.WriteLine(ownerNameMessage);
        }

        public bool NameValidation(string i_Name)
        {
            bool isNameValid;

            if (i_Name.Length <= k_MaximumNameLength)
            {
                isNameValid = true;
            }

            else
            {
                isNameValid = false;
            }

            return isNameValid;
        }


    }
}
