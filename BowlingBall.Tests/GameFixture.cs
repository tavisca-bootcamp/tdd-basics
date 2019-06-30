using System;
using Xunit;
using BowlingBall;

namespace BowlingBall.Tests
{
    public class GameFixture
    {
        private Game g;
        public GameFixture() {
            g = new Game();
        }

        [Fact]
        public void TestAllStrikes()
        {
            g.Roll(new[] { 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10 });
            Assert.Equal(300, g.GetScore());
        }
        [Fact]
        public void TestAllZero()
        {
            g.Roll(new[] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 });
            Assert.Equal(0, g.GetScore());
        }
        [Fact]
        public void TestOneStrike()
        {
            g.Roll(new[] { 10, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 });
            Assert.Equal(10, g.GetScore());
        }

    }
}
