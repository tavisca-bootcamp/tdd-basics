using System;
using System.Collections.Generic;

namespace BowlingBall
{
    public class Game
    {
        List<Frame> frames;
        public Game() {
            frames = new List<Frame>(10);
        }
        public void Roll(int pinsKnocked) {
            if (frames.Count == 0)       //Initial roll
                AddFrame(pinsKnocked);
            else {
                var currentFrame = frames[frames.Count - 1];
                if (frames.Count == 10)                                      //for tenth frame don't set spare or strike
                    currentFrame.isSpare = currentFrame.isStrike = false;
                if (currentFrame.rollCount == 1 && !currentFrame.isStrike)   //second roll if first roll is done and it's not strike 
                    currentFrame.SecondRoll(pinsKnocked);
                else if (currentFrame.rollCount == 2 && frames.Count == 10)  //Bonus roll
                    currentFrame.ThirdRoll(pinsKnocked);
                else                                                         //Add a new frame and perform first roll
                    AddFrame(pinsKnocked);
            }
        }
        public void AddFrame(int pinsKnocked) {
            var frame = new Frame();
            frame.FirstRoll(pinsKnocked);
            frames.Add(frame);
        }
        public int GetScore() {
            var bowlingScore = 0;
            for (var currentFrame = 0; currentFrame < frames.Count; currentFrame++) {
                var frame = frames[currentFrame];
                bowlingScore += frame.FrameTotal();
                if (frame.isSpare) {
                    var nextFrame = frames[currentFrame + 1];
                    bowlingScore += frame.SpareBonus(nextFrame);
                }
                else if (frame.isStrike) {
                    var nextFrame = frames[currentFrame + 1];
                    if (nextFrame.isStrike) {
                        var postNextFrame = frames[currentFrame + 2];
                        bowlingScore += frame.DoubleStrikeBonus(nextFrame, postNextFrame);
                    }
                    else {
                        bowlingScore += frame.StrikeBonus(nextFrame);
                    }
                }
            }
            return bowlingScore;
        }
    }
}