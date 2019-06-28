using System;
using System.Collections.Generic;

namespace BowlingBall
{
    public class Program{

        private static int InvalidInput = -1;

        public static void Main(string[] args){

            Console.WriteLine("Enter scores for the entire game");
            int[] Score = new int[21];
            for(int i = 0; i < 21; i++){
                Score[i] = (int.TryParse(Console.ReadLine(), out int element))?element : InvalidInput;
                if(Score[i] == InvalidInput){
                    Console.WriteLine($"{element} is not an integer");
                    return;
                }
            }
            Game bowlingGame = new Game();
            foreach(int ScoreValue in Score){
                bowlingGame.Roll(ScoreValue);
            }
            Console.WriteLine($"Final score is {bowlingGame.GetScore()}");
        }
    }
}