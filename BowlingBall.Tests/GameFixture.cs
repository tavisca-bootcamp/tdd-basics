using System;
using Xunit;

namespace BowlingBall.Tests
{
    public class GameFixture
    {
        public Game game = new Game();

        [Fact]
        public void TestForAllZeroes()
        {
            Roll(20,0);                                 //10 frames with 2 rolls each plus last 1 bonus roll = 21
            Assert.Equal(0, game.GetScore());
        }

        [Fact]
        public void TestForAllOnes()
        {
            Roll(20,1);
            Assert.Equal(20, game.GetScore());
        }

        [Fact]
        public void TestForOneSpare()
        {
            Spare();
            game.Roll(2);
            Roll(18,0);
            Assert.Equal(14, game.GetScore());
        }

        [Fact]
        public void TestForOneStrike()
        {
            Strike();
            int[] roll = { 4, 5 };
            DoRoll(roll);
            Roll(18,0);
            Assert.Equal(28, game.GetScore());
        }

        [Fact]
        public void TestForOneStrikeThenOneSpare()
        {
            Strike();
            Spare();
            game.Roll(5);
            Roll(17,0);
            Assert.Equal(40, game.GetScore());
        }

        [Fact]
        public void TestForOneSpareThenOneStrike()
        {
            Spare();
            Strike();
            int[] roll = { 4, 5 };
            DoRoll(roll);
            Roll(15,0);
            Assert.Equal(48, game.GetScore());
        }

        [Fact]
        public void TestForConsecutiveSpares()
        {
            Spare();
            Spare();
            game.Roll(5);
            Roll(13,0);
            Assert.Equal(35, game.GetScore());
        }

        [Fact]
        public void TestForConsecutiveStrikes()
        {
            Strike();
            Strike();
            int[] roll = { 4, 5 };
            DoRoll(roll);
            Roll(15,0);
            Assert.Equal(52, game.GetScore());
        }

        [Fact]
        public void TestRandom()
        {
            int[] roll = { 5, 5, 9, 10, 7, 5, 5, 10, 6, 10, 10, 10 };
            DoRoll(roll);
            Assert.Equal(111, game.GetScore());
        }

        [Fact]
        public void TestForAllStrike()
        {
            Roll(20,10);
            Assert.Equal(300, game.GetScore());
        }

        private void Strike()
        {
            game.Roll(10);
        }

        private void Spare()
        {
            game.Roll(5);
            game.Roll(5);
        }

        private void DoRoll(int[] roll)
        {
            for (int i = 0; i < roll.Length; i++)
            {
                game.Roll(roll[i]);
            }
        }

        private void Roll(int times, int pins)
        {
            for (int i = 0; i < times; i++)
            {
                game.Roll(pins);
            }
        }
    }
}
