using System;
using Xunit;

namespace BowlingBall.Tests
{
    public class GameFixture
    {
        Game g = new Game();

        [Fact]
        public void TestAllZeros()
        {
            rollMultipleChances(20, 0);
            Assert.Equal(0, g.GetScore());
        }

        [Fact]
        public void TestAllOnes()
        {
            rollMultipleChances(20, 1);
            Assert.Equal(20, g.GetScore());
        }

        [Fact]
        public void TestOneSpare()
        {
            Spare();
            g.Roll(4);
            rollMultipleChances(17, 0);
            Assert.Equal(18, g.GetScore());
        }

        [Fact]
        public void TestOneStrike()
        {
            g.Roll(10);
            g.Roll(4);
            g.Roll(5);
            rollMultipleChances(17, 0);
            Assert.Equal(28, g.GetScore());
        }

        [Fact]
        public void TestPerfectGame()
        {
            rollMultipleChances(12, 10);
            Assert.Equal(300, g.GetScore());
        }

        [Fact]
        public void TestNoExtraRoll()
        {
            g.Roll(new int[] { 1, 3, 7, 3, 10, 1, 7, 5, 2, 5, 3, 8, 2, 8, 2, 10, 9, 0 });
            Assert.Equal(131, g.GetScore());
        }

        [Fact]
        public void TestWithSpareThenStrikeInEnd()
        {
            g.Roll(new int[] { 1, 3, 7, 3, 10, 1, 7, 5, 2, 5, 3, 8, 2, 8, 2, 10, 9, 1, 10 });
            Assert.Equal(143, g.GetScore());
        }

        [Fact]
        public void TestWithThreeStrikesInEnd()
        {
            g.Roll(new int[] { 1, 3, 7, 3, 10, 1, 7, 5, 2, 5, 3, 8, 2, 8, 2, 10, 10, 10, 10 });
            Assert.Equal(163, g.GetScore());
        }

        private void rollMultipleChances(int rolls, int pins)
        {
            for (int i = 0; i < rolls; i++)
                g.Roll(pins);
        }

        private void Spare()
        {
            g.Roll(6);
            g.Roll(4);
        }

    }
}
