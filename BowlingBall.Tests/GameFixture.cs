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
        public void All2s()
        {
            RollFrames(2, 2,10);
            Assert.Equal(40, game.GetScore());
        }

        [Fact]
        public void FirstFrameSpare()
        {
            game.RollSpare(2, 8);
            RollFrames(2, 2, 9);
            Assert.Equal(48, game.GetScore());
        }

        [Fact]
        public void FirstTwoFramesSpare()
        {
            game.RollSpare(2, 8);
            game.RollSpare(2, 8);
            RollFrames(2, 2, 8);
            Assert.Equal(56, game.GetScore());
        }

        [Fact]
        public void BowlMoreThan10Frames()
        {
            Exception ex = Assert.Throws<IndexOutOfRangeException>(() => RollFrames(2, 2, 11));
        }

        [Fact]
        public void FirstFrameStrike()
        {
            game.RollStrike();
            RollFrames(2, 2, 9);
            Assert.Equal(50, game.GetScore());
        }

        [Fact]
        public void FirstTwoFramesStrikes()
        {
            game.RollStrike();
            game.RollStrike();
            RollFrames(2, 2, 8);
            Assert.Equal(68, game.GetScore());
        }


        [Fact]
        public void PerfectGame()
        {
            for (var i = 1; i <= 9; i++)
            {
                game.RollStrike();
            }
            game.RollTenthFrame(10, 10, 10);
            Assert.Equal(300, game.GetScore());
        }

        [Fact]
        public void RandomGame()
        {
            game.RollSpare(3, 7);
            for (var i = 0; i < 4; i++)
                game.RollFrame(i, i + 1);
            for (var j = 4; j >0; j--)
                game.RollFrame(j, j + 1);
            game.RollTenthFrame(10, 10, 10);

            Assert.Equal(80, game.GetScore());
        }

        [Fact]
        public void LastFrameStrike()
        {
            RollFrames(2, 2, 9);
            game.RollTenthFrame(10,10,10);
            Assert.Equal(66, game.GetScore());
        }
        private void RollFrames(int roll1,int roll2,int numberOfFrames)
        {
            for(var frame = 0; frame < numberOfFrames; frame++)
            {
                game.RollFrame(roll1, roll2);
            }
        }
    }
}
