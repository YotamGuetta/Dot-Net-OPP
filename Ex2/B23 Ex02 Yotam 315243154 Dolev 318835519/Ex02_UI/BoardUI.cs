using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ex02.ConsoleUtils;
using GameLogics;
namespace GameUI
{
    public class BoardUI
    {
        
        private readonly char r_ExitConditionInput = 'Q';
        private readonly char r_Player1Symbol = 'X';
        private readonly char r_Player2Symbol = 'O';
        private readonly short r_MinBoradSize = 3;
        private readonly short r_MaxBoradSize = 9;
        private GameLogic m_BoardLogics;
        private short m_boardSize;
        private GameTypeEnum.eGameType m_gameType;
        private GameResultEnum.eGameResult m_CurrentGameState;

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
                    break;
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


        public void StartGame()
        {
            Console.WriteLine("!!!!!!!!!!! Welcome To Tic-Tac-Toe !!!!!!!!!!");
            Console.WriteLine("Please enter The board desiered length (between " + r_MinBoradSize + "-" + r_MaxBoradSize + "), press Q to exit");
            getValidNumberInRangeFromUser(r_MinBoradSize, r_MaxBoradSize, out m_boardSize, out bool v_ExitGame);
            if (v_ExitGame)
            {
                Environment.Exit(0);
            }

            Console.WriteLine("Choose game type (enter 1 or 2), press Q to exit");
            Console.WriteLine("1) Player VS AI");
            Console.WriteLine("2) 2 Players");
            getValidNumberInRangeFromUser(GameTypeEnum.GetMinValue(), GameTypeEnum.GetMaxValue(), out short v_gameTypeAsShort, out v_ExitGame);
            if (v_ExitGame)
            {
                Environment.Exit(0);
            }

            m_gameType = (GameTypeEnum.eGameType)v_gameTypeAsShort;
            Screen.Clear();
            m_BoardLogics = new GameLogic(m_boardSize, m_gameType, r_Player1Symbol, r_Player2Symbol);
            while (!v_ExitGame)
            {
                
                int v_currentround = 1;
                bool v_WasAnEmptySpace;
                bool v_HasAPlayerWon = false;
                while (!v_HasAPlayerWon)
                {

                    showCurrentBoardState();
                    Console.WriteLine("Choose a row and col to enter your symbol");
                    getValidNumberInRangeFromUser(1, m_boardSize, out short v_ChosenRow, out v_ExitGame);
                    if (v_ExitGame)
                    {
                        Environment.Exit(0);
                    }

                    getValidNumberInRangeFromUser(1, m_boardSize, out short v_ChosenCol, out v_ExitGame);
                    if (v_ExitGame)
                    {
                        Environment.Exit(0);
                    }

                    v_WasAnEmptySpace = m_BoardLogics.PlaceSymbol(v_ChosenRow - 1, v_ChosenCol - 1, v_currentround);
                    if (!v_WasAnEmptySpace)
                    {
                        Screen.Clear();
                        Console.WriteLine("Choosen space is not empty");
                        continue;
                    }

                    Screen.Clear();
                    m_CurrentGameState = m_BoardLogics.CheckIfAPlayerWon();
                    v_HasAPlayerWon = m_BoardLogics.HasGameEnded(m_CurrentGameState);
                    v_currentround++;
                }
                

                while (true)
                {
                    switch (m_CurrentGameState)
                    {
                        case GameResultEnum.eGameResult.Draw:
                            Console.WriteLine("The Game Ended With A Draw");
                            m_BoardLogics.AddScore(GameResultEnum.eGameResult.Draw);
                            break;
                        case GameResultEnum.eGameResult.Player1:
                            Console.WriteLine("Player 1 Won");
                            m_BoardLogics.AddScore(GameResultEnum.eGameResult.Player1);
                            break;
                        case GameResultEnum.eGameResult.Player2:
                            Console.WriteLine("Player 2 Won");
                            m_BoardLogics.AddScore(GameResultEnum.eGameResult.Player2);
                            break;
                    }

                    int[] playersScore = m_BoardLogics.GetPlayersScore();
                    Console.WriteLine("Standing scores are: Player 1: "+ playersScore[(int)GameResultEnum.eGameResult.Player1] + " |Player 2: " +
                        playersScore[(int)GameResultEnum.eGameResult.Player2] + " |Draws: " + playersScore[(int)GameResultEnum.eGameResult.Draw]);
                    Console.WriteLine("Would You Like To Play Another Round? (Y/N)");
                    string v_UserInput = Console.ReadLine();
                    if (string.Equals(v_UserInput, "Y", StringComparison.OrdinalIgnoreCase))
                    {
                        Screen.Clear();
                        m_BoardLogics.ClearBoard();
                        break;
                    }

                    if (string.Equals(v_UserInput, "N", StringComparison.OrdinalIgnoreCase) ||
                        string.Equals(v_UserInput, char.ToString(r_ExitConditionInput), StringComparison.OrdinalIgnoreCase))
                    {
                        Screen.Clear();
                        v_ExitGame = true;
                        Environment.Exit(0);
                    }

                    Screen.Clear();
                    Console.WriteLine("Invalid input, please choose Y/N");
                }
            }
        }
    }
}
