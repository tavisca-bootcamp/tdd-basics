using System;
using Xunit;

namespace BowlingBall.Tests
{
    public class GameFixture
    {
        private Game g = new Game();

        [Fact]
        public void DummyTest()
        {
            // This is a dummy test that will always pass.
        }
        [Fact]
        public void TestGutterGame()
        {
            rollMany(20, 0);
            Assert.Equal(0, g.GetScore());
        }
        private void rollMany(int n, int pins)
        {
            for (int i = 0; i < n; i++)
                g.Roll(pins);
        }

        [Fact]
        public void TestAllOnes()
        {
            rollMany(20, 1);
            Assert.Equal(20, g.GetScore());

        }
        [Fact]
        public void TestOneSpare()
        {
            rollSpare();
            g.Roll(3);
            rollMany(17, 0);
            Assert.Equal(16, g.GetScore());
        }
        [Fact]
        public void rollSpare()
        {
            g.Roll(5);
            g.Roll(5);
        }
        [Fact]
        public void TestOneStrike()
        {
            g.Roll(10);
            g.Roll(4);
            g.Roll(5);
            rollMany(16,0);
            Assert.Equal(28, g.GetScore());
        }
        [Fact]
        public void TestPerfectGame()
        {
            rollMany(12,10);
            Assert.Equal(300,g.GetScore());
        }
    }
}
