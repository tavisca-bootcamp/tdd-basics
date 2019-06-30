using System;
namespace BowlingBall
{
    public class Frame
    {
        public int Roll1;
        public int Roll2;
        public bool isSpare = false;
        public bool isStrike = false;
        public int bonusRoll;
        public Frame(int roll1,int roll2)
        {
            this.Roll1 = roll1;
            this.Roll2 = roll2;
        }

        public int TotalRoll()
        {
            return Roll1 + Roll2 + bonusRoll;
        }

    }
}
