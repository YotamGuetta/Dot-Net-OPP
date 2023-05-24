using System;
using System.Collections.Generic;
using System.Reflection;
using CustomException;
using GarageLogic;
namespace Ex03_UI
{
    public class UI
    {
        private VehicleWorkshop m_vehicleManager;

        public UI()
        {
            m_vehicleManager = new VehicleWorkshop();
        }

        public void Menu()
        {
            bool systemIsRunning = true;

            Console.WriteLine("~~ Welcome to the garage! ~~");
            while (systemIsRunning)
            {
                Console.Clear();
                Console.WriteLine("Please choose one option (1-8) - ");
                Console.WriteLine("1) Add new vehicle");
                Console.WriteLine("2) Display the list of all vehicles");
                Console.WriteLine("3) Change vehicle mode");
                Console.WriteLine("4) Inflate air volume in wheels");
                Console.WriteLine("5) Refuel vehicle");
                Console.WriteLine("6) Charge electric vehicle");
                Console.WriteLine("7) Display all of the vehicle data");
                Console.WriteLine("8) Exit");

                string chosenFunction = Console.ReadLine();

                try
                {
                    systemIsRunning = activatedChosenFunction(chosenFunction);
                }

                catch (FormatException i_FormatException)
                {
                    Console.WriteLine(i_FormatException.Message);
                }

                catch (ArgumentException i_ArgumentException)
                {
                    Console.WriteLine(i_ArgumentException.Message);
                }

                catch (ValueOutOfRangeException i_ValueOutOfRangeException)
                {
                    Console.WriteLine(i_ValueOutOfRangeException.Message);
                }

                finally
                {
                    if (chosenFunction != "8")
                    {
                        Console.WriteLine("Press any key to continue");
                        Console.ReadKey();
                    }
                }
            }
        }
       
        private bool activatedChosenFunction(string i_chosenFunction)
        {
            bool systemIsRunning = true;

            switch (i_chosenFunction)
            {
                case "1":
                    addNewVehicle();
                    break;
                case "2":
                    displayAllVehicles();
                    break;
                case "3":
                    changeVehicleStatus();
                    break;
                case "4":
                    inflateTirePressure();
                    break;
                case "5":
                    refuelVehicle();
                    break;
                case "6":
                    chargeElectricVehicle();
                    break;
                case "7":
                    displayVehicleDetails();
                    break;
                case "8":
                    systemIsRunning = false;
                    break;
                default:
                    throw new FormatException("Invalid menu choice.");
            }
            return systemIsRunning;
        }

        private void addNewVehicle()
        {
            Console.Clear();
            Console.Write("Please enter the license number of the vehicle - ");
            string licenseNumber = Console.ReadLine();

            bool DoesVehicleExist = m_vehicleManager.CheckIfVehicleExistInWorkshop(licenseNumber);

            if (DoesVehicleExist)
            {
                Console.WriteLine("The vehicle already exists in the system, its status has been updated to under repair");
            }
            else
            {
                Console.Write("Please enter the vehicle type - ");
                Console.WriteLine();
                Array allVehicleTypes = Enum.GetValues(typeof(eVehicleKind));
                foreach (int i in allVehicleTypes)
                {
                    eVehicleKind vehicleTypeValue = (eVehicleKind)i;
                    Console.WriteLine(string.Format("{0}) {1} ", i, vehicleTypeValue.ToString()));
                }
                string vehicleTypeString = Console.ReadLine();

                bool isValidVehiclechoise = int.TryParse(vehicleTypeString, out int vehicleTypeNumber);
                if (!isValidVehiclechoise || allVehicleTypes.Length <= vehicleTypeNumber || vehicleTypeNumber < 0)
                {
                    throw new ArgumentException("Invalid choice type");
                }
                else
                {
                    eVehicleKind vehicleKind = (eVehicleKind)vehicleTypeNumber;
                    m_vehicleManager.AddNewVehicleToWorkshop(licenseNumber, vehicleKind);
                    Dictionary<string, object> givenArgumentsValues = new Dictionary<string, object>();
                    Dictionary<string, Type> requiredArguments =  m_vehicleManager.GetRequiredArguments(licenseNumber);
                    List<string> requiredArgumentsNames = new List<string>(requiredArguments.Keys);

                    foreach (string argumentsName in requiredArgumentsNames)
                    {
                        Type objectType = requiredArguments[argumentsName];
                        Console.Write("Please enter {0}, which has type {1} - ", argumentsName, objectType.Name);
                        string inputValue = Console.ReadLine();
                        bool isEnum;
                        isEnum = objectType.IsEnum;
                        if (objectType.Equals(typeof(string)))
                        {
                            givenArgumentsValues.Add(argumentsName, inputValue);
                        }
                        else
                        {
                            if (isEnum)
                            {
                                objectType = typeof(int);
                            }
                            MethodInfo parseMethod = objectType.GetMethod("Parse", new[] { typeof(string) });
                            if (parseMethod != null)
                            {
                                try
                                {
                                    object parsedValue = parseMethod.Invoke(null, new object[] { inputValue });

                                    if (isEnum)
                                    {
                                        int enumValue = (int)parsedValue;
                                        parsedValue = Enum.ToObject(objectType, enumValue);

                                    }
                                    givenArgumentsValues.Add(argumentsName, parsedValue);
                                }
                                catch (Exception i_ex)
                                {
                                    throw new ArgumentException("Invalid input argument type");
                                }
                            }
                        }


                    } 

                }
            }
        }

