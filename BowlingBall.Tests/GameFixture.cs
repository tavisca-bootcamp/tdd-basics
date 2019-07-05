using System;
using Xunit;
using BowlingBall;
//using Moq;

namespace BowlingBall.Tests
{
    public class GameFixture
    {

        [Fact]
        public void Game_when_UserRollsValidInput_should_ReturnCorrectScore()
        {
            Game game = new Game();
            int[] pins = { 1, 2, 3, 4 };

            game.Roll(pins);

            Assert.Equal(10, game.GetScore());

        }

        [Fact]
        public void Game_when_UserRollsAllZeroes_should_ReturnCorrectScore()
        {
            Game game = new Game();
            int[] pins = { 0,0,0,0,0,0,0,0 };

            game.Roll(pins);

            Assert.Equal(0, game.GetScore());
        }

        [Fact]
        public void Game_when_UserRollsAllOnes_should_ReturnCorrectScore()
        {
            Game game = new Game();
            int[] pins = { 1, 1, 1, 1, 1, 1, 1, 1 };

            game.Roll(pins);

            Assert.Equal(8, game.GetScore());
        }

        [Fact]
        public void Game_when_UserRollsSpare_should_ReturnCorrectScore()
        {
            Game game = new Game();
            int[] pins = { 9, 1 , 1 , 2};
            game.Roll(pins);

            Assert.Equal(14, game.GetScore());
            //Mock<IFrames> mockObject = new Mock<IFrames>();
            //mockObject.Setup(m => m.IsSpare()).Returns(true);
        }

        [Fact]

        //Failed because odd length input, Frames class sets an array of 2
        public void Game_when_UserRollsStrike_should_ReturnCorrectScore()
        {
            Game game = new Game();
            int[] pins = { 10  , 2 , 3};
            game.Roll(pins);

            Assert.Equal(20 , game.GetScore());
            //Mock<IFrames> mockObject = new Mock<IFrames>();
            //mockObject.Setup(m => m.IsStrike()).Returns(true);
        }

        [Fact]

        public void Game_when_UserRollsForAllValues_should_ReturnCorrectScore()
        {
            Game game = new Game();
            int[] pins = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 0};

            game.Roll(pins);

            Assert.Equal(90 , game.GetScore());
        }

        [Fact]
        public void Game_when_UserRollsOddInput_should_ReturnCorrectScore()
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
            int[] pins = { 1, 2, 45, 8 };

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

        public void Game_when_UserRollsSpareOnLastFrame_should_ReturnCorrectScore()
        {
            Game game = new Game();
            int[] pins = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 1, 1 };

            game.Roll(pins);

            Assert.Equal(92, game.GetScore());
        }

        [Fact]

        public void Game_when_UserRollsStrikeOnLastFrame_should_ReturnCorrectScore()
        {
            Game game = new Game();
            int[] pins = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 0, 1, 2, 3, 4, 5, 6, 7, 8, 10, 1 };

            game.Roll(pins);

            Assert.Equal(92, game.GetScore());
        }

    }
}
