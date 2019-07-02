//Game for 4th test
using System;

namespace BowlingBall
{
    public class Game
    {
	   int count = 0;
	   int score = 0;
	   bool isSpare = false;
	   bool isStrike = false;
	   int prevPin = 0;
       int strikeCount = 2;    
    public void Roll(int pins)
        {
			count++;
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
			if(isStrike)
			{
			 score+=pins;
			 strikeCount--;
			 if(strikeCount==0)
			 {
				 isStrike = false;
				 strikeCount = 2;
			 }
			}
			if(pins==10)
			{
			 isStrike = true;
			 prevPin = 0;
			 return;
			}
			if(pins+prevPin==10)
			{
			  isSpare = true;
			}
		    if(count%2!=0)
			   prevPin = pins;
		    else if(count%2==0)
			   prevPin = 0;
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

