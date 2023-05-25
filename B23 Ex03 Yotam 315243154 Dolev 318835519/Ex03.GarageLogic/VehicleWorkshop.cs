using System;
using System.Collections.Generic;

namespace GarageLogic
{
    public class VehicleWorkshop
    {
        private readonly Dictionary<string, VehicleInWorkshop> m_VehiclesInWorkshop;

        public VehicleWorkshop() {
            m_VehiclesInWorkshop = new Dictionary<string, VehicleInWorkshop>();
        }

        public bool CheckIfVehicleExistInWorkshop(string i_licenceNumber) 
        {
            return m_VehiclesInWorkshop.ContainsKey(i_licenceNumber);
        }

        public void AddNewVehicleToWorkshop(string i_licenceNumber, eVehicleKind i_VehicleKind)
        {
            if (CheckIfVehicleExistInWorkshop(i_licenceNumber)) 
            {
                throw new Exception("Vehicle " + i_licenceNumber + " Alredy Exists");
            }
            VehicleInWorkshop thisVehicle = new VehicleInWorkshop();
            thisVehicle.SetVehicleData(i_licenceNumber, i_VehicleKind);
            m_VehiclesInWorkshop.Add(i_licenceNumber, thisVehicle);
        }
        public Dictionary<string, Type> GetRequiredArguments(string i_licenceNumber) 
        {
            if (!m_VehiclesInWorkshop.TryGetValue(i_licenceNumber, out VehicleInWorkshop thisVehicle)) {
                throw new Exception("Vehicle " + i_licenceNumber + " Doesn't Exist");
            }
            return thisVehicle.GetRequiredArguments();
        }
        public void SetRequiredArguments(string i_licenceNumber, Dictionary<string, object> i_RequiredArguments)
        {
            if (!m_VehiclesInWorkshop.TryGetValue(i_licenceNumber, out VehicleInWorkshop thisVehicle))
            {
                throw new Exception("Vehicle " + i_licenceNumber + " Doesn't Exists");
            }
            thisVehicle.SetRequiredArguments(i_RequiredArguments);
        }
        public List<string> GetVehiclesLicencePlatesInWorkshop(eVehicleState i_RequestedState = eVehicleState.NaN) 
        { 
            List<string> vehiclesLicencePlates = new List<string>(m_VehiclesInWorkshop.Keys);
            List<string> FilteredVehiclesLicencePlates = new List<string>(m_VehiclesInWorkshop.Keys);
            if (i_RequestedState != eVehicleState.NaN) 
            {
                foreach (string vehicleLicencePlate in vehiclesLicencePlates) 
                {
                    if (m_VehiclesInWorkshop[vehicleLicencePlate].VehicleState != i_RequestedState) 
                    {
                        FilteredVehiclesLicencePlates.Remove(vehicleLicencePlate);
                    }
                }
            }
            return FilteredVehiclesLicencePlates;
        }
        public void ChangeVehicleState(string i_licenceNumber, eVehicleState i_NewVehicleState) {
            bool doesLicenceExsist = m_VehiclesInWorkshop.TryGetValue(i_licenceNumber, out VehicleInWorkshop requestedVehicle);
            if (!doesLicenceExsist) 
            {
                throw new ArgumentException("The licence number " + i_licenceNumber + " Does Not Exsist");
            }
            requestedVehicle.VehicleState = i_NewVehicleState;
        }
        public void FillAirInWheelToMax(string i_licenceNumber) {
            bool doesLicenceExsist = m_VehiclesInWorkshop.TryGetValue(i_licenceNumber, out VehicleInWorkshop requestedVehicle);
            if (!doesLicenceExsist)
            {
                throw new ArgumentException("The licence number " + i_licenceNumber + " Does Not Exsist");
            }
            requestedVehicle.FillAirInWheelToMax();
        }
        public void FuelUpVehcle(string i_licenceNumber, eFuelKind i_FuelKind, float i_FuelToAdd) {
            bool doesLicenceExsist = m_VehiclesInWorkshop.TryGetValue(i_licenceNumber, out VehicleInWorkshop requestedVehicle);
            if (!doesLicenceExsist)
            {
                throw new ArgumentException("The licence Number " + i_licenceNumber + " Does Not Exsist");
            }
            bool isFuelBasedVeicle = requestedVehicle.TryFuelUpVehicle(i_FuelKind,i_FuelToAdd);
            if (!isFuelBasedVeicle) 
            {
                throw new FormatException("The vehcle with the licence number " + i_licenceNumber + " is not fuel based");
            }
        }
        public void ChargeUpVehcle(string i_licenceNumber, float i_FuelToAdd)
        {
            bool doesLicenceExsist = m_VehiclesInWorkshop.TryGetValue(i_licenceNumber, out VehicleInWorkshop requestedVehicle);
            if (!doesLicenceExsist)
            {
                throw new ArgumentException("The licence Number " + i_licenceNumber + " Does Not Exsist");
            }
            bool isElectricVeicle = requestedVehicle.TryChargeUpVehicle( i_FuelToAdd);
            if (!isElectricVeicle)
            {
                throw new FormatException("The vehcle with the licence number " + i_licenceNumber + " is not Electric");
            }
        }
        public Dictionary<string, object> GetVehcleData(string i_licenceNumber)
        {
            bool doesLicenceExsist = m_VehiclesInWorkshop.TryGetValue(i_licenceNumber, out VehicleInWorkshop requestedVehicle);
            if (!doesLicenceExsist)
            {
                throw new ArgumentException("The licence Number " + i_licenceNumber + " Does Not Exsist");
            }
            return requestedVehicle.GetVehcleData();
        }
        public bool RemoveVehcleFromWorkshop(string i_licenceNumber) {
            return m_VehiclesInWorkshop.Remove(i_licenceNumber);     

        }
    }
}
