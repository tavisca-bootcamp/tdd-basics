using System;
using System.Collections.Generic;
using System.Text;

namespace BowlingBall
{
    public class BowlingUtility
    {
        Game game;
        public BowlingUtility()
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

        public void RollingAStrike() => game.Roll(10);
        
        public void RollsManyTimes(int pins, int n)
        {
            for (int i = 0; i < n; i++)
            {
                game.Roll(pins);
            }
        }
        public void RollsNormal(int pins) => game.Roll(pins);
        
        public void RollsNothing() => game.Roll(0);
        
    }
}
