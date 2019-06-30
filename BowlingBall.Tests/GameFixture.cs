using System;
using Xunit;

namespace BowlingBall.Tests
{
    public class GameFixture
    {
        Game game = new Game();

        [Fact]
        public void NormalRoll()
        {
            game.Roll(new int[] { 2, 2 });
            Assert.Equal(4, game.GetScore());
        }

        [Fact]
        public void StrikeOnly()
        {
            game.Roll(new int[] { 8, 1, 10, 6, 2 });
            Assert.Equal(35, game.GetScore());
        }

        [Fact]
        public void SpareOnly()
        {
            game.Roll(new int[] { 2, 8, 8, 1, 6, 2 });
            Assert.Equal(35, game.GetScore());
        }

        [Fact]
        public void StrikeThenSpare()
        {
            game.Roll(new int[] { 10, 2, 8, 1, 6 });
            Assert.Equal(38, game.GetScore());
        }

        [Fact]
        public void SpareThenStrike()
        {
            game.Roll(new int[] { 2, 8, 10, 1, 6 });
            Assert.Equal(44, game.GetScore());
        }

        [Fact]
        public void StrikeOnLastRoll()
        {
            game.Roll(new int[] { 2, 6, 10, 1, 8, 10 });
            Assert.Equal(46, game.GetScore());
        }

        [Fact]
        public void SpareOnLastRoll()
        {
            game.Roll(new int[] { 2, 8, 10, 2, 8 });
            Assert.Equal(50, game.GetScore());
        }

        [Fact]
        public void AllStrikes()
        {
            game.Roll(new int[] { 10, 10, 10, 10, 10 });
            Assert.Equal(120, game.GetScore());
        }

        [Fact]
        public void TwoConsecutiveStrike()
        {
            game.Roll(new int[] { 1, 5, 10, 10, 5, 2 });
            Assert.Equal(55, game.GetScore());
        }

        [Fact]
        public void TwoConsecutiveSpare()
        {
            game.Roll(new int[] { 2, 2, 5, 5, 7, 3, 5, 0 });
            Assert.Equal(41, game.GetScore());
        }
    }
}
