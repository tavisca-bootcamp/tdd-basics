using System;
using Xunit;

namespace BowlingBall.Tests
{
    public class GameFixture
    {
        private Game g = new Game();

        private void RollMany(int n, int pins)
        {
            for (int i = 0; i < n; i++)
                g.Roll(pins);
        }

        private void RollStrike()
        {
            g.Roll(10);
        }

        private void RollSpare()
        {
            g.Roll(5);
            g.Roll(5);
        }

        [Fact]
        public void TestGutterGame()
        {
            int expected = 0;

            RollMany(20, 0);
            int actual=g.GetScore();

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void TestAllOnes()
        {
            int expected = 0;
            
            RollMany(20, 1);
            int actual=g.GetScore();

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void TestOneSpare()
        {
            int expected = 16;

            RollSpare();
            g.Roll(3);
            RollMany(17, 0);
            int actual = g.GetScore();

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void TestOneStrike()
        {
            int excepted = 24;

            RollStrike();
            g.Roll(3);
            g.Roll(4);
            RollMany(16, 0);
            int actual = g.GetScore();

            Assert.Equal(excepted, actual);
        }

        [Fact]
        public void TestPerfectGame()
        {
            int expected = 300;

            RollMany(12,10);
            int actual = g.GetScore();

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void RollRandomScore()
        {
            int expected = 164;

            int[] score = { 7, 3, 10, 10, 8, 1, 9, 1, 8, 1, 10, 9, 1, 8, 2, 6, 1 };
            foreach (int pins in score)
                g.Roll(pins);
            int actual = g.GetScore();

            Assert.Equal(expected, actual);
        }
    }
}
