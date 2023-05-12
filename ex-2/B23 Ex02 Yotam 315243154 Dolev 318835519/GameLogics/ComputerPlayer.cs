using System;


namespace GameLogics
{    
    class ComputerPlayer
    {
            private Random m_random;
        private Player m_computerPlayer;

            public ComputerPlayer(char symbol) : base(symbol)
            {
                random = new Random();
            }

            public override int GetMove(Board board)
            {
                int size = board.GetSize();

                int position;
                do
                {
                    position = random.Next(0, size * size);
                } while (board.IsPositionOccupied(position));

                Console.WriteLine($"Player {Symbol} chooses position {position}");
                return position;
            }
        }

        public class Program
        {
            public static void Main(string[] args)
            {
                Game game = new Game();
                game.Start();
            }
        }
    }
}

