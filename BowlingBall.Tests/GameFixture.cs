using System;
using Xunit;

namespace BowlingBall.Tests
{
    public class GameFixture
    {        
        [Fact]
        public void GetScore_AllZeroes()
        {
            Game game = new Game();
            for (int i = 0; i < 20; i++)
            {
                game.Roll(0);
            }

            Assert.Equal(0, game.GetScore());
        }

        [Fact]
        public void GetScore_AllOnes()
        {
            Game game = new Game();
            for (int i = 0; i < 20; i++)
            {
                game.Roll(1);
            }

            Assert.Equal(20, game.GetScore());
        }


        [Fact]
        public void GetScore_AllSpares()
        {
            Game game = new Game();
            for (int i = 0; i < 21; i++)
            {
                game.Roll(5);
            }

            Assert.Equal(150, game.GetScore());
        }

        [Fact]
        public void GetScore_AllStrikes()
        {
            Game game = new Game();
            for (int i = 0; i < 10; i++)
            {
                game.Roll(10);
            }

            Assert.Equal(300, game.GetScore());
        }

        [Theory]
        [InlineData(new int[] { 7, 2, 4, 2, 4, 6, 3, 1, 5, 4, 2, 7, 4, 3, 4, 5, 6, 4, 3, 7, 5 }, 94)]
        public void GetScore_RandomPins(int[] inputPins, int expected)
        {
            Game game = new Game();
            for (int i = 0; i < inputPins.Length; i++)
            {
                game.Roll(inputPins[i]);
            }

            Assert.Equal(expected, game.GetScore());
        }

    }
}
