using System;

namespace BowlingBall
{
    public class Game
    {
        private int[] rolls = new int[21];
        private int currentRoll = 0;
        
        public void Roll(int pins)
        {
            rolls[currentRoll++] = pins;
        }

        public int GetScore()
        {
            int score = 0;
            int frameIdx = 0;
            for(int frame = 0; frame < 10; frame++)
            {
                score += rolls[frameIdx] + rolls[frameIdx + 1];
                frameIdx += 2;
            }

            return score;
        }

    }
}

