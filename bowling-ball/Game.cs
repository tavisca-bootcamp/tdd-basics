using System;

namespace BowlingBall
{
    public class Game
    {
        //to store points in the game
        int[] frame = new int[21];
        //for accessing frame array for storing the rolled pins
        int framePointer = 0;
        //for maintaining score
        int totalScore = 0;
        public void Roll(int pins)
        {
            if (pins < 0 || pins > 10)
                throw new ArgumentException("Enter pin between 1 to 10 both inclusive");

            frame[framePointer++] = pins;
        }

        public int GetScore()
        {
            int index = 0;
            for(int frameNumber = 0; frameNumber < 10; frameNumber++)
            {
                // Case when it is a strike
                if(IsStrike(index))
                {
                    totalScore = totalScore + 10 + BonusForStrike(index);
                    index++;
                }
                // Case when it is a spare
                else if(IsSpare(index))
                {
                    totalScore = totalScore + 10 + BonusForSpare(index);
                    index = index + 2;
                }
                // Calculate normal score
                else
                {
                    totalScore = totalScore + CurrentScore(index);
                    index = index + 2;
                }
            }

            return totalScore;
        }

        public bool IsSpare(int index)
        {
            return frame[index] + frame[index + 1] == 10;
        }

        public bool IsStrike(int index)
        {
            return frame[index] == 10;
        }

        public int BonusForSpare(int index)
        {
            //For spare, bonus is current roll point plus next roll point
            return frame[index + 2];
        }
        
        public int BonusForStrike(int index)
        {
            //For strike, bonus is current roll point plus next two rolls point
            return frame[index + 1] + frame[index + 2];
        }

        public int CurrentScore(int index)
        {
            return frame[index] + frame[index + 1];
        }

    }
}

