using System;

namespace BowlingBall
{
    public class Game
    {
        private const int maxPossibleRolls = 21;
        private const int maxPossibleFrames = 10;
        private int[] rollScore = new int[maxPossibleRolls];
        private int[] frameScore = new int[maxPossibleFrames];
        private int rollNumber = 0;

        public void Roll(int pins)
        {
            rollScore[rollNumber] = pins;
            rollNumber++;
        }

        public int GetScore()
        {
            int score = 0;
            int currentRoll = 0;

            for(int frame=0; frame<maxPossibleFrames; frame++)
            {
                if(CheckForStrike(currentRoll) == true)
                {
                    score += rollScore[currentRoll] + rollScore[currentRoll + 1] + rollScore[currentRoll + 2];
                    frameScore[frame] = score;
                    currentRoll++;
                }
                else if (CheckForSpare(currentRoll) == true)
                {
                    score += rollScore[currentRoll] + rollScore[currentRoll + 1] + rollScore[currentRoll + 2];
                    frameScore[frame] = score;
                    currentRoll += 2;
                }
                else
                {
                    score += rollScore[currentRoll] + rollScore[currentRoll + 1];
                    frameScore[frame] = score;
                    currentRoll += 2;
                }
            }

            return score;
        }

        private bool CheckForStrike(int currentRoll)
        {
            if (rollScore[currentRoll] == 10)
                return true;
            else
                return false;
        }

        private bool CheckForSpare(int currentRoll)
        {
            if ((rollScore[currentRoll] + rollScore[currentRoll + 1]) == 10)
                return true;
            else
                return false;
        }

    }
}

