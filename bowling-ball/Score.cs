using System;
using Frames;

namespace BowlingBall
{
    internal class Score
    {
        const int totalFrames = 10;
        internal int calculateScore(Frame[] frame)
        {
            int i, score = 0;
            for(i = 0; i < totalFrames; i++)
            {
                if(frame[i].isStrike())
                {
                    score += frame[i].getTotalKnockedPins() + getStrikeBonus(i + 1, frame);
                }
                else if(frame[i].isSpare())
                {
                    score += frame[i].getTotalKnockedPins() + getSpareBonus(i + 1, frame);
                }
                else
                {
                    score += frame[i].getTotalKnockedPins();
                }
            }
            return score;
        }

        private int getSpareBonus(int frameNumber, Frame[] frame)
        {
            return frame[frameNumber].getNumberOfKnockedPinsInRollOne();
        }

        private int getStrikeBonus(int frameNumber, Frame[] frame)
        {
            if(frame[frameNumber].isStrike())
            {
                return frame[frameNumber].getTotalKnockedPins() + frame[frameNumber + 1].getNumberOfKnockedPinsInRollOne();
            }
            return frame[frameNumber].getTotalKnockedPins();
        }
    }
}