using System;

namespace BowlingBall
{
    public class Game
    {
         int[] rolls = new int[21];
        int currentBall = 0;
        //int score = 0;
        public void Roll(int pins)
        {
            rolls[currentBall++] = pins;
        }
       public int GetScore()
        {
            int score = 0;
            int RollIndex = 0;
            for(int i=0;i<10;i++)
            {
                if (IsStrike(RollIndex))
                {
                    score += StrikeScore(RollIndex);
                    RollIndex++;
                }
                else if (IsSpare(RollIndex))
                {
                    score += SpareScore(RollIndex);
                    RollIndex = +2;
                }
                else
                {
                    score += NormalScore(RollIndex);
                    RollIndex = +2;
                }
            }
            return score;
        }

      
       public bool IsSpare(int rollIndex)
        {
            if ((rolls[rollIndex] + rolls[rollIndex + 1]) == 10)
            {
                return true;
            }
            else
            {
                return false;
            }

        }
        private bool IsStrike(int rollIndex)
        {
            if (rolls[rollIndex] == 10)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private int NormalScore(int rollIndex)
        {
            return rolls[rollIndex] + rolls[rollIndex + 1];
        }
        private int SpareScore(int rollIndex)
        {
            return rolls[rollIndex] + rolls[rollIndex + 1] + rolls[rollIndex + 2];

        }
        private int StrikeScore(int rollIndex)
        {
            return rolls[rollIndex] + rolls[rollIndex + 1] + rolls[rollIndex + 2];
        }

    }
}

