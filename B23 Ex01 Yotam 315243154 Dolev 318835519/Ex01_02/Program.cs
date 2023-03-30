using System;
using System.Text;

namespace Ex01_02
{
    class Program
    {
        static void Main()
        {
            StringBuilder SB = new StringBuilder();
            printDiamondForBegginers(SB, 5, 0);
            Console.WriteLine(SB.ToString());
        }

        static void printDiamondForBegginers(StringBuilder i_SB, int i_numOfRows, int i_currenRow)
        {
            if (i_numOfRows < 1)
            {
                return;
            }

            i_SB.Append(' ', i_numOfRows - 1);
            i_SB.Append('*', 2 * i_currenRow + 1);
            i_SB.AppendLine();
            printDiamond(sb, i_numOfRows - 1, i_currenRow + 1);
            if (i_currenRow != 0)
            {
                i_SB.Append(' ', i_numOfRows);
                i_SB.Append('*', (2 * i_currenRow) - 1);
                i_SB.AppendLine();
            }
        }
    }
}
}
