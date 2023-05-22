using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GarageLogic
{
    public enum eColor
    {
        White,
        Black,
        Yellow,
        Red
    }
    class Car: Vehicle
    {
        private static readonly string sr_CarColorTag = "Car Color";
        private static readonly string sr_NumberOfDoorsTag = "Number Of Doors"; 
        private eColor m_CarColor;
        private byte m_NumberOfDoors;
        public eColor CarColor
        {
            get { return m_CarColor; }
            set { m_CarColor = value; }
        }
        public byte NumberOfDoors
        {
            get { return m_NumberOfDoors; }
            set { m_NumberOfDoors = value; }
        }
        public Car(bool i_Electric, int i_NumberOfWeels, float i_MaxAirPressure, float i_MaxCapacity, eFuelKind i_FuelKind = eFuelKind.NaN)
            : base(i_Electric, i_NumberOfWeels, i_MaxAirPressure, i_MaxCapacity, i_FuelKind) { }

        public override Dictionary<string, Type> GetRequiredArguments()
        {
            Dictionary<string, Type> neededArguments =  base.GetRequiredArguments();
            neededArguments.Add(sr_CarColorTag, m_CarColor.GetType());
            neededArguments.Add(sr_NumberOfDoorsTag, m_NumberOfDoors.GetType());

            return neededArguments;
        }
        public override void SetRequiredArguments(Dictionary<string, object> i_RequiredArguments)
        {
            m_CarColor = ArgumentsSetter.GetArgument<eColor>(i_RequiredArguments, sr_CarColorTag);
            m_NumberOfDoors = ArgumentsSetter.GetArgument<byte>(i_RequiredArguments, sr_NumberOfDoorsTag);
            base.SetRequiredArguments(i_RequiredArguments);
        }
        public override Dictionary<string, object> GetVehcleData()
        {
            Dictionary<string, object> carData = base.GetVehcleData();
            carData.Add(sr_CarColorTag, m_CarColor);
            carData.Add(sr_NumberOfDoorsTag, m_NumberOfDoors);
            return carData;
        }

    }
}
