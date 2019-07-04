using System;
using System.Collections.Generic;
using System.Text;

namespace BowlingBall
{
    public interface IFrames
    {
        void SetFrame(int pin, int indexStatus);
        int GetFrame(int indexStatus);
        int CalculateScore();
        bool IsSpare();
        bool IsStrike();
        int SpareBonus();
        int StrikeBonus();
        bool CheckValidInput();
        bool CheckForEmptyFrame();
    }
}
