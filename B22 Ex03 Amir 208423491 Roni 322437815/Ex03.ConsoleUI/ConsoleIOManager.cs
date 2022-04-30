﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace Ex03.ConsoleUI
{
    using GarageLogic;
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

        public VehicleManufacturer.eVehicleType GetVehicleType()
        {
            int vehicleTypeChoice;
            VehicleManufacturer.eVehicleType vehicleType;
            bool inputIsValid;

            PrintRequestOfVehicleType();
            inputIsValid = int.TryParse(Console.ReadLine(), out vehicleTypeChoice);
            while (!inputIsValid || !VehicleTypeValidation(vehicleTypeChoice))
            {
                PrintInvalidInputMessage();
                PrintRequestOfVehicleType();
                inputIsValid = int.TryParse(Console.ReadLine(), out vehicleTypeChoice);
            }

            vehicleType = ConvertChoiceToVehicleType(vehicleTypeChoice);

            return vehicleType;
        }

        public StringBuilder GetOwnerName()
        {
            StringBuilder ownerName = new StringBuilder();

            PrintRequestForTheOwnerName();
            ownerName.Append(Console.ReadLine());

            while (!NameLengthValidation(ownerName))
            {
                PrintInvalidInputMessage();
                PrintRequestForTheOwnerName();
                ownerName.Append(Console.ReadLine());
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

        public Energy.eEnergyType GetEnergyType()
        {
            Energy.eEnergyType energyTypeEnum;
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

        public Energy.eEnergyType EnergyTypeConvertToEnum(int i_energyType)
        {
            Energy.eEnergyType energyTypeEnum;

            if(i_energyType == 1)
            {
                energyTypeEnum = Energy.eEnergyType.Fuel;
            }

            else
            {
                energyTypeEnum = Energy.eEnergyType.Electric;
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

            carColor = ConvertChoiceToCarColor(carColorChoose);
            return carColor;
        }

        public Car.eDoorsNumber GetDoorsNumberInCar()
        {
            int numberOfDoors;
            bool carDoorsNumberIsValid;
            Car.eDoorsNumber doorsCar;

            PrintRequesrForDoorsNumberInCar();
            carDoorsNumberIsValid = int.TryParse(Console.ReadLine(), out numberOfDoors);
            while (!carDoorsNumberIsValid || !DoorsNumberInCarValidation(numberOfDoors))
            {

                PrintRequesrForDoorsNumberInCar();
                carDoorsNumberIsValid = int.TryParse(Console.ReadLine(), out numberOfDoors);
            }

            doorsCar = DoorsNumbersInCarConvertToEnum(numberOfDoors);
            return doorsCar;
        }

        public void PrintRequesrForDoorsNumberInCar()
        {
            StringBuilder doorsCarMessage = new StringBuilder();

            doorsCarMessage.Append("Please enter the doors number in your car: ");
            Console.WriteLine(doorsCarMessage);
        }

        public bool DoorsNumberInCarValidation(int i_DoorsCar)
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

        public Car.eDoorsNumber DoorsNumbersInCarConvertToEnum(int i_DoorsCarNumber)
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

        public VehicleManufacturer.eVehicleType ConvertChoiceToVehicleType(int i_VehicleType)
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

        public bool NameLengthValidation(StringBuilder i_Name)
        {
            bool isNameValid;

            if (i_Name.Length <= k_MaximumOwnerNameLength)
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

            if(i_OwnerPhoneNumber.Length == k_PhoneNumberLength)
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

        public Car.eColor ConvertChoiceToCarColor(int i_CarColor)
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

        public Motorcycle.eMotorcycleLicenceType GetMotorcycleLicenceType()
        {
            int licenceTypeChoice;
            bool inputIsValid;
            Motorcycle.eMotorcycleLicenceType licenceType;

            PrintRequestForLicenceType();
            inputIsValid = int.TryParse(Console.ReadLine(), out licenceTypeChoice);
            while (!inputIsValid || !LicenceTypeChoiceValidation(licenceTypeChoice))
            {
                PrintInvalidInputMessage();
                PrintRequestForLicenceType();
                inputIsValid = int.TryParse(Console.ReadLine(), out licenceTypeChoice);
            }

            licenceType = ConvertChoiceToLicenceType(licenceTypeChoice);
            return licenceType;
        }

        public bool LicenceTypeChoiceValidation(int i_LicenceTypeChoice)
        {
            bool licenceTypeChoiceIsValid;

            if (i_LicenceTypeChoice >= 1 && i_LicenceTypeChoice <= 4)
            {
                licenceTypeChoiceIsValid = true;
            }

            else
            {
                licenceTypeChoiceIsValid = false;
            }

            return licenceTypeChoiceIsValid;
        }

        public Motorcycle.eMotorcycleLicenceType ConvertChoiceToLicenceType(int i_LicenceTypeChoice)
        {
            Motorcycle.eMotorcycleLicenceType licenceType;

            switch (i_LicenceTypeChoice)
            {
                case 1:
                    licenceType = Motorcycle.eMotorcycleLicenceType.A;
                    break;

                case 2:
                    licenceType = Motorcycle.eMotorcycleLicenceType.A1;
                    break;

                case 3:
                    licenceType = Motorcycle.eMotorcycleLicenceType.B1;
                    break;

                case 4:
                default:
                    licenceType = Motorcycle.eMotorcycleLicenceType.BB;
                    break;

            }

            return licenceType;
        }

        public void PrintRequestForLicenceType()
        {
            StringBuilder licenceTypeMessage = new StringBuilder();

            licenceTypeMessage.AppendLine("Please enter the motorcycle licence type: ");
            licenceTypeMessage.AppendLine("1 - A");
            licenceTypeMessage.AppendLine("2 - A1");
            licenceTypeMessage.AppendLine("3 - B1");
            licenceTypeMessage.Append("3 - BB");
            Console.WriteLine(licenceTypeMessage);
        }

        public int GetMotorcycleEngineCapacity()
        {
            int engineCapacityCC;
            bool inputIsValid;

            PrintRequestForEngineCapacity();
            inputIsValid = int.TryParse(Console.ReadLine(), out engineCapacityCC);
            while (!inputIsValid)
            {
                PrintInvalidInputMessage();
                PrintRequestForEngineCapacity();
                inputIsValid = int.TryParse(Console.ReadLine(), out engineCapacityCC);
            }

            return engineCapacityCC;
        }

        public void PrintRequestForEngineCapacity()
        {
            StringBuilder engineCapacityMessage = new StringBuilder();

            engineCapacityMessage.Append("Please enter the motorcycle engine capcity: ");
            Console.WriteLine(engineCapacityMessage);
        }

        public bool GetIfTruckHasCoolingCargo()
        {
            bool hasCoolingCargo;
            int coolingCargoChoice;
            bool inputIsValid;

            PrintRequestForCoolingCargoOption();
            inputIsValid = int.TryParse(Console.ReadLine(), out coolingCargoChoice);
            while (!inputIsValid || !CoolingCargoChoiceValidation(coolingCargoChoice))
            {
                PrintInvalidInputMessage();
                PrintRequestForCoolingCargoOption();
                inputIsValid = int.TryParse(Console.ReadLine(), out coolingCargoChoice);
            }

            if (coolingCargoChoice == 1)
            {
                hasCoolingCargo = true;
            }

            else // == 2
            {
                hasCoolingCargo = false;
            }

            return hasCoolingCargo;
        }

        public bool CoolingCargoChoiceValidation(int i_CoolingCargoChoice)
        {
            bool coolingCargoChoiceIsValid;

            if (i_CoolingCargoChoice == 1 || i_CoolingCargoChoice == 2)
            {
                coolingCargoChoiceIsValid = true;
            }

            else
            {
                coolingCargoChoiceIsValid = false;
            }

            return coolingCargoChoiceIsValid;
        }

        public void PrintRequestForCoolingCargoOption()
        {
            StringBuilder CoolingCargoMessage = new StringBuilder();

            CoolingCargoMessage.AppendLine("Please enter whether the truck has cooling cargo or not ");
            CoolingCargoMessage.AppendLine("1 - Add cooling cargo in truck");
            CoolingCargoMessage.AppendLine("2 - Do not add cooling cargo in truck");
            Console.WriteLine(CoolingCargoMessage);
        }

        public float GetTruckCargoCapacity()
        {
            float cargoCapacity;
            bool inputIsValid;

            PrintRequestForCargoCapacity();
            inputIsValid = float.TryParse(Console.ReadLine(), out cargoCapacity);
            while (!inputIsValid)
            {
                PrintInvalidInputMessage();
                PrintRequestForCargoCapacity();
                inputIsValid = float.TryParse(Console.ReadLine(), out cargoCapacity);
            }

            return cargoCapacity;
        }

        public void PrintRequestForCargoCapacity()
        {
            StringBuilder cargoCapacityMessage = new StringBuilder();

            cargoCapacityMessage.Append("Please enter the motorcycle engine capcity: ");
            Console.WriteLine(cargoCapacityMessage);
        }

        public StringBuilder GetVehicleModelName()
        {
            StringBuilder vehicleModelName = new StringBuilder();

            PrintRequestForVehicleModelName();
            vehicleModelName.Append(Console.ReadLine());
            while (!ModelNameLengthValidation(vehicleModelName))
            {
                PrintInvalidInputMessage();
                PrintRequestForVehicleModelName();
                vehicleModelName.Append(Console.ReadLine());
            }

            return vehicleModelName;
        }

        public bool ModelNameLengthValidation(StringBuilder i_ModelName)
        {
            bool modelNameLengthIsValid;

            if (i_ModelName.Length < k_MaximumModelNameLength)
            {
                modelNameLengthIsValid = true;
            }

            else
            {
                modelNameLengthIsValid = false; 
            }

            return modelNameLengthIsValid;
        }

        public void PrintRequestForVehicleModelName()
        {
            StringBuilder modelNameMessage = new StringBuilder();

            modelNameMessage.Append("Please enter the vehicle model name: ");
            Console.WriteLine(modelNameMessage);
        }

        public StringBuilder GetWheelManufacturerName()
        {
            StringBuilder wheelManufacturerName = new StringBuilder();

            PrintRequestForWheelManufacturerName();
            wheelManufacturerName.Append(Console.ReadLine());
            while (!WheelManufacturerNameLengthValidation(wheelManufacturerName))
            {
                PrintInvalidInputMessage();
                PrintRequestForWheelManufacturerName();
                wheelManufacturerName.Append(Console.ReadLine());
            }

            return wheelManufacturerName;
        }

        public bool WheelManufacturerNameLengthValidation(StringBuilder i_WheelManufacturerName)
        {
            bool wheelManufacturerNameLengthIsValid;

            if (i_WheelManufacturerName.Length <= k_MaximumWheelManufacturerNameLength)
            {
                wheelManufacturerNameLengthIsValid = true;
            }

            else
            {
                wheelManufacturerNameLengthIsValid = false;
            }

            return wheelManufacturerNameLengthIsValid;
        }

        public void PrintRequestForWheelManufacturerName()
        {
            StringBuilder wheelManufacturerNameMessage = new StringBuilder();

            wheelManufacturerNameMessage.Append("Please enter the wheel manufacturer name: ");
            Console.WriteLine(wheelManufacturerNameMessage);
        }
    }
}
