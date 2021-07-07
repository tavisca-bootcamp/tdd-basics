using System;

namespace BowlingBall
{
    public class Game
    {
        private int[] bowlingRoll = new int[21];
        private int currentRoll = 0;
        private int score = 0;
        public void Roll(int pins)
        {
            bowlingRoll[currentRoll] = pins;
            currentRoll++;
            //throw new NotImplementedException();
        }

        public int GetScore()
        {
            int rollCount = 0;
            int frameNumber=0;
            while (frameNumber < 10)            
            {
                if (bowlingRoll[rollCount] == 10)
                {
                    score = score + GetStrikeScore(rollCount);
                    rollCount++;
                }
                else if ((bowlingRoll[rollCount] + bowlingRoll[rollCount + 1]) == 10)
                {
                    score = score + GetSpareScore(rollCount);
                    rollCount = rollCount + 2;
                }
                else
                {
                    score = score + bowlingRoll[rollCount] + bowlingRoll[rollCount + 1];
                    rollCount = rollCount + 2;
                }
                frameNumber++;
            }
            return score;
        }
        public int GetStrikeScore(int rollCount)
        {
            int strikeScore = bowlingRoll[rollCount] + bowlingRoll[rollCount + 1] + bowlingRoll[rollCount + 2];
            return strikeScore;
        }
        public int GetSpareScore(int rollCount)
        {
            int spareScore = bowlingRoll[rollCount] + bowlingRoll[rollCount + 1] + bowlingRoll[rollCount + 2];
            return spareScore;
        }

        //throw new NotImplementedException();

    }
}

