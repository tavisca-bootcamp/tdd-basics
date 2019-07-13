using System;
using System.Collections.Generic;
using System.Text;

namespace BowlingBall {
    public class Frame {
        public int firstRoll;
        public int secondRoll;
        public int thirdRoll;
        public bool isSpare;
        public bool isStrike;
        public int rollCount;
        public Frame() {
            this.firstRoll = 0;
            this.secondRoll = 0;
            this.thirdRoll = 0;
            this.isSpare = false;
            this.isStrike = false;
            this.rollCount = 0;
        }
        public void FirstRoll(int pinsKnocked) {
            this.firstRoll = pinsKnocked;
            if (pinsKnocked == 10) {
                this.isStrike = true;
            }
            this.rollCount = 1;
        }
        public void SecondRoll(int pinsKnocked) {
            this.secondRoll = pinsKnocked;
            if (this.firstRoll + this.secondRoll == 10) {
                this.isSpare = true;
            }
            this.rollCount = 2;
        }
        public void ThirdRoll(int pinsKnocked) {
            this.thirdRoll = pinsKnocked;
            this.rollCount = 3;
        }

        public int FrameTotal() {
            return firstRoll + secondRoll + thirdRoll;
        }
        public int SpareBonus(Frame nextFrame) {
            return nextFrame.firstRoll;
        }
        public int StrikeBonus(Frame nextFrame) {
            return nextFrame.firstRoll + nextFrame.secondRoll;
        }
        public int DoubleStrikeBonus(Frame nextFrame,Frame postNextFrame) {
            return nextFrame.firstRoll + postNextFrame.firstRoll;
        }
    }
}
