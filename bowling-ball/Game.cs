using System;

namespace BowlingBall
{
    public class Game
    {
        
        private int [] score = new int[21];
        private int count=0;

        public void Roll(int pins)
        {
            score[count] = pins;
            count++;
            throw new NotImplementedException();
        }

        public int GetScore()
        {
            throw new NotImplementedException();
        }

    }
}

