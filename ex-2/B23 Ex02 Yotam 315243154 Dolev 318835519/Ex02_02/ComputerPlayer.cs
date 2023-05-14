using System;


namespace GameLogics
{
    class ComputerPlayer
    {
        private Random m_randomRow;
        private Random m_randomColumn;
        private Player m_computerPlayer;

        public ComputerPlayer(char i_symbol)
        {
            m_randomRow = new Random();
            m_randomColumn = new Random();
            m_computerPlayer = new Player(i_symbol, "Computer");
        }

        public char Symbol 
        {
            get { return m_computerPlayer.Symbol; } 
        }

        public string Name
        {
            get { return m_computerPlayer.Name; }
        }

        public int Score 
        {
            get { return m_computerPlayer.Score; }
            set { m_computerPlayer.Score = value; } 
        }

        public void GetMove(Board i_board, int o_rowPosition, int o_columnPosition)
        {
            int size = i_board.Size;

            do
            {
                o_rowPosition = m_randomRow.Next(0, size);
                o_columnPosition = m_randomColumn.Next(0, size);
            } while (i_board.IsCellEmpty(o_rowPosition, o_columnPosition));
        }
    }

}


