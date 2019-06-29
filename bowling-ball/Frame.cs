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
            this.two = Roll.Zero();
            this.strike = true;
        }

        public Frame(Roll one, Roll two)
        {
            this.one = one;
            this.two = two;
            if(one.GetNumberOfKnockedPins() + two.GetNumberOfKnockedPins() == 10)
            {
                this.spare = true;
            }
        }

        public int GetNumberOfKnockedPinsInRollOne()
        {
            return one.GetNumberOfKnockedPins();
        }

        public int GetTotalKnockedPins()
        {
            return one.GetNumberOfKnockedPins() + two.GetNumberOfKnockedPins();
        }

        public bool IsSpare()
        {
            return spare;
        }

        public bool IsStrike()
        {
            return strike;
        }
    }
}