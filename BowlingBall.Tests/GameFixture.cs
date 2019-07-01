using System;
using Xunit;
using BowlingBall;

namespace BowlingBall.Tests
{
    public class GameFixture
    {
        BowlingUtility bowlingUtility = new BowlingUtility();
        [Fact]
        public void TestAllZeros()
        {
            bowlingUtility.RollsManyTimes(0, 20);
            var expected = 0;
            var actual = bowlingUtility.GetScore();
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void TestAllOnes()
        {
            bowlingUtility.RollsManyTimes(1, 20);
            var expected = 20;
            var actual = bowlingUtility.GetScore();
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void TestRollingOneScoresOne()
        {
                bowlingUtility.RollsNormal(1);
                var expected = 1;
                var actual = bowlingUtility.GetScore();
                Assert.Equal(expected, actual);
        }

        [Fact]
        public void TestRollingTwoScoresTwo()
        {
            bowlingUtility.RollsNormal(2);
            var expected = 2;
            var actual = bowlingUtility.GetScore();
            Assert.Equal(expected, actual);
   
        }

        public void TestASpare()
        {
            bowlingUtility.RollingASpare(5);
            var expacted = 10;
            var actual = bowlingUtility.GetScore();
            Assert.Equal(expacted, actual);
        }
        
        [Fact]
        public void TestSpareThenOneScoresTwelve()
        {
            bowlingUtility.RollingASpare(5);
            bowlingUtility.RollsNormal(1);
            var expected = 12;
            var actual = bowlingUtility.GetScore();
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void TestAStrike()
        {
            bowlingUtility.RollingAStrike();
            var expected = 10;
            var actual = bowlingUtility.GetScore();
            Assert.Equal(expected, actual);
        }
        [Fact]
        public void TestStrikeThenTwoThenFiveScoresTwentyFour()
        {
            bowlingUtility.RollingAStrike();
            bowlingUtility.RollsNormal(5);
            bowlingUtility.RollsNormal(2);
            var expected = 24;
            var actual = bowlingUtility.GetScore();
            Assert.Equal(expected, actual);
            // This is a dummy test that will always pass.
        }
        [Fact]
        public void TestActualMatchScoreOfAllTenFrames()
        {
            bowlingUtility.RollingAStrike();
            bowlingUtility.RollingASpare(9);
            bowlingUtility.RollingASpare(5);
            bowlingUtility.RollsNormal(7);
            bowlingUtility.RollsNormal(2);
            bowlingUtility.RollingAStrike();
            bowlingUtility.RollingAStrike();
            bowlingUtility.RollingAStrike();
            bowlingUtility.RollsNormal(9);
            bowlingUtility.RollsNothing();
            bowlingUtility.RollingASpare(8);
            bowlingUtility.RollingASpare(9);
            bowlingUtility.RollingAStrike();
            var expected = 187;
            var actual = bowlingUtility.GetScore();
            Assert.Equal(expected, actual);

        }

    }
}