using BowlingBall.Enums;

namespace BowlingBall {
    public interface IFrame {
        int Bonus { get; set; }
        int CurrentRollIndex { get; set; }
        int[] Rolls { get; set; }
        TypeOfFrames TypeOfFrame { get; set; }
        TypeOfFrameStates TypeOfFrameState { get; set; }

        int GetPinCount();
        void Roll(int pins);
    }
}