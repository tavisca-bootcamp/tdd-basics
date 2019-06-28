using System;
using Xunit;

namespace BowlingBall.Tests
{
    public class GameFixture
    {
        [Fact]
        public void DummyTest()
        {
            var game = new Game();
            int[] frameOpportunityOne = {10, 9, 5, 7, 10, 10, 10, 9, 8, 9};
            int[] frameOpportunityTwo = {00, 1, 5, 2, 00, 00, 00, 0, 2, 1};
            var oneExtraShot = 10;
            var expected = 187;

            //act
            var actual = Game.GetScore(frameOpportunityOne, frameOpportunityTwo, oneExtraShot);

            //assert
            Assert.Equal(expected, actual);
        }
    }
}
