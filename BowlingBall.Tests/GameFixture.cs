using System;
using Xunit;
using BowlingBall;

namespace BowlingBall.Tests
{
    public class GameFixture
    {
        private Game newGame;
        public GameFixture()
        {
            //newGame = new Game();
        }

        private void MultipleRolls(int [] pins,ref Game copy)
        {
            foreach (int pin in pins)
                copy.Roll(pin);
        }

        [Fact]
        public void DummyTest()
        {
            // This is a dummy test that will always pass.
        }
        [Fact]
        public void TestAllStrikes()
        {
            Game newGame = new Game();
            var pins = new int[] { 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10 };
            MultipleRolls(pins, ref newGame);
            Assert.Equal(300, newGame.GetScore());
        }
        
        [Fact]
        public void TestAllZero()
        {
            Game newGame = new Game();
            var pins = new int[] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
            MultipleRolls(pins, ref newGame);
            Assert.Equal(0, newGame.GetScore());
        }

        [Fact]
        public void TestAllSpare()
        {
            Game newGame = new Game();
            var pins = new int[] { 1, 9, 2, 8, 3, 7, 4, 6, 5, 5, 6, 4, 7, 3, 8, 2, 9, 1, 0, 10, 10 };
            MultipleRolls(pins, ref newGame);
            Assert.Equal(154, newGame.GetScore());
        }

        [Fact]
        public void TestAllOne()
        {
            Game newGame = new Game();
            var pins = new int[] { 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1 };
            MultipleRolls(pins, ref newGame);
            Assert.Equal(20, newGame.GetScore());
        }

        [Fact]
        public void TestOneStrike()
        {
            Game newGame = new Game();
            var pins = new int[] { 10, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
            MultipleRolls(pins, ref newGame);
            Assert.Equal(10, newGame.GetScore());
        }

        [Fact]
        public void TestOneSpare()
        {
            Game newGame = new Game();
            var pins = new int[] { 2, 8, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
            MultipleRolls(pins, ref newGame);
            Assert.Equal(10, newGame.GetScore());
        }

        [Fact]
        public void TestLastFrameSpare()
        {
            Game newGame = new Game();
            var pins = new int[] { 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 8, 10 };
            MultipleRolls(pins, ref newGame);
            Assert.Equal(56, newGame.GetScore());
        }

        [Fact]
        public void TestLastFrameStrike()
        {
            Game newGame = new Game();
            var pins = new int[] { 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 10, 10, 10 };
            MultipleRolls(pins, ref newGame);
            Assert.Equal(66, newGame.GetScore());
        }
    }
}
