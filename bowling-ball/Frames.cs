using System;
using System.Collections.Generic;
using System.Text;

namespace BowlingBall
{
    class Frames : IFrames
    {
        int[] EachFrame = new int[2];

        public Frames()
        {
            this.EachFrame[0] = 0;
            this.EachFrame[1] = 0;
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

    }
}
