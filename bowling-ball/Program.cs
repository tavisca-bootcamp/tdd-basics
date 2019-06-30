using System;

namespace BowlingBall
{
    class Program
    {
        public static void Main(string[] args)
        {
            Game game = new Game();

            int[] scoreArray = {3, 5, 1, 5, 7, 1, 10, 1, 6, 10, 6, 2, 1, 2, 0, 5, 8, 1};

            foreach (var score in scoreArray)
            {
                game.Roll(score);
            }

            System.Console.WriteLine($"Score : {game.GetScore()}");
        }
    }
}