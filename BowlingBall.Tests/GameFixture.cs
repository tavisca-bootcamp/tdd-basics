using System;
using Xunit;

namespace BowlingBall.Tests
{
    public class GameFixture
    {
        Game game = new Game();
        [Fact]
        public void CanRollGutterGame()
        {
            RollMany(0,20);
            Assert.Equal(0,game.GetScore());
        }

        [Fact]
        public void CanRollSpare()
        {
            game.Roll(5);
            game.Roll(5);
            game.Roll(3);
            RollMany(0, 17);
            Assert.Equal(16, game.GetScore());
        }

        [Fact]
        public void CanRollStrike()
        {
            game.Roll(10);
            game.Roll(5);
            game.Roll(3);
            RollMany(0, 16);
            Assert.Equal(26, game.GetScore());
        }

        [Fact]
        public void CanRollPerfectGame()
        {
            RollMany(10, 12);
            Assert.Equal(300, game.GetScore());
        }

        public void RollMany(int pins, int rolls) {
            for (int i = 0; i < rolls; i++)
            {
                game.Roll(pins);
            }
        }
    }
}
