using System;
using Xunit;

namespace BowlingBall.Tests
{
    public class GameFixture
    {
        Game game = new Game();

        [Fact]
        public void AllZeros()
        {
            for (int i = 0; i < 20; i++)
                game.Roll(0);
            Assert.Equal(0, game.GetScore());

        }

        [Fact]
        public void AllOnes()
        {

            for (int i = 0; i < 20; i++)
                game.Roll(1);
            Assert.Equal(20, game.GetScore());
        }
        [Fact]
        public void AllSpares()
        {

            for (int i = 0; i < 21; i++)
                game.Roll(5);
            Assert.Equal(150, game.GetScore());
        }
        [Fact]
        public void AllStrikes()
        {

            for (int i = 0; i < 12; i++)
                game.Roll(10);
            Assert.Equal(300, game.GetScore());
        }
        
        [Fact]
        public void SpareStrikeZero() //starts with a spare in middle strikes and ends with gutter balls
        {
            int[] frame = new int[17] { 10, 9, 6, 0, 6, 3, 5, 0, 10, 10, 2, 1, 10, 9, 8, 4, 9 };

            for (int i = 0; i < 17; i++)
                game.Roll(frame[i]);
            Assert.Equal(147, game.GetScore());
        }
        [Fact]
        public void StrikeZeroSpare() //starts with a srike in middle gutter balls and ends with spare
        {
            int[] frame = new int[18] { 10, 0, 0, 10, 10, 0, 0, 4, 1, 5, 2, 5, 5, 4, 4, 2, 2, 8 };

            for (int i = 0; i < 18; i++)
                game.Roll(frame[i]);
            Assert.Equal(78, game.GetScore());
        }
        [Fact]
        public void StrikeSpareZero() //starts with a srike in middle spare and ends with gutter ball
        {
            int[] frame = new int[17] { 10, 0, 0, 10, 10, 6, 9, 2, 6, 8, 5, 0, 4, 9, 0, 0, 0 };

            for (int i = 0; i < 17; i++)
                game.Roll(frame[i]);
            Assert.Equal(110, game.GetScore());
        }
        [Fact]
        public void ZeroSpareStrike() //starts with a gutter ball  in middle spare and ends with srike
        {
            int[] testcase = new int[18] { 0, 0, 0, 0, 0, 0, 6, 4, 5, 5, 1, 3, 10, 10, 10, 10, 1, 2 };

            for (int i = 0; i < 18; i++)
                game.Roll(testcase[i]);
            Assert.Equal(124, game.GetScore());
        }
        
    }
}
