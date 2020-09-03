using BowlingBall.Enums;
using System;

namespace BowlingBall {
    public class Frame : IFrame {
        int currentRollIndex;
        int bonus;
        int[] rolls;
        TypeOfFrameStates typeOfFrameState;
        TypeOfFrames typeOfFrame;

        public TypeOfFrames TypeOfFrame {
            get { return typeOfFrame; }

            set {
                if (value == TypeOfFrames.Final) {
                    Rolls = new int[] { 0, 0, 0 };
                }
                typeOfFrame = value;
            }
        }
        public TypeOfFrameStates TypeOfFrameState { get { return typeOfFrameState; } set { typeOfFrameState = value; } }
        public int Bonus { get { return bonus; } set { bonus = value; } }
        public int[] Rolls { get { return rolls; } set { rolls = value; } }
        public int CurrentRollIndex { get { return currentRollIndex; } set { currentRollIndex = value; } }

        public Frame() {
            Rolls = new int[] { 0, 0 };
            TypeOfFrameState = TypeOfFrameStates.NotAttempted;
            CurrentRollIndex = -1;
            Bonus = 0;
        }

        public void Roll(int pins) {
            Rolls[++CurrentRollIndex] = pins;

            if (Rolls[0] == 10) {
                TypeOfFrameState = TypeOfFrameStates.Strike;
            } else if (Rolls[0] + Rolls[1] == 10) {
                TypeOfFrameState = TypeOfFrameStates.Spare;
            } else if (CurrentRollIndex == 1) {
                TypeOfFrameState = TypeOfFrameStates.Attempted;
            }

            if (Rolls[0] + Rolls[1] > 10 && typeOfFrame != TypeOfFrames.Final) {
                throw new InvalidOperationException();
            }
        }

        public int GetPinCount() {
            if (typeOfFrame == TypeOfFrames.Final) {
                return Rolls[0] + Rolls[1] + Rolls[2];
            } else {
                return Rolls[0] + Rolls[1];
            }
        }
    }
}
