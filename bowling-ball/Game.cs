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
                if (IsSpare(roll))
                    score += 10 + Rolls[roll + 2];
                else
                    score += Rolls[roll] + Rolls[roll + 1];
                roll += 2; //jump to next frame;
            }
            return score;
        }

        private bool IsSpare(int roll)
        {
            return Rolls[roll] + Rolls[roll + 1] == 10;
        }

    }
}

