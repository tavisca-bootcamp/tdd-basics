using System;
using Xunit;

namespace BowlingBall.Tests
{
    public class GameFixture
    {
        private Game game;
        
        // Constuctor
        public GameFixture()
        {
            game = new Game();
        }

        [Fact]
        public void BasicTestForZeroScoring()
        {
            // Arrange
            int actual;
            int expected;

            // Act
            rollMultipleTimes(20, 0);
            actual = game.GetScore();
            expected = 0;

            // Assert
            Assert.Equal(expected, actual);
        }


        [Fact]
        public void testAllOnes()
        {
            // Arrange
            int actual;
            int expected;

            // Act
            rollMultipleTimes(20, 1);
            actual = game.GetScore();
            expected = 20;

            // Assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void testOneSpare()
        {
            // Arrange
            int actual;
            int expected;

            // Act
            rollSpare();
            game.Roll(3);
            rollMultipleTimes(17, 0);
            actual = game.GetScore();
            expected = 16;

            // Assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void testOneStrike()
        {
            // Arrange
            int actual;
            int expected;

            // Act
            rollStrike();
            game.Roll(3);
            game.Roll(4);
            rollMultipleTimes(16, 0);
            actual = game.GetScore();
            expected = 24;

            // Assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void testPerfectGame()
        {
            // Arrange
            int actual;
            int expected;

            // Act

            rollMultipleTimes(12, 10);
            actual = game.GetScore();
            expected = 300;

            // Assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void test1()
        {
            // Arrange
            int actual;
            int expected;

            // Act
            int[] rolls = { 10, 9, 1, 5, 5, 7, 2, 10, 10, 10, 9, 0, 8, 2, 9, 1, 10 };
            makeRolls(rolls);
            actual = game.GetScore();
            expected = 187;

            // Assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void test2()
        {
            // Arrange
            int actual;
            int expected;

            // Act
            int[] rolls = { 9, 0, 9, 0, 9, 0, 9, 0, 9, 0, 9, 0, 9, 0, 9, 0, 9, 0, 9, 0 };
            makeRolls(rolls);
            actual = game.GetScore();
            expected = 90;

            // Assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void test3()
        {
            // Arrange
            int actual;
            int expected;

            // Act
            int[] rolls = { 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5 };
            makeRolls(rolls);
            actual = game.GetScore();
            expected = 150;

            // Assert
            Assert.Equal(expected, actual);
        }


        /*
            Utility functions for testing.
        */
        private void rollMultipleTimes(int numberOfTimes, int pins)
        {
            for (int i = 0; i < numberOfTimes; i++)
            {
                game.Roll(pins);
            }
        }

        private void makeRolls(int[] rolls)
        {
            for (int i = 0; i < rolls.Length; i++)
            {
                game.Roll(rolls[i]);
            }
        }

        private void rollStrike()
        {
            game.Roll(10);
        }

        private void rollSpare()
        {
            game.Roll(7);
            game.Roll(3);
        }
    }
}
