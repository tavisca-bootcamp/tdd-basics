﻿using System;

namespace BowlingBall
{
    public class Game
    {
        private int[] _rolls = new int[21];
        private int _currentRoll = 0;

        public void Roll(int pins)
        {
            _rolls[_currentRoll] = pins;
            _currentRoll++;
        }

        public int GetScore()
        {
            int score = 0;
            int frameIndex = 0;
            for (int frame = 0; frame < 10; frame++) {
                if (IsStrike(frameIndex)) {
                    score += 10 + StrikeBonus(frameIndex);
                    frameIndex += 1;
                } else if (IsSpare(frameIndex)) {
                    score += 10 + SpareBonus(frameIndex);
                    frameIndex += 2;
                } else {
                    score += SumOfBallsInFrame(frameIndex);
                    frameIndex += 2;
                }
            }
            return score;
        }

        private bool IsStrike(int frameIndex) {
            return _rolls[frameIndex] == 10;
        }

        private int SumOfBallsInFrame(int frameIndex) {
            return _rolls[frameIndex] + _rolls[frameIndex+1];
        }

        private int SpareBonus(int frameIndex) {
            return _rolls[frameIndex+2];
        }

        private int StrikeBonus(int frameIndex) {
            return _rolls[frameIndex+1] + _rolls[frameIndex+2];
        }

        private bool IsSpare(int frameIndex) {
            return _rolls[frameIndex] + _rolls[frameIndex+1] == 10;
        }

    }
}

