using System;
namespace BowlingBall
{
    public class Game
    {
        
        private int[] Chances = new int[21];
        private int ChanceFlag = 0;
        public void Roll(int pins)
        {
            Chances[ChanceFlag++] = pins;
        }

        public int GetScore()
        {
            int Result = 0;
            int FramePointer = 0;
            for (int i = 0; i < 10; i++)
            {
                if (Strike(FramePointer))
                {
                    Result = Result + 10 + StrikeBonus(FramePointer);
                    FramePointer++;
                }
                else if (Spare(FramePointer))
                {
                    Result =Result + 10 + SpareBonus(FramePointer);
                    FramePointer = FramePointer + 2;
                }
                else
                {
                    Result = Result + TotalBalls(FramePointer);
                    FramePointer = FramePointer + 2;
                }

            }

            return Result;
        }

        private int TotalBalls(int frameIndex)
        {
            return Chances[frameIndex] + Chances[frameIndex + 1];

        }

        private int SpareBonus(int frameIndex)
        {
            return Chances[frameIndex+2];
        }

        private int StrikeBonus(int frameIndex)
        {
            return Chances[frameIndex+1] + Chances[frameIndex+2];
        }

        private bool Strike(int frameIndex)
        {
            return int.Equals(10, Chances[frameIndex]);
        }

        
        private bool Spare(int frameIndex)
        {
            
            return int.Equals(10, Chances[frameIndex] + Chances[frameIndex+1]);
        }
    }
}   
