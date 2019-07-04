using System;

namespace BowlingBall
{
    public class Game
    {
        var Rolls=new ArrayList();
        public void Roll(int pins)
        {
            Rolls.add(pins);
        }

        public int GetScore()
        {
            var bowlingGame=new TheBowlingGame(Rolls);
            return bowlingGame.GetScore();
        }

    }
}

