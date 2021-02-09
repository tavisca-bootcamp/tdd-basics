using System;
using Xunit;
using BowlingBall;

namespace BowlingBall.Tests
{
    public class GameFixture
    {
        [Fact]
        public void DummyTest()
        {
            // Arrange
            Game G = new Game();
            // example 1 random
            int[] board = { 10, 9, 1, 5, 5, 7, 2, 10, 10, 10, 9, 0, 8, 2, 9, 1, 10 };

            // Act
            for (int i = 0; i < board.Length; ++i)
            {
                G.Roll(board[i]);
            }

            // Assert
            Assert.Equal(187, G.GetScore());
        }
        [Fact]
        public void AllStrike()
        {
            // Arrange
            Game G = new Game();
            // all strike
            int[] board = { 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10 };

            // Act
            for (int i = 0; i < board.Length; ++i)
            {
                G.Roll(board[i]);
            }

            // Assert
            Assert.Equal(300, G.GetScore());
        }
        [Fact]
        public void AllSpare()
        {
            // Arrange
            Game G = new Game();
            // all spare
            int[] board = { 5, 5, 6, 4, 7, 3, 8, 2, 5, 5, 9, 1, 2, 8, 7, 3, 4, 6, 7, 3, 8 };

            // Act
            for (int i = 0; i < board.Length; ++i)
            {
                G.Roll(board[i]);
            }

            // Assert
            Assert.Equal(163, G.GetScore());
        }
        [Fact]
        public void AllMiss()
        {
            // Arrange
            Game G = new Game();
            // all MISS

            // Act
            for (int i = 0; i < 20; ++i)
            {
                G.Roll(0);
            }

            // Assert
            Assert.Equal(0, G.GetScore());
        }
        [Fact]
        public void AllOnes()
        {
            // Arrange
            Game G = new Game();
            // all Ones

            // Act
            for (int i = 0; i < 20; ++i)
            {
                G.Roll(1);
            }

            // Assert
            Assert.Equal(20, G.GetScore());
        }
    }
}
