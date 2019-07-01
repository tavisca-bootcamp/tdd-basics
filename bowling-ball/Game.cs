using System;
using System.Collections;
namespace BowlingBall
{
    public class Game
    {
        private int _score = 0;
        private ArrayList _frames;

        public Game()
        {
            _frames = new ArrayList();
        }

        private void AddFrame(Frame frame)
        {
            if (_frames.Count == 10)
            {
                throw new IndexOutOfRangeException();
            }
            _frames.Add(frame);
        }

        public void RollFrame(int roll1, int roll2)
        {
            AddFrame(new Frame(roll1, roll2));
        }

        public void RollSpare(int roll1, int roll2)
        {
            var spare = new Spare(roll1, roll2);
            AddFrame(spare);
        }

        public void RollStrike()
        {
            var strike = new Strike();
            AddFrame(strike);
        }

        public void RollTenthFrame(int roll1, int roll2, int roll3)
        {
            var frame = new Frame(roll1, roll2);
            frame.bonusRoll = roll3;
            AddFrame(frame);
        }

        public int GetScore()
        {
            for(var currentFrame = 0; currentFrame < _frames.Count; currentFrame++)
    {
                var frame = (Frame)_frames[currentFrame];
                _score += (frame.TotalRoll());
                if (frame.isSpare)
                {
                    var nextFrame = (Frame)_frames[currentFrame + 1];
                    _score += nextFrame.tryRoll1;
                }
                else if (frame.isStrike)
                {
                    var nextFrame = (Frame)_frames[currentFrame + 1];
                    _score += nextFrame.tryRoll1;
                    if (nextFrame.isStrike)
                    {
                        var thirdFrame = (Frame)_frames[currentFrame + 2];
                        _score += thirdFrame.tryRoll1;
                    }
                    else
                    {
                        _score += nextFrame.tryRoll2;
                    }
                }
            }
            return _score;
        }

    }
}

