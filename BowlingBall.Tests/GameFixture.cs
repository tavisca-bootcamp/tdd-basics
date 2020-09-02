using System;
using Xunit;

namespace BowlingBall.Tests
{
    public class GameFixture
    {
        private Game g;

        public GameFixture()
        {
            this.g = new Game();
        }

        [Fact]
        public void TestGutterGame()
        {
            for(int i=0; i< 20; i++){
                g.Roll(0);
            }
            Assert.Equal(0, g.GetScore());
        }

        public void RollMany(int n, int pins)
        {
            for(int i=0; i<n; i++){
                g.Roll(pins);
            }
        }


        [Fact]
        public void TestAllOnes()
        {
            RollMany(20,1);
            Assert.Equal(20, g.GetScore());
        }

        [Fact]
        public void TestOneSpare()
        {
            g.Roll(5);
            g.Roll(5);
            g.Roll(3);
            RollMany(17,0);
            Assert.Equal(16, g.GetScore());
        }

        [Fact]
        public void TestOneStrike()
        {
            RollStrike();
            g.Roll(3);
            g.Roll(4);
            RollMany(16,0);
            Assert.Equal(24, g.GetScore());
        }

        [Fact]
        public void testPerfectGame()
        {
            RollMany(12,10);
            Assert.Equal(300, g.GetScore());
        }

        private void RollStrike(){
            g.Roll(10);
        }

        public void RollSpare()
        {
            g.Roll(5);
            g.Roll(5);
        }
    }
}
