using System;

namespace BowlingBall
{
    public class Game
    {
        private int[] Rolls = new int[21];
        private int CurrentRoll = 0;

        public void Roll(int pins)
        {
            Rolls[CurrentRoll++] = pins;
        }

        public int GetScore()
        {
            int score = 0, frameIndex = 0;
            for (int frame = 0; frame < 10; frame++)
            {
                if (_isStrike(frameIndex))
                {
                    score += 10 + _strikeBonus(frameIndex);
                    frameIndex++;
                }
                else if (_isSpare(frameIndex))
                {
                    score += 10 + _spareBonus(frameIndex);
                    frameIndex += 2;
                }
                else
                {
                    score += _sumOfBallsInFrame(frameIndex);
                    frameIndex += 2;
                }
            }

            return score;
        }

        private int _sumOfBallsInFrame(int frameIndex)
        {
            return Rolls[frameIndex] + Rolls[frameIndex + 1];
        }

        private int _spareBonus(int frameIndex)
        {
            return 10 + Rolls[frameIndex + 1];
        }

        private int _strikeBonus(int frameIndex)
        {
            return 10 + Rolls[frameIndex + 1] + Rolls[frameIndex + 2];
        }

        private bool _isSpare(int frameIndex)
        {
            return Rolls[frameIndex] + Rolls[frameIndex + 1] == 10;
        }

        private bool _isStrike(int frameIndex)
        {
            return Rolls[frameIndex] == 10;
        }
    }
}