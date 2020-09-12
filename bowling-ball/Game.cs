using System;

namespace BowlingBall
{
    public class Game
    {
        
        private int[] rolls = new int[21];
        private int currentRoll=0;
        public void Roll(int pins)
        {
            //throw new NotImplementedException();
            rolls[currentRoll++] = pins;

        }

        public int GetScore()
        {
            //throw new NotImplementedException();
            int score = 0;
            int frameIndex = 0;
            for (int frame = 0; frame < 10; frame++)
            {
                if (isStrike(frameIndex)) 
                {
                    score += 10 + StrikeBonus(frameIndex);
                    frameIndex++;
                }

                else if (isSpare(frameIndex))
                {
                    score += 10 + spareBonus(frameIndex);
                    frameIndex += 2;
                }
                else
                {
                    score += sumOfBallsInFrame(frameIndex);
                    frameIndex += 2;
                }
            }    
            return score;
        }
        private Boolean isSpare(int frameIndex)
        {
            return rolls[frameIndex] + rolls[frameIndex + 1] == 10;
        }
        private Boolean isStrike(int frameIndex)
        {
            return rolls[frameIndex] == 10;
        }
        private int spareBonus(int frameIndex)
        {
            return rolls[frameIndex + 2];
        }

        private int StrikeBonus(int frameIndex)
        {
            return rolls[frameIndex + 1] + rolls[frameIndex + 2];   
        }
        private int sumOfBallsInFrame(int frameIndex)
        {
            return rolls[frameIndex] + rolls[frameIndex + 1];
        }











    }
}

