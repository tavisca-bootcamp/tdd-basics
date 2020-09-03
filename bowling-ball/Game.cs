using BowlingBall.Enums;
using System;

namespace BowlingBall {
    public class Game : IGame {
        Frame[] frames;
        int currentFrameIndex;
        int score;

        public int Score { get => score; set => score = value; }
        public int CurrentFrameIndex { get => currentFrameIndex; set => currentFrameIndex = value; }
        public Frame[] Frames { get => frames; set => frames = value; }

        public Game() {
            Frames = new Frame[10];
            CurrentFrameIndex = 0;
            Score = 0;
        }

        public void Roll(int pins) {
            if (Frames[CurrentFrameIndex] == null) {
                Frames[CurrentFrameIndex] = new Frame();
                //Check for final frame
                Frames[CurrentFrameIndex].TypeOfFrame = CurrentFrameIndex == 9 ? TypeOfFrames.Final : TypeOfFrames.Normal;
            }

            Frames[CurrentFrameIndex].Roll(pins);

            if (Frames[CurrentFrameIndex].TypeOfFrameState != TypeOfFrameStates.NotAttempted && Frames[CurrentFrameIndex].TypeOfFrame != TypeOfFrames.Final) {
                CurrentFrameIndex++;
            }
        }

        public int GetScore() {
            CalculateFrameBonus();
            CalculateTotalScore();
            return Score;
        }

        private void CalculateTotalScore() {
            Score = 0;
            for (int frameIndex = 0; frameIndex < 10; frameIndex++) {
                Score += Frames[frameIndex].GetPinCount() + Frames[frameIndex].Bonus;
            }
        }

        private void CalculateFrameBonus() {
            try {
                for (int frameIndex = 0; frameIndex < 10; frameIndex++) {
                    //Strike
                    if (Frames[frameIndex].TypeOfFrameState == TypeOfFrameStates.Strike && Frames[frameIndex].TypeOfFrame != TypeOfFrames.Final) {
                        if (Frames[frameIndex + 1].TypeOfFrame != TypeOfFrames.Final) {
                            if (Frames[frameIndex + 1].TypeOfFrameState == TypeOfFrameStates.Strike) {
                                Frames[frameIndex].Bonus = Frames[frameIndex + 1].Rolls[0] + Frames[frameIndex + 2].Rolls[0];
                            } else {
                                Frames[frameIndex].Bonus = Frames[frameIndex + 1].Rolls[0] + Frames[frameIndex + 1].Rolls[1];
                            }
                        } else {//for second last frame
                            Frames[frameIndex].Bonus = Frames[frameIndex + 1].Rolls[0] + Frames[frameIndex + 1].Rolls[1];
                        }
                    }

                    //Spare
                    if (Frames[frameIndex].TypeOfFrameState == TypeOfFrameStates.Spare && Frames[frameIndex].TypeOfFrame != TypeOfFrames.Final) {
                        Frames[frameIndex].Bonus = Frames[frameIndex + 1].Rolls[0];
                    }

                    //Final
                    if (Frames[frameIndex].TypeOfFrame == TypeOfFrames.Final) {
                        Frames[frameIndex].Bonus = 0;
                    }
                }
            } catch (Exception ex) {
                throw ex;
            }
        }
    }
}

