using System;
using Xunit;

namespace BowlingBall.Tests
{
    public class GameFixture
    {
        private Game g;

        private void _setUp()
        {
            g = new Game();
        }

        private void RollMany(int n, int pins)
        {
            for (int i = 0; i < n; i++)
            {
                g.Roll(pins);
            }
        }

        [Fact]
        public void TestGutterGame()
        {
            _setUp();
            RollMany(20, 0);
            Assert.Equal(0, g.GetScore());
        }

        [Fact]
        public void TestAllOnes()
        {
            _setUp();
            RollMany(20, 1);
            Assert.Equal(20, g.GetScore());
        }

        [Fact]
        public void TestOneSpare()
        {
            _setUp();
            _rollSpare();
            g.Roll(3);
            RollMany(17, 0);
            Assert.Equal(16, g.GetScore());
        }

        [Fact]
        public void TestOneStrike()
        {
            _setUp();
            _rollStrike();
            g.Roll(3);
            g.Roll(4);
            RollMany(16, 0);
            Assert.Equal(24, g.GetScore());
        }

        [Fact]
        public void TestPerfectGame()
        {
            _setUp();
            RollMany(12, 10);
            Assert.Equal(300, g.GetScore());
        }
        private void _rollStrike()
        {
            g.Roll(10);
        }

        private void _rollSpare()
        {
            g.Roll(5);
            g.Roll(5);
        }
    }
}