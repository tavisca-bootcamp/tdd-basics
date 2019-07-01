using System;
using Xunit;

namespace BowlingBall.Tests
{
   public class GameWorkingTest
    {
        [Fact]
        public void TestAllOnes()
        {
            Game game = new Game();
            var pins = new int[] { 1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1 };
            MultipleRollHandler(pins, ref game);
            Assert.Equal(20, game.GetScore());
        }
        [Fact]
        public void TestOneSpare()
        {
            Game game = new Game();
            game.Roll(5);
            game.Roll(5);
            game.Roll(5);
            rollMultipleTimes(17, 0, ref game);
            Assert.Equal(20, game.GetScore());
        }
        [Fact]
        public void TestOneStrike()
        {
            Game game = new Game();
            game.Roll(10);
            game.Roll(4);
            game.Roll(5);
            rollMultipleTimes(17, 0, ref game);
            Assert.Equal(28, game.GetScore());
        }
        [Fact]
        public void TestPerfectGame()
        {
            Game game = new Game();
            rollMultipleTimes(12, 10, ref game);
            Assert.Equal(300, game.GetScore());
        }
        [Fact]
        public void TestNoExtraRoll()
        {
            Game game = new Game();
            MultipleRollHandler(new int[] { 1, 3, 7, 3, 10, 1, 7, 5, 2, 5, 3, 8, 2, 8, 2, 10, 9, 0 },ref game);
            Assert.Equal(131, game.GetScore());
        }

        private void MultipleRollHandler(int[] pins, ref Game game)
        {
            foreach (int pin in pins)
                game.Roll(pin);

        }
        [Fact]
        public void TestWithSpareThenStrikeInEnd()
        {
            Game game = new Game();
            MultipleRollHandler(new int[] { 1, 3, 7, 3, 10, 1, 7, 5, 2, 5, 3, 8, 2, 8, 2, 10, 9, 1, 10 },ref game);
            Assert.Equal(143, game.GetScore());
        }
       

        private void rollMultipleTimes(int rolls, int pins, ref Game game)
        {
            for (int i = 0; i < rolls; i++)
                game.Roll(pins);
        }

    }
}
