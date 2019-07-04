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
            Rolls.Add(pins);
        }

        public int GetScore()
        {
            var bowlingGame=new TheBowlingGame(Rolls);
            return bowlingGame.GetScore();
        }

    }
}

