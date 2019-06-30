using System;
using Xunit;

namespace BowlingBall.Tests
{
    public class GameFixture
    {
        private Game game;

        protected void SetUp()
        {
            game=new Game();
        }

        private void RollMany(int n,int pins)
        {
            for(int i=0;i<n;i++)
                game.Roll(pins);
        }

        private void RollSpare()
        {
            game.Roll(5);
            game.Roll(5);
        }
        private void RollStrike()
        {
            game.Roll(10);
        }
        [Fact]
        public void TestGutterGame()
        {
            SetUp();
            RollMany(20,0);
            Assert.Equal(0,game.GetScore());
        }

        [Fact]
        public void TestAllOnesGame()
        {
            SetUp();
            RollMany(20,1);
            Assert.Equal(20,game.GetScore());
        }

        [Fact]
        public void TestOneSpareGame()
        {
            SetUp();
            RollSpare();
            game.Roll(4);
            game.Roll(3);
            RollMany(16,0);
            Assert.Equal(21,game.GetScore());
        }
        
        [Fact]
        public void TestOneStrikeGame()
        {
            SetUp();
            RollStrike();
            game.Roll(5);
            game.Roll(4);
            RollMany(16,0);
            Assert.Equal(28,game.GetScore());
        }

        [Fact]
        public void TestPerfectGame()
        {
            SetUp();
            RollMany(12,10);
            Assert.Equal(300,game.GetScore());
        }

    }
}
