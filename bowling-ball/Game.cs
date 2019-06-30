using System;

namespace BowlingBall
{
    public class Game
    {
        const int MAXIMUM_ROLL_SIZE = 21;           // Maximum no. of rolls (9*2 + 3 = 21) considering all frames
        const int MAXIMUM_FRAME_SIZE = 10;          // Maximum no. of frames
        int[] rolls = new int[MAXIMUM_ROLL_SIZE];   // Array to store the pins knockdown in each roll
        int[] frameScore = new int[MAXIMUM_FRAME_SIZE + 1]; // Array to store the updated score of each frame
        int currentRoll = 0;        // Counter to update the rolls array indexes

        public void Roll(int pins)
        {
            rolls[currentRoll] = pins;
            currentRoll++;
        }

        public int GetScore()
        {
            int rollsIndex = 0;
            frameScore[0] = 0;  // Dummy frame to which always store Zero (0) value
            /*
                1-based indexing for frameScore Array.
            */
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

        /*
            Utillty functions to check spare/strike and update score.
        */

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

