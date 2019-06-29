using System;
using Xunit;

namespace BowlingBall.Tests
{
    public class GameFixture
    {
        private Game g;
        private void RollMany(int n, int pins)
        {
            for (int i=0; i<n; i++)
                g.Roll(pins);
        } 
        [Fact]
        public void TestGutterGame()
        {
            g=new Game();
            RollMany(20,0);
            Assert.Equal(0,g.GetScore());
        }
        [Fact]
        public void TestAllOnes()
        {
            g=new Game();
            RollMany(20,1);
            Assert.Equal(20,g.GetScore());
        }
        [Fact]
        public void TestOneSpare()
        {
            g=new Game();
            RollSpare();
            g.Roll(3);
            RollMany(17,0);
            Assert.Equal(16,g.GetScore());
        }
        [Fact]
        public void TestOneStrike()  
        {
            g=new Game();
            RollStrike();
            g.Roll(3);
            g.Roll(4);
            RollMany(16, 0);
            Assert.Equal(24, g.GetScore());
        }

        [Fact]
        public void TestPerfectGame()
        {
            g=new Game();
            RollMany(12,10);
            Assert.Equal(300, g.GetScore());
        }


        private void RollSpare()
        {
            g.Roll(5);
            g.Roll(5);
        }
        private void RollStrike()
        {
            g.Roll(10);
        }
    }
}
