using Rolls;

namespace Frames
{
    internal class FrameParser : IFrameParser
    {
        private Frame []frame;

        public FrameParser()
        {
            frame = new Frame[Frame.totalFrames];
        }
        public Frame[] ParseFrame(Roll[] roll)
        {
            int i, numberOfRolls = 0;
            for (i = 0; i < Frame.totalFrames && numberOfRolls < roll.Length; i++)
            {
                frame[i] = GetFrame(numberOfRolls, roll);
                numberOfRolls += frame[i].IsStrike() ? 1 : 2;
            }
            return frame;
        }

        public Frame GetFrame(int numberOfRolls, Roll[] roll)
        {
            Roll rollOne = roll[numberOfRolls];
            Frame f;
            if(rollOne.GetNumberOfKnockedPins() == 10)
            {
                f = new Frame(rollOne);
                return f;
            }

            if(numberOfRolls + 1 >= roll.Length)
            {
                f = new Frame(rollOne, Roll.Zero());
                return f;
            }
            Roll rollTwo = roll[numberOfRolls + 1];
            f = new Frame(rollOne, rollTwo);
            return f;
        }
    }
}