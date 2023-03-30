using System;

namespace Ex01_01
{
    class Program
    {
        public static void Main()
        {
            int amountOfZeroes = 0, amountOfOnes = 0;

            GetAllTheBinaryNumbersFromUser(out string binaryStr1, out string binaryStr2, out string binaryStr3);
            ConvertAllBinaryStringToDecimalNumbers(binaryStr1, binaryStr2, binaryStr3, out int decimalNum1, out int decimalNum2, out int decimalNum3, ref amountOfZeroes, ref amountOfOnes);
            PrintDecimalNumbersByOrder(decimalNum1, decimalNum2, decimalNum3);
            PrintStatistic(decimalNum1, decimalNum2, decimalNum3, amountOfZeroes, amountOfOnes);
        }

        public static string GetOneBinaryNumberFromUser()
        {
            string userInput = Console.ReadLine();
            bool isValidInput = (userInput.Length == 8) && IsBinaryNumber(userInput);
            while (!isValidInput)
            {
                Console.WriteLine("Invalid Input. Try again.");
                userInput = Console.ReadLine();
                isValidInput = (userInput.Length != 8) && IsBinaryNumber(userInput);
            }

            return userInput;
        }

        public static void GetAllTheBinaryNumbersFromUser(out string o_binaryStr1, out string o_binaryStr2, out string o_binaryStr3)
        {
            Console.WriteLine("Please enter three binary numbers (with 8 digits each). Press enter after every number.");
            o_binaryStr1 = GetOneBinaryNumberFromUser();
            o_binaryStr2 = GetOneBinaryNumberFromUser();
            o_binaryStr3 = GetOneBinaryNumberFromUser();
        }

        public static int ConvertBinaryStringToInt(string i_binaryStr, ref int o_numOfZeroes, ref int o_numOfOnes)
        {
            int decimalNumber = 0;

            for (int i = i_binaryStr.Length - 1, j = 0; i >= 0; i--, j++)
            {
                if (i_binaryStr[i] == '1')
                {
                    decimalNumber += (int)Math.Pow(2, j);
                    o_numOfOnes++;
                }
                else
                {
                    o_numOfZeroes++;
                }
            }

            return decimalNumber;
        }

        public static void ConvertAllBinaryStringToDecimalNumbers(string i_binaryStr1, string i_binaryStr2, string i_binaryStr3, out int o_decimalNum1, out int o_decimalNum2, out int o_decimalNum3, ref int o_numOfZeroes, ref int o_numOfOnes)
        {
            o_decimalNum1 = ConvertBinaryStringToInt(i_binaryStr1, ref o_numOfZeroes, ref o_numOfOnes);
            o_decimalNum2 = ConvertBinaryStringToInt(i_binaryStr2, ref o_numOfZeroes, ref o_numOfOnes);
            o_decimalNum3 = ConvertBinaryStringToInt(i_binaryStr3, ref o_numOfZeroes, ref o_numOfOnes);
        }

        public static void PrintDecimalNumbersByOrder(int i_decimalNum1, int i_decimalNum2, int i_decimalNum3)
        {
            if (i_decimalNum1 > i_decimalNum2)
            {
                if (i_decimalNum2 > i_decimalNum3)
                {
                    Console.WriteLine("The decimal numbers (in descending order) - {0} {1} {2}", i_decimalNum1, i_decimalNum2, i_decimalNum3);
                }
                else if (i_decimalNum1 > i_decimalNum3)
                {
                    Console.WriteLine("The decimal numbers (in descending order) - {0} {1} {2}", i_decimalNum1, i_decimalNum3, i_decimalNum2);
                }
                else
                {
                    Console.WriteLine("The decimal numbers (in descending order) - {0} {1} {2}", i_decimalNum3, i_decimalNum1, i_decimalNum2);
                }
            }
            else
            {
                if (i_decimalNum1 > i_decimalNum3)
                {
                    Console.WriteLine("The decimal numbers (in descending order) - {0} {1} {2}", i_decimalNum2, i_decimalNum1, i_decimalNum3);
                }
                else if (i_decimalNum2 > i_decimalNum3)
                {
                    Console.WriteLine("The decimal numbers (in descending order) - {0} {1} {2}", i_decimalNum2, i_decimalNum3, i_decimalNum1);
                }
                else
                {
                    Console.WriteLine("The decimal numbers (in descending order) - {0} {1} {2}", i_decimalNum3, i_decimalNum2, i_decimalNum1);
                }
            }
        }

