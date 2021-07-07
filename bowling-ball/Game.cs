using System;

namespace BowlingBall
{
    public class Game
    { 
        private int[] rolls = new int[21];
        private int currentIndex = 0;
        public void Roll(int pins)
        { 
          rolls[currentIndex]=pins;
          currentIndex++;  
        }
       private bool FindStrike(int rollIndex)
		{
			return (rolls[rollIndex] == 10);
		}

		private bool FindSpare(int rollIndex)
		{
			return (rolls[rollIndex] + rolls[rollIndex+1] == 10);
		}


        public int GetScore()
        { int score=0;
          int rollIndex=0;

            for(int i=0;i<10;i++){

             if(FindSpare(rollIndex)){
                    score += 10 + rolls[rollIndex+2];
					rollIndex += 2;
             }else if(FindStrike(rollIndex)){
                    score += 10 + rolls[rollIndex+1]+ rolls[rollIndex+2];
					rollIndex += 1;
             }else{
                 score+=(rolls[rollIndex]+rolls[rollIndex+1]);
                 rollIndex+=2;
             }

            }

         return score;
        }


    }
}

