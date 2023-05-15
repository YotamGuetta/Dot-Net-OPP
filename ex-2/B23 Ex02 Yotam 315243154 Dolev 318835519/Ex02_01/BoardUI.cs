using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ex02.ConsoleUtils;

namespace Ex02_01
{
    public class BoardUI
    {
        private readonly char r_ExitConditionInput = 'Q';
        private readonly char r_Player1Symbol = 'X';
        private readonly char r_Player2Symbol = 'O';
        private readonly short r_MinBoradSize = 3;
        private readonly short r_MaxBoradSize = 9;
        private Board m_BoardLogics;
        private short m_boardSize;
        private eGameType m_gameType;

        private enum eGameType
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

        private void getValidNumberInRangeFromUser(short i_MinValue, short i_MaxValue, out short o_UserNumber, out bool o_ExitRequest)
        {
            string v_UserInput;
            while (true)
            {
                v_UserInput = Console.ReadLine();
                if (string.Equals(v_UserInput, char.ToString(r_ExitConditionInput), StringComparison.OrdinalIgnoreCase))
                {
                    Screen.Clear();
                    o_ExitRequest = true;
                    o_UserNumber = 0;
                    return;
                }

                o_ExitRequest = false;

                bool v_ValidInputCheck = short.TryParse(v_UserInput, out short v_UserInputAsANumber);
                if (!v_ValidInputCheck)
                {
                    Console.WriteLine("Invalid input, please enter an integer");
                    continue;
                }
                else if (v_UserInputAsANumber < i_MinValue || v_UserInputAsANumber > i_MaxValue)
                {
                    Console.WriteLine("Invalid input, please enter an integer in range: " + i_MinValue + " - " + i_MaxValue);
                    continue;
                }

                o_UserNumber = v_UserInputAsANumber;
                return;
            }
        }

        private void showCurrentBoardState()
        {
            m_BoardLogics.GetBoardState(out char[,] v_BoardValues);
            Console.Write(" ");
            for (int i = 0; i < m_boardSize; i++)
            {
                Console.Write(" " + (i + 1) + "  ");
            }

            Console.WriteLine();
            for (int i = 0; i < m_boardSize; i++)
            {
                Console.Write((i + 1) + "|");

                for (int j = 0; j < m_boardSize; j++)
                {
                    Console.Write(" " + v_BoardValues[i, j] + " |");
                }

                Console.WriteLine();
                Console.Write(" =");
                for (int j = 0; j < m_boardSize; j++)
                {
                    Console.Write("====");
                }

                Console.WriteLine();
            }
        }

        public class Board
        {
            private char[,] board;

            public void Make(short size, byte type)
            {
                board = new char[size, size];
                for (int i = 0; i < size; i++)
                {
                    for (int j = 0; j < size; j++)
                    {
                        board[i, j] = ' ';
                    }
                }
            }

            public void GetBoardState(out char[,] board)
            {
                board = this.board;
            }

            public bool Put(int row, int col, char sym)
            {
                if (board[row - 1, col - 1] == ' ')
                {
                    board[row - 1, col - 1] = sym;
                    return true;
                }

                return false;
            }

            public bool CheckIfWon(out byte won)
            {
                won = 0;
                return false;
            }
        }

        public void StartGame()
        {
            Console.WriteLine("!!!!!!!!!!! Welcome To Tic-Tac-Toe !!!!!!!!!!");
            Console.WriteLine("Please enter The board desiered length (between " + r_MinBoradSize + "-" + r_MaxBoradSize + "), press Q to exit");
            getValidNumberInRangeFromUser(r_MinBoradSize, r_MaxBoradSize, out m_boardSize, out bool v_ExitGame);
            if (v_ExitGame)
            {
                return;
            }

            Console.WriteLine("Choose game type (enter 1 or 2), press Q to exit");
            Console.WriteLine("1) Player VS AI");
            Console.WriteLine("2) 2 Players");
            getValidNumberInRangeFromUser(GetMinValue(), GetMaxValue(), out short v_gameTypeAsShort, out v_ExitGame);
            if (v_ExitGame)
            {
                return;
            }

            m_gameType = (eGameType)v_gameTypeAsShort;
            Screen.Clear();
            m_BoardLogics = new Board();
            while (!v_ExitGame)
            {
                m_BoardLogics.Make(m_boardSize, (byte)m_gameType);

                bool v_WasAnEmptySpace;
                char v_CurrentPlayerSymble = r_Player2Symbol;
                byte v_GameResult = 0;
                bool v_HasAPlayerWon = false;
                while (!v_HasAPlayerWon)
                {
                    if (v_CurrentPlayerSymble == r_Player2Symbol)
                    {
                        v_CurrentPlayerSymble = r_Player1Symbol;
                    }
                    else if (v_CurrentPlayerSymble == r_Player1Symbol)
                    {
                        v_CurrentPlayerSymble = r_Player2Symbol;
                    }

                    showCurrentBoardState();
                    Console.WriteLine("Choose a row and col to enter your symbol");
                    getValidNumberInRangeFromUser(1, m_boardSize, out short v_ChosenRow, out v_ExitGame);
                    if (v_ExitGame)
                    {
                        return;
                    }

                    getValidNumberInRangeFromUser(1, m_boardSize, out short v_ChosenCol, out v_ExitGame);
                    if (v_ExitGame)
                    {
                        return;
                    }

                    v_WasAnEmptySpace = m_BoardLogics.Put(v_ChosenRow, v_ChosenCol, v_CurrentPlayerSymble);
                    if (!v_WasAnEmptySpace)
                    {
                        Screen.Clear();
                        Console.WriteLine("Choosen space is not empty");
                        continue;
                    }

                    Screen.Clear();
                    v_HasAPlayerWon = m_BoardLogics.CheckIfWon(out v_GameResult);
                }

                while (true)
                {
                    switch (v_GameResult)
                    {
                        case 0:
                            Console.WriteLine("The Game Ended With A Draw");
                            break;
                        case 1:
                            Console.WriteLine("Player 1 Won");
                            break;
                        case 2:
                            Console.WriteLine("Player 2 Won");
                            break;
                    }

                    Console.WriteLine("Would You Like To Play Another Round? (Y/N)");
                    string v_UserInput = Console.ReadLine();
                    if (string.Equals(v_UserInput, "Y", StringComparison.OrdinalIgnoreCase))
                    {
                        Screen.Clear();
                        return;
                    }

                    if (string.Equals(v_UserInput, "N", StringComparison.OrdinalIgnoreCase) ||
                        string.Equals(v_UserInput, char.ToString(r_ExitConditionInput), StringComparison.OrdinalIgnoreCase))
                    {
                        Screen.Clear();
                        v_ExitGame = true;
                        return;
                    }

                    Screen.Clear();
                    Console.WriteLine("Invalid input, please choose Y/N");
                }
            }
        }
    }
}
