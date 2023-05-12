using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameLogics
{
    public class Board
    {
        private char[,] m_board;
        private int m_size; //static?

        public Board(int i_size)
        {
            this.m_size = i_size;
            m_board = new char[i_size, i_size];
        }
        public int Size
        {
            get { return m_size; }
        }

        public void ClearBoard()
        {
            m_board = new char[m_size, m_size];
        }

        public bool IsCellEmpty(int i_row, int i_col)
        {
            return m_board[i_row, i_col] == '\0';
        }

        public void PlaceSymbol(int i_row, int i_col, char i_symbol)
        {
            m_board[i_row, i_col] = i_symbol;
        }

        public bool IsBoardFull() ///v_?
        {
            for (int v_row = 0; v_row < m_size; v_row++)
            {
                for (int v_col = 0; v_col < m_size; v_col++)
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
            bool columnSequence = true;
            bool rowSequence;
            bool diagonalSequence = true;

            for (int i = 0; i < m_size; i++)
            {
                rowSequence = true;
                for (int j = 0; j < m_size; j++)
                {
                    if (m_board[i, j] != symbol)
                        rowSequence = false;
                }
            }

            for (int j = 0; j < m_size; j++)
            {
                if (CheckSequence(m_board, 0, j, 1, 0, m_size))
                    return true;
            }

            if (CheckSequence(m_board, 0, 0, 1, 1, m_size) ||
                CheckSequence(m_board, 0, m_size - 1, 1, -1, m_size))
                return true;

            return false;
        } /// change
    }
}
