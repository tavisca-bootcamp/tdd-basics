using System;
using Xunit;

namespace BowlingBall.Tests
{
    public class GameFixture
    {
        [Fact]
        public void TestAllZeroPins()
        {
            Game game = new Game();
            int k;
            for (k = 0; k < 20; k++)
                game.Roll(0);
            Assert.Equal(0, game.GetScore());
        }

        [Fact]
        public void TestAllOnePins()
        {
            Game game = new Game();
            int k;
            for (k = 0; k < 20; k++)
                game.Roll(1);
            Assert.Equal(20, game.GetScore());
        }

        [Fact]
        public void TestOneSpare()
        {
            Game game = new Game();
            int k;
            game.Roll(5);
            game.Roll(5);
            game.Roll(2);
            for (k = 0; k < 17; k++)
                game.Roll(1);
            Assert.Equal(31, game.GetScore());
        }

        [Fact]
        public void TestOneStrike()
        {
            Game game = new Game();
            int k;
            game.Roll(10);
            game.Roll(5);
            game.Roll(2);
            for (k = 0; k < 16; k++)
                game.Roll(1);
            Assert.Equal(40, game.GetScore());
        }


        [Fact]
        public void TestStrikeAndSpare()
        {
            Game game = new Game();
            int k;
            int[] rolls = { 10, 9, 1, 5, 5, 7, 2, 10, 10, 10, 9, 0, 8, 2, 9, 1, 10 };
            for (k = 0; k < rolls.Length; k++)
                game.Roll(rolls[k]);
            Assert.Equal(187, game.GetScore());
        }
    }
}
