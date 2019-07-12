using System;
using Xunit;

namespace BowlingBall.Tests
{
    public class GameFixture
    {
        private Game game;

        public GameFixture()
        {
            game = new Game();
        }

        [Fact]
        public void TestGutterGame()
        {
            int n = 20;
            int pins = 0;
            for (int i = 0; i < n; i++)
                game.Roll(pins);
            Assert.Equal(0, game.GetScore());
        }

        [Fact]
        public void TestOnes()
        {
            int n = 20;
            int pins = 1;
            for (int i = 0; i < n; i++)
                game.Roll(pins);
            Assert.Equal(20, game.GetScore());
        }

        [Fact]
        public void TestSpare()
        {
            game.Roll(5);
            game.Roll(5);
            game.Roll(5);
            for (int i = 0; i < 17; i++)
               game.Roll(1);
            Assert.Equal(37, game.GetScore());
        }

        [Fact]
        public void TestStroke()
        {
            game.Roll(10);
            game.Roll(4);
            game.Roll(2);
            for(int i=0;i<17;i++)
                game.Roll(0);
            Assert.Equal(22, game.GetScore());
        }

        [Fact]
        public void TestPerfectGame()
        {
            for(int I=0;I<12;I++)
                game.Roll(10);
            Assert.Equal(300, game.GetScore());
        }
    }
}
