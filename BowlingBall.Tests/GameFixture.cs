using System;
using Xunit;
using BowlingBall;

namespace BowlingBall.Tests
{
    public class GameFixture
    {

        Game game = new Game();
        [Fact]
        public void TestTypeOfGameObject()
        {
            Assert.IsType<Game>(game);
        }

        [Fact]
        public void TestGameSetupScore()
        {
            Assert.Equal(0, game.GetScore());
        }

        [Fact]
        public void TestGameSetupTotalSlots()
        {
            Assert.Equal(20, game.GetTotalSlotsCount());
        }

        [Fact]
        public void TestGameSetupTotalBowlsToRoll()
        {
            Assert.Equal(20, game.GetTotalBowl());
        }
        [Fact]
        public void TestTotalFramesAvailable()
        {
            Assert.Equal(10, game.GetTotalFrameCount());
        }

        [Fact]
        public void TestRemainingPinsInFrame()
        {
            game.Roll(5);
            Assert.Equal(5, game.GetCurrentFrameRemainingPins());
        }

        [Fact]
        public void TestFrameRemainingPinsInAParticularFrame()
        {
            game.Roll(4);
            Assert.Equal(6, game.GetFrameRemainingPins(0));
        }

        [Fact]
        public void TestValueInSlot()
        {
            game.Roll(4);
            Assert.Equal(4, game.GetValueInSlot(0));
        }

        [Fact]
        public void TestAllZeros()
        {
            game.RollMultipleTimes(0, 20);
            var expected = 0;
            var actual = game.GetScore();
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void TestGameSetupRemainingPins()
        {
            Assert.Equal(100, game.GetTotalPins());
        }
        [Fact]
        public void TestGameSetupRemainingBowl()
        { 
            Assert.Equal(20, game.GetTotalBowl());
        }
        [Fact]
        public void TestCurrentFrameIndexOnThreeBallRoll()
        {
            Game game = new Game();
            game.Roll(4);
            game.Roll(4);
            game.Roll(7);
            Assert.Equal(1, game.GetCurrentFrameIndex());
        }

        [Fact]
        public void TestCurrentFrameIndexOnFiveBallRoll()
        {
            Game game = new Game();
            game.Roll(4);
            game.Roll(4);
            game.Roll(7);
            game.Roll(3);
            game.Roll(4);
            Assert.Equal(2, game.GetCurrentFrameIndex());
        }
        [Fact]
        public void TestPinsRemainingOnThreeBallRoll()
        {
            Game game = new Game();
            game.Roll(4);
            game.Roll(4);
            game.Roll(7);
            Assert.Equal(3, game.GetCurrentFrameRemainingPins());
        }

        [Fact]
        public void TestAllOnes()
        {
            game.RollMultipleTimes(1, 20);
            var expected = 20;
            var actual = game.GetScore();
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void TestRollingOneScoresOne()
        {
            game.Roll(1);
            var expected = 1;
            var actual = game.GetScore();
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void TestRollingTwoScoresTwo()
        {
            game.Roll(2);
            var expected = 2;
            var actual = game.GetScore();
            Assert.Equal(expected, actual);
   
        }

        [Theory]
        [InlineData(-1)]
        [InlineData(15)]
        [InlineData(11)]
        [InlineData(-20)]
        public void TestRollWithWrongRollValue(int pins)
        {
            Assert.Throws<ArgumentException>(() => game.Roll(pins));
        }

        [Fact]
        public void TestWithMoreThanTenFrames()
        {
            int[] pins =
            {
                10, 9, 1, 5, 5, 7, 2, 10, 10, 10, 9, 0, 8, 2, 9, 1, 10
            };
            game.HandleArrayOfPins(pins);
            Assert.Throws<PinsNotAvailableException>(() => game.Roll(5));
        }

        [Fact]
        public void TestASpare()
        {
            int[] pins = { 5, 5 };
            game.HandleArrayOfPins(pins);
            var expacted = 10;
            var actual = game.GetScore();
            Assert.Equal(expacted, actual);
        }
        
        [Fact]
        public void TestSpareThenTwoThenTwoScoresSixteen()
        {
            int[] pins = { 5, 5, 2, 2 };
            game.HandleArrayOfPins(pins);
            var expected = 16;
            var actual = game.GetScore();
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void TestAStrike()
        {
            game.Roll(10);
            var expected = 10;
            var actual =game.GetScore();
            Assert.Equal(expected, actual);
        }
        [Fact]
        public void TestStrikeThenTwoThenFiveScoresTwentyFour()
        {
            int[] pins = { 10, 2, 5 };
            game.HandleArrayOfPins(pins);
            var expected = 24;
            var actual = game.GetScore();
            Assert.Equal(expected, actual);
            // This is a dummy test that will always pass.
        }
        [Fact]
        public void TestTenthFrameWhenNoStrikeOrSpareScoredCountTotalSlots()
        {
            int[] pins = { 1, 2, 3, 5, 2, 2, 0, 8, 8, 1, 1, 7, 3, 5, 0, 9, 1, 6, 1, 2 };
            game.HandleArrayOfPins(pins);
            int expectedSlot = 2;
            int ActualSlot = game.GetCurrentFrameTotalSlotCount();
            Assert.Equal(expectedSlot, ActualSlot);
        }
        [Fact]
        public void TestTenthFrameWhenNoStrikeOrSpareScoredCountRemainingPins()
        {
            int[] pins = { 1, 2, 3, 5, 2, 2, 0, 8, 8, 1, 1, 7, 3, 5, 0, 9, 1, 6 };
            game.HandleArrayOfPins(pins);
            game.Roll(1);
            int expectedPins = 9;
            int ActualPins = game.GetCurrentFrameRemainingPins();
            Assert.Equal(expectedPins, ActualPins);
        }
        [Fact]
        public void TestActualMatchScoreOfAllTenFrames()
        {
            int[] pins =
            {
                10, 9, 1, 5, 5, 7, 2, 10, 10, 10, 9, 0, 8, 2, 9, 1, 10
            };
            game.HandleArrayOfPins(pins);
            var expected = 187;
            var actual = game.GetScore();
            Assert.Equal(expected, actual);

        }
        [Fact]
        public void TestAllStrikes()
        {
            game.RollMultipleTimes(10, 12);
            var expected = 300;
            var actual = game.GetScore();
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void TestWhenStrikesInAllFrameButRollsOneMoreTime()
        {
            game.RollMultipleTimes(10, 12);
            var actual = game.GetScore();
            Assert.Throws<PinsNotAvailableException>(() => game.Roll(10));
        }


    }
}