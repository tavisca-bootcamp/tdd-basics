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

        [Fact]
        public void All2sShouldScore40()
        {
            var game = new Game();
            for(int frame = 1; frame <= 10; frame++)
            {
                game.RollFrame(2, 2);
            }
            Assert.Equal(40, game.GetScore());
        }
    }
}
