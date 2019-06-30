using System;
using System.Collections.Generic;

namespace BowlingBall
{
    public class Game
    {
        private const int MaximumNumberOfRolls = 21;
        private const int NumberOfFrames = 10;
        private const int NextFrame = 2;
        int[] rolls = new int[MaximumNumberOfRolls];

        int rollsIndex = 0;

        private const int MaxScore = 10;

        public void Roll(int pins)
        {
            rolls[rollsIndex++] = pins;
        }

        public int GetScore()
        {
            int score = 0;
            int roll = 0;
            for (int i = 0; i < NumberOfFrames; i++)
            {
                if (IsStrike(roll))
                {
                    score += StrikeSum(roll);
                    roll++;
                }
                else if (IsSpare(roll))
                {
                    score += SpareSum(roll);
                    roll += NextFrame;
                }
                else
                {
                    score += Sum(roll);
                    roll += NextFrame;
                }
            }
            return score;
        }

        private int Sum(int roll)
        {
            return rolls[roll] + rolls[roll + 1];
        }

        private bool IsStrike(int roll)
        {
            return rolls[roll] == MaxScore;
        }

        private bool IsSpare(int roll)
        {
            return rolls[roll] + rolls[roll + 1] == MaxScore;
        }

        private int StrikeSum(int roll)
        {
            return MaxScore + rolls[roll + 1] + rolls[roll + 2];
        }
        private int SpareSum(int roll)
        {
            return MaxScore + rolls[roll + 2];
        }
    }
}
