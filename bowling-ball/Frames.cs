using System;
using System.Collections.Generic;
using System.Text;

namespace BowlingBall
{
    class Frames : IFrames
    {
        int[] EachFrame = new int[2];
        const int LowestPossibleValue = 0;
        const int HighestPossibleValue = 10;
        const int EmptyFrame = -1;

        public Frames()
        {
            this.EachFrame[0] = -1;
            this.EachFrame[1] = -1;
        }

        public void SetFrame(int pin, int indexStatus) => this.EachFrame[indexStatus] = pin;

        public int GetFrame(int indexStatus) => this.EachFrame[indexStatus];

        public int CalculateScore()
        {
            return EachFrame[0] + EachFrame[1];
        }

        public bool IsSpare()
        {
            return ((this.EachFrame[0] + this.EachFrame[1]) == 10) ? true : false;
        }

        public bool IsStrike()
        {
            return (this.EachFrame[0] == 10 || this.EachFrame[1] == 10) ? true : false;
        }

        public int SpareBonus()
        {
            return this.EachFrame[0];
        }

        public int StrikeBonus()
        {
            return this.EachFrame[0] + this.EachFrame[1];
        }

        public bool CheckValidInput()
        {
            if (this.EachFrame[0] >= LowestPossibleValue && this.EachFrame[0] <= HighestPossibleValue &&
                this.EachFrame[1] >= LowestPossibleValue && this.EachFrame[1] <= HighestPossibleValue)
                return true;
            return false;
        }

        public bool CheckForEmptyFrame()
        {
            if (this.EachFrame[0] == EmptyFrame || this.EachFrame[1] == EmptyFrame)
                return true;
            return false;
        }
    }
}
