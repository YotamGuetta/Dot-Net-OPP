using System;
using System.Collections.Generic;

namespace GarageLogic
{
    public enum eVehicleKind
    {
        NormalCar,
        ElectricCar,
        NormalMotorcycle,
        ElectriccMotorcycle,
        NormalTruck
    }
    public enum eVehicleState
    {
        NaN,
        Fixxing,
        Fixxed,
        Paid
    }
    class VehicleInWorkshop
    {
        private static readonly string sr_OwnerNameTag = "Owner Name";
        private static readonly string sr_PhoneNumberTag = "Phone Number";
        private Vehicle m_Vehicle;
        private string m_OwnerName;
        private string m_PhoneNumber;
        private eVehicleState m_VehicleState;

        public string OwnerName
        {
            get { return OwnerName; }
            set { m_OwnerName = value; }
        }
        public string PhoneNumber
        {
            get { return PhoneNumber; }
            set { m_PhoneNumber = value; }
        }
        public eVehicleState VehicleState
        {
            get { return m_VehicleState; }
            set { m_VehicleState = value; }
        }
        public void SetVehicleData(string i_LicensePlate, eVehicleKind i_VehicleKind)
        {
            switch (i_VehicleKind) {
                case eVehicleKind.NormalMotorcycle:
                    m_Vehicle = new Motorcycle(false, 2, 31, 6.4f, eFuelKind.Octan98);
                    break;
                case eVehicleKind.ElectriccMotorcycle:
                    m_Vehicle = new Motorcycle(true, 2, 31, 2.6f);
                    break;
                case eVehicleKind.NormalCar:
                    m_Vehicle = new Car(false, 5, 33, 46f, eFuelKind.Octan95);
                    break;
                case eVehicleKind.ElectricCar:
                    m_Vehicle = new Car(true, 5, 33, 5.2f);
                    break;
                case eVehicleKind.NormalTruck:
                    m_Vehicle = new Truck(false, 14, 26, 135f, eFuelKind.Soler);
                    break;
            }
            m_Vehicle.LicensePlate = i_LicensePlate;
            m_VehicleState = eVehicleState.Fixxing;
        }
        public Dictionary<string, Type>  GetRequiredArguments() {
            Dictionary<string, Type> requiredArguments = m_Vehicle.GetRequiredArguments();
            requiredArguments.Add(sr_OwnerNameTag, sr_OwnerNameTag.GetType());
            requiredArguments.Add(sr_PhoneNumberTag, sr_PhoneNumberTag.GetType());
            return requiredArguments;
        }
        public void SetRequiredArguments(Dictionary<string, object> i_RequiredArguments) {
            m_Vehicle.SetRequiredArguments(i_RequiredArguments);
            m_OwnerName = ArgumentsSetter.GetArgument<string>(i_RequiredArguments, sr_OwnerNameTag);
            m_PhoneNumber = ArgumentsSetter.GetArgument<string>(i_RequiredArguments, sr_PhoneNumberTag);
        }
        public void FillAirInWheelToMax() {
            m_Vehicle.FillAirInWheelsToMax();
        }
        public bool TryFuelUpVehicle(eFuelKind i_FuelKind, float i_FuelToAdd) {
            return  m_Vehicle.TryFuelUpCar(i_FuelKind, i_FuelToAdd);
        }
        public bool TryChargeUpVehicle( float i_FuelToAdd)
        {
            return m_Vehicle.TryChargeCar( i_FuelToAdd);
        }
        public Dictionary<string, object> GetVehcleData() 
        {
            Dictionary<string, object> vehicleInWorkshopData = m_Vehicle.GetVehcleData();
            vehicleInWorkshopData.Add(sr_OwnerNameTag, m_OwnerName);
            vehicleInWorkshopData.Add(sr_PhoneNumberTag, m_PhoneNumber);
            return vehicleInWorkshopData;
        }
    }
}
