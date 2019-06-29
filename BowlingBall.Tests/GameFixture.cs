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
        public roll(int number_of_pins,int value)
        {
            for(int i=0;i<number_of_pins;i++)
            {
                g.roll(value);
            }
        }

        [Fact]
        public void TestAllStrikes()
        {
            roll(20,10);
            Assert.Equal(300,g.final_score);
            
        }
    }
}
