using System;

namespace BowlingBall
{
    class Program
    {
        public static void Main(string[] args)
        {
            Game game = new Game();

            int[] playerScore = {10, 9, 1, 5, 5, 7, 2, 10, 10, 10, 9, 0, 8, 2, 9, 1, 10};

            foreach (var score in playerScore)
            {
                game.Roll(score);
            }

            System.Console.WriteLine($"Maximum score = {game.GetScore()}");
        }
    }
}