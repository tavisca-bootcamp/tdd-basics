using System;
using Xunit;

namespace BowlingBall.Tests
{
    public class GameFixture
    {
        private Game game;

        public GameFixture()
        {
            game = new Game();
        }

        private void RollMany(int n, int pins)
        {
            for (int i = 0; i < n; i++)
                game.Roll(pins);
        }

        [Fact]
        public void TestGutterGame()
        {
            int n = 20;
            int pins = 0;
            RollMany(n, pins);
            Assert.Equal(0, game.GetScore());
        }

        [Fact]
        public void TestOnes()
        {
            int n = 20;
            int pins = 1;
            RollMany(n, pins);
            Assert.Equal(20, game.GetScore());
        }

        [Fact]
        public void TestSpare()
        {
            game.Roll(5);
            game.Roll(5);
            game.Roll(5);
            RollMany(17, 1);
            Assert.Equal(37, game.GetScore());
        }

        [Fact]
        public void TestStroke()
        {
            game.Roll(10);
            game.Roll(4);
            game.Roll(2);
            RollMany(17, 0);
            Assert.Equal(22, game.GetScore());
        }

        [Fact]
        public void TestPerfectGame()
        {
            RollMany(12, 10);
            Assert.Equal(300, game.GetScore());
        }
    }
}
