using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameLogics
{
    public class GameTypeEnum
    {
        public enum eGameType
        {
            HumanVsAi = 1,
            HumanVsHuman = 2
        }
        public static short GetMaxValue()
        {
            return (short)Enum.GetValues(typeof(eGameType)).Cast<eGameType>().Max();
        }

        public static short GetMinValue()
        {
            return (short)Enum.GetValues(typeof(eGameType)).Cast<eGameType>().Min();
        }

    }
}
