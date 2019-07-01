using System;
using Xunit;

namespace BowlingBall.Tests
{
    public class GameFixture
    {
        Game g = new Game();

        [Fact]
        public void ForAllZeroes()
        {
            for (int i = 0; i < 20; i++)
            {
                g.Roll(0);
            }
            Assert.Equal(0, g.GetScore());

        }

        [Fact]
        public void ForAllOnes()
        {

            for (int i = 0; i < 20; i++)
            {
                g.Roll(1);
            }
            Assert.Equal(20, g.GetScore());
        }

        [Fact]
        public void ForOneSpare()
        {

            g.Roll(6);
            g.Roll(4);
            g.Roll(3);
            for (int i = 0; i < 17; i++)
            {
                g.Roll(0);
            }
            Assert.Equal(16, g.GetScore());
        }

        [Fact]
        public void ForOneStrike()
        {

            g.Roll(10);
            g.Roll(3);
            g.Roll(4);
            for (int i = 0; i < 16; i++)
            {
                g.Roll(2);
            }
            Assert.Equal(56, g.GetScore());
        }

        [Fact]
        public void ForAllStrikes()
        {
            for (int i = 0; i < 12; i++)
            {
                g.Roll(10);
            }
            Assert.Equal(300, g.GetScore());
        }

        [Fact]
        public void ForAllSpares()
        {
            for (int i = 0; i < 10; i++)
            {
                Spare();
            }
            g.Roll(6);
            Assert.Equal(160, g.GetScore());
        }
        [Fact]
        public void ForStrikeAndSpareInEnd()
        {
            g.Roll(new int[] { 5, 2, 4, 5, 10, 2, 6, 4, 5, 7, 1, 8, 2, 9, 1, 10, 8, 2, 10 });
            Assert.Equal(138, g.GetScore());
        }


        private void Spare()
        {
           
            g.Roll(6);
            g.Roll(4);
        }
    }
}
