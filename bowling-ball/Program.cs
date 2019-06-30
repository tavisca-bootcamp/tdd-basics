using System;
using System.Collections.Generic;

namespace BowlingBall
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Enter scores :");
            var inputArray = Console.ReadLine().Split(' ');
            var scoreArray = new int[21];
            for (int i = 0; i < inputArray.Length; i++) {
                scoreArray[i] = int.Parse(inputArray[i]);
            }
            Game bowlingGame = new Game();
            foreach(int scoreValue in scoreArray){
                bowlingGame.Roll(scoreValue);
            }
            Console.WriteLine($"Final score : {bowlingGame.GetScore()}");
        }
    }
}