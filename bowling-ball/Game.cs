using System;

namespace BowlingBall
{
    
    public class Game
    {
        private int[] Rolls = new int[21];
        private int currentRoll;
        public void Roll(int pins)
        {
            Rolls[currentRoll++] = pins;
        }

        public int GetScore()
        {
            int score = 0;
            int roll = 0;
            for (int frame = 1; frame <= 10; frame++)
            {
                if(IsStrike(roll))// strike bonus 2 next rolls so first check for strike.
                {
                    score += 10 + StrikeBonus(roll);
                    roll++;
                }
                else if (IsSpare(roll))
                {
                    score += 10 + SpareBonus(roll);
                    roll += 2;
                }
                    
                else
                {
                    score += SumOfBallInFrame(roll);
                    roll += 2;
                }

                
            }
            return score;
        }

        private bool IsSpare(int roll)
        {
            return Rolls[roll] + Rolls[roll + 1] == 10;
        }
        private bool IsStrike(int roll)
        {
            return Rolls[roll] == 10;
        }
        private int StrikeBonus(int roll)
        {
            return Rolls[roll + 1] + Rolls[roll + 2];
        }
        private int SpareBonus(int roll)
        {
            return Rolls[roll + 2];
        }
        private int SumOfBallInFrame(int roll)
        {
            return Rolls[roll] + Rolls[roll + 1];
        }

    }
}

