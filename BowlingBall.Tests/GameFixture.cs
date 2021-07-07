using System;
using Xunit;

namespace BowlingBall.Tests
{
    public class GameFixture
    {
        public GameFixture()
        {
            game = new Game();
        }
        private Game game;

        [Fact] 
        public void TestAllZeros()
        {
            RollMany(20, 0);
            Assert.Equal(0, game.GetScore());
        }

        [Fact]
        public void TestAllOnes()
        {
            RollMany(20, 1);
            Assert.Equal(20, game.GetScore());
        }

        [Fact]
        public void TestOneSpare()
        {
            RollSpare();
            game.Roll(3);
            RollMany(17, 0);
            Assert.Equal(16, game.GetScore());
        }

        [Fact]
        public void TestOneStrike()
        {
            RollStrike();
            game.Roll(4);
            game.Roll(3);
            RollMany(16, 0);
            Assert.Equal(24, game.GetScore());
        }
        
        [Fact] 
        public void TestAllStrikes()
        {
            RollMany(12, 10);
            Assert.Equal(300, game.GetScore());
        }

        [Fact] 
        public void TestWholeRandomGame()
        {
            int[] scoreOfEachRoll = {1,4,4,5,6,4,5,5,10,0,1,7,3,6,4,10,2,8,6};
            int numberOfRolls = scoreOfEachRoll.Length;
            for (int i=0;i<numberOfRolls;i++)
            {
                game.Roll(scoreOfEachRoll[i]);
            }
            Assert.Equal(133, game.GetScore());
        }

        private void RollStrike()
        {
            game.Roll(10);
            //throw new NotImplementedException();
        }

        private void RollSpare()
        {
            game.Roll(5);
            game.Roll(5);
            //throw new NotImplementedException();
        }

        private void RollMany(int numberOfRolls, int pins)
        {
            for(int i = 0; i < numberOfRolls; i++)
                game.Roll(pins);
            //throw new NotImplementedException();
        }
    }
}
