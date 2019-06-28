using System;
using Xunit;

namespace BowlingBall.Tests
{
    public class GameFixture
    {
        [Fact]
        public void DummyTest()
        {
            // This is a dummy test that will always pass.
        }
        [Fact]
        public void TotalZeroScore() {
            Game game = new Game();
            int[] rolls = {0,0,0,0,0,0,10,0,0,0};
            game.MultipleRolls(rolls);
            int score = game.GetScore();
            Assert.Equal(10,score);
        }
        [Fact]
        public void AllStrikeAndStrikeAfterStrikeScoreTest()
        {
            Game game = new Game();
            int[] rolls = { 10,10,10,10,10,10,10,10,10,10,10,10 };
            game.MultipleRolls(rolls);
            int score = game.GetScore();
            Assert.Equal(300, score);
        }
        [Fact]
        public void AllSpearAndSpearAfterSpearScoreTest()
        {
            Game game = new Game();
            int[] rolls = { 0, 10, 5, 5, 6, 4, 2, 8, 9, 1, 1, 9,7,3,5,5,4,6,0,10,10 };
            game.MultipleRolls(rolls);
            int score = game.GetScore();
            Assert.Equal(149, score);
        }

        [Fact]
        public void RandomInputScoreTest()
        {
            Game game = new Game();
            int[] rolls = {10,9,1,5, 5, 7, 2, 10, 10, 10, 9, 0,8,2,9,1,10 };
             game.MultipleRolls(rolls);
            int score = game.GetScore();
            Assert.Equal(187, score);
        }
        [Fact]
        public void StrikeAfterSpear()
        {
            Game game = new Game();
             int[] rolls = { 1, 4, 5, 4, 6, 4, 5, 5, 10, 0, 1, 7, 3, 6, 4, 10, 2, 8, 6 };
            game.MultipleRolls(rolls);
            int score = game.GetScore();
            Assert.Equal(133, score);

        }
        [Fact]
        public void SpearAfterStrike()
        {
            Game game = new Game();
            int[] rolls = { 1, 4, 5, 4, 6, 4, 5, 5, 10, 5, 5, 7, 3, 6, 4, 10, 2, 8, 6 };
            game.MultipleRolls(rolls);
            int score = game.GetScore();
            Assert.Equal(158, score);


        }
    }
}
