using System;
using Xunit;

namespace BowlingBall.Tests
{
    public class GameFixture
    {
        Game game = new Game();

        [Fact]
        public void TestAllZeros()
        {
            RollMultipleChances(20, 0);
            Assert.Equal(0, game.GetScore());
        }

        [Fact]
        public void TestAllOnes()
        {
            RollMultipleChances(20, 1);
            Assert.Equal(20, game.GetScore());
        }

        [Fact]
        public void TestOneSpare()
        {
            Spare();
            game.Roll(4);
            RollMultipleChances(17, 0);
            Assert.Equal(18, game.GetScore());
        }

        [Fact]
        public void TestOneStrike()
        {
            game.Roll(10);
            game.Roll(4);
            game.Roll(5);
            RollMultipleChances(17, 0);
            Assert.Equal(28, game.GetScore());
        }

        [Fact]
        public void TestPerfectGame()
        {
            RollMultipleChances(12, 10);
            Assert.Equal(300, game.GetScore());
        }

        [Fact]
        public void TestNoExtraRoll()
        {
            game.Roll(new int[] { 1, 3, 7, 3, 10, 1, 7, 5, 2, 5, 3, 8, 2, 8, 2, 10, 9, 0 });
            Assert.Equal(131, game.GetScore());
        }

        [Fact]
        public void TestWithSpareThenStrikeInEnd()
        {
            game.Roll(new int[] { 1, 3, 7, 3, 10, 1, 7, 5, 2, 5, 3, 8, 2, 8, 2, 10, 9, 1, 10 });
            Assert.Equal(143, game.GetScore());
        }

        [Fact]
        public void TestWithThreeStrikesInEnd()
        {
            game.Roll(new int[] { 1, 3, 7, 3, 10, 1, 7, 5, 2, 5, 3, 8, 2, 8, 2, 10, 10, 10, 10 });
            Assert.Equal(163, game.GetScore());
        }

        private void RollMultipleChances(int rolls, int pins)
        {
            for (int i = 0; i < rolls; i++)
                game.Roll(pins);
        }

        private void Spare()
        {
            game.Roll(6);
            game.Roll(4);
        }

    }
}
