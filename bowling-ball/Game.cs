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
            for(int i = 0; i < rolls.Length; i++)
            {
                score += rolls[i];
            }

            return score;
        }

    }
}

