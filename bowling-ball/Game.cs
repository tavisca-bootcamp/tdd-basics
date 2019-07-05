using System;

namespace BowlingBall
{
    public class Game
    {
        private int pinIndex = 0;
        private const int MaxScore = 10;
        private const int TotalFrames = 10;
        public int[] rollsArray = new int[21];
        public void Roll(int pins)
        {
            rollsArray[pinIndex++] = pins;
        }

        public int GetScore()
        {
            int score = 0;
            int roll = 0;

            for(int frame = 0; frame < TotalFrames; frame++)
            {
                if(IsStrike(roll))
                {
                    score += MaxScore + StrikeBonus(roll);
                    roll++;
                }
                else if(IsSpare(roll))
                {
                    score += MaxScore + SpareBonus(roll); 
                    roll += 2;
                }
                else
                {
                    score += SumOfBallsInFrame(roll);
                    roll += 2;
                }
            }
            return score;
        }

        private int SumOfBallsInFrame(int roll)                             // return strike ball score
        {
            return rollsArray[roll] + rollsArray[roll + 1];
        }

        private int SpareBonus(int roll)                                    // return the spare ball score
        {
            return rollsArray[roll + 2];
        }

        private int StrikeBonus(int roll)                                   // return sum of consecutive rolls
        {
            return rollsArray[roll + 1] + rollsArray[roll + 2];
        }

        private bool IsStrike(int rollIndex)                                // return true if roll are strike(10)
        {
            return rollsArray[rollIndex] == MaxScore;
        }
        private bool IsSpare(int rollIndex)                                 // return true if rolls are spare
        {
            return (rollsArray[rollIndex] + rollsArray[rollIndex + 1]) == MaxScore;
        }

    }
}

