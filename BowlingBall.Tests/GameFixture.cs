using System;
using Xunit;

namespace BowlingBall.Tests
{
    public class GameFixture
    {
        Game game;

        public GameFixture()
        {
            game = new Game();
        }


        [Fact]
        public void CanScoreGutterGame()
        {
            int[] rolls = { 0,0, 0,0, 0,0, 0,0, 0,0, 0,0, 0,0, 0,0, 0,0, 0,0 };
            game.Roll(rolls);
            Assert.Equal(0, game.GetScore());
        }

        [Fact]
        public void CanScoreGameOfOnes()
        {
            int[] rolls = { 1,1, 1,1, 1,1, 1,1, 1,1, 1,1, 1,1, 1,1, 1,1, 1,1 };
            game.Roll(rolls);
            Assert.Equal(20, game.GetScore());
        }

        [Fact]
        public void CanScoreSpareFollowedByThree()
        {
            int[] rolls = { 5,5, 3,0, 0,0, 0,0, 0,0, 0,0, 0,0, 0,0, 0,0, 0,0 };
            game.Roll(rolls);
            Assert.Equal(16, game.GetScore());
        }

        [Fact]
        public void CanScoreStrikeFollowedByThreeThenThree()
        {
            int[] rolls = { 10, 3,3, 0,0, 0,0, 0,0, 0,0, 0,0, 0,0, 0,0, 0,0 };
            game.Roll(rolls);
            Assert.Equal(22, game.GetScore());
        }

    }
}
