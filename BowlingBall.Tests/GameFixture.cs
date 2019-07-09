using System;
using Xunit;

namespace BowlingBall.Tests
{
    public class GameFixture
    {
         private Game g;

        [Fact]
        public void allNull()
        {
            g = new Game();
            rollTheBall(20, 0);
            Assert.Equal(0, g.getScore());
        }
        [Fact]
        public void checkSpare()
        {
            g = new Game();
            g.Roll(7);
            g.Roll(3);
            g.Roll(5);
            rollTheBall(17, 0);
            Assert.Equal(20, g.getScore());
        }

        [Fact]
        public void checkStrike()
        {
            g = new Game();
            g.Roll(10);
            g.Roll(3);
            g.Roll(5);
            rollTheBall(16, 0);
            Assert.Equal(26, g.getScore());
        }
        [Fact]
        public void allStrike()
        {   g = new Game();
            rollTheBall(12,10);
            Assert.Equal(300, g.getScore());
        }
        private void rollTheBall(int times, int score)
        {
            for (int i = 0; i < times; i++)
            {
                g.Roll(score);
            }
        }
   
        [Fact]
        public void DummyTest()
        {
            // This is a dummy test that will always pass.
        }
    }
}
