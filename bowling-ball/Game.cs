using System;

namespace BowlingBall
{
    public class Game
    {
        const int maximumRolls = 21;
        const int maximumFrames = 10;
        int[] rolls = new int[maximumRolls];
        int currentRoll = 0;
        public void Roll(int pins)
        {
            rolls[currentRoll++] = pins;
            //throw new NotImplementedException();
        }

        public int GetScore()
        {
            int score = 0;
            int frameIndex = 0;
            for(int frame = 0; frame < maximumFrames; frame++)
            {
                if(IsStrike(frameIndex))
                {
                    score += 10 + StrikeBonus(frameIndex);
                    frameIndex++;
                }
                else if(IsSpare(frameIndex))
                {
                    score += 10 + SpareBonus(frameIndex);
                    frameIndex += 2;
                }
                else
                {
                    score += CalculateFrameScore(frameIndex);
                    frameIndex += 2;
                }
            }
            return score;
            //throw new NotImplementedException();
        }

        private int CalculateFrameScore(int frameIndex)
        {
            return rolls[frameIndex] + rolls[frameIndex + 1];
            //throw new NotImplementedException();
        }

        private int SpareBonus(int frameIndex)
        {
            return rolls[frameIndex + 2];
            //throw new NotImplementedException();
        }

        private int StrikeBonus(int frameIndex)
        {
            return rolls[frameIndex + 1] + rolls[frameIndex + 2];
            //throw new NotImplementedException();
        }

        private bool IsSpare(int frameIndex)
        {
            return rolls[frameIndex] + rolls[frameIndex + 1] == 10;
            //throw new NotImplementedException();
        }

        private bool IsStrike(int frameIndex)
        {
            return rolls[frameIndex] == 10;
            //throw new NotImplementedException();
        }
    }
}

