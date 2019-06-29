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
            roll(20,10);
            Assert.Equal(300,g.GetScore());
            
        }
        [Fact]
        public void TestAllZeros()
        {
            roll(20,0);
            Assert.Equal(0,g.GetScore());
        }
    }
}