        public static bool IsBinaryNumber(string i_binaryNumber)
        {
            bool isBinary = true;

            for (int i = 0; i < i_binaryNumber.Length; i++)
            {
                if (i_binaryNumber[i] != '0' && i_binaryNumber[i] != '1')
                {
                    isBinary = false;
                }
            }

            return isBinary;
        }

        public static int CountNumbersDividesByFour(int i_decimalNum1, int i_decimalNum2, int i_decimalNum3)
        {
            int countNumsDividesByFour = 0;

            if (i_decimalNum1 % 4 == 0)
            {
                countNumsDividesByFour++;
            }

            // Check if num2 is divisible by 4
            if (i_decimalNum2 % 4 == 0)
            {
                countNumsDividesByFour++;
            }

            // Check if num3 is divisible by 4
            if (i_decimalNum3 % 4 == 0)
            {
                countNumsDividesByFour++;
            }

            return countNumsDividesByFour;
        }

        public static bool IsDescendingNumbers(int i_numToCheck)
        {
            bool isDescending = true;

            while (i_numToCheck > 0 && isDescending)
            {
                int previosDigit = i_numToCheck % 10;
                i_numToCheck = i_numToCheck / 10;
                int currentDigit = i_numToCheck % 10;

                if (previosDigit > currentDigit)
                {
                    previosDigit = currentDigit;
                    currentDigit = i_numToCheck % 10;
                    i_numToCheck = i_numToCheck / 10;
                }
                else
                {
                    isDescending = false;
                }
            }

            return isDescending;
        }

        public static int CountDescendingNumbers(int i_decimalNum1, int i_decimalNum2, int i_decimalNum3)
        {
            int countDescendingNums = 0;

            if (IsDescendingNumbers(i_decimalNum1))
            {
                countDescendingNums++;
            }

            if (IsDescendingNumbers(i_decimalNum2))
            {
                countDescendingNums++;
            }

            if (IsDescendingNumbers(i_decimalNum3))
            {
                countDescendingNums++;
            }

            return countDescendingNums;
        }

        public static bool IsPalindrome(int i_numToCheck)
        {
            int originalNum = i_numToCheck;
            int reversedNum = 0;

            while (i_numToCheck > 0)
            {
                int currDigit = i_numToCheck % 10; // Extract the last digit of num1
                i_numToCheck = i_numToCheck / 10; // Remove the last digit from num1

                reversedNum = (reversedNum * 10) + currDigit; // Add the current digit to the reversed number
            }

            return originalNum == reversedNum;
        }

        public static int CountPalindromeNumbers(int i_decimalNum1, int i_decimalNum2, int i_decimalNum3)
        {
            int countPalindromeNums = 0;

            if (IsPalindrome(i_decimalNum1))
            {
                countPalindromeNums++;
            }

            if (IsPalindrome(i_decimalNum2))
            {
                countPalindromeNums++;
            }

            if (IsPalindrome(i_decimalNum3))
            {
                countPalindromeNums++;
            }

            return countPalindromeNums;
        }

        public static void PrintStatistic (int i_decimalNum1, int i_decimalNum2, int i_decimalNum3, int i_amountOfZeroes, int i_amountOfOnes)
        {
            int amountOfDividesByFour = 0, amountOfDescendingNums = 0, amountOfPalindromeNums = 0;

            Console.WriteLine("The mean of the zeros is - {0} and the mean of the ones is - {1}", i_amountOfZeroes / 3, i_amountOfOnes / 3);
            amountOfDividesByFour = CountNumbersDividesByFour(i_decimalNum1, i_decimalNum2, i_decimalNum3);
            Console.WriteLine("The amount of numbers that divides by four is - {0}", amountOfDividesByFour);
            amountOfDescendingNums = CountDescendingNumbers(i_decimalNum1, i_decimalNum2, i_decimalNum3);
            Console.WriteLine("The amount of numbers that their digits is descending series is - {0}", amountOfDescendingNums);
            amountOfPalindromeNums = CountPalindromeNumbers(i_decimalNum1, i_decimalNum2, i_decimalNum3);
            Console.WriteLine("The ampunt of palindrome numbers is - {0}", amountOfPalindromeNums);
        }
    }
}
