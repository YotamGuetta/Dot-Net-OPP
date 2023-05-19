using System;
using System.Collections.Generic;
using VehicleManager;
using Vehicle;

namespace Ex03_UI
{
    public class UI
    {
        private VehicleManager m_vehicleManager;

        public UI()
        {
            m_vehicleManager = new VehicleManager();
        }

        public void PrintMenu()
        {
            bool running = true;
            while (running)
            {
                Console.Clear();
                Console.WriteLine("Please choose one option (1-8) - ");
                Console.WriteLine("1) Add new vehicle");
                Console.WriteLine("2) Displaying the list of all vehicles");
                Console.WriteLine("3) Change vehicle mode");
                Console.WriteLine("4) Air volume in wheels");
                Console.WriteLine("5) Refuel car");
                Console.WriteLine("6) Charge electric vehicle");
                Console.WriteLine("7) Displaying complete vehicle data");
                Console.WriteLine("8) Exit");

                string choice = Console.ReadLine();

                
                switch (choice)
                {
                    case "1":
                        AddNewVehicle();
                        break;
                    case "2":
                        DisplayAllVehicles();
                        break;
                    case "3":
                        ChangeVehicleStatus();
                        break;
                    case "4":
                        InflateTirePressure();
                        break;
                    case "5":
                        RefuelVehicle();
                        break;
                    case "6":
                        ChargeElectricVehicle();
                        break;
                    case "7":
                        DisplayVehicleDetails();
                        break;
                    case "8":
                        running = false;
                        break;
                    default:
                        throw new InvalidInputException("Invalid menu choice.");
                }

                Console.WriteLine("Press any key to continue");
                Console.ReadKey();
            }
        }

        private void AddNewVehicle() //not good need to think about solution
        {
            Console.Clear();
            Console.Write("Please enter the license number of the vehicle - ");
            string licenseNumber = Console.ReadLine();

            if (i_vehicles.Exists(v => v.LicenseNumber == licenseNumber))
            {
                Vehicle existingVehicle = i_vehicles.Find(v => v.LicenseNumber == licenseNumber);
                existingVehicle.Status = "under repair";
                Console.WriteLine("The vehicle already exists in the system, the vehicle status has been updated to under repair");
            }

            else
            {
                Console.Write("Please enter the vehicle type");
                string type = Console.ReadLine();

                try
                {
                    Vehicle newVehicle = new Vehicle(licenseNumber, type);
                    i_vehicles.Add(newVehicle);
                }
                catch (ArgumentException i_ArgumentException)
                {
                    Console.WriteLine(i_ArgumentException.Message);
                }
            }
        } 
        private void DisplayAllVehicles()
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
                        throw new InvalidInputException("Invalid menu choice.");
                }

                Console.WriteLine("The list - ");
                foreach (Vehicle vehicle in filteredVehicles)
                {
                    Console.WriteLine($"License Number- {vehicle.LicenseNumber}");
                }
            }
        }
    }
}
