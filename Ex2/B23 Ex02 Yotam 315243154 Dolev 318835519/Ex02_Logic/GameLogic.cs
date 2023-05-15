using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameLogics
{
    public class GameLogic
    {
        private Board m_GameBoard;
        private GameTypeEnum.eGameType m_gameType;
        private ComputerPlayer m_computerPlayer;
        private readonly char r_Player1Symbol;
        private readonly char r_Player2Symbol;
        private int[] playersScore = { 0, 0, 0 };

        public GameLogic(int i_size, GameTypeEnum.eGameType i_gameType, char i_Player1Symbol, char i_Player2Symbol)
        {
            m_GameBoard = new Board(i_size);
            this.m_gameType = i_gameType;
            this.r_Player1Symbol = i_Player1Symbol;
            this.r_Player2Symbol = i_Player2Symbol;
            if (m_gameType.Equals(GameTypeEnum.eGameType.HumanVsAi))
            {
                m_computerPlayer = new ComputerPlayer(r_Player2Symbol);
            }
        }
        public bool PlaceSymbol(int i_rowNumber, int i_columnNumber, int currentRound)
        {
            bool placeableSymbol;
            if (m_gameType.Equals(GameTypeEnum.eGameType.HumanVsHuman) && currentRound % 2 == 0)
            {
                placeableSymbol = m_GameBoard.PlaceSymbolInBoard(i_rowNumber, i_columnNumber, r_Player2Symbol);
                return placeableSymbol;
            }

            placeableSymbol = m_GameBoard.PlaceSymbolInBoard(i_rowNumber, i_columnNumber, r_Player1Symbol);

            if (placeableSymbol && m_gameType.Equals(GameTypeEnum.eGameType.HumanVsAi))
            {
                if (CheckIfAPlayerWon().Equals(GameResultEnum.eGameResult.NoWinner))
                {
                    m_computerPlayer.SetComputerAction(m_GameBoard);

                }
            }

            return placeableSymbol;
        }
        public GameResultEnum.eGameResult CheckIfAPlayerWon()
        {
            if (m_GameBoard.IsBoardFull())
            {
                return GameResultEnum.eGameResult.Draw;
            }
            if (m_GameBoard.HasWinningSequence(r_Player1Symbol))
            {
                return GameResultEnum.eGameResult.Player1;
            }
            if (m_GameBoard.HasWinningSequence(r_Player2Symbol))
            {
                return GameResultEnum.eGameResult.Player2;
            }
            return GameResultEnum.eGameResult.NoWinner;
        }
        public bool HasGameEnded(GameResultEnum.eGameResult i_gameResult)
        {
            if (i_gameResult.Equals(GameResultEnum.eGameResult.NoWinner))
            {
                return false;
            }
            return true;
        }
        public void GetBoardState(out char[,] o_gameBoard)
        {
            m_GameBoard.GetBoardState(out o_gameBoard);
        }

        public void AddScore(GameResultEnum.eGameResult i_winner) 
        {
            playersScore[(int)i_winner]++;
        }

        public int[] GetPlayersScore() {
            return playersScore;
        }
        public void ClearBoard() 
        {
            m_GameBoard.ClearBoard();
        }
    }
}
