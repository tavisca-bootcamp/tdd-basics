using System;
using Xunit;
using BowlingBall;
//using Moq;

namespace BowlingBall.Tests
{
    public class GameFixture
    {

        [Fact]
        public void Game_when_UserRollsValidInput()
        {
            Game game = new Game();
            int[] pins = { 1, 2, 3, 4 };

            game.Roll(pins);

            Assert.Equal(10, game.GetScore());

        }

        [Fact]
        public void Game_when_UserRollsAllZeroes()
        {
            Game game = new Game();
            int[] pins = { 0,0,0,0,0,0,0,0 };

            game.Roll(pins);

            Assert.Equal(0, game.GetScore());
        }

        [Fact]
        public void Game_when_UserRollsAllOnes()
        {
            Game game = new Game();
            int[] pins = { 1, 1, 1, 1, 1, 1, 1, 1 };

            game.Roll(pins);

            Assert.Equal(8, game.GetScore());
        }

        [Fact]
        public void Game_when_UserRollsSpare()
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
        public void Game_when_UserRollsStrike()
        {
            Game game = new Game();
            int[] pins = { 10 , 0 , 2 , 3};
            game.Roll(pins);

            Assert.Equal(20 , game.GetScore());
            //Mock<IFrames> mockObject = new Mock<IFrames>();
            //mockObject.Setup(m => m.IsStrike()).Returns(true);
        }

    }
}
