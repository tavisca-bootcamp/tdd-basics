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
        public void CanInstanciateGameObjectTest()
        {
            new Game();
        }

        [Fact]
        public void CanRollTheBallTest()
        {
            var game = new Game();
            game.Roll(0);
        }

        [Fact]
        public void GetTheScoreTest()
        {
            var game = new Game();
            for(int i=0;i<20;i++)      
            game.Roll(1);
            Assert.Equal( 20,game.GetScore());
        }

        [Fact]
        public void ThrowingASpareTest()
        {
            var game = new Game();
            game.Throws(new[] { 5, 5, 8, 0, 6, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 });
            Assert.Equal(32, game.GetScore());


        }
        [Fact]
        public void StrikeTest()
        {
            var game = new Game();
            game.Throws(new[] { 10, 8, 8, 0, 6, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 });
            Assert.Equal(48, game.GetScore());

        }
        [Fact]
        public void PerfectGameTesst()
        {
            var game = new Game();
            game.Throws(new[] { 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10 });
            Assert.Equal(300, game.GetScore());
        }
    }
}
