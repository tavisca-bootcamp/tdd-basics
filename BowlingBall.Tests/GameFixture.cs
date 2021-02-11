using System;
using Xunit;

namespace BowlingBall.Tests
{
    public class GameFixture
    {
        private readonly Game _game;
        public GameFixture()
        {
            _game = new Game();
        }
        [Fact]
        public void Expected_ZeroScore_GutterGame()
        {
            for (var i =0; i<20; i++)
            {
                _game.Roll(pins : 0);
            }
            Assert.Equal(expected: 0, actual: _game.GetScore());
        }

        [Fact]
        public void Expected_twenty_OnesGame()
        {
            var pins = 1;
            var rolls = 20;
            for (var i = 0; i < rolls; i++)
            {
                _game.Roll(pins);
            }
            Assert.Equal(expected: 20, actual: _game.GetScore());
        }


        [Fact]
        public void SpareGame()
        {
            _game.Roll(pins: 5);
            _game.Roll(pins: 5);
            _game.Roll(pins: 3);
            for (var i = 0; i < 17; i++)
            {
                _game.Roll(pins: 0);
            }
            Assert.Equal(expected: 16, actual: _game.GetScore());
        }


        [Fact]
        public void StrikeGame()
        {
            _game.Roll(pins: 10);
            _game.Roll(pins: 3);
            _game.Roll(pins: 4);
            for (var i = 0; i < 16; i++)
            {
                _game.Roll(pins: 0);
            }
            Assert.Equal(expected: 24, actual: _game.GetScore());
        }


        [Fact]
        public void PerfectGame()
        {
            _game.Roll(pins: 10);
            
            for (var i = 0; i < 12; i++)
            {
                _game.Roll(pins: 10);
            }
            Assert.Equal(expected: 300, actual: _game.GetScore());
        }
    }
}
