using System;
namespace BowlingBall
{
    public class Frame
    {
        private int roll1;
        private int roll2;
        public bool isSpare = false;
        public bool isStrike = false;
        public Frame(int roll1,int roll2)
        {
            this.roll1 = roll1;
            this.roll2 = roll2;
        }
        public int Roll1 { get { return roll1; } }
        public int Roll2 { get { return roll2; } }

        public int TotalRoll()
        {
            return roll1 + roll2;
        }


    }
}
