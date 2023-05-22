using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GarageLogic
{
    class ValueOutOfRangeException : Exception
    {
        private float m_MaxValue;
        private float m_MinValue;
        public float MaxValue
        {
            get { return m_MaxValue; }
        }
        
        public float MinValue
        {
            get { return m_MinValue; }
        }

        public ValueOutOfRangeException(float i_MinValue, float i_MaxValue) 
            :base(string.Format("Filling out ranges {0}-{1}.", i_MinValue, i_MaxValue))
        {
        }
    }
}
