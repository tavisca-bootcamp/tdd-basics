using System;

namespace BowlingBall
{
    public class Game
    {
        public const int MAX_BALLS = 21;
        public int[] rolls = new int[MAX_BALLS];
        int countRoll = 0;

        private bool IsSpare(int RollIndex) {
            if(rolls[RollIndex] + rolls[RollIndex + 1] == 10)
                return true;
            return false;
        }

        private bool IsStrike(int RollIndex)
        {
            if(rolls[RollIndex] == 10)
                return true;
            return false;
        }
        public void Roll(int pins)
        {
             rolls[countRoll++] = pins;
        }

        
        public int GetScore()
        {
            int score = 0;
            int RollIndex = 0;
            for (int frame = 0; frame < 10; frame++)
            {
                if(IsSpare(RollIndex))
                {
                    score += 10 + rolls[RollIndex + 2];
                    RollIndex += 2;
                } 
                else if(IsStrike(RollIndex))
                {
                    score += 10 + rolls[RollIndex + 1] + rolls[RollIndex + 2];
                    RollIndex++;
                }
                else
                {
                    score += rolls[RollIndex] + rolls[RollIndex + 1];
                    RollIndex += 2;
                }
                
            }

            if(RollIndex != countRoll)
            {
                if (IsStrike(RollIndex - 1) || IsSpare(RollIndex - 2))
                {

                }
                else
                    return -1;
            }
            
            return score;
        }

    }
}

