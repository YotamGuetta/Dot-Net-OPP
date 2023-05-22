using System;
using System.Collections.Generic;
using ValueOutOfRangeException;
using VehicleManager;
using Vehicle;
using Factory;

namespace Ex03_UI
{
    public class UI
    {
        private VehicleManager m_vehicleManager;

        public UI()
        {
            m_vehicleManager = new VehicleManager();
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
                    Console.WriteLine("Press any key to continue");
                    Console.ReadKey();
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

            Vehicle isVehicleExist = m_vehicleManager.GetVehicleByLicensePlate(licenseNumber);

            if (isVehicleExist == null)
            {
                isVehicleExist.Status = "Under repair";
                Console.WriteLine("The vehicle already exists in the system, its status has been updated to under repair");
            }

            else
            {
                Console.Write("Please enter the vehicle type");
                string vehicleTypeString = Console.ReadLine();

                Type vehicleType = Type.GetType(vehicleTypeString);
                if (vehicleType == null)
                {
                    throw new ArgumentException("Invalid vehicle type");
                }

                else
                {
                    Vehicle newVehicle = (Vehicle)Factory.createNewVehicle(vehicleType);

                    foreach (var property in newVehicle.GetType().GetProperties())
                    {
                        Console.Write("Please enter the {0} - ", property.Name);
                        string value = Console.ReadLine();

                        try
                        {
                            property.SetValue(newVehicle, Convert.ChangeType(value, property.PropertyType));
                        }

                        catch (ArgumentException i_ArgumentException)
                        {
                            Console.WriteLine(i_ArgumentException.Message);
                        }

                        catch (ValueOutOfRangeException i_ValueOutOfRangeException)
                        {
                            Console.WriteLine(i_ValueOutOfRangeException.Message);
                        }
                    }
                }
            }
        } 

        private void displayAllVehicles()
        {
            List<Vehicle> vehicles = m_vehicleManager.GetAllVehicles();

            Console.Clear();
            Console.Clear();
            Console.WriteLine("The list of vehicles in the garage - ");
            Console.WriteLine("----------------------------------");

            if (vehicles.Count == 0)
            {
                Console.WriteLine("There are no vehicles");
            }

            else
            {
                Console.WriteLine("Displaying vehicles according to their condition (please choose 1-3) - ");
                Console.WriteLine("1) Under repair");
                Console.WriteLine("2) Not in repair");
                Console.WriteLine("3) Displaying all vehicles");

                string choice = Console.ReadLine();

                List<Vehicle> filteredVehicles;
                switch (choice)
                {
                    case "1":
                        filteredVehicles = vehicles.FindAll(v => v.Status == "Under repair");
                        break;
                    case "2":
                        filteredVehicles = vehicles.FindAll(v => v.Status != "Under repair");
                        break;
                    case "3":
                        filteredVehicles = vehicles;
                        break;
                    default:
                        throw new FormatException("Invalid menu choice input");
                }

                Console.WriteLine("The list - ");
                foreach (Vehicle vehicle in filteredVehicles)
                {
                    Console.WriteLine("License Number- {0}", vehicle.LicenseNumber);
                }
            }
        }

        private void changeVehicleStatus()
        {
            Console.WriteLine("Enter the license plate number of the vehicle - ");
            string licensePlate = Console.ReadLine();

            Console.WriteLine("Enter the new status - ");
            Console.WriteLine("1. Under repair");
            Console.WriteLine("2. Repaired");
            Console.WriteLine("3. Paid");

            if (!int.TryParse(Console.ReadLine(), out int statusOption))
            {
                throw new FormatException("Invalid menu choice input");
            }

            try
            {
                m_vehicleManager.ChangeVehicleStatus(licensePlate, (VehicleStatus)statusOption); //if there is enum for the status, if not change
            }

            catch (ArgumentException i_ArgumentException)
            {
                Console.WriteLine(i_ArgumentException.Message);
            }
        }

        private void inflateTirePressure()
        {
            Console.WriteLine("Enter the license plate number of the vehicle - ");
            string licensePlate = Console.ReadLine();

            m_vehicleManager.InflateTires(licensePlate);
        }

        private void refuelVehicle()
        {
            Console.WriteLine("Enter the license plate number of the vehicle - ");
            string licensePlate = Console.ReadLine();

            Console.WriteLine("Enter the amount of fuel to refuel (in liters) - ");
            if (!float.TryParse(Console.ReadLine(), out float fuelAmount))
            {
                throw new FormatException("Invalid fuel amount input");
            }

            try
            {
                m_vehicleManager.RefuelVehicle(licensePlate, fuelAmount);
            }

            catch (ArgumentException i_ArgumentException)
            {
                Console.WriteLine(i_ArgumentException.Message);
            }

            catch (ValueOutOfRangeException i_ValueOutOfRangeException)
            {
                Console.WriteLine(i_ValueOutOfRangeException.Message);
            }
        }

        private void chargeElectricVehicle()
        {
            Console.WriteLine("Enter the license plate number of the vehicle -");
            string licensePlate = Console.ReadLine();

            Console.WriteLine("Enter the duration of charging (in minutes) - ");
            if (!int.TryParse(Console.ReadLine(), out int chargingTime))
            {
                throw new FormatException("Invalid fuel amount input");
            }

            try
            {
                m_vehicleManager.ChargeElectricVehicle(licensePlate, chargingTime);
            }

            catch (ArgumentException i_ArgumentException)
            {
                Console.WriteLine(i_ArgumentException.Message);
            }

            catch (ValueOutOfRangeException i_ValueOutOfRangeException)
            {
                Console.WriteLine(i_ValueOutOfRangeException.Message);
            }
        }

        private void displayVehicleDetails()
        {
            Console.WriteLine("Enter the license plate number of the vehicle - ");
            string licensePlate = Console.ReadLine();

            Vehicle vehicleToPrint = m_vehicleManager.GetVehicleByLicensePlate(licensePlate);

            foreach (var property in vehicleToPrint.GetType().GetProperties())
            {
                string propertyName = property.Name;

                var propertyValue = property.GetValue(vehicleToPrint);

                Console.WriteLine("{0} - {1}", propertyName, propertyValue);
            }
        }
    }
}
