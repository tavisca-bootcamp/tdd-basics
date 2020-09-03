using System;
using Xunit;

namespace BowlingBall.Tests
{
    public class GameFixture
    {
        [Fact]
        public void GetScore_AllRollsWithInputZero_ReturnsZero() {
            Game game = new Game();
            for (int i = 0; i < 20; i++) {
                game.Roll(0);
            }

            Assert.Equal(0, game.GetScore());
        }

        [Fact]
        public void GetScore_AllRollsWithInputOne_ReturnsTwenty() {
            Game game = new Game();
            for (int i = 0; i < 20; i++) {
                game.Roll(1);
            }

            Assert.Equal(20, game.GetScore());
        }

        [Fact]
        public void GetScore_AllFramesWithSpares() {
            Game game = new Game();
            for (int i = 0; i < 21; i++) {
                game.Roll(5);
            }

            Assert.Equal(150, game.GetScore());
        }

        [Fact]
        public void GetScore_AllFramesWithStrikes() {
            Game game = new Game();
            for (int i = 0; i < 12; i++) {
                game.Roll(10);
            }

            Assert.Equal(300, game.GetScore());
        }

        [Theory]
        [InlineData(new int[] { 7, 2, 4, 2, 4, 6, 3, 1, 5, 4, 2, 7, 4, 3, 4, 5, 6, 4, 3, 7, 5 }, 94)]
        [InlineData(new int[] { 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 10 }, 155)]
        [InlineData(new int[] { 5, 5, 10, 10, 6, 3, 6, 4, 7, 3, 2, 6, 4, 3, 2, 7, 5, 4 }, 136)]
        [InlineData(new int[] { 10, 9, 1, 5, 5, 7, 2, 10, 10, 10, 9, 0, 8, 2, 9, 1, 10 }, 187)]
        public void GetScore_RandomPins(int[] inputPins, int expected) {
            Game game = new Game();
            for (int i = 0; i < inputPins.Length; i++) {
                game.Roll(inputPins[i]);
            }

            Assert.Equal(expected, game.GetScore());
        }
    }
}
