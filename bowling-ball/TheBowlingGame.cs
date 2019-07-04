using System;
using System.Collections.Generic;
using System.Linq;
namespace BowlingBall
{
    class TheBowlingGame
    {
        private var TotalScore;
        private var Frames;
        public TheBowlingGame(var rolls)
        {
            GameSetup();
            Play(rolls);
        }
        private void GameSetup()
        {
            TotalScore = 0;
            Frames = new Dictionary<int, Frame>();
        }
        private void Play(var rolls)
        {
            throw NotImplementedException();
        }
        public int GetScore()
        {
            return TotalScore;
        }
    }
}