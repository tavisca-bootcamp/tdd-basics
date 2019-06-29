using System;

namespace BowlingBall
{
    public class Game
    {
        public int score = 0;
        public void Roll(int pins)
        {
            score += pins;
        }

        public int GetScore()
        {
            return score;
        }

    }
}

