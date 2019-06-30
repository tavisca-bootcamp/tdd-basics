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

        public void CompleteRollSet(int[] roll)
        {
            for (int i = 0; i < roll.Length; i++)
            {
                game.Roll(roll[i]);
            }
        }

        public void MultipleRoll(int roll, int pins)
        {
            for (int i = 0; i < roll; i++)
            {
                game.Roll(pins);
            }
        }

        [Fact]
        public void TestGameClass()
        {
            Assert.IsType<Game>(game);
        }

        [Fact]
        public void TestSpare()
        {
            game.Roll(7);
            game.Roll(3);
            Assert.Equal(10, game.GetScore());
        }

        [Fact]
        public void TestStrike()
        {
            game.Roll(10);
            Assert.Equal(10, game.GetScore());
        }

        [Fact]
        public void TestMissingRoll()
        {
            game.Roll(0);
            Assert.Equal(0, game.GetScore());
        }


        [Fact]
        public void TestCompleteRollSet()
        {
            int[] roll = { 10, 9, 1, 5, 5, 7, 2, 10, 10, 10, 9, 0, 8, 2, 9, 1, 10 };
            CompleteRollSet(roll);
            Assert.Equal(187, game.GetScore());
        }

        [Fact]
        public void TestPerfectGame()
        {
            MultipleRoll(12, 10);
            Assert.Equal(300, game.GetScore());
        }
    }
}
