using System;

namespace BowlingBall
{
    public class Game
    {
        private int[] rolls;
        private int currentRoll;

        public Game()
        {
            rolls = new int[21];
            currentRoll = 0;
        }
        public void Roll(int pins)
        {
            rolls[currentRoll++] = pins;
        }

        public int GetScore()
        {
            int score = 0;
            int rollIndex = 0;
            for(int frame = 0; frame < 10; frame++)
            {
                if(IsStrike(rollIndex))
                {
                    score += 10 + GetStrikeBonus(rollIndex);
                    rollIndex++;
                }
                else if(IsSpare(rollIndex))
                {
                    score += 10 + GetSpareBonus(rollIndex);
                    rollIndex += 2;
                }
                else
                {
                    score += GetFrameScore(rollIndex);
                    rollIndex += 2;
                }
            }
            return score;
        }

        public bool IsStrike(int rollIndex)
        {
            return rolls[rollIndex] == 10;
        }

        public bool IsSpare(int rollIndex)
        {
            return (rolls[rollIndex] + rolls[rollIndex + 1]) == 10;
        }

        public int GetStrikeBonus(int rollIndex)
        {
            return rolls[rollIndex + 1] + rolls[rollIndex + 2];
        }

        public int GetSpareBonus(int rollIndex)
        {
            return rolls[rollIndex + 2];
        }

        public int GetFrameScore(int rollIndex)
        {
            return rolls[rollIndex] + rolls[rollIndex + 1];
        }
    }
}
