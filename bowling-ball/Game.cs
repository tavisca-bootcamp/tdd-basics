using System;
using System.Collections.Generic;

namespace BowlingBall
{
    public class Game
    {
        private int[] rolls = new int[21];
        private int rollCount = 0;

        public void Roll(int pins)
        {
            rolls[rollCount++] = pins;
        }
        public int GetScore()
        {
            int score = 0;
            int rollIndex = 0;
            for (int frame = 0; frame < 10; frame++)
            {
                if (IsStrike(rollIndex))
                {
                    score += 10 + StrikeBonus(rollIndex);
                    rollIndex += 1;

                }
                else if (IsSpare(rollIndex))
                {
                    score += 10 + rolls[rollIndex + 2];
                    rollIndex += 2;
                }
                else
                {
                    score += SumOfPinsInFrame(rollIndex);
                    rollIndex += 2;
                }
            }
            return score;
        }

        private bool IsStrike(int rollIndex)
        {
            return rolls[rollIndex] == 10;
        }

        private int SumOfPinsInFrame(int rollIndex)
        {
           return rolls[rollIndex] + rolls[rollIndex + 1];
        }

        private int StrikeBonus(int rollIndex)
        {
            return rolls[rollIndex + 1] + rolls[rollIndex + 2];
        }

        private bool IsSpare(int rollIndex)
        {
            return rolls[rollIndex] + rolls[rollIndex + 1] == 10;
        }
    }
}

