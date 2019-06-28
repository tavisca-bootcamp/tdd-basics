using System;
using Xunit;

namespace BowlingBall.Tests
{
    public class GameFixture
    {
        private Game g;

        public GameFixture()
        {
            g = new Game();
        }

        private void rollMany(int nRolls, int pins)
        {
            for(int i = 0; i < nRolls; i++)
            {
                g.Roll(pins);
            }
        }
        [Fact]
        public void TestGutterGame()
        {

            //act
            rollMany(20, 0);

            int expected = 0;
            int actual = g.GetScore();

            //assert
            Assert.Equal(actual, expected);

        }

        [Fact]
        public void TestAllOnes()
        {
            //act
            rollMany(20, 1);
            int expected = 20;
            int actual = g.GetScore();

            //assert
            Assert.Equal(actual, expected);

        }

        [Fact]
        public void TestOneSpare()
        {
            g.Roll(5);
            g.Roll(5);
            g.Roll(3);
            rollMany(17, 0);

            Assert.Equal(16, g.GetScore());
        }

        [Fact]
        public void TestOneStrike()
        {
            RollStrike();
            g.Roll(3);
            g.Roll(4);
            rollMany(16, 0);
            Assert.Equal(24, g.GetScore());
        }

        [Fact]
        public void TestPerfectStrike()
        {
            rollMany(12, 10);
            Assert.Equal(300, g.GetScore());
        }

        private void RollStrike()
        {
            g.Roll(10);
        }
    }
}
