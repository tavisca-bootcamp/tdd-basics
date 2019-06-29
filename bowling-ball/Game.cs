using System;

namespace BowlingBall
{
    public class Game
    {
        public int score = 0;
        public int count = 1;
        public int buffer = 0;
        public int valid = 0;
        public void Roll(int pins)
        {
            if (valid != 0)
            {
                score += pins;
                valid--;
            }
            if(count%2==1)
            {
                buffer = pins;
            }
            else
            {
                buffer += pins;
                if (buffer == 10)
                {
                    valid = 1;
                    if (pins == 0)
                        valid = 3;
                }
                
            }

            score += pins;
            count++;
        }

        public int GetScore()
        {
            return score;
        }

    }
}

