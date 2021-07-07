using System;

namespace BowlingBall
{
   public class Game
    {
        int[] Rolls = new int[21];
        int currentRoll = 0;

        public void Roll(int pins)
        {
            Rolls[currentRoll++]=pins;
        }

        public int GetScore()
        {
            var score = 0;
            var rollIndex = 0;

            for (int i = 0; i < 10; i++) {
                if (Rolls[rollIndex] == 10)
                {
                    score += Rolls[rollIndex] + Rolls[rollIndex + 1] + Rolls[rollIndex + 2];
                    rollIndex ++;
                }
                else if (Rolls[rollIndex] + Rolls[rollIndex + 1] == 10)
                {
                    score += Rolls[rollIndex] + Rolls[rollIndex + 1] + Rolls[rollIndex + 2];
                    rollIndex += 2;
                }
                else {
                    score += Rolls[rollIndex] + Rolls[rollIndex + 1];
                    rollIndex += 2;
                }
                
            }
            return score;
        }   
    }
}

