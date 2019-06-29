using System;
using Xunit;

namespace BowlingBall.Tests
{
    public class GameFixture
    {
        private Game g = new Game();
        private void RollNumberOfTimes(int n,int pins)
        {
            for (int i = 0; i < n; i++)
            {
                g.Roll(pins);
            }
        }
        [Fact]
        public void TestForAllZeros()
        {
            RollNumberOfTimes(20,0);
            Assert.Equal(0,g.GetScore());
        }
        [Fact]
        public void TestForAllOnes()
        {
            RollNumberOfTimes(20,1);
            Assert.Equal(20,g.GetScore());
        }
        [Fact]
        public void TestForOneSpare()
        {
            g.Roll(5);
            g.Roll(5);//score here is 10+3 = 13
            g.Roll(3);// 13+3 = 16
            RollNumberOfTimes(17,0);
            Assert.Equal(16,g.GetScore());
        }
        [Fact]
        public void TestForOneStrike()
        {
            g.Roll(10);//strike 10+3+4 = 17
            g.Roll(3);//17+3 = 20
            g.Roll(4);//20+4 = 24
            RollNumberOfTimes(17,0);
            Assert.Equal(24,g.GetScore());
        }
        [Fact]
        public void TestForAllStrikes()
        {
            RollNumberOfTimes(12,10);
            Assert.Equal(300,g.GetScore());
        }
        [Fact]
        public void TestForAllSpares()
        {
            RollNumberOfTimes(21,5);
            Assert.Equal(150,g.GetScore());
        }
        [Fact]
        public void TestForRandomGame()
        {
            g.Roll(5);
            g.Roll(5);
            g.Roll(10);
            g.Roll(5);
            g.Roll(4);
            g.Roll(3);
            g.Roll(2);
            g.Roll(6);
            g.Roll(4);
            g.Roll(3);
            g.Roll(2);
            RollNumberOfTimes(9,0);
            Assert.Equal(71,g.GetScore());
        }
        [Fact]
        public void TestForFullGame()
        {
            g.Roll(5);
            g.Roll(5);
            g.Roll(10);
            g.Roll(5);
            g.Roll(4);
            g.Roll(3);
            g.Roll(2);
            g.Roll(6);
            g.Roll(4);
            g.Roll(3);
            g.Roll(2);
            g.Roll(5);
            g.Roll(3);
            g.Roll(8);
            g.Roll(1);
            g.Roll(5);
            g.Roll(2);
            g.Roll(2);
            g.Roll(3);
            Assert.Equal(100,g.GetScore());
        }
    }
}
