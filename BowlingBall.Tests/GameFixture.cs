using System;
using Xunit;

namespace BowlingBall.Tests
{
    public class GameFixture
    {
        private Game game = new Game();

        protected void setUp() 
        {
            game = new Game();
        }

        private void RollMany(int n, int pins)
        {
            for (int i = 0; i < n; i++)
            {
                game.Roll(pins);
            }
        }

        [Fact]
        public void TestGutterGame()
        {
            RollMany(20, 0);
            Assert.Equal(0, game.GetScore());
        }

        [Fact]
        public void TestAllOnes()
        {
            RollMany(20, 1);
            Assert.Equal(20, game.GetScore());
        }

        [Fact]
        public void TestOneSpare()
        {
            RollSpare();      //Spare
            game.Roll(3);
            RollMany(17, 0);
            Assert.Equal(16, game.GetScore());
        }

        [Fact]
        public void TestOneStrike() 
        {
            RollStrike(); // strike
            game.Roll(3);
            game.Roll(4);
            RollMany(16, 0);
            Assert.Equal(24, game.GetScore());
        }

        [Fact]
        public void TestPerfectGame() 
        {
            RollMany(12,10);
            Assert.Equal(300, game.GetScore());
        }

        private void RollSpare()
        {
            game.Roll(5);
            game.Roll(5);
        }

        private void RollStrike()
        {
            game.Roll(10);
        }

    }
}
