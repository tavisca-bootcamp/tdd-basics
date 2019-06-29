using System;
using System.Collections.Generic;
namespace BowlingBall
{
    public class Game
    {
        List<int>rolls = new List<int>(21);
        int currentRoll = 0;
        public Game()
        {
            for (int i = 0; i < 22; i++)
                rolls.Add(0);
        }
        public void Roll(int pins)
        {
            rolls[currentRoll++] = pins;
        }

        public int GetScore()
        {
            int score = 0;
            int frameIndex = 0;
            for(int frame = 0; frame < 10; frame++)
            {
                if (rolls[frameIndex] == 10) //Condition for strike
                {
                    score += 10 + rolls[frameIndex + 1] + rolls[frameIndex + 2];
                    frameIndex++;
                }
                else if(rolls[frameIndex] + rolls[frameIndex + 1] == 10) //Condition for spare
                {
                    score += 10 + rolls[frameIndex + 2];
                    frameIndex += 2;
                }
                else
                {
                    score += rolls[frameIndex] + rolls[frameIndex + 1];
                    frameIndex += 2;
                }
            }
            return score;
        }

    }
}

