using System;

namespace BowlingBall
{
    public class Game
    {
        private int[] roll = new int[21];
        private int currentroll = 0;

        public void Roll(int pins)
        {
            roll[currentroll++] = pins;
        }
        public void Roll(int[] pins)
        {
            for (int i = 0; i < pins.Length; i++)
            {
                roll[currentroll++] = pins[i];
            }
        }

        public int GetScore()
        {
            int score = 0;
            int index = 0;
            for (int frame = 0; frame < 10; frame++)
            {
                if (roll[index] == 10)
                {
                    score += 10 + roll[index + 1] + roll[index + 2];
                    index += 1;

                }
                else if (roll[index] + roll[index + 1] == 10)
                {
                    score += 10 + roll[index + 2];
                    index += 2;
                }
                else
                {
                    score += roll[index] + roll[index + 1];
                    index += 2;
                }
            }
            return score;
        }


        //throw new NotImplementedException();


    }
}

