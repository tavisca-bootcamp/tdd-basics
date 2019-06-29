using System;
using Xunit;

namespace BowlingBall.Tests
{
    public class GameFixture
    {
        public Game g;
        public GameFixture()
        {
            g= new Game();
        }
        public void roll(int number_of_pins,int value)
        {
            for(int i=0;i<number_of_pins;i++)
            {
                g.RollSinglePin(value);
            }
        }

        [Fact]
        public void TestAllStrikes()
        {
            roll(12,10);
            Assert.Equal(300,g.GetScore());
            
        }
        [Fact]
        public void TestAllZeros()
        {
            roll(20,0);
            Assert.Equal(0,g.GetScore());
        }
        [Fact]
        public void TestSpare()
        {
            g.RollSinglePin(7);
            g.RollSinglePin(3);
            g.RollSinglePin(4);
            roll(17,1);
            Assert.Equal(35,g.GetScore());
        }
        [Fact]
        public void Random()
        {
            g.RollMultiplePin(new int[]{9,0,10,1,9,3,0,7,2,8,2,0,5,9,0,10,1,6});
            Assert.Equal(102,g.GetScore());

        }
        [Fact]
        public void AllSpares()
        {
            g.RollMultiplePin(new int[]{9,1,8,2,7,3,6,4,5,5,4,6,7,3,1,9,8,2,7,3,10});
            Assert.Equal(163,g.GetScore());
            }

    }
}
