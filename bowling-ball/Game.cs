using System;

namespace BowlingBall
{
    public class Game
    {
        private int[] frame = new int[10];
        private int [] score = new int[21];
        private int count=0;

        public void Roll(int pins)
        {
            score[count] = pins;
            count++;
           // throw new NotImplementedException();

        }

        public int GetScore()
        {
            int j = 0, x = 0;
            for(int i=0;i<10;i++)
            {
                if (score[j] + score[j + 1] == 10)
                {
                    frame[i] = x + 10 + score[j + 2];
                    j = j + 2;
                }
                else
                {
                    frame[i] = x + score[j] + score[j + 1];
                    j = j + 2;
                }
                    x = frame[i];
            }
            return frame[9];
            throw new NotImplementedException();
        }

    }
}

