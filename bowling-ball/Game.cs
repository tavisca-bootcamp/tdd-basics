//  Game with Test2
using System;

namespace BowlingBall
{
    public class Game
    {
	   int score = 0;
	   bool isSpare = false;
	   int prevPin = 0;
        public void Roll(int pins)
        {
			if(pins==0)
			{		
     		score += 0;
			return;
			}
			score+=pins;
				if(isSpare)
			{
				score+=pins;
				isSpare = false;
			}
			if(pins+prevPin==10)
			{
			  isSpare = true;
			}
		
			prevPin = pins;
			return;
            throw new NotImplementedException();
        }

        public int GetScore()
        {
			return score;
            throw new NotImplementedException();
        }

    }
}

