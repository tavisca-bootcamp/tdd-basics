using System;
using Xunit;

namespace BowlingBall.Tests
{
    public class GameFixture
    {
        [Fact]
        public void DummyTest()
        {
            var game = new Game();
            for (int i = 0; i < 20; i++)
                game.Roll(0);
            Assert.Equal(0, game.GetScore());
            // This is a dummy test that will always pass.
        }
    }
}
