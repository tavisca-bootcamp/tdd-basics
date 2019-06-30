using System;
using Xunit;

namespace BowlingBall.Tests
{
    public class GameFixture
    {
        Game g = new Game(); // Arrange
        [Fact]
        public void TestAllZero()
        {
            RollSame(20, 0); //Act
            Assert.Equal(0, g.GetScore()); //Assert
        }

        [Fact]
        public void TestNoStrikeNoSpare()
        {
            RollSame(20, 3); // Act
            Assert.Equal(60, g.GetScore()); //Assert
        }

        [Fact]
        public void TestSpare()
        {
            g.Roll(7);
            g.Roll(3); // Spare
            g.Roll(5);
            RollSame(17, 1); // Act
            Assert.Equal(37, g.GetScore()); //Assert
        }
        [Fact]
        public void TestStrike()
        {
            g.Roll(10);
            RollSame(18, 1);
            Assert.Equal(30, g.GetScore());
        }
        [Fact]
        public void TestSpareAndStrike()
        {
            g.Roll(10);
            RollSame(6, 0);
            g.Roll(4);
            g.Roll(6);
            RollSame(10, 1);
            Assert.Equal(31, g.GetScore());
        }
        private void RollSame(int rollsCount, int pins)
        {
            for (int i = 0; i < rollsCount; i++)
                g.Roll(pins);
        }

    }
}
