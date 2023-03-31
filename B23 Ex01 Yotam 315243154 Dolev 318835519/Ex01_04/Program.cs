namespace Ex01_04
{
    using System;

    public class Program
    {   
        private const int k_DesiredLength = 6;
        private const bool k_ValidStringFormat = true;
        private static int m_StringAsANumber;
        private static string m_EnglishCharactersString;
        private static bool m_IsAStringOfNumbers = false;

        public static void Main()
        {
            Console.WriteLine("Enter a string with 6 english letters or a 6 digits number: ");

            string userInput = Console.ReadLine();

            if (!InsertStringToDataMembers(userInput))
            {
                Console.WriteLine("Invalid input");
            }
            else
            {
                if (IsPalindrome())
                {
                    Console.WriteLine("The string is a palindrome");
                }
                else
                {
                    Console.WriteLine("The string is not a palindrome");
                }

                if (m_IsAStringOfNumbers)
                {
                    if (IsDividableBy3())
                    {
                        Console.WriteLine("The Number is Dividable by 3");
                    }
                    else
                    {
                        Console.WriteLine("The Number is not Dividable by 3");
                    }
                }
                else
                {
                    Console.WriteLine(string.Format(@"There are {0} upper case letters in the string", UpperCaseLettersSum()));
                }
            }
        }

        private static bool IsValidInputLength(string i_StringToCheck)
        {
            return k_DesiredLength == i_StringToCheck.Length;
        }

        private static bool InsertStringToDataMembers(string i_StringToAdd)
        {
            if (!IsValidInputLength(i_StringToAdd))
            {
                return !k_ValidStringFormat;
            }

            m_EnglishCharactersString = i_StringToAdd;

            m_IsAStringOfNumbers = int.TryParse(i_StringToAdd, out m_StringAsANumber);

            if (!m_IsAStringOfNumbers)
            {
                for (int i = 0; i < i_StringToAdd.Length; i++)
                {
                    if (!IsEnglishLetter(i_StringToAdd[i]))
                    {
                        return !k_ValidStringFormat;
                    }
                }
            }

            return k_ValidStringFormat;
        }

        private static bool IsEnglishLetter(char i_Letter)
        {
            return (i_Letter >= 'a' && i_Letter <= 'z') || IsUpperCaseLetter(i_Letter);
        }

        private static bool IsPalindrome()
        {
            return IsPalindromeRecursion(0, m_EnglishCharactersString.Length - 1);
        }

        private static bool IsPalindromeRecursion(int i_StringStartChar, int i_StringEndChar)
        {
            if (i_StringStartChar == i_StringEndChar)
            {
                return true;
            }   

            if (m_EnglishCharactersString[i_StringStartChar] != m_EnglishCharactersString[i_StringEndChar])
            {
                return false;
            }
                
            if (i_StringStartChar < i_StringEndChar + 1)
            {
                return IsPalindromeRecursion(i_StringStartChar + 1, i_StringEndChar - 1);
            }
                
            return true;
        }

        private static bool IsDividableBy3()
        {
            return m_StringAsANumber % 3 == 0;
        }

        private static int UpperCaseLettersSum()
        {
            int numberOfUpperCaseLetters = 0;

            for (int i = 0; i < m_EnglishCharactersString.Length; i++)
            {
                if (IsUpperCaseLetter(m_EnglishCharactersString[i]))
                {
                    numberOfUpperCaseLetters++;
                }
            }

            return numberOfUpperCaseLetters;
        }

        private static bool IsUpperCaseLetter(char i_Letter)
        {
            return i_Letter >= 'A' && i_Letter <= 'Z';
        }     
    }
}
