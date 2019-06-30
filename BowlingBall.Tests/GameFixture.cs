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
        [Fact]
        public void SpareStrikeZero() //starts with a spare in middle strikes and ends with gutter balls
        {
            int[] testcase = new int[17] { 5, 5, 1, 2, 7, 3, 5, 0, 10, 10, 2, 1, 10, 9, 0, 0, 0 };

            for (int i = 0; i < 17; i++)
                obj.Roll(testcase[i]);
            Assert.Equal(100, obj.GetScore());
        }
        [Fact]
        public void StrikeZeroSpare() //starts with a srike in middle gutter balls and ends with spare
        {
            int[] testcase = new int[18] { 10, 0, 0, 10, 10, 0, 0, 4, 1, 5, 2, 5, 5, 1, 4, 8, 2, 5 };

            for (int i = 0; i < 18; i++)
                obj.Roll(testcase[i]);
            Assert.Equal(83, obj.GetScore());
        }
        [Fact]
        public void StrikeSpareZero() //starts with a srike in middle spare and ends with gutter ball
        {
            int[] testcase = new int[17] { 10, 0, 0, 10, 10, 5, 5, 4, 1, 6, 4, 8, 1, 9, 0, 0, 0 };

            for (int i = 0; i < 17; i++)
                obj.Roll(testcase[i]);
            Assert.Equal(110, obj.GetScore());
        }
        [Fact]
        public void ZeroSpareStrike() //starts with a gutter ball  in middle spare and ends with srike
        {
            int[] testcase = new int[18] { 0, 0, 0, 0, 0, 0, 6, 4, 5, 5,  1, 3, 10, 10, 10, 10, 1, 2 };

            for (int i = 0; i < 18; i++)
                obj.Roll(testcase[i]);
            Assert.Equal(124, obj.GetScore());
        }



    }
}
