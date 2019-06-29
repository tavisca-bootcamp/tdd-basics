using System;
using Xunit;

namespace BowlingBall.Tests
{
    public class GameFixture
    {
        
        [Fact]
        public void TestAllZero()
        {
            var g = new Game(); // Arrange
            for (int i = 0; i < 20; i++) // Act
                g.Roll(0);
            Assert.Equal(0, g.GetScore()); //Assert
        }

        public void TestNoStrikeNoSpare()
        {
            var g = new Game(); // Arrange
            for (int i = 0; i < 20; i++) // Act
                g.Roll(3);
            Assert.Equal(60, g.GetScore()); //Assert
        }


    }
}
