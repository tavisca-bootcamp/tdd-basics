using System;
using Xunit;

namespace BowlingBall.Tests
{
    public class GameFixture : IDisposable
    {
        private Game _game; 
        public GameFixture()
        {
            _game = new Game();
        }

        [Fact]
        public void DummyTest()
        {
            // This is a dummy test that will always pass.
        }

        [Fact]
        public void AllZerosTest()
        {
            Roll(0, 20);
            int score = _game.GetScore();

            Assert.Equal(0, score);
        }

        private void Roll(int pins, int times)
        {
            for (int i = 0; i < times; i++)
                _game.Roll(pins);
        }

        public void Dispose()
        {
            
        }
    }
}
