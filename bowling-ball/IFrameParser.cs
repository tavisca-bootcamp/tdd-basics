using Rolls;

namespace Frames
{
    internal interface IFrameParser
    {
        Frame[] frameParser(Roll []roll);
        Frame getFrame(int numberOfRolls, Roll []roll);
    }
}