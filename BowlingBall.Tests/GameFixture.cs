using System;
using Xunit;

namespace BowlingBall.Tests
{
    public class GameFixture
    { 
        private void ManyRolls(int n,int pins,Game game)
        {
            for (int i = 0; i < n; i++)
                game.Roll(pins);

        }
        private void StrikeRoll(Game game)
        {
            game.Roll(10);
        }
        private void SpareRoll(Game game)
        {
            game.Roll(5);
            game.Roll(5);
        }
        [Fact]
        public void TestAllZero() 
        {
            Game game = new Game();
            ManyRolls(20, 0, game);          
            Assert.Equal(0, game.GetScore());
            // This is a dummy test that will always pass.
        }


        [Fact]
        public void TestAllOnes() 
        {
            var game = new Game();
            ManyRolls(20, 1, game);
            Assert.Equal(20, game.GetScore());
            
        }
        [Fact]
        public void TestOneStrikeGame()
        {
            Game game = new Game();
            StrikeRoll(game);
            ManyRolls(18, 2, game);
            Assert.Equal(50, game.GetScore());

        }

        [Fact]
        public void TestAllStrikesGame()
        {
            Game game = new Game();
            ManyRolls(12, 10, game);
            Assert.Equal(300, game.GetScore());

        }

        [Fact]
        public void TestOneSpareGame()
        {
            Game game = new Game();
            SpareRoll(game);
            ManyRolls(18, 2, game);
            Assert.Equal(48, game.GetScore());

        }

        [Fact]
        public void TestAllSparesGame()
        {
            Game game = new Game();
            ManyRolls(21, 5, game);
            Assert.Equal(150, game.GetScore());

        }
        [Fact]
        public void FirstHalfStrikesSecondHalfSparesGame()
        {
            Game game = new Game();
            ManyRolls(5, 10, game);
            ManyRolls(11, 5, game);
            Assert.Equal(210, game.GetScore());

        }
        [Fact]
        public void FirstHalfSparesSecondHalfStrikesGame()
        {
            Game game = new Game();
            ManyRolls(10, 5, game);
            ManyRolls(7, 10, game);
            Assert.Equal(230, game.GetScore());

        }
        [Fact]
        public void CheckingTenthFrameStrike()
        {
            Game game = new Game();
            ManyRolls(18, 0, game);
            ManyRolls(3, 10, game);
            Assert.Equal(30, game.GetScore());

        }

        [Fact]
        public void CheckingTenthFrameSpare()
        {
            Game game = new Game();
            ManyRolls(18, 0, game);
            ManyRolls(3, 5, game);
            Assert.Equal(15, game.GetScore());

        }
        [Fact]
        public void TestAllMixedGame()
        {
            Game game = new Game();
            game.Roll(10);
            game.Roll(9);
            game.Roll(1);
            game.Roll(5);
            game.Roll(5);
            game.Roll(7);
            game.Roll(2);
            game.Roll(10);
            game.Roll(10);
            game.Roll(10);
            game.Roll(9);
            game.Roll(0);
            game.Roll(8);
            game.Roll(2);
            game.Roll(9);
            game.Roll(1);
            game.Roll(10);

            Assert.Equal(187, game.GetScore());

        }



    }
}
