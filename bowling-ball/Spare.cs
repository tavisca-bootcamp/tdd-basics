using System;
namespace BowlingBall
{
    public class Spare : Frame
    {
        public Spare(int roll1, int roll2) : base(roll1, roll2)
        {
            this.isSpare = true;
        }
    }
}
