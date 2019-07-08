using System;
using System.Collections;
using System.Linq;
namespace BowlingBall
{
    public class Game
    {
        ArrayList Rolls=new ArrayList();
        public void Roll(int pins)
        {
            if ((pins >= 0) && (pins <= 10))
                Rolls.Add(pins);
            else
                throw new Exception("Not possible to roll");
        }

        public int GetScore()
        {
            var bowlingGame=new BowlingGame(Rolls);
            return bowlingGame.GetScore();
        }

    }
}

