using System;
using Xunit;

namespace BowlingBall.Tests
{
    public class GameFixture
    {
        [Fact]
        public void AllZeroTest()
        {
            int[] roll = new int[] {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0};
            int expected = 0;
            int actual = GetActualScore(roll);
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void AllOneTest()
        {
            int[] roll = new int[] { 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1 };
            int expected = 0;
            int actual = GetActualScore(roll);
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void StrikeSpareTest()
        {
            int[] roll = new int[] { 10, 9, 1, 5, 5, 7, 2, 10, 10, 10, 9, 0, 8, 2, 9, 1, 10 };
            int expected = 0;
            int actual = GetActualScore(roll);
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void AllSpareTest()
        {
            int[] roll = new int[] { 5,5, 9, 1, 5, 5, 7, 3, 3,7, 4,6, 5,5, 9, 1, 8, 2, 9, 1, 1 };
            int expected = 0;
            int actual = GetActualScore(roll);
            Assert.Equal(expected, actual);
        }

        public static int GetActualScore(int[] roll)
        {
            var game = new Game();
            foreach(int rollValue in roll)
            {
                game.Roll(rollValue);
            }
            return game.GetScore();
        }
    }
}
