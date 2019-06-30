using System;
using System.Collections.Generic;
namespace BowlingBall
{
    public class Game
    {
        public int score = 0, current = 0;
        public int rounds = 0;
        public int[] Roll_values = new int[21];
        public void Roll(int pins)
        {
            Roll_values[current++] = pins;
        }
        public int GetScore()
        {
            int i, j;
            for (i = 0; i < current; i++)
            {
                if (rounds < 9)
                {
                    if (Roll_values[i] == 10)
                    {
                        score += Roll_values[i] + Roll_values[i + 1] + Roll_values[i + 2];
                        rounds++;
                    }
                    else
                    {
                        score += Roll_values[i];
                        i++;
                        if (Roll_values[i] == 10 - Roll_values[i - 1])
                            score += Roll_values[i] + Roll_values[i + 1];
                        else
                            score += Roll_values[i];
                        rounds++;
                    }
                }
                else
                {
                    for (j = i; j < current; j++)
                        score += Roll_values[j];
                    break;
                }
            }
            return score;
            //throw new NotImplementedException();
        }
    }
}

