using System;
using System.Collections.Generic;
using System.Text;

namespace BowlingBall
{
    public class RollingBall
    {
        Game game;
        public RollingBall()
        {
            game = new Game();
        }

        public int GetScore()
        {
            return game.GetScore();
        }

        public void RollingASpare(int firstRollPins)
        {
            game.Roll(firstRollPins);
            game.Roll(10 - firstRollPins);
        }

        public void RollingAStrike()
        {
            game.Roll(10);
        }

        public void RollMultipleTimes(int value, int n)
        {
            for (int i = 0; i < n; i++)
            {
                game.Roll(value);
            }
        }

        public void RollsNormal(int pins)
        {
            game.Roll(pins);
        }
        public void RollsNothing()
        {
            game.Roll(0);
           var n= game.rolling;
        }

       public int [] GetValues()
        {
            return game.rolling;
        }

    }
}
