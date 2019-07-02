using System;
using Frames;

namespace BowlingBall
{
    internal class Score
    {
        const int totalFrames = 10;
        internal int CalculateScore(Frame[] frame)
        {
            int i, score = 0;
            for(i = 0; i < totalFrames; i++)
            {
                if(frame[i].IsStrike())
                {
                    score += frame[i].GetTotalKnockedPins() + GetStrikeBonus(i + 1, frame);
                }
                else if(frame[i].IsSpare())
                {
                    score += frame[i].GetTotalKnockedPins() + GetSpareBonus(i + 1, frame);
                }
                else
                {
                    score += frame[i].GetTotalKnockedPins();
                }
            }
            return score;
        }

        private int GetSpareBonus(int frameNumber, Frame[] frame)
        {
            return frame[frameNumber].GetNumberOfKnockedPinsInRollOne();
        }

        private int GetStrikeBonus(int frameNumber, Frame[] frame)
        {
            if(frame[frameNumber].IsStrike())
            {
                return frame[frameNumber].GetTotalKnockedPins() + frame[frameNumber + 1].GetNumberOfKnockedPinsInRollOne();
            }
            return frame[frameNumber].GetTotalKnockedPins();
        }
    }
}