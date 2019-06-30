using System;

namespace BowlingBall
{
    public class Game
    {
        private int[] rolls;
        private int[] frames = new int[10];

        private int score = 0;
        private int currrentRoll = 0;

        public void Roll(int[] pins)
        {
            rolls = pins;
        }

        public void Roll(int pins)
        {
            rolls[currrentRoll++] = pins;
        }


        public int GetScore()
        {
            int rollIndex = 0;
            int frameIndex = 0;
            while(rollIndex < rolls.Length) { 
                if (IsSpare(rollIndex))
                {
                    SpareRoll(frameIndex, rollIndex);
                    rollIndex += 2;
                }
                else if (IsStrike(rollIndex))
                {
                    StrikeRoll(frameIndex, rollIndex);
                    rollIndex += 1;
                }
                else
                {
                    NormalRoll(frameIndex, rollIndex);
                    rollIndex += 2;
                }
                frameIndex++;
            }
            return score;
        }

        private bool IsSpare(int rollIndex)
        {
            return rolls.Length > rollIndex + 1 && (rolls[rollIndex] + rolls[rollIndex + 1]) == 10;
        }

        private bool IsStrike(int rollIndex)
        {
            return rolls[rollIndex] == 10;
        }

        private void NormalRoll(int frameIndex, int rollIndex)
        {
            if (rollIndex + 1 < rolls.Length)
            {
                score += rolls[rollIndex] + rolls[rollIndex + 1];
                frames[frameIndex] = rolls[rollIndex] + rolls[rollIndex + 1];
            }
            else
            {
                score += rolls[rollIndex];
                frames[frameIndex] = rolls[rollIndex];
            }
        }

        private void StrikeRoll(int frameIndex, int rollIndex)
        {
            if (rollIndex + 2 < rolls.Length)
            {
                score += 10 + rolls[rollIndex + 1] + rolls[rollIndex + 2];
                frames[frameIndex] = 10 + rolls[rollIndex + 1] + rolls[rollIndex + 2];
            }

            else if (rollIndex + 2 == rolls.Length)
            {
                score += 10 + rolls[rollIndex + 1];
                frames[frameIndex] = 10 + rolls[rollIndex + 1];
            }
            else
            {
                score += 10;
                frames[frameIndex] = 10;
            }
        }

        private void SpareRoll(int frameIndex, int rollIndex)
        {
            if (rollIndex + 2 < rolls.Length)
            {
                score += 10 + rolls[rollIndex + 2];
                frames[frameIndex] = 10 + rolls[rollIndex + 2];
            }
            else
            {
                score += 10;
                frames[frameIndex] = 10;
            }
        }
    }
}

