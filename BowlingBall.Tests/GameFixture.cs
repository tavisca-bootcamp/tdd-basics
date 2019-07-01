using System;
using Xunit;

namespace BowlingBall.Tests
{
    public class GameFixture
    {
        [Fact]
        public void RandomTestCase()
        {
            Game game = new Game();
            game.Roll(3);
            game.Roll(2);
            game.Roll(1);
            game.Roll(5);
            Assert.Equal(11, game.GetScore());

        }


        [Fact]
        public void TestCaseForStrike()
        {
            Game game = new Game();
            game.Roll(10);
            game.Roll(2);
            game.Roll(5);
            game.Roll(3);
            
            Assert.Equal(27, game.GetScore());

        }

        [Fact]
        public void TestCaseForSpare()
        {
            Game game = new Game();
            game.Roll(5);
            game.Roll(5);
            game.Roll(2);
            game.Roll(3);

            Assert.Equal(17, game.GetScore());

        }

    }
}