        private void displayAllVehicles()
        {

            Console.Clear();
            Console.WriteLine("The list of vehicles in the garage - ");



            Console.WriteLine("Displaying vehicles according to their condition (please choose 1-4) - ");
            Console.WriteLine("1) Under repair");
            Console.WriteLine("2) Repaired");
            Console.WriteLine("3) Paid");
            Console.WriteLine("4) Displaying all vehicles");

            string userChoice = Console.ReadLine();
            eVehicleState vehicleStateDisplay;
            switch (userChoice)
            {
                case "1":
                    vehicleStateDisplay = eVehicleState.Fixxing;
                    break;
                case "2":
                    vehicleStateDisplay = eVehicleState.Fixxed;
                    break;
                case "3":
                    vehicleStateDisplay = eVehicleState.Paid;
                    break;
                case "4":
                    vehicleStateDisplay = eVehicleState.NaN;
                    break;
                default:
                    throw new FormatException("Invalid menu choice input");
            }

            List<string> vehicleFillteredByState;
            if (vehicleStateDisplay.Equals(eVehicleState.NaN))
            {
                vehicleFillteredByState = m_vehicleManager.GetVehiclesLicencePlatesInWorkshop();
            }

            else
            {
                vehicleFillteredByState = m_vehicleManager.GetVehiclesLicencePlatesInWorkshop(vehicleStateDisplay);
            }

            Console.WriteLine("The license numbers list - ");
            foreach (string vehicle in vehicleFillteredByState)
            {
                Console.WriteLine("License Number- {0}", vehicle);
            }
        }

        private void changeVehicleStatus()
        {
            Console.WriteLine("Enter the license plate number of the vehicle - ");
            string licensePlate = Console.ReadLine();

            bool DoesVehicleExist = m_vehicleManager.CheckIfVehicleExistInWorkshop(licensePlate);

            if (!DoesVehicleExist)
            {
                Console.WriteLine("The vehicle doesnt exits in the garage.");
            }

            else
            {
                Console.WriteLine("Enter the new status (1-3) - ");
                Console.WriteLine("1. Under repair");
                Console.WriteLine("2. Repaired");
                Console.WriteLine("3. Paid");

                if (!int.TryParse(Console.ReadLine(), out int statusOption))
                {
                    throw new FormatException("Invalid menu choice input");
                }

                m_vehicleManager.ChangeVehicleState(licensePlate, (eVehicleState)statusOption);
            }
        }

        private void inflateTirePressure()
        {
            Console.WriteLine("Enter the license plate number of the vehicle - ");
            string licensePlate = Console.ReadLine();

            bool DoesVehicleExist = m_vehicleManager.CheckIfVehicleExistInWorkshop(licensePlate);

            if (!DoesVehicleExist)
            {
                Console.WriteLine("The vehicle doesnt exits in the garage.");
            }

            else
            {
                m_vehicleManager.FillAirInWheelToMax(licensePlate);
            }
        }

        private void refuelVehicle()
        {
            Console.WriteLine("Enter the license plate number of the vehicle - ");
            string licensePlate = Console.ReadLine();

            bool DoesVehicleExist = m_vehicleManager.CheckIfVehicleExistInWorkshop(licensePlate);

            if (!DoesVehicleExist)
            {
                Console.WriteLine("The vehicle doesnt exits in the garage.");
            }

            else
            {
                Console.WriteLine("Enter the Fuel Kind - ");
                if (!eFuelKind.TryParse(Console.ReadLine(), out eFuelKind fuelKind))
                {
                    throw new FormatException("Invalid fuel amount input");
                }
                Console.WriteLine("Enter the amount of fuel to refuel (in liters) - ");
                if (!float.TryParse(Console.ReadLine(), out float fuelAmount))
                {
                    throw new FormatException("Invalid fuel amount input");
                }

                try
                {
                    m_vehicleManager.FuelUpVehcle(licensePlate, fuelKind, fuelAmount);
                }

                catch (ValueOutOfRangeException i_ValueOutOfRangeException)
                {
                    Console.WriteLine(i_ValueOutOfRangeException.Message);
                }
            }
        }

        private void chargeElectricVehicle()
        {
            Console.WriteLine("Enter the license plate number of the vehicle -");
            string licensePlate = Console.ReadLine();

               bool DoesVehicleExist = m_vehicleManager.CheckIfVehicleExistInWorkshop(licensePlate);

            if (!DoesVehicleExist)
            {
                Console.WriteLine("The vehicle doesnt exits in the garage.");
            }

            else
            {
                Console.WriteLine("Enter the duration of charging (in minutes) - ");
                if (!int.TryParse(Console.ReadLine(), out int chargingTime))
                {
                    throw new FormatException("Invalid fuel amount input");
                }

                try
                {
                    m_vehicleManager.ChargeUpVehcle(licensePlate, chargingTime);
                }

                catch (ValueOutOfRangeException i_ValueOutOfRangeException)
                {
                    Console.WriteLine(i_ValueOutOfRangeException.Message);
                }
            }
        }

        private void displayVehicleDetails()
        {
            Console.WriteLine("Enter the license plate number of the vehicle - ");
            string licensePlate = Console.ReadLine();

            bool DoesVehicleExist = m_vehicleManager.CheckIfVehicleExistInWorkshop(licensePlate);

            if (!DoesVehicleExist)
            {
                Console.WriteLine("The vehicle doesnt exits in the garage.");
            }

            else
            {
                Dictionary<string, object> vehicleData = m_vehicleManager.GetVehcleData(licensePlate);
                List<string> vehicleDataNames = new List<string>(vehicleData.Keys);

                Console.WriteLine("The vehicle details - ");
                foreach (string name in vehicleDataNames)
                {
                    Console.WriteLine("{0} - {1} ", name, vehicleData[name].ToString());
                }
            }
        }
    }
}
