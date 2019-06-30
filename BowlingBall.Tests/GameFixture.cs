using System;
using Xunit;

namespace BowlingBall.Tests
{
    
    public class GameFixture
    {
        [Fact]
        public void DummyTest()
        {
            Game game = new Game();
            int k;
            int[] a = { 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10 };
            for (k = 0; k < a.Length; k++)
                game.Roll(a[k]);
            Assert.Equal(300, game.GetScore());
        }
        [Fact]
        public void DummyTest1()
        {
            Game game1 = new Game();
            int k;
            int[] a = { 10,9,1,5,5,7,2,10,10,10,9,0,8,2,9,1,10};
            for (k = 0; k < a.Length; k++)
                game1.Roll(a[k]);
            Assert.Equal(187, game1.GetScore());
        }
    }
}
