using System;

namespace BowlingBall
{
    class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Enter score or 'q' for quit");
            string score;
            int[] playerScore = new int[21];
            for(int i = 0; i < 21; i++){
                score = Console.ReadLine();
                if(score == "q")
                    break;
                playerScore[i] = int.Parse(score);
            }

            Game game = new Game();
            foreach (var roll in playerScore)
            {
                game.Roll(roll);
            }

            int finalScore = game.GetScore();
            System.Console.WriteLine($"Maximum score = {finalScore}");
        }
    }
}