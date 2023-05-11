using System;
using System.Text;

namespace Ex01_03
{
    public class Program
    {
        public static void Main()
        {
            int wanredNumOfDiamondRows = GetNumberOfDiamondsRowsFromUser();
            if (wanredNumOfDiamondRows % 2 == 0)
            {
                wanredNumOfDiamondRows--;
            }

            StringBuilder sb = new StringBuilder();
            Ex01_02.Program.PrintDiamond(sb, wanredNumOfDiamondRows / 2 + 1, 0);
            Console.WriteLine(sb.ToString());
        }


        public static int GetNumberOfDiamondsRowsFromUser()
        {
            bool isValidInput = true;
            int numberOfDiamondRows;

            Console.WriteLine("Please enter a number for the diamond rows - ");
            string userInput = Console.ReadLine();
            isValidInput = int.TryParse(userInput, out numberOfDiamondRows);
            while (!isValidInput && numberOfDiamondRows <= 0)
            {
                Console.WriteLine("Invalid Input. Try again.");
                userInput = Console.ReadLine();
                isValidInput = int.TryParse(userInput, out numberOfDiamondRows);
            }

            return numberOfDiamondRows;
        }
    }
}
