using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
namespace BowlingBall
{
    class TheBowlingGame
    {
        private int TotalScore;
        private Dictionary<int,Frame> Frames;
        public TheBowlingGame(ArrayList rolls)
        {
            GameSetup();
            Play(rolls);
        }
        private void GameSetup()
        {
            TotalScore = 0;
            Frames = new Dictionary<int, Frame>();
        }
        private void Play(ArrayList rolls)
        {
            throw new NotImplementedException();
        }
        public int GetScore()
        {
            return TotalScore;
        }
    }
}