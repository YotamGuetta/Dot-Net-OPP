using System;
using System.Collections.Generic;
using System.Linq;

namespace GarageLogic
{
    class Vehicle
    {
        private static readonly string sr_ModuleNameTag = "Module Name";
        private static readonly string sr_LicensePlateTag = "License Plate";
        private static readonly string sr_EnergyPercentageLeftInSourceTag = "Energy Percentage Left In Source";
        private string m_ModuleName;
        private string m_LicensePlate;
        private float m_EnergyPercentageLeftInSource;
        private readonly List<Wheel> r_Wheels;
        private EnergySource m_EnergySource;

        public string LicensePlate
        {
            get { return m_LicensePlate; }
            set { m_LicensePlate = value; }
        }
        public string ModuleName
        {
            get { return m_ModuleName; }
            set { m_ModuleName = value; }
        }
        public Vehicle(bool i_Electric, int i_NumberOfWeels, float i_MaxAirPressure, float i_MaxCapacity, eFuelKind i_FuelKind = eFuelKind.NaN)
        {
            r_Wheels = new List<Wheel>();
            for (int i = 0; i < i_NumberOfWeels; i++)
            {
                r_Wheels.Add(new Wheel(i_MaxAirPressure));
            }
            if (i_Electric)
            {
                m_EnergySource = new Electric(i_MaxCapacity);
            }
            else
            {
                m_EnergySource = new Fuel(i_MaxCapacity, i_FuelKind);
            }
        }
        
        public virtual Dictionary<string, Type> GetRequiredArguments()
        {
            Dictionary<string, Type> wheelsNeededArguments = r_Wheels[0].GetRequiredArguments();
            Dictionary<string, Type> energySourceNeededArguments = m_EnergySource.GetRequiredArguments();
            Dictionary<string, Type> combinedDictionary = wheelsNeededArguments
                .Concat(energySourceNeededArguments)
                .ToDictionary(pair => pair.Key, pair => pair.Value);
            combinedDictionary.Add(sr_ModuleNameTag, typeof(string));

            return combinedDictionary;
        }
        public virtual void SetRequiredArguments(Dictionary<string, object> i_RequiredArguments)
        {
            m_ModuleName = ArgumentsSetter.GetArgument<string>(i_RequiredArguments, sr_ModuleNameTag);
            foreach (Wheel wheel in r_Wheels) {
                wheel.SetRequiredArguments(i_RequiredArguments);
            }
            m_EnergySource.AddEnergy(i_RequiredArguments);
            m_EnergyPercentageLeftInSource = m_EnergySource.GetEnergyPercentage();
        }
        public void FillAirInWheelsToMax() {
            foreach(Wheel wheel in r_Wheels) {
                wheel.AirPressure = wheel.MaximumAirPressure;
            }
        }
        public bool TryFuelUpCar(eFuelKind i_FuelKind, float i_FuelToAdd) {
            bool isFuelBasedVeicle = true;
            if (m_EnergySource is Fuel carFuel)
            {
                if (carFuel.FuelKind.Equals(i_FuelKind))
                {
                    carFuel.AddFuel(i_FuelToAdd);
                }
                else
                {
                    throw new ArgumentException(string.Format("Fuel kind {0} doesn't match the fuel kind which is {1}", i_FuelKind, carFuel.FuelKind));
                }
            }
            else 
            {
                isFuelBasedVeicle = false;
            }
            return isFuelBasedVeicle;
        }
        public bool TryChargeCar( float i_MinutesToAdd)
        {
            bool isElectricVeicle = true;
            float HoursToAdd = i_MinutesToAdd / 60;
            if (m_EnergySource is Electric carBattery)
            {
                carBattery.Recharge(HoursToAdd);
            }
            else
            {
                isElectricVeicle = false;
            }
            return isElectricVeicle;
        }
        public virtual Dictionary<string, object> GetVehcleData() {
            Dictionary<string, object> wheelsData = r_Wheels[0].GetWheelData();
            Dictionary<string, object> energySourceData = m_EnergySource.GetEnergySourceData();
            Dictionary<string, object> combineData = wheelsData
                .Concat(energySourceData)
                .ToDictionary(pair => pair.Key, pair => pair.Value);
            combineData.Add(sr_ModuleNameTag, typeof(string));

            combineData.Add(sr_LicensePlateTag, m_LicensePlate);
            combineData.Add(sr_EnergyPercentageLeftInSourceTag, string.Format("{0}%", m_EnergyPercentageLeftInSource * 100));

            return combineData;
        }
    }
}
