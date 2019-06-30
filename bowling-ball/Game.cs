using System;
using System.Collections;
namespace BowlingBall
{
    public class Game
    {
        private int score = 0;
        private ArrayList frames;
        public Game()
        {
            frames = new ArrayList();
        }

        public void RollFrame(int roll1, int roll2)
        {
            frames.Add(new Frame(roll1, roll2));
        }

        public void RollSpare(int roll1, int roll2)
        {
            var frame = new Frame(roll1, roll2);
            frame.IsSpare(true);
            frames.Add(frame);
        }

        public int GetScore()
        {
            for(int currentFrame = 0; currentFrame < frames.Count; currentFrame++)
    {
                Frame frame = (Frame)frames[currentFrame];
                score += (frame.Roll1 + frame.Roll2);
                if (frame.isSpare)
                {
                    Frame nextFrame = (Frame)frames[currentFrame + 1];
                    score += nextFrame.Roll1;
                }
            }
            return score;
        }

    }
}

