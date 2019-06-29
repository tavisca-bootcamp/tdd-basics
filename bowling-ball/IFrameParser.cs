using Rolls;

namespace Frames
{
    internal interface IFrameParser
    {
        Frame[] ParseFrame(Roll []roll);
        Frame GetFrame(int numberOfRolls, Roll []roll);
    }
}