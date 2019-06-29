using System;
using Xunit;

namespace BowlingBall.Tests
{
    public class GameFixture
    {
        [Fact]
        public void DummyTest()
        {
            //arrange
            var game = new Game();

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

            int expected = 187;

            //act
            var actual = game.GetScore();

            //assert
            Assert.Equal(expected, actual);
        }
    }
}
