using System;
using Xunit;
namespace BowlingBall.Tests
{
    public class GameFixture
    {
        Game game=null;

        public GameFixture()
        {
            game = new Game();
        }

        [Fact]
        public void AllGutterBalls()
        {
            RollFrames(0, 0, 10);
            Assert.Equal(0, game.GetScore());
        }

        [Fact]
        public void All2sShouldScore40()
        {
            RollFrames(2, 2,10);
            Assert.Equal(40, game.GetScore());
        }

        [Fact]
        public void FirstFrameSpareRest2s()
        {
            game.RollSpare(2, 8);
            RollFrames(2, 2, 9);
            Assert.Equal(48, game.GetScore());
        }

        [Fact]
        public void FirstTwoFramesSpareRest2sShouldScore56()
        {
            game.RollSpare(2, 8);
            game.RollSpare(2, 8);
            RollFrames(2, 2, 8);
            Assert.Equal(56, game.GetScore());
        }

        [Fact]
        public void TryingToBowlMoreThan10FramesThrowsOutOfFramesException()
        {
            Exception ex = Assert.Throws<IndexOutOfRangeException>(() => RollFrames(2, 2, 11));
        }

        private void RollFrames(int roll1,int roll2,int numberOfFrames)
        {
            for(int frame = 0; frame < numberOfFrames; frame++)
            {
                game.RollFrame(roll1, roll2);
            }
        }
    }
}
