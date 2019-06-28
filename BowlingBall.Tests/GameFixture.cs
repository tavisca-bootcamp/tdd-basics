using System;
using Xunit;
using BowlingBall;

namespace BowlingBall.Tests
{
    public class GameFixture
    {
        RollingBall rollingBall = new RollingBall();
        [Fact]
        public void TestAllZeros()
        {
            rollingBall.RollsManyTimes(0, 20);
            var expected = 0;
            var actual = rollingBall.GetScore();
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void TestAllOnes()
        {
            rollingBall.RollsManyTimes(1, 20);
            var expected = 20;
            var actual = rollingBall.GetScore();
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void TestRollingOneScoresOne()
        {
                rollingBall.RollsNormal(1);
                var expected = 1;
                var actual = rollingBall.GetScore();
                Assert.Equal(expected, actual);
        }

        [Fact]
        public void TestRollingTwoScoresTwo()
        {
            rollingBall.RollsNormal(2);
            var expected = 2;
            var actual = rollingBall.GetScore();
            Assert.Equal(expected, actual);
   
        }

        public void TestASpare()
        {
            rollingBall.RollingASpare(5);
            var expacted = 10;
            var actual = rollingBall.GetScore();
            Assert.Equal(expacted, actual);
        }
        
        [Fact]
        public void TestSpareThenOneScoresTwelve()
        {
            rollingBall.RollingASpare(5);
            rollingBall.RollsNormal(1);
            var expected = 12;
            var actual = rollingBall.GetScore();
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void TestAStrike()
        {
            rollingBall.RollingAStrike();
            var expected = 10;
            var actual = rollingBall.GetScore();
            Assert.Equal(expected, actual);
        }
        [Fact]
        public void TestStrikeThenTwoThenFiveScoresTwentyFour()
        {
            rollingBall.RollingAStrike();
            rollingBall.RollsNormal(5);
            rollingBall.RollsNormal(2);
            var expected = 24;
            var actual = rollingBall.GetScore();
            Assert.Equal(expected, actual);
            // This is a dummy test that will always pass.
        }
        [Fact]
        public void TestActualMatchScoreOfAllTenFrames()
        {
            rollingBall.RollingAStrike();
            rollingBall.RollingASpare(9);
            rollingBall.RollingASpare(5);
            rollingBall.RollsNormal(7);
            rollingBall.RollsNormal(2);
            rollingBall.RollingAStrike();
            rollingBall.RollingAStrike();
            rollingBall.RollingAStrike();
            rollingBall.RollsNormal(9);
            rollingBall.RollsNothing();
            rollingBall.RollingASpare(8);
            rollingBall.RollingASpare(9);
            rollingBall.RollingAStrike();
            var expected = 187;
            var actual = rollingBall.GetScore();
            Assert.Equal(expected, actual);

        }

    }
}