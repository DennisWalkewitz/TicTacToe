namespace TicTacToe
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            TicTacToe game = new TicTacToe();
            game.Start();

            Console.ReadKey();
        }
    }
}

