using System;
using System.Collections.Generic;

namespace BowlingBall
{
    public class Game
    {
        List<int> rolls;
        public Game() {
            rolls = new List<int>();
        }
        public void Roll(int pinsKnocked) {
            rolls.Add(pinsKnocked);
        }
        public int GetScore() {
            var bowlingScore = 0;
            var currentRoll = 0;
            for (var frame = 0; frame < 10; frame++) {
                if (IsStrike(currentRoll)) {
                    bowlingScore += rolls[currentRoll] + rolls[currentRoll + 1] + rolls[currentRoll + 2];
                    currentRoll++;
                }
                else if (IsSpare(currentRoll)) {
                    bowlingScore += 10 + rolls[currentRoll + 2];
                    currentRoll += 2;
                }
                else {
                    bowlingScore += rolls[currentRoll] + rolls[currentRoll + 1];
                    currentRoll += 2;
                }
            }
            return bowlingScore;
        }
        public void Roll(int[] pins) {
            for (int i = 0; i < pins.Length; i++)
                rolls.Add(pins[i]);
        }
        private bool IsSpare(int roll) {
            return rolls[roll] + rolls[roll + 1] == 10;
        }
        private bool IsStrike(int roll) {
            return rolls[roll] == 10;
        }
    }
}