using System;

namespace BowlingBall
{
    public class Game
    {
         int[] pinsCollector = new int[21];

        int currentRollIndex = 0;


        public void Roll(int pins)
        {
            if(pins>0 && pins <100)
            {
                pinsCollector[currentRollIndex++] = pins;
            }
            else
            {
                throw new ArgumentException("the pin values should be 1 to 99");
            }
        }

        public int GetScore()
        {
            int scoreForRolls = 0;

            int frameIndex = 0;

            for(int frame = 0; frame < 10; frame++)
            {
                if(IsStrike(frameIndex))
                {
                    scoreForRolls += 10 + pinsCollector[frameIndex + 1] + pinsCollector[frameIndex + 2];
                    frameIndex++;
                }
                else if(IsSpare(frameIndex))
                {
                    scoreForRolls += 10 + pinsCollector[frameIndex + 2];
                    frameIndex += 2;
                }
                else
                {
                    scoreForRolls += pinsCollector[frameIndex] + pinsCollector[frameIndex + 1];
                    frameIndex += 2;
                }
            }

            return scoreForRolls;
        }

        public bool IsStrike(int frameIndex)
        {
            return pinsCollector[frameIndex] == 10;
        }

        public bool IsSpare(int frameIndex)
        {
            return pinsCollector[frameIndex] + pinsCollector[frameIndex + 1] == 10;
        }
        
    }
}

