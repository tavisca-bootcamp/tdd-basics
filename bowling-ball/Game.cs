using System;

namespace BowlingBall
{
    public class Game
    {
        const int TOTALBOWLS = 21;
        const int TOTALFRAMES = 10;
        private int[] bowls = new int[TOTALBOWLS];
        private int currentBowl = 0;

        private bool IsSpare(int frameIndex)
        {
            return bowls[frameIndex] + bowls[frameIndex + 1] == 10;
        }

        private bool IsStrike(int frameIndex)
        {
            return bowls[frameIndex] == 10;
        }

        private int SpareBonus(int frameIndex)
        {
            return bowls[frameIndex+2];
        }

        private int StrikeBonus(int frameIndex)
        {
            return bowls[frameIndex+1] + bowls[frameIndex+2];
        }

        

        public void Roll(int pins)
        {
            bowls[currentBowl] = pins;
            currentBowl += 1;
        }

        private int SumOfPinsInFrame(int frameIndex)
        {
            return bowls[frameIndex] + bowls[frameIndex+1];
        }

        public int GetScore()
        {
            int totalScore = 0;
            int frameIndex = 0;

            for(int frame=0; frame < TOTALFRAMES; frame++)
            {
                if(IsStrike(frameIndex))
                {
                    totalScore += 10 + StrikeBonus(frameIndex);
                    frameIndex += 1;
                }
                else if(IsSpare(frameIndex))
                {
                    totalScore += 10 + SpareBonus(frameIndex);
                    frameIndex += 2;;
                }
                else
                {
                    totalScore += SumOfPinsInFrame(frameIndex);
                    frameIndex+=2;
                }
            }  
            return totalScore; 
        }

        
    }
}

