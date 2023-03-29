using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex01_04
{
    class Program
    {
        private static int m_StringAsANumber;
        private static string m_EnglishCharactersString;
        private const int k_DesiredLength = 6;
        private const bool k_validString = true;
        private static bool m_isStringOfNumbers;
        private static bool m_isStringOfEnglishCharacters;

        private static bool isValidInputLength(string i_StringToCheck)
        {
            return k_DesiredLength == i_StringToCheck.Length;
        }
        private static bool IsValidInputCharecters(string i_StringToCheck)
        {
            m_isStringOfNumbers = int.TryParse(i_StringToCheck, out m_StringAsANumber);
            if (m_isStringOfNumbers) ;
            for (int i = 0; i < i_StringToCheck.Length; i++)
            {
                if (!IsEnglishLetter(i_StringToCheck[i]))
                {
                    return !k_validString;
                }
            }

            return k_validString;
        }

        private static bool IsEnglishLetter(char i_Letter)
        {
            return (i_Letter >= 'a' && i_Letter <= 'z') || (i_Letter >= 'A' && i_Letter <= 'Z');
        }

        private static bool IsValidInputString(string i_StringInput)
        {
            return isValidInputLength(i_StringInput) && IsValidInputCharecters(i_StringInput);

        }


        public bool IsPolindrom()
        {
            return true;
        }

        public bool IsDividableBy3()
        {
            return true;
        }

        public bool UpperCaseLettersSum()
        {
            return true;
        }

        
        public static void Main()
        {
           

            string userInput = Console.ReadLine();



            if (!IsValidInputString(userInput))
            {
                Console.WriteLine("Invalid input");
            }
            else
            {

            }
        }
    }
}
