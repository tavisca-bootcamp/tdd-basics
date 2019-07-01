using System;

namespace BowlingBall
{
    public class Game
    {
        private int[] rolls = new int[21];
        private int currentRoll = 0;
        
        public void Roll(int pins)
        {
            rolls[currentRoll++] = pins;
        }

        public int GetScore()
        {
            int score = 0;
            int frameIdx = 0;
            for(int frame = 0; frame < 10; frame++)
            {
                if (IsStrike(frameIdx))
                {
                    score += 10 + StrikeBonus(frameIdx);
                    frameIdx++;
                }else if (IsSpare(frameIdx))
                {
                    score += 10 + SpareBonus(frameIdx);
                    frameIdx += 2;
                }
                else
                {
                    score += SumOfRolls(frameIdx);
                    frameIdx += 2;
                }

                
            }

            return score;
        }

        private bool IsSpare(int frameIdx)
        {
            if (rolls[frameIdx] + rolls[frameIdx + 1] == 10)
                return true;
            else
                return false;
        }
        private int SpareBonus(int frameIdx)
        {
            return rolls[frameIdx + 2];
        }
        private bool IsStrike(int frameIdx)
        {
            if (rolls[frameIdx] == 10)
                return true;
            else
                return false;
        }
        private int StrikeBonus(int frameIdx)
        {
            return rolls[frameIdx + 1] + rolls[frameIdx + 2];
        }
        private int SumOfRolls(int frameIdx)
        {
            return rolls[frameIdx] + rolls[frameIdx + 1];
        }
    }
}

