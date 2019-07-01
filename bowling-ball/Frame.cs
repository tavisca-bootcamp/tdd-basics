using System;
namespace BowlingBall
{
    public class Frame
    {
        public int tryRoll1;
        public int tryRoll2;
        public bool isSpare = false;
        public bool isStrike = false;
        public int bonusRoll;
        public Frame(int roll1,int roll2)
        {
            this.tryRoll1 = roll1;
            this.tryRoll2 = roll2;
        }

        public int TotalRoll()
        {
            return tryRoll1 + tryRoll2 + bonusRoll;
        }

    }
}
