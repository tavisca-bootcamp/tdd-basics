using System;
using Xunit;

namespace BowlingBall.Tests
{
    public class GameFixture
    {
        Game g = new Game();

        [Fact]
        public void DummyTest()
        {
            // This is a dummy test that will always pass.
        }

        private void RollMany(int n, int pins)
        {
            for (int i = 0; i < n; i++)
            {
                g.Roll(pins);
            }
        }

        [Fact]
        public void TestAllZeros()
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
            g.Roll(2);
            RollMany(17, 0);
            Assert.Equal(14, g.GetScore());
        }

        [Fact]
        public void TestOneStrike()
        {
            RollStrike();
            g.Roll(2);
            g.Roll(3);
            RollMany(16, 0);
            Assert.Equal(20, g.GetScore());
        }

        [Fact]
        public void TestPerfectGame()
        {
            RollMany(12, 10);
            Assert.Equal(300, g.GetScore());
        }

        [Fact]
        public void TestWithNoSpareAndStrike()
        {
            RollMany(10, 2);
            RollMany(10, 3);
            Assert.Equal(50, g.GetScore());
        }

        [Fact]
        public void TestWithAllSpare()
        {
            RollSpare();
            RollSpare();
            RollSpare();
            RollSpare();
            RollSpare();
            RollSpare();
            RollSpare();
            RollSpare();
            RollSpare();
            RollSpare();
            g.Roll(2);
            Assert.Equal(147, g.GetScore());
        }

        private void RollStrike()
        {
            g.Roll(10);
        }

        private void RollSpare()
        {
            g.Roll(5);
            g.Roll(5);
        }
    }
}
