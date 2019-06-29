using System;
using Xunit;

namespace BowlingBall.Tests
{
    public class GameFixture
    {
        Game obj = new Game();

        [Fact]
        public void DummyTest()
        {
            for (int i = 0; i < 20; i++)
                obj.Roll(0);
            Assert.Equal(0, obj.GetScore());
            // This is a dummy test that will always pass.
        }

        [Fact]
        public void DummyTest1()
        {
            // This is a dummy test that will always pass.
            for (int i = 0; i < 20; i++)
                obj.Roll(1);
            Assert.Equal(20, obj.GetScore());
        }
        [Fact]
        public void DummyTest2()
        {
            // This is a dummy test that will always pass.
            for (int i = 0; i < 21; i++)
                obj.Roll(5);
            Assert.Equal(150, obj.GetScore());
        }
    }
}
