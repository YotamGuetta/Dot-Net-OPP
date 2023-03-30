namespace Ex01_05
{
    using System;

    public class Program
    {
        private const int k_DesiredLength = 6;
        private const bool k_ValidStringFormat = true;
        private static int m_StringAsANumber;
        
        public static void Main()
        {
            while (true)
            {
                string userInput;
                do
                {
                    userInput = Console.ReadLine();
                }
                while (!InsertStringToDataMembers(userInput));

                Console.WriteLine(string.Format(
@"The number of digits bigger then the unit's place is: {0}
The minimum digit is: {1}
The number of digits dividable by 3 are: {2}
The avrage of the digits is: {3}",
NumberOfDigitsBiggerThenTheUnitsPlace(),
MinimumDigit(),
NumberOfDigitsDividableBy3(),
DigitsAvrage()));
            }
        }

        private static int NumberOfDigitsBiggerThenTheUnitsPlace()
        {
            short digitToCompare = TheNumbersDigit(0);
            int numberOfBiggerDigits = 0;
            for (int i = 1; i < k_DesiredLength; i++)
            {
                if (TheNumbersDigit(i) > digitToCompare)
                {
                    numberOfBiggerDigits++;
                }
            }

            return numberOfBiggerDigits;
        }

        private static int MinimumDigit()
        {
            int minimumDigit = 1;
            short currentDigitValue;
            short minimumDigitValue = TheNumbersDigit(minimumDigit - 1);
            for (int i = 1; i < k_DesiredLength; i++)
            {
                currentDigitValue = TheNumbersDigit(i);
                if (currentDigitValue < minimumDigitValue)
                {
                    minimumDigitValue = currentDigitValue;
                    minimumDigit = i + 1;
                }
            }

            return minimumDigit;
        }

        private static int NumberOfDigitsDividableBy3()
        {
            int numberOfDigitsDividableBy3 = 0;
            for (int i = 0; i < k_DesiredLength; i++)
            {
                if (TheNumbersDigit(i) % 3 == 0)
                {
                    numberOfDigitsDividableBy3++;
                }
            }

            return numberOfDigitsDividableBy3;
        }

        private static float DigitsAvrage()
        {
            int sumOfDigits = 0;
            int numberOfDigits = 0;
            for (int i = 0; i < k_DesiredLength; i++)
            {
                sumOfDigits += TheNumbersDigit(i);

                numberOfDigits++;
            }

            return (float)sumOfDigits / numberOfDigits;
        }

        private static short TheNumbersDigit(int i_DigitIndex)
        {
            return (short)((m_StringAsANumber % Math.Pow(10.0, i_DigitIndex + 1)) / Math.Pow(10, i_DigitIndex));
        }

        private static bool IsValidInputLength(string i_StringToCheck)
        {
            return k_DesiredLength == i_StringToCheck.Length;
        }

        private static bool InsertStringToDataMembers(string i_StringToAdd)
        {
            if (!IsValidInputLength(i_StringToAdd))
            {
                Console.WriteLine("Invalid input");
                return !k_ValidStringFormat;
            }

           if(int.TryParse(i_StringToAdd, out m_StringAsANumber))
            {
                return k_ValidStringFormat;
            }

            Console.WriteLine("Invalid input");
            return !k_ValidStringFormat;
        }
    }
}
