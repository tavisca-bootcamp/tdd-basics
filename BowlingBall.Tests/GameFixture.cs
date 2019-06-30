using System;
using Xunit;

namespace BowlingBall.Tests
{
    public class GameFixture
    {
        Game game = new Game();
        private void RollMany(int n, int pins)
        {
            for(int i=0; i<n; i++)
            {
                game.Roll(pins);
            }
        }

        private void RollMany(int[] pins)
        {
            for(int i=0; i<pins.Length; i++)
            {
                game.Roll(pins[i]);
            }
        }

        [Fact]
        public void TestForAllZeros()
        {
            RollMany(20, 0);
            Assert.Equal(0, game.GetScore());
        }

        [Fact]
        public void TestForAllOnes()
        {
            RollMany(20, 1);
            Assert.Equal(20, game.GetScore());
        }

        [Fact]
        public void TestOneSpare()
        {
            game.Roll(4);
            game.Roll(6);
            game.Roll(3);
            RollMany(17, 0);
            Assert.Equal(16, game.GetScore());
        }

        [Fact]
        public void TestOneStrike()
        {
            game.Roll(10);
            game.Roll(3);
            game.Roll(4);
            RollMany(16, 0);
            Assert.Equal(24, game.GetScore());
        }

        [Fact]
        public void TestPerfectGame()
        {
            RollMany(12, 10);
            Assert.Equal(300, game.GetScore());
        }

        [Fact]
        public void TestRandomGame()
        {
            int[] pins = { 5, 4, 9, 1, 7, 3, 2, 0, 10, 10, 6, 2, 3, 3, 10, 3, 7, 6 };
            RollMany(pins);
            Assert.Equal(134, game.GetScore());
        }

        [Fact]
        public void TestProblemStatementGame()
        {
            int[] pins = { 10, 9, 1, 5, 5, 7, 2, 10, 10, 10, 9, 0, 8, 2, 9, 1, 10 };
            RollMany(pins);
            Assert.Equal(187, game.GetScore());
        }
    }
}
