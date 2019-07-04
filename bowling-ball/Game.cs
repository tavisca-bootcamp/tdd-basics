using System;

namespace BowlingBall
{
    public class Game
    {
        private int[] rolls = new int[21];
        private int[] frame = new int[10];
        int currentRoll = 0;
        
        public int GetScore()
        {
            int score = 0;
            int indexFrame = 0;
            for (int frame = 0; frame < 10; frame++)
            {
                if (IsSpare(indexFrame))
                {
                    score += 10 + rolls[indexFrame + 2];
                    indexFrame += 2;
                }
                else if (IsStrike(indexFrame))
                {
                    score += 10 + rolls[indexFrame + 1] + rolls[indexFrame + 2];
                    indexFrame++;
                }
                else
                {
                    score += rolls[indexFrame] + rolls[indexFrame + 1];
                    indexFrame += 2;
                }   
            }
            return score;
        }

        public void Roll(int pins)
        {
            rolls[currentRoll++] = pins;
        }

        public void Roll(int[] pins)
        {
            for(int indexPins = 0; indexPins < pins.Length; indexPins++)
                rolls[currentRoll++] = pins[indexPins];
        }
        private bool IsSpare(int indexFrame)
        {
            return rolls[indexFrame] + rolls[indexFrame + 1] == 10;
        }

        private bool IsStrike(int indexFrame)
        {
            return rolls[indexFrame] == 10;
        }
    }
}

