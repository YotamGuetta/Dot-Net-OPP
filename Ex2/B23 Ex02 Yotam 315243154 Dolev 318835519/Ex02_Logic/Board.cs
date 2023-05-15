
namespace GameLogics
{
    public class Board
    {
        private readonly char[,] r_board;
        private int r_boardSize;

        public int getSize() 
        {
            return r_boardSize;
        }

        public Board(int i_size)
        {
            this.r_boardSize = i_size;
            r_board = new char[i_size, i_size];
            for (int i = 0; i < r_boardSize; i++)
            {
                for (int j = 0; j < r_boardSize; j++)
                {
                    r_board[i, j] = ' ';
                }
            }

        }
        public void ClearBoard()
        {
            for (int i = 0; i < r_boardSize; i++)
            {
                for (int j = 0; j < r_boardSize; j++)
                {
                    r_board[i, j] = ' ';
                }
            }
        }

        public void GetBoardState(out char[,] board)
        {
            board = this.r_board;
        }

        public bool IsCellEmpty(int i_rowNumber, int i_columnNumber)
        {
            return r_board[i_rowNumber, i_columnNumber] == ' ';
        }

        public bool PlaceSymbolInBoard(int i_rowNumber, int i_columnNumber, char i_symbolToPlace)
        {
            bool placeableSymbol = false;
            if (IsCellEmpty(i_rowNumber, i_columnNumber))
            {
                r_board[i_rowNumber, i_columnNumber] = i_symbolToPlace;
                placeableSymbol = true;
            }
            return placeableSymbol;
        }

        public bool IsBoardFull()
        {
            bool isBoardFull = true;
            for (int row = 0; row < r_boardSize; row++)
            {
                for (int column = 0; column < r_boardSize; column++)
                {
                    if (IsCellEmpty(row, column))
                    {
                        isBoardFull = false;
                        break;
                    }
                }
                if (!isBoardFull) 
                {
                    break;
                }
            }
            return isBoardFull;
        }


        public bool HasWinningSequence(char i_symbolToCheck)
        {
            bool hasMainDiagonalSequence = true, hasSecondaryDiagonalSequence = true;

            for (int i = 0; i <  r_boardSize; i++)
            {
                bool hasRowSequence = true;
                bool hasColumnSequence = true;

                for (int j = 0; j < r_boardSize; j++)
                {
                    if (r_board[i, j] != i_symbolToCheck)
                    {
                        hasRowSequence = false;
                    }

                    if (r_board[j, i] != i_symbolToCheck)
                    {
                        hasColumnSequence = false;
                    }
                }

                if (hasRowSequence || hasColumnSequence) 
                {
                    return (hasRowSequence || hasColumnSequence);
                }
            }


            for (int i = 0; i < r_boardSize; i++)
            {
                if (r_board[i, i] != i_symbolToCheck)
                {
                    hasMainDiagonalSequence = false;
                    break;
                }
            }

            if (hasMainDiagonalSequence)
            {
                return hasMainDiagonalSequence;
            }

            for (int i = 0; i < r_boardSize; i++)
            {
                if (r_board[i, r_boardSize - 1 - i] != i_symbolToCheck)
                {
                    hasSecondaryDiagonalSequence = false;
                    break;
                }
            }

            return hasSecondaryDiagonalSequence;
        }
    }
}
