using System;
using Xunit;
namespace BowlingBall.Tests
{
    public class GameFixture
    {
        private Game _game = null;

        public GameFixture()
        {
            _game = new Game();
        }

        [Fact]
        public void AllGutterBalls()
        {
            RollFrames(0, 0, 10);
            Assert.Equal(0, _game.GetScore());
        }

        [Fact]
        public void All2s()
        {
            RollFrames(2, 2,10);
            Assert.Equal(40, _game.GetScore());
        }

        [Fact]
        public void FirstFrameSpare()
        {
            _game.RollSpare(2, 8);
            RollFrames(2, 2, 9);
            Assert.Equal(48, _game.GetScore());
        }

        [Fact]
        public void FirstTwoFramesSpare()
        {
            _game.RollSpare(2, 8);
            _game.RollSpare(2, 8);
            RollFrames(2, 2, 8);
            Assert.Equal(56, _game.GetScore());
        }

        [Fact]
        public void BowlMoreThan10Frames()
        {
            Exception ex = Assert.Throws<IndexOutOfRangeException>(() => RollFrames(2, 2, 11));
        }

        [Fact]
        public void FirstFrameStrike()
        {
            _game.RollStrike();
            RollFrames(2, 2, 9);
            Assert.Equal(50, _game.GetScore());
        }

        [Fact]
        public void FirstTwoFramesStrikes()
        {
            _game.RollStrike();
            _game.RollStrike();
            RollFrames(2, 2, 8);
            Assert.Equal(68, _game.GetScore());
        }


        [Fact]
        public void PerfectGame()
        {
            for (var i = 1; i <= 9; i++)
            {
                _game.RollStrike();
            }
            _game.RollTenthFrame(10, 10, 10);
            Assert.Equal(300, _game.GetScore());
        }

        [Fact]
        public void RandomGame()
        {
            _game.RollSpare(3, 7);
            for (var i = 0; i < 4; i++)
                _game.RollFrame(i, i + 1);
            for (var j = 4; j >0; j--)
                _game.RollFrame(j, j + 1);
            _game.RollTenthFrame(10, 10, 10);

            Assert.Equal(80, _game.GetScore());
        }

        [Fact]
        public void LastFrameStrike()
        {
            RollFrames(2, 2, 9);
            _game.RollTenthFrame(10,10,10);
            Assert.Equal(66, _game.GetScore());
        }
        private void RollFrames(int roll1,int roll2,int numberOfFrames)
        {
            for(var frame = 0; frame < numberOfFrames; frame++)
            {
                _game.RollFrame(roll1, roll2);
            }
        }
    }
}
