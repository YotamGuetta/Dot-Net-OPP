using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GarageLogic
{
    class Electric : EnergySource
    {
        private static readonly string sr_BatteryTimeLeftInHoursTag = "Battery Time Left In Hours";
        private float m_BatteryTimeLeftInHours;
        public Electric(float i_MaxBatteryCapacity) : base(i_MaxBatteryCapacity)
        {
            m_BatteryTimeLeftInHours = 0;
        }
        public override void AddEnergy(Dictionary<string, object> i_RequiredArguments)
        {
            Recharge(ArgumentsSetter.GetArgument<float>(i_RequiredArguments, sr_BatteryTimeLeftInHoursTag));
        }
        public void Recharge(float timeToChargeInHours)
        {
            if ((m_BatteryTimeLeftInHours + timeToChargeInHours) > m_MaxCapacity)
            {
                throw new ValueOutOfRangeException(sr_MinCapacity, m_MaxCapacity);
            }

            m_BatteryTimeLeftInHours += timeToChargeInHours;
        }
        public override Dictionary<string, Type> GetRequiredArguments()
        {
            Dictionary<string, Type> neededArguments = new Dictionary<string, Type>
            {
                { sr_BatteryTimeLeftInHoursTag, m_BatteryTimeLeftInHours.GetType() }
            };

            return neededArguments;
        }
        public override float GetEnergyPercentage()
        {
            return m_BatteryTimeLeftInHours / m_MaxCapacity;
        }
        public override Dictionary<string, object> GetEnergySourceData()
        {
            Dictionary<string, Object> dataDictionary = new Dictionary<string, Object>();
            dataDictionary.Add(sr_BatteryTimeLeftInHoursTag, m_BatteryTimeLeftInHours);
            return dataDictionary;
        }
    }
}
