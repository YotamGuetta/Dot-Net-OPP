namespace GameLogics
{
    public class Board
    {
        private char[,] m_board;
        private int m_boardSize; //static?

        public Board(int i_size)
        {
            this.m_boardSize = i_size;
            m_board = new char[i_size, i_size];
        }
        public int Size
        {
            get { return m_boardSize; }
        }

        public void ClearBoard()
        {
            m_board = new char[m_boardSize, m_boardSize];
        }

        public bool IsCellEmpty(int i_rowNumber, int i_columnNumber) //static?
        {
            return m_board[i_rowNumber, i_columnNumber] == '\0';
        }

        public void PlaceSymbol(int i_rowNumber, int i_columnNumber, char i_symbolToPlace) //check if the if needed here or in the UI, static?
        {
            if (IsCellEmpty(i_rowNumber, i_columnNumber))
                m_board[i_rowNumber, i_columnNumber] = i_symbolToPlace;
        }

        public bool IsBoardFull() //static?
        {
            bool isBoardFull = true;
            for (int row = 0; row < m_boardSize; row++)
            {
                for (int column = 0; column < m_boardSize; column++)
                {
                    if (IsCellEmpty(row, column))
                    {
                        isBoardFull = false;
                    }
                }
            }
            return isBoardFull;
        }

        public bool HasWinningSequence(char i_symbolToCheck) //static?
        {
            bool hasRowSequence = true,hasColumnSequence = true, hasMainDiagonalSequence = true, hasSecondaryDiagonalSequence = true;

            for (int i = 0; i < m_boardSize; i++)
            {
                hasRowSequence = true;
                hasColumnSequence = true;

                for (int j = 0; j < m_boardSize; j++)
                {
                    if (m_board[i, j] != i_symbolToCheck)
                    {
                        hasRowSequence = false;
                        break;
                    }

                    if (m_board[j, i] != i_symbolToCheck)
                    {
                        hasColumnSequence = false;
                        break;
                    }
                }
            }


            for (int i = 0; i < m_boardSize; i++)
            {
                if (m_board[i, i] != i_symbolToCheck)
                {
                    hasMainDiagonalSequence = false;
                    break;
                }
            }

            for (int i = 0; i < m_boardSize; i++)
            {
                if (m_board[i, m_boardSize - 1 - i] != i_symbolToCheck)
                {
                    hasSecondaryDiagonalSequence = false;
                    break;
                }
            }

            return hasRowSequence || hasColumnSequence || hasMainDiagonalSequence || hasSecondaryDiagonalSequence;
        }
    }
}
