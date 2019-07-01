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
                if (isSpare(frame))
                    score += SpareBonus(frame);
                
                score += rolls[frameIdx] + rolls[frameIdx + 1];
                frameIdx += 2;
            }

            return score;
        }

        private int SpareBonus(int frame)
        {
            return rolls[frame + 2];
        }

        private bool isSpare(int frame)
        {
            if (rolls[frame] + rolls[frame + 1] == 10)
                return true;
            else
                return false;
        }

    }
}

