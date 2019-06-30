using System;

namespace BowlingBall
{
    public class Game
    {
        private int rollsIndex = 0;
        private const int MaxScore = 10;
        private const int TotalFrames = 10;
        public int[] rollsArray = new int[21];
        public void Roll(int pins)
        {
            rollsArray[rollsIndex++] = pins;
        }

        public int GetScore()
        {
            int score = 0;
            int roll = 0;

            for(int frame = 0; frame < TotalFrames; frame++)
            {
                if(IsStrike(roll))
                {
                    score += MaxScore + rollsArray[roll + 1] + rollsArray[roll + 2];
                    roll++;
                }
                else if(IsSpare(roll))
                {
                    score += MaxScore + rollsArray[roll + 2]; 
                    roll += 2;
                }
                else
                {
                    score += rollsArray[roll] + rollsArray[roll + 1];
                    roll += 2;
                }
            }
            return score;
        }

        private bool IsStrike(int rollIndex)
        {
            return rollsArray[rollIndex] == MaxScore;
        }

        private bool IsSpare(int rollIndex)
        {
            return (rollsArray[rollIndex] + rollsArray[rollIndex + 1]) == MaxScore;
        }

    }
}
