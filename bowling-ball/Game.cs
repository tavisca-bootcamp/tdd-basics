using System;

namespace BowlingBall
{
    public class Game
    {
        const int MAXIMUM_ROLL_SIZE = 21;
        const int MAXIMUM_FRAME_SIZE = 10;
        int[] rolls = new int[MAXIMUM_ROLL_SIZE];
        int[] frameScore = new int[MAXIMUM_FRAME_SIZE + 1];
        int currentRoll = 0;
        public void Roll(int pins)
        {
            rolls[currentRoll] = pins;
            currentRoll++;
        }

        public int GetScore()
        {
            int rollsIndex = 0;
            frameScore[0] = 0;
            for (int frameIndex = 1; frameIndex <= MAXIMUM_FRAME_SIZE; frameIndex++)
            {
                if (isStrike(rollsIndex))
                {
                    frameScore[frameIndex] = frameScore[frameIndex - 1] + 10 + strikeBonus(rollsIndex);
                    rollsIndex++;
                }
                else if (isSpare(rollsIndex))
                {
                    frameScore[frameIndex] = frameScore[frameIndex - 1] + 10 + spareBonus(rollsIndex);
                    rollsIndex += 2;
                }
                else
                {
                    frameScore[frameIndex] = frameScore[frameIndex - 1] + sumOfBallsInTheFrame(rollsIndex);
                    rollsIndex += 2;
                }
            }
            return frameScore[frameScore.Length - 1];
        }

        private bool isSpare(int rollsIndex)
        {
            return rolls[rollsIndex] + rolls[rollsIndex + 1] == 10;
        }

        private int spareBonus(int rollsIndex)
        {
            return rolls[rollsIndex + 2];
        }

        private int sumOfBallsInTheFrame(int rollsIndex)
        {
            return rolls[rollsIndex] + rolls[rollsIndex + 1];
        }

        private int strikeBonus(int rollsIndex)
        {
            return rolls[rollsIndex + 1] + rolls[rollsIndex + 2];
        }

        private bool isStrike(int rollsIndex)
        {
            return rolls[rollsIndex] == 10;
        }
    }
}

