
using System;

namespace BowlingBall
{
    public class Game
    {

        Frame frame = new Frame();

        public void Roll(int pins)
        {
            frame.rolls[frame.Rollindex++] = pins;
        }
        public int GetScore()
        {
            int score = 0;
            for (int i = 0; i < 10; i++)
            {
                if (frame.IsSpare(frame.Ballindex))
                {
                    score += frame.ScoreSpare(frame.Ballindex);
                }
                else if (frame.IsStrike(frame.Ballindex))
                {
                    score += frame.ScoreStrike(frame.Ballindex);
                }
                else
                {
                    score += frame.Score(frame.Ballindex);
                    frame.Ballindex += 2;
                }
            }
            if (frame.Ballindex != frame.Rollindex)
            {
                if (frame.IsStrike(frame.Ballindex - 1) || frame.IsSpare(frame.Ballindex - 2))
                { }
                else
                    return -1;
            }

            return score;
        }

    }
}

