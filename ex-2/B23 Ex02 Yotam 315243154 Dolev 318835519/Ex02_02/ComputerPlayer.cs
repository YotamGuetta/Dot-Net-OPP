using System;


namespace GameLogics
{    
    class ComputerPlayer
    {
            private Random m_random;
            private Player m_computerPlayer;

            public ComputerPlayer(char i_symbol, string i_playerName) 
            {
                m_random = new Random();
                m_computerPlayer = new Player(i_symbol, i_playerName)
            }

            public int GetMove(Board board)
            {
                int size = board.Size;
                int position;

                do
                {
                    position = random.Next(0, size * size);
                } while (board.IsPositionOccupied(position));

                return position;
            }
        }

    }
}

