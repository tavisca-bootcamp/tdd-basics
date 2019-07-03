using System;
using Xunit;

namespace BowlingBall.Tests
{
    public class GameFixture
    {
        private Game _game;

        public GameFixture()
        {
            _game = new Game();
        }

        private void RollMany(int nRolls, int pins)
        {
            for(int index = 0; index < nRolls; index++)
            {
                _game.Roll(pins);
            }
        }
        [Fact]
        public void TestGutterGame()
        {

            //act
            RollMany(20, 0);

            int expected = 0;
            int actual = _game.GetScore();

            //assert
            Assert.Equal(actual, expected);

        }

        [Fact]
        public void TestAllOnes()
        {
            //act
            RollMany(20, 1);
            int expected = 20;
            int actual = _game.GetScore();

            //assert
            Assert.Equal(actual, expected);

        }

        [Fact]
        public void TestOneSpare()
        {
            _game.Roll(5);
            _game.Roll(5);
            _game.Roll(3);
            RollMany(17, 0);

            Assert.Equal(16, _game.GetScore());
        }

        [Fact]
        public void TestOneStrike()
        {
            RollStrike();
            _game.Roll(3);
            _game.Roll(4);
            RollMany(16, 0);
            Assert.Equal(24, _game.GetScore());
        }

        [Fact]
        public void TestPerfectStrike()
        {
            RollMany(12, 10);
            Assert.Equal(300, _game.GetScore());
        }

        private void RollStrike()
        {
            _game.Roll(10);
        }
    }
}
