using System;

namespace BowlingBall
{
    public class Game
    {
        int score = 0;
        int[] rolls = new int[21];
        int[] frames = new int[10];
        int counter = 0;

        public void Roll(int pins)
        {
            rolls[counter++] = pins;
        }

        public int GetScore()
        {
            CalcScore();
            for (int i = 0; i < frames.Length; i++)
            {
                score += frames[i];
            }            
            return score;
        }

        private void CalcScore()
        {
            int i = 0;
            for (int j = 0; j < 10; j++)
            {
                if (rolls[i] == 10)
                {
                    frames[j] = 10 + rolls[i + 1] + rolls[i + 2];
                    i++;
                }
                else if (rolls[i] + rolls[i + 1] == 10)
                {
                    frames[j] = 10 + rolls[i + 2];
                    i += 2;
                }
                else
                {
                    frames[j] = rolls[i] + rolls[i + 1];
                    i += 2;
                }
            }
        }
    }
}

