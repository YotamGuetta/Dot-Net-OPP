using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GarageLogic
{
    class Wheel
    {
        private static readonly float sr_MinCapacityTag = 0;
        private static readonly string ManufacturerTag = "Manufacturer";
        private static readonly string AirPressureTag = "Air Pressure";
        private string m_Manufacturer;
        private float m_AirPressure;
        private readonly float r_MaximumAirPressure;

        public float MaximumAirPressure
        {
            get { return r_MaximumAirPressure; }
        }
        public string Manufacturer
        {
            get { return m_Manufacturer; }
            set { m_Manufacturer = value; }
        }
        public float AirPressure
        {
            get { return m_AirPressure; }
            set { m_AirPressure = value; }
        }
        public Wheel(float i_MaximumAirPressure)
        {
            this.r_MaximumAirPressure = i_MaximumAirPressure;
            m_AirPressure = 0;
        }

        public void inflate(float i_AirToAdd)
        {
            if ((i_AirToAdd + m_AirPressure) > r_MaximumAirPressure)
            {
                throw new ValueOutOfRangeException(sr_MinCapacityTag, r_MaximumAirPressure);
            }
            m_AirPressure += i_AirToAdd;
        }
        public virtual Dictionary<string, Type> GetRequiredArguments()
        {
            Dictionary<string, Type> neededArguments = new Dictionary<string, Type>();
            neededArguments.Add(ManufacturerTag, typeof(string));
            neededArguments.Add(AirPressureTag, typeof(float));

            return neededArguments;
        }
        public virtual void SetRequiredArguments(Dictionary<string, object> i_RequiredArguments)
        {
            m_Manufacturer = ArgumentsSetter.GetArgument<string>(i_RequiredArguments, ManufacturerTag);
            m_AirPressure = ArgumentsSetter.GetArgument<float>(i_RequiredArguments, AirPressureTag);
            
        }
        public Dictionary<string, object> GetWheelData() {
            Dictionary<string, object> dataDictionary = new Dictionary<string, Object>();
            dataDictionary.Add(ManufacturerTag, m_Manufacturer);
            dataDictionary.Add(AirPressureTag, m_AirPressure);
            return dataDictionary;
        }
    }
}
