using System;
using Xunit;
using BowlingBall;
namespace BowlingBall.Tests
{
    public class GameFixture
    {
        private Game g;

        // Constructor runs before every test function
        public GameFixture() {
            g = new Game();
        }

        [Fact]
        public void TestAllStrikes()
        {
           g.Roll(new [] { 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10 } );
           Assert.Equal(300,g.GetScore());
        }
        
    }
}
