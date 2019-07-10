using System;
using Xunit;
using BowlingBall;

namespace BowlingBall.Tests
{
    public class GameFixture
    {

        [Fact]
        public void Game_when_UserRollsValidInput_should_ReturnValidOutput()
        {
            Game game = new Game();
            int[] pins = { 1, 2, 3, 4 };

            game.Roll(pins);

            Assert.Equal(10, game.GetScore());

        }

        [Fact]
        public void Game_when_UserRollsAllZeroes_should_ReturnZeroScore()
        {
            Game game = new Game();
            int[] pins = { 0,0,0,0,0,0,0,0 };

            game.Roll(pins);

            Assert.Equal(0, game.GetScore());
        }

        [Fact]
        public void Game_when_UserRollsAllOnes_should_ReturnValidOutput()
        {
            Game game = new Game();
            int[] pins = { 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1 };

            game.Roll(pins);

            Assert.Equal(20, game.GetScore());
        }

        [Fact]
        public void Game_when_UserRollsSpare_should_ReturnScoreWithAddedSpareBonus()
        {
            Game game = new Game();
            int[] pins = { 9, 1 , 1 , 2};
            game.Roll(pins);

            Assert.Equal(14, game.GetScore());
        }

        [Fact]

        public void Game_when_UserRollsStrike_should_ReturnScoreWithAddedStrikeBonus()
        {
            Game game = new Game();
            int[] pins = { 10  , 2 , 3};
            game.Roll(pins);

            Assert.Equal(20 , game.GetScore());
        }

        [Fact]

        public void Game_when_UserRollsForAllValues_should_ReturnValidOutput()
        {
            Game game = new Game();
            int[] pins = { 1, 2, 3, 4, 5, 4, 7, 1, 9, 0, 1, 2, 3, 4, 5, 4, 7, 1, 9, 0};

            game.Roll(pins);

            Assert.Equal(72 , game.GetScore());
        }

        [Fact]
        public void Game_when_UserIsStillPlaying_should_ReturnScoreWithoutAddingIncompleteFrame()
        {
            Game game = new Game();
            int[] pins = { 1, 2, 3 };

            game.Roll(pins);

            // 1+2 = 3 beacuse the user is still playing for second frame (3,-)
            Assert.Equal(3, game.GetScore());
        }

        [Fact]
        public void Game_when_UserRollsInValidInput_should_ThrowException()
        {
            Game game = new Game();
            int[] pins = { 1, 2, 7, 8 };

            Exception ex = Assert.Throws<ArgumentOutOfRangeException>(() => game.Roll(pins));

            Assert.Equal("Specified argument was out of the range of valid values.", ex.Message);
        }

        [Fact ]

        public void Game_when_UserRollsMoreThanPossiblePins_should_ThrowException()
        {
            Game game = new Game();
            int[] pins = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 0, 1, 2 };

            Exception ex = Assert.Throws<ArgumentOutOfRangeException>(() => game.Roll(pins));

            Assert.Equal("Specified argument was out of the range of valid values.", ex.Message);
        }

        [Fact]

        public void Game_when_UserRollsSpareOnLastFrame_should_ReturnScoreWithAddedExtraBonus()
        {
            Game game = new Game();
            int[] pins = { 1, 2, 3, 4, 5, 4, 7, 1, 9, 0, 1, 2, 3, 4, 5, 4, 7, 1, 9, 1, 1 };

            game.Roll(pins);

            Assert.Equal(74, game.GetScore());
        }

        [Fact]

        public void Game_when_UserRollsStrikeOnLastFrame_should_ReturnScoreWithAddedExtraBonus()
        {
            Game game = new Game();
            int[] pins = { 1, 2, 3, 4, 5, 4, 7, 1, 9, 0, 1, 2, 3, 4, 5, 4, 7, 1, 10, 1 , 1 };

            game.Roll(pins);

            Assert.Equal(75, game.GetScore());
        }

        [Fact]
        public void Game_when_UserRollsRandomGameWithManyStrikes_should_ReturnScoreWithAddedExtraBonus()
        {
            Game game = new Game();
            int[] pins = { 10, 9, 1, 5, 5, 7, 2, 10, 10, 10, 9, 0, 8, 2 , 9 , 1 , 10};

            game.Roll(pins);

            Assert.Equal(187, game.GetScore());
        }

        [Fact]
        public void Game_when_UserRollsAllStrikes_should_ReturnPerfectGameScore300()
        {
            Game game = new Game();

            int[] pins = { 10, 10, 10, 10, 10, 10, 10, 10, 10, 10 , 10 , 10};

            game.Roll(pins);

            Assert.Equal(300, game.GetScore());
        }

        [Fact]
        public void Game_when_UserRollsAllSpares_should_ReturnValidScore()
        {
            Game game = new Game();

            int[] pins = { 9 , 1 , 9 , 1 , 9 , 1 , 9 , 1 , 9 , 1 , 9 , 1, 9, 1, 9, 1, 9, 1, 9, 1 , 9};

            game.Roll(pins);

            Assert.Equal(190, game.GetScore());
        }
    }
}
