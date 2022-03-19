using System;

namespace TicTacToe
{
    /// <summary>
    /// Represents the TicTacToe game logic
    /// </summary>
    public class TicTacToe
    {
        public const int MAXIMUM_NUMBER_OF_MOVES = 9;
        private int numberOfMoves;
        private bool GameOver()
        {
            return numberOfMoves >= MAXIMUM_NUMBER_OF_MOVES;
        }

        public void Start()
        {
            UserInputReader userInputReader = new UserInputReader();
            Board board = new Board();
            
            Player startingPlayer = Player.one;
            Player currentPlayer = startingPlayer;
            Player winningPlayer = Player.none;

            numberOfMoves = 0;

            board.Print();

            while (winningPlayer == Player.none && !GameOver())
            {
                int[] coordinates = null;

                //Below infinte loop scans for user given coordinates
                while (true)
                {
                    coordinates = userInputReader.GetCoordinates($"Player {currentPlayer}, please enter coordinates");
                    if (coordinates == null)
                        continue; //Skips the remainder of the loop

                    Player playerOnField = board.GetAt(coordinates[0], coordinates[1]);
                    if (playerOnField == Player.none)
                        break; //Exists the loop
                    else Console.WriteLine($"Field already owned by player {playerOnField}. Please choose a different location");
                }

                numberOfMoves++;
                board.SetAt(coordinates[0], coordinates[1], currentPlayer);
               
                Console.Clear();
                board.Print();

                if (board.PlayerWon(currentPlayer))
                {
                    winningPlayer = currentPlayer;
                    break;
                }

                //Cycle trough players. 
                currentPlayer = 3 - currentPlayer;
            }

            if (winningPlayer == Player.none)
            {
                Console.WriteLine("Draw game");
            }
            else
            {
                Console.WriteLine($"Player {winningPlayer} won");
            }
        }
    }
}

