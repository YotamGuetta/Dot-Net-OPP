using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GarageLogic
{
    public enum eFuelKind
    {
        NaN,
        Soler,
        Octan95,
        Octan96,
        Octan98
    }
    class Fuel : EnergySource
    {
        private static readonly string sr_FuelKindTag = "Fuel Kind";
        private static readonly string sr_CurrentFuelAmountTag = "Current Fuel Amount";
        private eFuelKind m_FuelKind;
        private float m_CurrentFuelAmount;
        public eFuelKind FuelKind
        {
            get { return m_FuelKind; }
            set { m_FuelKind = value; }
        }
        public float CurrentFuelAmount
        {
            get { return m_CurrentFuelAmount; }
            set { m_CurrentFuelAmount = value; }
        }
        public Fuel(float i_MaxFuelCapacity, eFuelKind i_FuelKind) : base(i_MaxFuelCapacity)
        {
            m_CurrentFuelAmount = 0;
            m_FuelKind = i_FuelKind;
        }

        public override void AddEnergy(Dictionary<string, object> i_RequiredArguments)
        {
            AddFuel(ArgumentsSetter.GetArgument<float>(i_RequiredArguments, sr_CurrentFuelAmountTag));
        }

        public void AddFuel(float fuelToAdd)
        {
            if ((m_CurrentFuelAmount + fuelToAdd) > m_MaxCapacity)
            {
                throw new ValueOutOfRangeException(sr_MinCapacity, m_MaxCapacity);
            }

            m_CurrentFuelAmount += fuelToAdd;
        }
        public override Dictionary<string, Type> GetRequiredArguments()
        {
            Dictionary<string, Type> neededArguments = new Dictionary<string, Type>
            {
                { sr_CurrentFuelAmountTag, m_CurrentFuelAmount.GetType() }
            };

            return neededArguments;
        }
        public override float GetEnergyPercentage()
        {
            return m_CurrentFuelAmount / m_MaxCapacity;
        }
        public override Dictionary<string, object> GetEnergySourceData()
        {
            Dictionary<string, Object> dataDictionary = new Dictionary<string, object>();
            dataDictionary.Add(sr_CurrentFuelAmountTag, m_CurrentFuelAmount);
            dataDictionary.Add(sr_FuelKindTag, FuelKind);
            return dataDictionary;
        }
    }
}
