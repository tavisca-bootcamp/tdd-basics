using System;

namespace BowlingBall
{
    public class Game
    {
        private int[] rolls = new int[21];
        private int currentRoll = 0;
        private const int MAXROLL = 21;
        public void Roll(int pins)
        {
            if (currentRoll < MAXROLL)
            {
                rolls[currentRoll++] = pins;

            }
        }

        public int GetScore()
        {
            int score = 0;
            currentRoll = 0;
            for (var frames = 1; frames <= 10; frames++)
            {
                if (IsStrike(currentRoll))
                {
                    score += GetScoreByRoll(currentRoll) + Bonus(currentRoll);
                    currentRoll++;
                }
                else if (IsSpare(currentRoll))
                {
                    score += GetScoreByRoll(currentRoll) + Bonus(currentRoll);
                    currentRoll += 2;
                }
                else
                {
                    score += GetScoreByRoll(currentRoll++);
                    score += GetScoreByRoll(currentRoll++);
                }
            }

            return score;
        }

        private bool IsStrike(int currentRoll)
        {
            return rolls[currentRoll] == 10;
        }

        private bool IsSpare(int currentRoll)
        {
            return rolls[currentRoll] + rolls[currentRoll + 1] == 10;
        }

        private int Bonus(int currentRoll)
        {
            return rolls[currentRoll + 1] + rolls[currentRoll + 2];
        }

        private int GetScoreByRoll(int currentRoll)
        {
            return rolls[currentRoll];
        }
    }
}

