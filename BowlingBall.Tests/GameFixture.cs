using System;
using Xunit;
using BowlingBall;

namespace BowlingBall.Tests
{
    public class GameFixture
    {
        private Game newGame;
        public GameFixture() {
            newGame = new Game();
        }

        [Fact]
        public void TestAllStrikes()
        {
              newGame.SetRoll(new[] { 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10 });
            Assert.Equal(300, newGame.GetScore());
        }
        [Fact]
        public void TestAllZero()
        {
            newGame.SetRoll(new[] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 });
            Assert.Equal(0, newGame.GetScore());
        }
        [Fact]
        public void TestOneStrike()
        {
            newGame.SetRoll(new[] { 10, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 });
            Assert.Equal(10, newGame.GetScore());
        }
        [Fact]
        public void AllSpares()
        {
            newGame.SetRoll(new[] {9,1, 9, 1, 9, 1, 9, 1, 9, 1, 9, 1, 9, 1, 9, 1, 9, 1, 9, 1,9 });
            Assert.Equal(190, newGame.GetScore());
        }
        [Fact]
        public void RollSpareFirstFrame()
        {
            newGame.SetRoll(new[] { 9, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1 });
            Assert.Equal(29, newGame.GetScore());
        }

        [Fact]
        public void RollSpareEveryFrame()
        {
            newGame.SetRoll(new[] { 5,5,5,5,5,5,5,5,5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5 });
            Assert.Equal(150, newGame.GetScore());
        }

    }
}
