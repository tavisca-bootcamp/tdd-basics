using System;
using Xunit;

namespace BowlingBall.Tests
{
    public class GameFixture
    {
        private Game game = new Game();

        public GameFixture(){
            game = new Game();
        }

        [Fact]
        public void DummyTest()
        {
            // This is a dummy test that will always pass.
        }

        [Fact]
        public void BasicTest1()
        {
            int[] scorelist = {10, 9, 1, 5, 5, 7, 2, 10, 10, 10, 9, 0, 8, 2, 9, 1, 10};
            for(var i=0; i<scorelist.Length; i++){
                game.Roll(scorelist[i]);
            }

            Assert.Equal(187, game.GetScore());
        }
    }
}

