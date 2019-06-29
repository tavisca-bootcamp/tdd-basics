using System;
using Xunit;
using BowlingBall;

namespace BowlingBall.Tests
{
    public class GameFixture
    {

        private Game g = new Game();

        private void RollMany(int n, int pins)
        {
            for (int i = 0; i < n; i++)
                g.Roll(pins);
        }

        [Fact]
        public void TestGutterGame()
        {
            RollMany(20, 0);
            Assert.Equal(0, g.GetScore());
        }

        [Fact]
        public void TestAllOnes()
        {
            RollMany(20, 1);
            Assert.Equal(20, g.GetScore());
        }

        [Fact]
        public void TestOneSpare()
        {
            RollSpare();
            g.Roll(3);
            RollMany(17,0);
            Assert.Equal(16, g.GetScore());
        }

        private void RollSpare()
        {
            g.Roll(5);
            g.Roll(5);
        }
    }
}
