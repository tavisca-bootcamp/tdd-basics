using System;
using Xunit;

namespace BowlingBall.Tests
{
    public class GameFixture {
        Game g;
        public GameFixture() {
            g = new Game();
        }
        [Fact]
        public void TestAllGutters() {
            NRolls(20, 0);
            Assert.Equal(0, g.GetScore());
        }
        [Fact]
        public void TestAllOnes() {
            NRolls(20, 1);
            Assert.Equal(20, g.GetScore());
        }
        [Fact]
		public void TestFirstFrameSpare(){
			g.Roll(7); 
            g.Roll(3);
            NRolls(18, 2);
            Assert.Equal(48, g.GetScore());
		}
        [Fact]
        public void TestFirstFrameStrike() {
            g.Roll(10);
            NRolls(18, 2);
            Assert.Equal(50, g.GetScore());
        }
        [Fact]
        public void TestFirstTwoFramesSpares() {
            g.Roll(7);
            g.Roll(3);
            g.Roll(5);
            g.Roll(5);
            NRolls(16, 2);
            Assert.Equal(59, g.GetScore());
        }
        [Fact]
        public void TestFirstTwoFramesStrikes() {
            g.Roll(10);
            g.Roll(10);
            NRolls(16, 2);
            Assert.Equal(68, g.GetScore());
        }
        [Fact]
        public void TestNineFrameStrikesTenthFrameSpare() {
            NRolls(9,10);
            g.Roll(9);
            g.Roll(1);
            g.Roll(1);
            Assert.Equal(270, g.GetScore());
        }
        [Fact]
        public void TestTenthFrameSpareAndStrike() {
            NRolls(18,0);
            g.Roll(8);
            g.Roll(2);
            g.Roll(10);
            Assert.Equal(20, g.GetScore());
        }
        [Fact]
        public void TestWithThreeStrikesInEnd() {
            g.Roll(new int[] { 4, 3, 7, 3, 10, 1, 8, 5, 3, 5, 3, 8, 2, 8, 2, 10, 10, 10, 10 });
            Assert.Equal(169, g.GetScore());
        }
        [Fact]
        public void TestAllSpares() {
            NRolls(21, 5);
            Assert.Equal(150, g.GetScore());
        }
        [Fact]
        public void TestAllStrikes() {
            NRolls(12, 10);
            Assert.Equal(300, g.GetScore());
        }
        [Fact]
        public void TestAlternatingStrikeAndSpare() {
            g.Roll(10);
            g.Roll(4); g.Roll(6);
            g.Roll(10);
            g.Roll(7); g.Roll(3);
            g.Roll(10);
            g.Roll(9); g.Roll(1);
            g.Roll(10);
            g.Roll(5); g.Roll(5);
            g.Roll(10);
            g.Roll(8); g.Roll(2); g.Roll(10);
            Assert.Equal(200, g.GetScore());
        }
        private void NRolls(int n, int pins) {
            for (int i = 0; i < n; i++)
                g.Roll(pins);
        } 
    }
}
