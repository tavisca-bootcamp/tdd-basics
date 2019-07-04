using System;
using Xunit;

namespace BowlingBall.Tests
{
    public class GameFixture
    {
         Game game = new Game();

        [Fact]
        public void TestGutterBalls()
        {
            RollMany(20, 0);
            Assert.Equal(0, game.Score());
        }

        [Fact]
        public void TestAllOnes()
        {
            RollMany(20, 1);
            Assert.Equal(20, game.Score());
        }

        [Fact]
        public void TestOneSpare()
        {
            RollSpare();
            game.roll(3);
            RollMany(17, 0);
            Assert.Equal(16, game.Score());
        }

        [Fact]
        public void TestOneStrike()
        {
            RollStrike();
            game.roll(3);
            game.roll(4);
            RollMany(16, 0);
            Assert.Equal(24, game.Score());
        }

        [Fact]
        public void TestPerfect()
        {
            RollMany(12, 10);
            Assert.Equal(300, game.Score());
        }

        [Fact]
        public void TestGame()
        {
            int[] scoreofRoll = {6,4,7,1,7,2,10,8,1,10,9,1,7,3,5,5,9,1,8};
            int numRolls = scoreofRoll.Length;
            for (int i = 0; i < numRolls; i++)
            {
                game.roll(scoreofRoll[i]);
            }
            Assert.Equal(151, game.Score());
        }

        

         void RollStrike()
        {
            game.roll(10);
        }

         void RollSpare()
        {
            game.roll(5);
            game.roll(5);
        }

         void RollMany(int n, int pins)
        {
            for (int i = 0; i < n; i++)
            {
                game.roll(pins);
            }
        }
    }
}
