using System;
using Xunit;
namespace BowlingBall.Tests
{
    public class GameFixture
    {

        [Fact]
        public void AllGutterBalls()
        {
            var game = new Game();
            for(int frame = 1; frame <= 10; frame++)
            {
                game.RollFrame(0, 0);
            }
            Assert.Equal(0, game.GetScore());
        }
    }
}
