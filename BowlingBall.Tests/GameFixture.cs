using System;
using Xunit;

namespace BowlingBall.Tests
{
    public class GameFixture
    {
        Game game = new Game();
        [Fact]
        public void TestToCheckNotNull()
        {
            Assert.NotNull(game);
        }
        [Fact]
        public void TestWithNoSpareNoStrike()
        {
            int[] score= {0,5,2,5,7,2,8,1,9,0,0,2,1,7,2,6,1,3,2,2};
            foreach(int number in score)
            {
                if (number < 0 || number > 10)
                {
                    Assert.NotInRange(number, 0, 10);
                    return;
                }
                else
                    game.Roll(number);
            }
            Assert.Equal(65, game.GetScore());
        }
        
       
        [Fact]
        public void TestWithInvalidRange()
        {
            int[] score = { 0, 5, 2, 5, 7, 2, 8, -1, 9, 0, 0, 2, 1, 7, 2, 6, 1, 3, 2, 2 };
            foreach (int number in score)
            {
                if (number < 0 || number > 10)
                {
                    Assert.NotInRange(number, 0, 10);
                    return;
                }
                else
                    game.Roll(number);
            }
        }
        [Fact]
        public void TestWithStrike()
        {
            int[] score = { 0, 5, 10, 7, 2, 8, 1, 9, 0, 0, 2, 1, 7, 2, 6, 1, 3, 2, 2 };
            foreach (int number in score)
            {
                if (number < 0 || number > 10)
                {
                    Assert.NotInRange(number, 0, 10);
                    return;
                }
                else
                    game.Roll(number);
            }
            Assert.Equal(77, game.GetScore());
        }
        [Fact]
        public void TestWithSpare()
        {
            int[] score = { 0, 5, 8, 2, 7, 2, 8, 1, 9, 0, 0, 2, 1, 7, 2, 6, 1, 3, 2, 2 };
            foreach (int number in score)
            {
                if (number < 0 || number > 10)
                {
                    Assert.NotInRange(number, 0, 10);
                    return;
                }
                else
                    game.Roll(number);
            }
            Assert.Equal(75, game.GetScore());
        }
        [Fact]
        public void TestWithSpareWithStrike()
        {
            int[] score = { 10,9,1,5,5,7,2,10,10,10,9,0,8,2,9,1,10 };
            foreach (int number in score)
            {
                if (number < 0 || number > 10)
                {
                    Assert.NotInRange(number, 0, 10);
                    return;
                }
                else
                    game.Roll(number);
            }
            Assert.Equal(187, game.GetScore());
        }
        [Fact]
        public void TestWithStrikesInTheEnd()
        {
            int[] score = { 1, 5, 7, 3, 10, 1, 8, 3, 4, 6, 2, 7, 3, 6, 4, 10, 10, 10, 10 };
            foreach (int number in score)
            {
                if (number < 0 || number > 10)
                {
                    Assert.NotInRange(number, 0, 10);
                    return;
                }
                else
                    game.Roll(number);
            }
            Assert.Equal(165, game.GetScore());
        }
        [Fact]
        public void TestWithSparesInTheEnd()
        {
            int[] score = { 1, 5, 7, 3, 10, 1, 8, 3, 4, 6, 2, 7, 3, 6, 4, 10, 9,1,5 };
            foreach (int number in score)
            {
                if (number < 0 || number > 10)
                {
                    Assert.NotInRange(number, 0, 10);
                    return;
                }
                else
                    game.Roll(number);
            }
            Assert.Equal(140, game.GetScore());
        }
        [Fact]
        public void TestWithExtraEnd()
        {
            int[] score = { 1, 3, 7, 3, 10, 1, 7, 5, 2, 5, 3, 8, 2, 8, 2, 10, 5, 1 ,5};
            foreach (int number in score)
            {
                if (number < 0 || number > 10)
                {
                    Assert.NotInRange(number, 0, 10);
                    return;
                }
                else
                    game.Roll(number);
            }
            Assert.Equal(-1, game.GetScore());
        }
    }
}