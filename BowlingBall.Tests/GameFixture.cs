using System;
using Xunit;

namespace BowlingBall.Tests
{
    public class GameFixture
    {
        [Fact]
        public void DummyTest()
        {
            // This is a dummy test that will always pass.
        }
        [Fact]
        public void TestAllZero()
        {
            var g = new Game(); // Arrange
            for (int i = 0; i < 20; i++) // Act
                g.Roll(0);
            Assert.Equal(0, g.GetScore()); //Assert
        }
        

    }
}
