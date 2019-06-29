using System;
using Xunit;

namespace BowlingBall.Tests
{
    public class GameFixture
    {
        Game obj = new Game();

        [Fact]
        public void DummyTest()
        {
            for (int i = 0; i < 20; i++)
                obj.Roll(0);
            Assert.Equal(0, obj.GetScore());
            // This is a dummy test that will always pass.
        }

        [Fact]
        public void DummyTest1()
        {
            // This is a dummy test that will always pass.
        }
    }
}
