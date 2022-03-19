namespace TicTacToe
{
    /// <summary>
    /// Represents the state of the Board
    /// </summary>
    public class Board
    {
        /// <summary>
        /// Tic Tac Toe board
        /// </summary>
        private int[,] boardState = {
            {0, 0, 0},
            {0, 0, 0},
            {0, 0, 0}
        };
        public void Print()
        {
            int boardWidth = boardState.GetLength(0);
            int boardHeight = boardState.GetLength(1);

            for (int iy = 0; iy < boardHeight; iy++)
            {
                //Every Row
                for (int ix = 0; ix < boardWidth; ix++)
                {
                    Player theCurrentValue = (Player)boardState[ix, iy];

                    switch (theCurrentValue)
                    {
                        case Player.none:
                            Console.Write(' ');
                            break;
                        case Player.one:
                            Console.Write('X');
                            break;
                        case Player.two:
                            Console.Write('Y');
                            break;
                    }

                }
                Console.Write("\n");
            }
        }
        public void SetAt(int x, int y, Player value)
        {
            boardState[x, y] = (int)value;
        }

        public Player GetAt(int x, int y)
        {
            return (Player)boardState[x, y];
        }

        /// <summary>
        /// Fills the board
        /// </summary>
        /// <param name="symbol">sds</param>
        public void Fill(char symbol)
        {
            int boardWidth = boardState.GetLength(0);
            int boardHeight = boardState.GetLength(1);
            for (int iy = 0; iy < boardHeight; iy++)
            {
                for (int ix = 0; ix < boardWidth; ix++)
                {
                    boardState[ix, iy] = symbol;
                }
                Console.Write("\n");
            }
        }

        public bool PlayerWon(Player player)
        {
            if (player == Player.none)
            {
                return false;
            }

            int playerIndex = (int)player;

            //Row by row
            int boardWidth = boardState.GetLength(0);
            for (int i = 0; i < boardWidth; i++)
            {
                if (boardState[i, 0] == playerIndex
                    && boardState[i, 1] == playerIndex
                    && boardState[i, 2] == playerIndex)
                {
                    return true;
                }
            }

            //Column by Column
            int boardHeight = boardState.GetLength(1);
            for (int i = 0; i < boardHeight; i++)
            {
                if (boardState[0, i] == playerIndex
                    && boardState[1, i] == playerIndex
                    && boardState[2, i] == playerIndex)
                {
                    return true;
                }
            }

            //Diagonals
            return (
                (boardState[0, 0] == playerIndex && boardState[1, 1] == playerIndex && boardState[2, 2] == playerIndex) ||
                (boardState[2, 0] == playerIndex && boardState[1, 1] == playerIndex && boardState[0, 2] == playerIndex)
                );
        }


        public void Clear()
        {
            //Re-Initialize board
            boardState = new int[,]{
            { 0, 0, 0},
            { 0, 0, 0},
            { 0, 0, 0}};
        }


    }
}
