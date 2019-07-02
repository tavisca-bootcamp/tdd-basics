using System;
using Xunit;

namespace BowlingBall.Tests
{
    public class GameFixture
    {
        public Game g;
        private void Rolls(int numberOfTries, int pins)
        {
            // test to roll any no of pins in any no of tries
            for (int index = 0; index < numberOfTries; index++)
                g.Roll(pins);
        }

        [Fact]
        public void TestBadGame()
        {
            g = new Game();
            Rolls(20, 0);
            Assert.Equal(0, g.GetScore());
        }

        [Fact]
        public void TestAllOnes()
        {
            g = new Game();
            Rolls(20, 1);
            Assert.Equal(20, g.GetScore());
        }

        [Fact]
        public void TestSpare()
        {
            g = new Game();
            g.Roll(7);
            g.Roll(3);
            g.Roll(5);
            Rolls(17, 0);
            Assert.Equal(20, g.GetScore());
        }

        [Fact]
        public void TestStrike()
        {
            g = new Game();
            g.Roll(10);
            g.Roll(6);
            g.Roll(2);
            Rolls(16, 0);
            Assert.Equal(26, g.GetScore());
        }

        [Fact]
        public void TestPerfectGame()
        {
            g = new Game();
            Rolls(12, 10);
            Assert.Equal(300, g.GetScore());
        }                              
    }
}