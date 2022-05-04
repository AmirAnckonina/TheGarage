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

            return vehicleTypeChoice;
        }

        public static void PrintRequestOfVehicleType()
        {
            StringBuilder vehicleTypeMessage = new StringBuilder();

            vehicleTypeMessage.AppendLine("Enter the type of your vehicle:");
            vehicleTypeMessage.AppendLine("1 - Car");
            vehicleTypeMessage.AppendLine("2 - Motorcycle");
            vehicleTypeMessage.Append("3 - Truck");
            Console.WriteLine(vehicleTypeMessage);
        }

        public string GetEnergyType()
        {
            string energyType;
           
            PrintRequestForEnergyType();
            energyType = Console.ReadLine();
          
            return energyType;
        }

        public static void PrintRequestForEnergyType()
        {
            StringBuilder EnergyTypeMessage = new StringBuilder();

            EnergyTypeMessage.AppendLine("Please specify the energy source type of your vehicle");
            EnergyTypeMessage.AppendLine("1 - Fuel");
            EnergyTypeMessage.Append("2 - Electric");
            Console.WriteLine(EnergyTypeMessage);
        }

        public string GetVehicleLicenseID()
        {
            StringBuilder vehicleLicenseNumber = new StringBuilder();

            PrintRequesOfVehicleLicenseNumber();
            vehicleLicenseNumber.Append(Console.ReadLine());

           /* while (!VehicleLicenseNumberValidation(vehicleLicenseNumber))
            {
                PrintInvalidInputMessage();
                PrintRequesOfVehicleLicenseNumber();
                vehicleLicenseNumber.Clear();
                vehicleLicenseNumber.Append(Console.ReadLine());
            }*/

            return vehicleLicenseNumber.ToString();
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

        public static void PrintGarageMenu()
        {
            StringBuilder vehicleTreatmentMessage = new StringBuilder();

            vehicleTreatmentMessage.AppendLine("Enter the garage operation you need:");
            vehicleTreatmentMessage.AppendLine("1 - Refuel");
            vehicleTreatmentMessage.AppendLine("2 - Charge battery");
            vehicleTreatmentMessage.AppendLine("3 - Inflate wheels");
            vehicleTreatmentMessage.AppendLine("4 - Existence check");
            vehicleTreatmentMessage.AppendLine("5 - Change vehicle status");
            Console.WriteLine(vehicleTreatmentMessage);
        }

        public int GetVehicleGarageOperation()
        {
            int garageOperationChoice;
            bool inputIsValid;

            PrintGarageMenu();
            inputIsValid = int.TryParse(Console.ReadLine(), out garageOperationChoice);
            while  (!inputIsValid || garageOperationChoice < 1 || garageOperationChoice > 5)
            {
                PrintInvalidInputMessage();
                PrintGarageMenu();
                inputIsValid = int.TryParse(Console.ReadLine(), out garageOperationChoice);
            }

            return garageOperationChoice;
        }



        public string GetOwnerName()
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

            return ownerName.ToString();
        }

        public string GetVehicleOwnerPhoneNumber()
        {
            StringBuilder ownerPhoneNumber = new StringBuilder();

            PrintRequestForOwnerPhoneNumber();
            ownerPhoneNumber.Append(Console.ReadLine());
            while(!OwnerPhoneNumberValidation(ownerPhoneNumber))
            {
                PrintInvalidInputMessage();
                ownerPhoneNumber.Clear();
                PrintRequestForOwnerPhoneNumber();
                ownerPhoneNumber.Append(Console.ReadLine());
            }

            return ownerPhoneNumber.ToString();
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

        public Car.eCarColor GetCarColor()
        {
            int carColorChoose;
            bool carColerIsValid;
            Car.eCarColor carColor;

            PrintRequestForCarColor();
            carColerIsValid = int.TryParse(Console.ReadLine(), out carColorChoose);
            while (!carColerIsValid || !CarColorValidation(carColorChoose)) 
            {
                PrintInvalidInputMessage();
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
                PrintInvalidInputMessage();
                PrintRequesrForDoorsNumberInCar();
                carDoorsNumberIsValid = int.TryParse(Console.ReadLine(), out numberOfDoors);
            }

            doorsCar = DoorsNumbersInCarConvertToEnum(numberOfDoors);
            return doorsCar;
        }

        public static void PrintRequesrForDoorsNumberInCar()
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


        public static void PrintInvalidInputMessage()
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

        public static void PrintRequestForTheOwnerName()
        {
            StringBuilder ownerNameMessage = new StringBuilder();

            ownerNameMessage.Append("Please enter the owner name of the vehicle");
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

        public static void PrintRequestForOwnerPhoneNumber()
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

        public static void PrintRequestForCarColor()
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

        public Car.eCarColor ConvertChoiceToCarColor(int i_CarColor)
        {
            Car.eCarColor carColorEnum;

            if(i_CarColor == 1)
            {
                carColorEnum = Car.eCarColor.Red;
            }

            else if (i_CarColor == 2)
            {
                carColorEnum = Car.eCarColor.White;
            }

            else if (i_CarColor == 3)
            {
                carColorEnum = Car.eCarColor.Green;
            }

            else ///i_CarColor = 4
            {
                carColorEnum = Car.eCarColor.Blue;
            }

            return carColorEnum;
        }

       /* public Motorcycle.eMCLicenceType GetMotorcycleLicenceType()
        {
            int licenceTypeChoice;
            bool inputIsValid;
            Motorcycle.eMCLicenceType licenceType;

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
        }*/

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

        public Motorcycle.eMCLicenceType ConvertChoiceToLicenceType(int i_LicenceTypeChoice)
        {
            Motorcycle.eMCLicenceType licenceType;

            switch (i_LicenceTypeChoice)
            {
                case 1:
                    licenceType = Motorcycle.eMCLicenceType.A;
                    break;

                case 2:
                    licenceType = Motorcycle.eMCLicenceType.A1;
                    break;

                case 3:
                    licenceType = Motorcycle.eMCLicenceType.B1;
                    break;

                case 4:
                default:
                    licenceType = Motorcycle.eMCLicenceType.BB;
                    break;

            }

            return licenceType;
        }

        /*public static void PrintRequestForLicenceType()
        {
            StringBuilder licenceTypeMessage = new StringBuilder();

            "Please enter the motorcycle licence type: \n 1 - A \n 2 - A1 \n 3 - B1 \n 4 - BB \n"
            Console.WriteLine(licenceTypeMessage);
        }*/

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

        public static void PrintRequestForEngineCapacity()
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

        public static void PrintRequestForCoolingCargoOption()
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

        public static void PrintRequestForCargoCapacity()
        {
            StringBuilder cargoCapacityMessage = new StringBuilder();

            cargoCapacityMessage.Append("Please enter the truck cargo capcity: ");
            Console.WriteLine(cargoCapacityMessage);
        }

        public string GetVehicleModelName()
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

            return vehicleModelName.ToString();
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

        public static void PrintRequestForVehicleModelName()
        {
            StringBuilder modelNameMessage = new StringBuilder();

            modelNameMessage.Append("Please enter the vehicle model name: ");
            Console.WriteLine(modelNameMessage);
        }

        public string GetWheelManufacturerName()
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

            return wheelManufacturerName.ToString();
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

        public static void PrintRequestForWheelManufacturerName()
        {
            StringBuilder wheelManufacturerNameMessage = new StringBuilder();

            wheelManufacturerNameMessage.Append("Please enter the wheel manufacturer name: ");
            Console.WriteLine(wheelManufacturerNameMessage);
        }

        public FuelEnergy.eFuelType GetFuelType()
        {
            int fuleType;
            bool inputIsValid;
            FuelEnergy.eFuelType fuleTypeEnum;

            PrintFuleTypeMessage();
            inputIsValid = int.TryParse(Console.ReadLine(), out fuleType);
            while(!inputIsValid || !FuleTypeValidation(fuleType))
            {
                PrintInvalidInputMessage();
                PrintFuleTypeMessage();
                inputIsValid = int.TryParse(Console.ReadLine(), out fuleType);
            }

            fuleTypeEnum = FuleTypeConvertToEnum(fuleType);
            return fuleTypeEnum;
        }

        public static void PrintFuleTypeMessage()
        {
            StringBuilder fuleTypeMessage = new StringBuilder();

            fuleTypeMessage.AppendLine("Please enter the fule type of your vehicle");
            fuleTypeMessage.AppendLine("1 - Soler");
            fuleTypeMessage.AppendLine("2 - Octan95");
            fuleTypeMessage.AppendLine("3 - Octan96");
            fuleTypeMessage.Append("4 - Octan98");
            Console.WriteLine(fuleTypeMessage);
        }

        public bool FuleTypeValidation(int i_FuleTyoe)
        {
            bool isFuleTypeValid;

            if (i_FuleTyoe >= 1 && i_FuleTyoe <= 4)
            {
                isFuleTypeValid = true;
            }

            else
            {
                isFuleTypeValid = false;
            }

            return isFuleTypeValid;
        }

        public FuelEnergy.eFuelType FuleTypeConvertToEnum(int i_FuleType)
        {
            FuelEnergy.eFuelType fuleTypeEnum;

            switch(i_FuleType)
            {
                case 1:
                    fuleTypeEnum = FuelEnergy.eFuelType.Soler;
                    break;
                case 2:
                    fuleTypeEnum = FuelEnergy.eFuelType.Octan95;
                    break;
                case 3:
                    fuleTypeEnum = FuelEnergy.eFuelType.Octan96;
                    break;
                case 4:
                default:
                    fuleTypeEnum = FuelEnergy.eFuelType.Octan98;
                    break;
            }

            return fuleTypeEnum;              
        }

        public int GetTimeToChargeInMinutes()
        {
            int timeToChargeInMinutes;
            bool inputIsValid;

            PrintRequestForTimeToCharge();
            inputIsValid = int.TryParse(Console.ReadLine(), out timeToChargeInMinutes);
            while(!inputIsValid)
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
            float fuleAmount;
            bool isInputValid;

            PrintRequestForFuleAmount();
            isInputValid = float.TryParse(Console.ReadLine(), out fuleAmount);
            while (!isInputValid) 
            {
                PrintInvalidInputMessage();
                PrintRequestForFuleAmount();
                isInputValid = float.TryParse(Console.ReadLine(), out fuleAmount);
            }

            return fuleAmount;
        }

        public static void PrintRequestForFuleAmount()
        {
            StringBuilder fuleAmountMessage = new StringBuilder();

            fuleAmountMessage.Append("Please enter the fule amount");
            Console.WriteLine(fuleAmountMessage);
        }

        public void PrintAllGarageVehiclesID(List<string> i_GarageVehiclesID)
        {
            StringBuilder vehicleLicenceIDSingleEntityMessage = new StringBuilder();

            foreach(string currLicenceID in i_GarageVehiclesID)
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
            while(!isInputValid || !VehicleStatusValidation(vehicleStatusChoice))
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

        public Garage.eVehicleStatus VehicleStatusConvertToEnum(int i_VehicleStatus)
        {
            Garage.eVehicleStatus vehicleStatusEnum;

            switch (i_VehicleStatus)
            {
                case 1:
                    vehicleStatusEnum = Garage.eVehicleStatus.InRepair;
                    break;
                case 2:
                    vehicleStatusEnum = Garage.eVehicleStatus.Repaired;
                    break;
                case 3:
                default:
                    vehicleStatusEnum = Garage.eVehicleStatus.Paid;
                    break;
            }

            return vehicleStatusEnum;
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

            switch(i_VehicleTreatment)
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
            
            if(printAllVehicleChoice == 1)
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
