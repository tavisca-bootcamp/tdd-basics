using System;

namespace BowlingBall
{
    public class Game
    {
        int[] Rolls = new int[21];

        public void Roll(int[] pins)
        {
            int i=0;
            foreach(int iterator in pins)
            {
                Rolls[i]=iterator;
                i=i+1;
            }
        }

        public int GetScore()
        {
            int score = 0;
            int FrameIndex = 0;
            for (int i = 0; i < 10; i++) {
                if (IsStrike(FrameIndex)) {
                    score = score + 10 + StrikeBonus(FrameIndex);
                    FrameIndex = FrameIndex + 1;
                } else if (IsSpare(FrameIndex)) {
                    score =score + 10 + SpareBonus(FrameIndex);
                    FrameIndex = FrameIndex + 2;
                } else {
                    score = score + SumOfBallsInFrame(FrameIndex);
                    FrameIndex = FrameIndex + 2;
                }
            }
            return score;
        }

        private bool IsStrike(int frameIndex) {
            return (Rolls[frameIndex] == 10);
        }

        private bool IsSpare(int frameIndex) {
            return (Rolls[frameIndex] + Rolls[frameIndex+1] == 10);
        }

        private int SumOfBallsInFrame(int frameIndex) {
            return (Rolls[frameIndex] + Rolls[frameIndex+1]);
        }

        private int SpareBonus(int frameIndex) {
            return (Rolls[frameIndex+2]);
        }

        private int StrikeBonus(int frameIndex) {
            return (Rolls[frameIndex+1] + Rolls[frameIndex+2]);
        }
    }
}

