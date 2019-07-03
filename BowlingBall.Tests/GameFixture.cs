using System;
using Xunit;

namespace BowlingBall.Tests
{

    public class GameFixture
    {
        Game obj = new Game();
        [Fact]
        public void DummyTest()
        {
            // This is a dummy test that will always pass.
        }
        [Fact]
        public void ForAllZeroes()
        {
            for (int i = 0; i < 20; i++)
            {
                obj.Roll(0);
            }
            
            Assert.Equal(0, obj.GetScore());

        }
        [Fact]
        public void ForAllOnes()
        {
            for (int i = 0; i < 20; i++)
            {
                obj.Roll(1);
            }
            Assert.Equal(20, obj.GetScore());
        }
        [Fact]
        public void ForAllStrikes()
        {
            for (int i = 0; i < 12; i++)
            {
                obj.Roll(10);
            }
            Assert.Equal(300, obj.GetScore());
        }
        [Fact]
        public void ForAllSpares()
        {
            for (int i = 0; i < 10; i++)
            {
                obj.Roll(6);
                obj.Roll(4);
            }
            obj.Roll(5);
            Assert.Equal(159, obj.GetScore());
        }
        [Fact]
        public void ForStrikeAndSpareInEnd()
        {
            int[] pins_down = new int[] { 5, 2, 6, 4, 10, 7, 2, 9, 1, 4, 4, 10, 8, 2, 4, 5, 8, 2, 10 };
            obj.Roll(pins_down);
            Assert.Equal(140, obj.GetScore());
        }
    }
}



