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

        public void RollSpare(int roll1,int roll2)
        {

        }

        public int GetScore()
        {
            foreach(Frame frame in frames)
            {
                score += (frame.Roll1 + frame.Roll2);
            }

            return score;
        }

    }
}

