using System;

namespace BowlingBall
{
    public class Game
    {
        private int score = 0;
        public void RollFrame(int roll1, int roll2)
        {
            score += (roll1 + roll2);
        }

        public int GetScore()
        {
            return score;
        }

    }
}

