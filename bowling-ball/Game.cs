using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BowlingBall
{
    public class Game
    {
        const int MAX_ROLLS = 21;
        const int MAX_FRAMES = 10;
        int[] roll_scores = new int[MAX_ROLLS];

        int currentRoll = 0;
        public void Roll(int pins)
        {
            roll_scores[currentRoll++] =pins;
        }

        public int GetScore()
        {
            var score = 0;
            int curIndex = 0;
            for (int frame=0; frame < MAX_FRAMES; frame++)
            {
                if (roll_scores[curIndex] == 10)
                {
                    score += roll_scores[curIndex] + roll_scores[curIndex + 1] + roll_scores[curIndex + 2];
                    curIndex++;
                }
                else if (roll_scores[curIndex] + roll_scores[curIndex + 1] == 10)
                {
                    score += roll_scores[curIndex] + roll_scores[curIndex + 1] + roll_scores[curIndex + 2];
                    curIndex += 2;
                }
                else
                {
                    score += roll_scores[curIndex] + roll_scores[curIndex + 1];
                    curIndex += 2;
                }
            }
            return score;
        }

    }
}
