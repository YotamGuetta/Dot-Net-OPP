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

        public bool IsCellEmpty(int i_row, int i_col)
        {
            return m_board[i_row, i_col] == '\0';
        }

        public void PlaceSymbol(int i_row, int i_col, char i_symbol) //check if the if needed here or in the UI
        {
            if (IsCellEmpty(i_row, i_col))
                m_board[i_row, i_col] = i_symbol;
        }

        public bool IsBoardFull() ///v_?
        {
            for (int v_row = 0; v_row < m_boardSize; v_row++)
            {
                for (int v_col = 0; v_col < m_boardSize; v_col++)
                {
                    if (IsCellEmpty(v_row, v_col))
                    {
                        return false;
                    }
                }
            }
            return true;
        }

        public bool HasWinningSequence(char symbol)
        {
            for (int i = 0; i < m_boardSize; i++)
            {
                bool rowSequence = true;
                for (int j = 0; j < m_boardSize; j++)
                {
                    if (m_board[i, j] != symbol)
                    {
                        rowSequence = false;
                        break;
                    }
                }

                if (rowSequence)
                    return true;
            }

            for (int i = 0; i < m_boardSize; i++)
            {
                bool columnSequence = true;
                for (int j = 0; j < m_boardSize; j++)
                {
                    if (m_board[j, i] != symbol)
                    {
                        columnSequence = false;
                        break;
                    }
                }

                if (columnSequence)
                    return true;
            }

            bool diagonalSequence = true;
            for (int i = 0; i < m_boardSize; i++)
            {
                if (m_board[i, i] != symbol)
                {
                    diagonalSequence = false;
                    break;
                }
            }

            if (diagonalSequence)
                return true;

            diagonalSequence = true;
            for (int i = 0; i < m_boardSize; i++)
            {
                if (m_board[i, m_boardSize - 1 - i] != symbol)
                {
                    diagonalSequence = false;
                    break;
                }
            }

            return diagonalSequence;
        }
    }
}
