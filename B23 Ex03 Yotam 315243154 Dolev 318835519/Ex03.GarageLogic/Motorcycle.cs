using System;
using System.Collections.Generic;

namespace GarageLogic
{
    public enum eLicenceTypes
    {
        A1,
        A2,
        AA,
        B1
    }
    class Motorcycle : Vehicle
    {
        private static readonly string sr_LicenceTypeTag = "Licence Type";
        private static readonly string sr_EngineCapacityTag = "Motorcycle Engine Capacity";
        private eLicenceTypes m_LicenceType;
        private int m_EngineCapacity;
        public eLicenceTypes LicenceType
        {
            get { return m_LicenceType; }
            set { m_LicenceType = value; }
        }
        public int EngineCapacity
        {
            get { return m_EngineCapacity; }
            set { m_EngineCapacity = value; }
        }
        public Motorcycle(bool i_Electric, int i_NumberOfWeels, float i_MaxAirPressure, float i_MaxCapacity, eFuelKind i_FuelKind = eFuelKind.NaN)
:           base(i_Electric, i_NumberOfWeels, i_MaxAirPressure, i_MaxCapacity, i_FuelKind) { }

        public override Dictionary<string, Type> GetRequiredArguments()
        {
            Dictionary<string, Type> neededArguments = base.GetRequiredArguments();
            neededArguments.Add(sr_LicenceTypeTag, m_LicenceType.GetType());
            neededArguments.Add(sr_EngineCapacityTag, m_EngineCapacity.GetType());

            return neededArguments;
        }
        public override void SetRequiredArguments(Dictionary<string, object> i_RequiredArguments)
        {
            m_LicenceType = ArgumentsSetter.GetArgument<eLicenceTypes> (i_RequiredArguments, sr_LicenceTypeTag);
            m_EngineCapacity = ArgumentsSetter.GetArgument<int>(i_RequiredArguments, sr_EngineCapacityTag);
            base.SetRequiredArguments(i_RequiredArguments);
        }
        public override Dictionary<string, object> GetVehcleData()
        {
            Dictionary<string, object> motorcycleData = base.GetVehcleData();
            motorcycleData.Add(sr_EngineCapacityTag, m_EngineCapacity);
            motorcycleData.Add(sr_LicenceTypeTag, m_LicenceType);
            return motorcycleData;
        }
    }
}
