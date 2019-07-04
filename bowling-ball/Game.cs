using System;
using System.Collections.Generic;

namespace BowlingBall
{
    public class Game
    {
        private int score = 0;
        private List<int> rolls = new List<int>(21);
        private int currentRoll = 0;

        public Game() {
            for (var i = 0; i < 21; i++) {
                rolls.Add(0);
            }
        }

        public void Roll(int pins)
        {
            //throw new NotImplementedException();
            rolls[currentRoll++] = pins;

        }

        public int GetScore()
        {
            //throw new NotImplementedException();
            int frameIndex = 0;
            for (int frame = 0; frame < 10; frame++) {
                if (IsStrike(frameIndex))
                {
                    score += 10 + StrikeBonus(frameIndex);
                    frameIndex++;
                }
                else if(IsSpare(frameIndex))
                {
                    score += 10 + SpareBonus(frameIndex);
                    frameIndex += 2;
                }
                else {
                    score += NormalFrameBonus(frameIndex);
                    frameIndex += 2;
                }
            }
            return score;
        }

        private bool IsSpare(int frameIndex) {
            if (rolls[frameIndex] + rolls[frameIndex + 1] == 10)
                return true;
            else return false;
        }
        private bool IsStrike(int frameIndex)
        {
            if (rolls[frameIndex] == 10)
                return true;
            else return false;
        }

        private int StrikeBonus(int frameIndex) {
            return rolls[frameIndex + 1] + rolls[frameIndex + 2];
        }

        private int SpareBonus(int frameIndex)
        {
            return rolls[frameIndex + 2];
        }

        private int NormalFrameBonus(int frameIndex)
        {
            return rolls[frameIndex] + rolls[frameIndex + 1];
        }
    }
}

