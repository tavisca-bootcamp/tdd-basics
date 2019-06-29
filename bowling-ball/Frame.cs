using Rolls;

namespace Frames
{
    public class Frame
    {
        public const int totalFrames = 12;
        private Roll one;
        private Roll two;

        private bool strike = false;

        private bool spare = false;

        public Frame(Roll one)
        {
            this.one = one;
            this.two = Roll.zero();
            this.strike = true;
        }

        public Frame(Roll one, Roll two)
        {
            this.one = one;
            this.two = two;
            if(one.getNumberOfKnockedPins() + two.getNumberOfKnockedPins() == 10)
            {
                this.spare = true;
            }
        }

        public int getNumberOfKnockedPinsInRollOne()
        {
            return one.getNumberOfKnockedPins();
        }

        public int getTotalKnockedPins()
        {
            return one.getNumberOfKnockedPins() + two.getNumberOfKnockedPins();
        }

        public bool isSpare()
        {
            return spare;
        }

        public bool isStrike()
        {
            return strike;
        }
    }
}