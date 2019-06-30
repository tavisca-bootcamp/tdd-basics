using System;
using Xunit;

namespace BowlingBall.Tests
{
    public class GameFixture
    {
        Game obj = new Game();

        [Fact]
        public void AllZeros()
        {
            for (int i = 0; i < 20; i++)
                obj.Roll(0);
            Assert.Equal(0, obj.GetScore());
            
        }

        [Fact]
        public void AllOnes()
        {
            
            for (int i = 0; i < 20; i++)
                obj.Roll(1);
            Assert.Equal(20, obj.GetScore());
        }
        [Fact]
        public void AllSpares()
        {
            
            for (int i = 0; i < 21; i++)
                obj.Roll(5);
            Assert.Equal(150, obj.GetScore());
        }
        [Fact]
        public void AllStrikes()
        {
           
            for (int i = 0; i < 12; i++)
                obj.Roll(10);
            Assert.Equal(300, obj.GetScore());
        }
        [Fact]
        public void SpareZeroStrike() //starts with a spare in middle gutter balls and ends with strike
        {
            int[] testcase = new int[20] { 5, 5, 1, 2, 7, 3, 5, 0, 0, 0, 4, 3, 2, 1, 10, 9, 0, 10, 5, 1 };

            for (int i = 0; i < 20; i++)
                obj.Roll(testcase[i]);
            Assert.Equal(88, obj.GetScore());
        }

    }
}
