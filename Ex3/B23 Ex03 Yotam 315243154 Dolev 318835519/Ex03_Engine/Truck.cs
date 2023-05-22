using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GarageLogic
{
    class Truck : Vehicle
    {
        private static readonly string sr_ContainsDangerousChemicalsTag = "Contains Dangerous Chemicals";
        private static readonly string sr_CargoCapacityTag = "Cargo Capacity";

        bool m_ContainsDangerousChemicals;
        float m_CargoCapacity;

        public bool ContainsDangerousChemicals
        {
            get { return m_ContainsDangerousChemicals; }
            set { m_ContainsDangerousChemicals = value; }
        }
        public float CargoCapacity
        {
            get { return m_CargoCapacity; }
            set { m_CargoCapacity = value; }
        }

        public Truck(bool i_Electric, int i_NumberOfWeels, float i_MaxAirPressure, float i_MaxCapacity, eFuelKind i_FuelKind = eFuelKind.NaN)
    : base(i_Electric, i_NumberOfWeels, i_MaxAirPressure, i_MaxCapacity, i_FuelKind) { }
        public override Dictionary<string, Type> GetRequiredArguments()
        {
            Dictionary<string, Type> neededArguments = base.GetRequiredArguments();
            neededArguments.Add(sr_ContainsDangerousChemicalsTag, typeof(bool));
            neededArguments.Add(sr_CargoCapacityTag, typeof(float));

            return neededArguments;
        }
        public override void SetRequiredArguments(Dictionary<string, object> i_RequiredArguments)
        {
            m_ContainsDangerousChemicals = ArgumentsSetter.GetArgument<bool>(i_RequiredArguments, sr_ContainsDangerousChemicalsTag);
            m_CargoCapacity = ArgumentsSetter.GetArgument<float>(i_RequiredArguments, sr_CargoCapacityTag);
            base.SetRequiredArguments(i_RequiredArguments);
        }
    }
}
