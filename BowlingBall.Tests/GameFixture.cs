using System;
using Xunit;

namespace BowlingBall.Tests
{
    public class GameFixture
    {
        private Game game = new Game();

        public GameFixture()
        {
            game = new Game();
        }

        [Fact]
        public void DummyTest()
        {
            // This is a dummy test that will always pass.
        }

        [Fact]
        public void RequiredTest()
        {
            int[] score = { 10, 9, 1, 5, 5, 7, 2, 10, 10, 10, 9, 0, 8, 2, 9, 1, 10 };
            for (var i = 0; i < score.Length; i++)
            {
                game.Roll(score[i]);
            }

            Assert.Equal(187, game.GetScore());
        }

        [Fact]
        public void AllStrikeTest()
        {
            for (var i = 0; i < 12; i++)
                game.Roll(10);

            Assert.Equal(300, game.GetScore());
        }

        [Fact]
        public void AllSpares()
        {
            for (var i = 0; i < 21; i++)
                game.Roll(5);
            Assert.Equal(150, game.GetScore());
        }

        [Fact]
        public void RollWithAllZero()
        {
            for (var i = 0; i < 20; i++)
                game.Roll(0);
            Assert.Equal(0, game.GetScore());
        }
    }
}
