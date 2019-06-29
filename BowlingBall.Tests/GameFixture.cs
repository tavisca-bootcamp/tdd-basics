using System;
using Xunit;

namespace BowlingBall.Tests
{
    public class GameFixture
    {
        private Game g;

        // Constructor runs before every test function
        public GameFixture() {
            g = new Game();
        }
        
        // Helper for below 2 functions
        private void RollMany(int n, int pins) {
            for (int i = 0; i < n; i++) {
                g.Roll(pins);
            }
        }

        [Fact]
        public void TestGutterGame() {
            RollMany(20, 0);
            Assert.Equal(0, g.GetScore());
        }

        [Fact]
        public void TestAllOnes() {
            RollMany(20, 1);
            Assert.Equal(20, g.GetScore());
        }

        [Fact] 
        public void TestOneSpare() {
            RollSpare();
            g.Roll(3);
            RollMany(17, 0);
            Assert.Equal(16, g.GetScore());
        }

        [Fact] 
        public void TestOneStrike() {
            g.Roll(10);
            g.Roll(3);
            g.Roll(4);
            RollMany(16, 0);
            Assert.Equal(24, g.GetScore());
        }

        [Fact]
        public void TestPerfectGame() {
            RollMany(12, 10);
            Assert.Equal(300, g.GetScore());
        }

        private void RollStrike() {
            g.Roll(10);
        }

        private void RollSpare() {
            g.Roll(5);
            g.Roll(5);
        }
    }
}
