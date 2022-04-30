using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace Ex03.ConsoleUI
{
    using GarageLogic;
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
            VehicleManufacturer.eVehicleType chosenVehicleType;
            bool vehicleTypeIsValid;

            PrintRequestOfVehicleType();
            vehicleTypeIsValid = int.TryParse(Console.ReadLine(), out vehicleType);
            while (!vehicleTypeIsValid || !VehicleTypeValidation(vehicleType))
            {
                PrintInvalidInputMessage();
                PrintRequestOfVehicleType();
                vehicleTypeIsValid = int.TryParse(Console.ReadLine(), out vehicleType);
            }

            chosenVehicleType = VehicleTypeConvertToEnum(vehicleType);
            return vehicleType;
        }

        public StringBuilder GetOwnerName()
        {
            StringBuilder ownerName = new StringBuilder();

            PrintRequestForTheOwnerName();
            ownerName.Append(System.Console.ReadLine());

            while (!NameValidation(ownerName))
            {
                PrintInvalidInputMessage();
                PrintRequestForTheOwnerName();
                ownerName.Append(System.Console.ReadLine());
            }

            return ownerName;
        }

        public StringBuilder GetVehicleOwnerPhoneNumber()
        {
            StringBuilder ownerPhoneNumber = new StringBuilder();

            PrintRequestForOwnerPhoneNumber();
            ownerPhoneNumber.Append(Console.ReadLine());
            while(!OwnerPhoneNumberValidation(ownerPhoneNumber))
            {
                PrintRequestForOwnerPhoneNumber();
                ownerPhoneNumber.Append(Console.ReadLine());
            }

            return ownerPhoneNumber;
        }

        public eEnergyType GetEnergType()
        {
            eEnergyType energyTypeEnum;
            int energyType;
            bool isenergyTypeValid;

            PrintRequestForEnergyType();
            isenergyTypeValid = int.TryParse(Console.ReadLine(), out energyType);
            while(!isenergyTypeValid || !EnergyTypeValidation(energyType))
            {
                PrintRequestForEnergyType();
                isenergyTypeValid = int.TryParse(Console.ReadLine(), out energyType);
            }

            energyTypeEnum = EnergyTypeConvertToEnum(energyType);
            return energyTypeEnum;
        }

        public void PrintRequestForEnergyType()
        {
            StringBuilder EnergyTypeMessage = new StringBuilder();

            EnergyTypeMessage.AppendLine("Please enter the energy type of yout vehicle");
            EnergyTypeMessage.AppendLine("1 - Fuel");
            EnergyTypeMessage.AppendLine("2 - Electric");
            Console.WriteLine(EnergyTypeMessage);
        }

        public bool EnergyTypeValidation(int i_EnergyType)
        {
            bool isEnergyTypeValid;

            if(i_EnergyType == 1 || i_EnergyType == 2)
            {
                isEnergyTypeValid = true;
            }

            else
            {
                isEnergyTypeValid = false;
            }

            return isEnergyTypeValid;
        }

        public eEnergyType EnergyTypeConvertToEnum(int i_energyType)
        {
            eEnergyType energyTypeEnum;

            if(i_energyType == 1)
            {
                energyTypeEnum = eEnergyType.Fuel;
            }

            else
            {
                energyTypeEnum = eEnergyType.Electric;
            }

            return energyTypeEnum;
        }

        public Car.eColor GetCarColor()
        {
            int carColorChoose;
            bool carColerIsValid;
            Car.eColor carColor;

            PrintRequestForCarColor();
            carColerIsValid = int.TryParse(Console.ReadLine(), out carColorChoose);
            while (!carColerIsValid || !CarColorValidation(carColorChoose)) 
            {
                PrintRequestForCarColor();
                carColerIsValid = int.TryParse(Console.ReadLine(), out carColorChoose);
            }

            carColor = CarColerConverToEnum(carColorChoose);
            return carColor;
        }

        public Car.eDoorsNumber GetDoorsCar()
        {
            int numberOfDoors;
            bool carDoorsNumberIsValid;
            Car.eDoorsNumber doorsCar;

            PrintRequesrForDoorsCar();
            carDoorsNumberIsValid = int.TryParse(Console.ReadLine(), out numberOfDoors);
            while (!carDoorsNumberIsValid || !DoorsCarValidation(numberOfDoors))
            {

                PrintRequesrForDoorsCar();
                carDoorsNumberIsValid = int.TryParse(Console.ReadLine(), out numberOfDoors);
            }

            doorsCar = DoorsCarConvertToEnum(numberOfDoors);
            return doorsCar;
        }

        public void PrintRequesrForDoorsCar()
        {
            StringBuilder doorsCarMessage = new StringBuilder();

            doorsCarMessage.Append("Please enter the numbers of your vehicle");
            Console.WriteLine(doorsCarMessage);
        }

        public bool DoorsCarValidation(int i_DoorsCar)
        {
            bool isDoorValid;

            if(i_DoorsCar == 2 || i_DoorsCar ==3 || i_DoorsCar == 4 || i_DoorsCar == 5 )
            {
                isDoorValid = true;
            }

            else
            {
                isDoorValid = false;
            }

            return isDoorValid;
        }

        public Car.eDoorsNumber DoorsCarConvertToEnum(int i_DoorsCarNumber)
        {
            Car.eDoorsNumber doorsCarEnum;

            if(i_DoorsCarNumber == 2)
            {
                doorsCarEnum = Car.eDoorsNumber.Two;
            }

            else if (i_DoorsCarNumber == 3)
            {
                doorsCarEnum = Car.eDoorsNumber.Three;
            }

            else if (i_DoorsCarNumber == 4)
            {
                doorsCarEnum = Car.eDoorsNumber.Four;
            }

            else /// i_DoorsCarNumber = 5
            {
                doorsCarEnum = Car.eDoorsNumber.Five;
            }

            return doorsCarEnum;
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

        public VehicleManufacturer.eVehicleType VehicleTypeConvertToEnum (int i_VehicleType)
        {
            VehicleManufacturer.eVehicleType enumVehicleType;

            if (i_VehicleType == 1)
            {
                enumVehicleType = VehicleManufacturer.eVehicleType.Car;
            }

            else if (i_VehicleType == 2)
            {
                enumVehicleType = VehicleManufacturer.eVehicleType.Motorcycle;
            }

            else  ///i_Vehicle == 3
            {
                enumVehicleType = VehicleManufacturer.eVehicleType.Truck;
            }

            return enumVehicleType;
        }

        public StringBuilder GetVehicleLicenseNumber()
        {
            StringBuilder vehicleLicenseNumber = new StringBuilder();

            PrintRequesOfVehicleLicenseNumber();
            vehicleLicenseNumber.Append(Console.ReadLine());

            while (!VehicleLicenseNumberValidation(vehicleLicenseNumber))
            {
                PrintInvalidInputMessage();
                PrintRequesOfVehicleLicenseNumber();
                vehicleLicenseNumber.Append(Console.ReadLine());
            }

            return vehicleLicenseNumber;
        }

        public void PrintRequesOfVehicleLicenseNumber()
        {
            StringBuilder vehicleLicenseNumberMessage = new StringBuilder();

            vehicleLicenseNumberMessage.Append("Pleas enter the license number of your vehicle");
            Console.WriteLine(vehicleLicenseNumberMessage);
        }

        public bool VehicleLicenseNumberValidation(StringBuilder i_VehicleLicenseNumber) ///check if the chars are numbers?
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

        public void PrintRequestForTheOwnerName()
        {
            StringBuilder ownerNameMessage = new StringBuilder();

            ownerNameMessage.Append("Please enter the owner of the vehicle");
            Console.WriteLine(ownerNameMessage);
        }

        public bool NameValidation(StringBuilder i_Name)
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

        public void PrintRequestForOwnerPhoneNumber()
        {
            StringBuilder ownerPhoneNumberMessage = new StringBuilder();

            ownerPhoneNumberMessage.Append("Pleas enter the vhicle's ownre phone number");
            Console.WriteLine(ownerPhoneNumberMessage);
        }

        public bool OwnerPhoneNumberValidation(StringBuilder i_OwnerPhoneNumber)
        {
            bool isPhoneNumberValid;

            if(i_OwnerPhoneNumber.Length == 10)
            {
                isPhoneNumberValid = true;
            }

            else
            {
                isPhoneNumberValid = false;
            }

            return isPhoneNumberValid;
        }

        public void PrintRequestForCarColor()
        {
            StringBuilder carColorMessage = new StringBuilder();

            carColorMessage.AppendLine("Pleas enter the color of your vehicle:");
            carColorMessage.AppendLine("1 - Red");
            carColorMessage.AppendLine("2 - White");
            carColorMessage.AppendLine("3 - Green");
            carColorMessage.Append("4 - Blue");
            Console.WriteLine(carColorMessage);
        }

        public bool CarColorValidation(int i_CarColor)
        {
            bool isCarColorValid;

            if (i_CarColor == 1 || i_CarColor == 2 || i_CarColor == 3 || i_CarColor == 4)
            {
                isCarColorValid = true;
            }

            else
            {
                isCarColorValid = false;
            }

            return isCarColorValid;
        }

        public Car.eColor CarColerConverToEnum(int i_CarColor)
        {
            Car.eColor carColorEnum;

            if(i_CarColor == 1)
            {
                carColorEnum = Car.eColor.Red;
            }

            else if (i_CarColor == 2)
            {
                carColorEnum = Car.eColor.White;
            }

            else if (i_CarColor == 3)
            {
                carColorEnum = Car.eColor.Green;
            }

            else ///i_CarColor = 4
            {
                carColorEnum = Car.eColor.Blue;
            }

            return carColorEnum;
        }

        //public Motorcycle.eLicenceType MotorcycleLicenceType()
        //{
        //    int licenceType;
        //    bool isLicenceTypeValid;
        //    Motorcycle.eLicenceType licenceTypeEnum;

        //    PrintRequestForLicenceType();
        //    isLicenceTypeValid = int.TryParse(Console.ReadLine(), out licenceType);
        //    while (!isLicenceTypeValid || !LicenceTypeValidation(licenceType))
        //    {
        //        PrintRequestForLicenceType();
        //        isLicenceTypeValid = int.TryParse(Console.ReadLine(), out licenceType);
        //    }

        //    licenceTypeEnum = LicenceTypeConvertToEnum();
        //    return licenceTypeEnum;
        //}

        public void PrintRequestForLicenceType()
        {
            StringBuilder licenceTypeMessage = new StringBuilder();
        }

    }
}
