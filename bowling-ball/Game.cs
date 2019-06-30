using System;
using System.Collections.Generic;
using System.Text;
namespace BowlingBall
{
    public class Game
    {
        private int score = 0;
        // Maximum no. of rolls (9 * 2 + 3 = 21) considering all frames
        public int[] rolling = new int[21];

       
        private int currentRoll = 0;

        public void Roll(int pins)
        {
            rolling[currentRoll++] = pins;
        }

        public int GetScore()
        {
            int rollIndex = 0;
            CheckingHits check = new CheckingHits(rolling);
            for (int frame = 0; frame < 10; frame++, rollIndex += 2)
            {
                if (check.IsSpare(rollIndex))
                    score += 10 + check.GetSpareBonus(rollIndex);

                else if (check.IsStrike(rollIndex))
                {
                    score += 10 + check.GetStrikeBonus(rollIndex);
                    rollIndex--;
                }

                else
                    score += rolling[rollIndex] + rolling[rollIndex + 1];

               // Console.WriteLine(score); // to see score progess
            }
            return score;
            
        }

    }
}

