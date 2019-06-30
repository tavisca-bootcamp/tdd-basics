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

        private void AddFrame(Frame frame)
        {
            if (frames.Count == 10)
            {
                throw new IndexOutOfRangeException();
            }
            frames.Add(frame);
        }

        public void RollFrame(int roll1, int roll2)
        {
            AddFrame(new Frame(roll1, roll2));
        }

        public void RollSpare(int roll1, int roll2)
        {
            var frame = new Frame(roll1, roll2);
            frame.isSpare=true;
            frames.Add(frame);
        }

        public void RollStrike()
        {
            Strike strike = new Strike();
            AddFrame(strike);
        }

        public int GetScore()
        {
            for(int currentFrame = 0; currentFrame < frames.Count; currentFrame++)
    {
                var frame = (Frame)frames[currentFrame];
                score += (frame.TotalRoll());
                if (frame.isSpare)
                {
                    var nextFrame = (Frame)frames[currentFrame + 1];
                    score += nextFrame.Roll1;
                }
                else if (frame.isStrike)
                {
                    var nextFrame = (Frame)frames[currentFrame + 1];
                    score += nextFrame.TotalRoll();
                }
            }
            return score;
        }

    }
}

