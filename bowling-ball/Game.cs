using System;

namespace BowlingBall
{
    public class Game
    {
        private int score = 0;
        private int[] rolls;
        private int[] frames = new int[10];
        private int currentRoll = 0;


        public void InitializeRoll(int[] rollsVal)
        {
            rolls = rollsVal;
        }

        public void Roll(int pins)
        {
            rolls[currentRoll++] = pins; 
        }

        public int GetScore()
        {
            int rollCounter = 0;
            int frameCounter = 0;
            while(rollCounter < rolls.Length){

                // Condition for a strike
                if(rolls[rollCounter] == 10)
                {
                    // adding 10 with score of next two rolls
                    if(rolls.Length > rollCounter + 2)
                    {
                        score += 10 + rolls[rollCounter + 1] + rolls[rollCounter + 2];
                        frames[frameCounter] = 10 + rolls[rollCounter + 1] + rolls[rollCounter + 2];
                    }

                    else if (rollCounter + 2 == rolls.Length)
                    {
                        score += 10 + rolls[rollCounter + 1];
                        frames[frameCounter] = 10 + rolls[rollCounter + 1];
                    }
                    else
                    {
                        score += 10;
                        frames[frameCounter] = 10;
                    }
                    

                    // incrementing rollCounter by 1 as next roll will be for next frame
                    rollCounter += 1;
                }
                // Condition for a spare
                else if(rolls.Length > rollCounter + 1 && (rolls[rollCounter] + rolls[rollCounter + 1] ) == 10){

                    // If this is not the last roll
                    // adding 10 with score of next roll i.e. first roll of next frame
                    if (rolls.Length > rollCounter + 2)
                    {
                        score += 10 + rolls[rollCounter + 2];
                        frames[frameCounter] = 10 + rolls[rollCounter + 2];
                    }
                    // If this is the last roll
                    // Add 10 for the current and last roll
                    else
                    {
                        score += 10;
                        frames[frameCounter] = 10;
                    }
                    
                    // incrementing rollCounter by 2 as 2 rolls are of same frame and next roll will be in the next frame
                    rollCounter += 2;
                }
                // Condition for normal roll
                else
                {
                    // if this is not the last roll
                    if(rolls.Length > rollCounter + 1)
                    {
                        score += rolls[rollCounter] + rolls[rollCounter + 1];
                        frames[frameCounter] = rolls[rollCounter] + rolls[rollCounter + 1];
                    }
                    // if this is the last roll
                    else
                    {
                        score += rolls[rollCounter];
                        frames[frameCounter] = rolls[rollCounter];
                    }
                    
                    rollCounter += 2;
                }
                //
                frameCounter++;
            }
            return score;
        }

    }
}

