using System;
using Xunit;

namespace BowlingBall.Tests
{
    public class GameFixture
    {

        Game g = new Game();

        [Fact]
        public void TestGutterBalls()
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
            g.Roll(3);
            RollMany(17, 0);
            Assert.Equal(16, g.GetScore());
        }

        [Fact]
        public void TestOneStrike()
        {
            RollStrike();
            g.Roll(3);
            g.Roll(4);
            RollMany(17, 0);
            Assert.Equal(24, g.GetScore());
        }

        [Fact]
        public void TestPerfect()
        {
            RollMany(12, 10);
            Assert.Equal(300, g.GetScore());
        }

        [Fact]
        public void TestRandomGame()
        {
            int[] scoreOfEachRoll = { 1, 4, 4, 5, 6, 4, 5, 5, 10, 0, 1, 7, 3, 6, 4, 10, 2, 8, 6 };
            int numberOfRolls = scoreOfEachRoll.Length;
            for (int i = 0; i < numberOfRolls; i++)
            {
                g.Roll(scoreOfEachRoll[i]);
            }
            Assert.Equal(133, g.GetScore());
        }

        [Fact]
        public void TestRandomGameTwo()
        {
            int[] scoreOfEachRoll = { 1,9,2,8,3,7,4,6,5,5,5,5,6,4,7,3,8,2,9,1,5 };
            int numberOfRolls = scoreOfEachRoll.Length;
            for (int i = 0; i < numberOfRolls; i++)
            {
                g.Roll(scoreOfEachRoll[i]);
            }
            Assert.Equal(154, g.GetScore());
        }


        public void RollStrike()
        {
            g.Roll(10);
        }

        public void RollSpare()
        {
            g.Roll(5);
            g.Roll(5);
        }

        public void RollMany(int n, int pins)
        {
            for (int i = 0; i < n; i++)
            {
                g.Roll(pins);
            }
        }




    }
}
