using System;
using Xunit;
using BowlingBall;

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
        public void TestCaseForCheckingStrike()
        {
            Game game = new Game();
            game.Roll(10);
            game.Roll(2);
            game.Roll(6);
            game.Roll(7);
            game.Roll(1);

            Assert.Equal(34, game.GetScore());
        }

        [Fact]
        public void TestCaseForCheckingSpare()
        {
            Game game = new Game();
            game.Roll(8);
            game.Roll(2);
            game.Roll(6);
            game.Roll(7);
            game.Roll(1);
            game.Roll(4);

            Assert.Equal(34, game.GetScore());
        }

        [Fact]
        public void GivenTestCase()
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

        [Fact]

        public void RollFunction_ThrowsArgumentException()
        {
            Game game = new Game();

            Exception ex = Record.Exception(() => game.Roll(100));
            Assert.NotNull(ex);
            Assert.IsType<ArgumentException>(ex);
            Assert.Equal("Enter pin between 1 to 10 both inclusive", ex.Message);
        }

    
    }
}
