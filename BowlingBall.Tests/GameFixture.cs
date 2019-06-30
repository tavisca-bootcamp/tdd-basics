using System;
using Xunit;

namespace BowlingBall.Tests
{
    public class GameFixture
    {
        RollingBall balls = new RollingBall();

        [Fact]
        
        public void BasicTestForZeroScoring()
        {
            // Arrange
            int actual;
            int expected;

            // Act
            balls.RollMultipleTimes(20, 0);
            actual = balls.GetScore();
            expected = 0;

            // Assert
            Assert.Equal(expected, actual);
        }

        [Fact]
         public void TestAllOnes()
        {
            balls.RollMultipleTimes(1, 20);

            var actual = balls.GetScore();
            var expected = 20;
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void TestingOneSpare()
        {
            balls.RollingASpare(7);
            var actual = balls.GetScore();
            var expected = 10;
            Assert.Equal(expected, actual);
        }
        [Fact]
        public void TestingANumber()
        {
            balls.RollsNormal(4);
            var actual = balls.GetScore();
            var expected = 4;
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void testingAOneSpareOneStrike()
        {
            balls.RollingASpare(9);
            balls.RollingAStrike();
            var actual = balls.GetScore();
            var expected = 30;
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void testingPerfectGame()
        {
            balls.RollMultipleTimes(10, 12);
            var actual = balls.GetScore();
            var expected = 300;
            Assert.Equal(expected, actual);
        }


        [Fact]
        public void testingTwoSpareTwoStrike()
        {
            balls.RollingASpare(9);
            balls.RollingASpare(0);
            balls.RollingAStrike();
            balls.RollingAStrike();
            balls.RollsNormal(6);
            balls.RollsNormal(2);
            var actual = balls.GetScore();
            var expected = 82;
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void testingActualTestrCase()
        {
            balls.RollingAStrike();
            balls.RollingASpare(9);
            balls.RollingASpare(5);
            balls.RollsNormal(7);
            balls.RollsNormal(2);
            balls.RollingAStrike();
            balls.RollingAStrike();
            balls.RollingAStrike();
            balls.RollsNormal(9);
            balls.RollsNothing();
            balls.RollingASpare(8);
            balls.RollingASpare(9);
            balls.RollingAStrike();
            var actual = balls.GetScore();
            var expected = 187;
            Assert.Equal(expected, actual);
        }




    }
}
