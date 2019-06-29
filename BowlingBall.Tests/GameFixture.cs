using System;
using Xunit;

namespace BowlingBall.Tests
{
    public class GameFixture
    {
        Game game = new Game();
        [Fact]
        public void TestGutterGame() //Test when no pins hit
        {
            RollPins(20, 0);
            Assert.Equal(0, game.GetScore());
        }
        [Fact]
        public void TestOnePinPerRoll() //Test when one pin per ball hits
        {
            RollPins(20, 1);
            Assert.Equal(20, game.GetScore());
        }
        [Fact]
        public void TestOneStrikeGame() //Test when strike occure
        {
            Strike();
            game.Roll(4);
            game.Roll(5);
            RollPins(18, 0);
            Assert.Equal(28, game.GetScore());
        }
        [Fact]
        public void TestOneSpareGame() //Test when spare occure
        {
            Spare();
            game.Roll(2);
            RollPins(18, 0);
            Assert.Equal(14, game.GetScore());
        }
        [Fact]
        public void TestPerfectGame() //Test when all the strike
        {
            RollPins(12, 10);
            Assert.Equal(300, game.GetScore());
        }
        [Fact]
        public void TestRandomGameNoExtraRoll()
        {
            int[] input = { 1, 3, 7, 3, 10, 1, 7, 5, 2, 5, 3, 8, 2, 8, 2, 10, 9, 0 };
            CallingRollFromArray(input);
            Assert.Equal(131, game.GetScore());
        }
        [Fact]
        public void TestRandomGameWithThreeStrikesAtEnd()
        {
            int[] input = { 1, 3, 7, 3, 10, 1, 7, 5, 2, 5, 3, 8, 2, 8, 2, 10, 10, 10, 10 };
            CallingRollFromArray(input);
            Assert.Equal(163, game.GetScore());
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
        private void CallingRollFromArray(int[] RollArray)
        {
            foreach (int element in RollArray)
            {
                game.Roll(element);
            }
        }
        private void RollPins(int numberOfRolls, int pinHitPerRoll)
        {
            for (int i = 0; i < numberOfRolls; i++)
                game.Roll(pinHitPerRoll);
        }
    }
}
