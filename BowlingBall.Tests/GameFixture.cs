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
        public void canScoreGutterGame()
        {
            int[] a = { 0,0, 0,0, 0,0, 0,0, 0,0, 0,0, 0,0, 0,0, 0,0, 0,0 };
            game.Roll(a);
            Assert.Equal(0, game.GetScore());
        }

        [Fact]
        public void canScoreGameOfOnes()
        {
            int[] a = { 1,1, 1,1, 1,1, 1,1, 1,1, 1,1, 1,1, 1,1, 1,1, 1,1 };
            game.Roll(a);
            Assert.Equal(20, game.GetScore());
        }

        [Fact]
        public void canScoreSpareFollowedByThree()
        {
            int[] a = { 5,5, 3,0, 0,0, 0,0, 0,0, 0,0, 0,0, 0,0, 0,0, 0,0 };
            game.Roll(a);
            Assert.Equal(16, game.GetScore());
        }

        [Fact]
        public void canScoreStrikeFollowedByThreeThenThree()
        {
            int[] a = { 10, 3,3, 0,0, 0,0, 0,0, 0,0, 0,0, 0,0, 0,0, 0,0 };
        }

    }
}
