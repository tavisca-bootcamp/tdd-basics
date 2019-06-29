using System;

namespace BowlingBall
{
    
    public class Game
    {
        private int score;
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

