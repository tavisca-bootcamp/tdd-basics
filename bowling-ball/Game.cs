using System;

namespace BowlingBall
{
    public class Game
    {
       
        public int[] ballRoll = new int[21];  //ball=10*2 + bonus=21
        public int[] frame = new int[10];  //number of frames=10
        int currentRoll = 0;
        //check if the bowling scoring is spare 
        public bool isSpare(int frameIndex)
        {
            return ballRoll[frameIndex] + ballRoll[frameIndex + 1] == 10;
        }

        //check if the bowling scoring is strike
        public bool isStrike(int frameIndex)
        {
            return ballRoll[frameIndex] == 10;
        }

        //record the number of pins in a ballRoll
        public void Roll(int pins)
        {
           ballRoll[currentRoll++] = pins;
        }
         
        //maintain an array
        public void Roll(int[] pins)
        {
            for (int i = 0; i < pins.Length; i++)
            {
                ballRoll[currentRoll++] = pins[i];
            }
        }

        public int Score()
        {
            int score = 0;
            int frameIndex = 0;
            for (int frame = 0; frame < 10; frame++)
            {
                if (isSpare(frameIndex))
                {
                    score += 10 + ballRoll[frameIndex + 2]; //first two index covered in spare(0,1) next score add=index value 2
                    frameIndex += 2;
                }
                else if (isStrike(frameIndex))
                {
                    score += 10 + ballRoll[frameIndex + 1] + ballRoll[frameIndex + 2];//add next two score
                    frameIndex++;
                }
                else
                {
                    score += ballRoll[frameIndex] + ballRoll[frameIndex + 1];//normal score
                    frameIndex += 2;
                }

            }

            return score;
        }

    }
}