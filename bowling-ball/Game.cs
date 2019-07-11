using System;

namespace BowlingBall
{
    public class Game
    {
        private int score = 0;
        private int[] rolls;
        private int currentRoll = 0;

        public Game()
        {
            rolls = new int[21];
        }
        public void Roll(int pins)
        {
            score += pins;
            rolls[currentRoll++] = pins; 
        }

        public int GetScore()
        {
            int score = 0;
            int frameIndex = 0;
            for(int frame=0; frame<10; frame++)
            {
                if (IsStrike(frameIndex))
                {
                    score += 10 + rolls[frameIndex + 1] + rolls[frameIndex + 2];
                    frameIndex++;
                }
                else if (IsSpare(frameIndex))
                {
                    score += 10 + rolls[frameIndex + 2];
                    frameIndex += 2;
                }
                else
                {
                    score += rolls[frameIndex] + rolls[frameIndex + 1];
                    frameIndex += 2;
                }
            }
            return score;
        }

        private bool IsSpare(int frameIndex)
        {
            return (rolls[frameIndex] + rolls[frameIndex + 1] == 10);
        }

        private bool IsStrike(int frameIndex)
        {
            return (rolls[frameIndex] == 10);
        }

    }
}

