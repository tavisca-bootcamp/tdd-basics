using System;
using Xunit;

namespace BowlingBall.Tests
{
    public class GameFixture
    {
        private Game g =new Game();
        [Fact]
        
        public void DummyTest()
        {
            // This is a dummy test that will always pass.
            
        }
        private void RollMany(int n,int pins)
        {
            for (int i = 0; i < n; i++)
                g.Roll(pins);
        }
        [Fact]
        public void TestCase1()
        {
            int n = 20;
            int pins = 0;
            RollMany(n, pins);
            Assert.Equal(0, g.GetScore());
        }
        [Fact]
        public void TestCase2()
        {
            int n = 20;
            int pins = 1;
            RollMany(20, pins);
            Assert.Equal(2, g.GetScore());
        }
        
    }
}
