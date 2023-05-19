using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03_UI
{
    public class ValueOutOfRangeException : Exception
    {
        public float MaxValue { get; }
        public float MinValue { get; }

        public ValueOutOfRangeException(string message, float maxValue, float minValue) : base(message)
        {
            MaxValue = maxValue;
            MinValue = minValue;
        }
    }
}
