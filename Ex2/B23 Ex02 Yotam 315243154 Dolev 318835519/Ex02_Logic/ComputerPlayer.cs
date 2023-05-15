using System;


namespace GameLogics
{
    class ComputerPlayer
    {
        private Random m_randomGenerator;
        private char m_computerSymbol;

        public ComputerPlayer(char i_symbol)
        {
            m_randomGenerator = new Random();
            m_computerSymbol = i_symbol;
        }

        public void SetComputerAction(Board i_board)
        {
            int o_rowPosition, o_columnPosition;
            int size = i_board.getSize();

            do
            {
                o_rowPosition = m_randomGenerator.Next(0, size);
                o_columnPosition = m_randomGenerator.Next(0, size);
            } while (!i_board.IsCellEmpty(o_rowPosition, o_columnPosition));
            i_board.PlaceSymbolInBoard(o_rowPosition, o_columnPosition, m_computerSymbol);
        }
    }
}


