using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GarageLogic
{
    abstract class EnergySource
    {
        protected static readonly float sr_MinCapacity = 0;
        protected float m_MaxCapacity;

        public EnergySource(float maxCapacity)
        {
            m_MaxCapacity = maxCapacity;
        }

        public abstract void AddEnergy(Dictionary<string, object> i_RequiredArguments);
        public abstract Dictionary<string, Type> GetRequiredArguments();
        public abstract float GetEnergyPercentage();
        public abstract Dictionary<string, object> GetEnergySourceData();
    }
}
