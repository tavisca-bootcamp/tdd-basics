using System;
using Xunit;

namespace BowlingBall.Tests
{
    public class GameFixture
    {
        [Fact]
        public void DummyTest()
        {
            return;
        }
        [Fact]
        public void TestTypeOfGameObject()
        {
            Game game = new Game();
            Assert.IsType<Game>(game);
        }
        [Fact]
        public void TestGameSetupScore()
        {
            Game game = new Game();
            Assert.Equal(0, game.GetScore());
        }

        [Fact]
        public void TestGameSetupRemainingPins()
        {
            Game game = new Game();
            Assert.Equal(100, game.GetTotalPins());
        }
        [Fact]
        public void TestGameSetupRemainingBowl()
        {
            Game game = new Game();
            Assert.Equal(20, game.GetTotalBowl());
        }
        [Fact]
        public void TestSingleRollWithNegativeNumberOfPins()
        {
            Game game = new Game();
            Assert.Throws<ArgumentOutOfRangeException>(() => game.Roll(-5));
        }
        [Fact]
        public void TestSingleRollWiMoreThanTenNumberOfPins()
        {
            Game game = new Game();
            Assert.Throws<ArgumentOutOfRangeException>(() => game.Roll(11));
        }
        [Fact]
        public void TestGameSetupTotalSlotAvailable()
        {
            Game game = new Game();
            Assert.Equal(20, game.GetTotalSlotsCount());
        }
        [Fact]
        public void TestGameSetupSingleRoll()
        {
            Game game = new Game();
            game.Roll(7);
            Assert.Equal(7, game.GetValueInSlot(0));
        }
        [Fact]
        public void TestGameSetupCurrentFrameReamainingPins()
        {
            Game game = new Game();
            game.Roll(4);
            Assert.Equal(6, game.GetCurrentFrameReamainingPins());
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
            Assert.Equal(3, game.GetCurrentFrameReamainingPins());
        }
        [Fact]
        public void TestRollMethodToValidateNoMorePinsAvailable()
        {
            Game game = new Game();
            game.Roll(4);
            Assert.Throws<NoMorePinsAvailable>(() => game.Roll(7));
        }
        [Fact]
        public void TestCurrentFrameIndexOnStrike()
        {
            Game game = new Game();
            game.Roll(10);
            Assert.Equal(1, game.GetCurrentFrameIndex());
        }
        [Fact]
        public void TestCurrentFrameIndexOnStrikeVariant2()
        {
            Game game = new Game();
            MultipleRollHandler(new int[] { 10, 10 }, ref game);
            Assert.Equal(2, game.GetCurrentFrameIndex());
        }
        [Fact]
        public void TestTenthFrameCurrentFrame()
        {
            Game game = new Game();
            var pins = new int[] { 1, 2, 9, 1, 3, 4, 9, 0, 5, 2, 3, 4, 9, 1, 4, 5, 4, 6 };
            MultipleRollHandler(pins, ref game);
            Assert.Equal(9, game.GetCurrentFrameIndex());
        }
        [Fact]
        public void TestTenthFrameSlotCountWithNoBallRoll()
        {
            Game game = new Game();
            var pins = new int[] { 1, 2, 9, 1, 3, 4, 9, 0, 5, 2, 3, 4, 9, 1, 4, 5, 4, 6 };
            MultipleRollHandler(pins, ref game);
            Assert.Equal(2, game.GetCurrentFrameTotalSlotCount());
        }
        [Fact]
        public void TestTenthFrameRemainingBallOnNOBallRoll()
        {
            Game game = new Game();
            var pins = new int[] { 1, 2, 9, 1, 3, 4, 9, 0, 5, 2, 3, 4, 9, 1, 4, 5, 4, 6 };
            MultipleRollHandler(pins, ref game);
            Assert.Equal(10, game.GetCurrentFrameReamainingPins());
        }
        [Fact]
        public void TestTenthFrameStrikeOnFirstBall()
        {
            Game game = new Game();
            var pins = new int[] { 1, 2, 9, 1, 3, 4, 9, 0, 5, 2, 3, 4, 9, 1, 4, 5, 4, 6 };
            MultipleRollHandler(pins, ref game);
            game.Roll(10);
            Assert.Equal(10, game.GetValueInSlot(0));
        }
        [Fact]
        public void TestTenthFrameStrikeOnFirstBallAndRemainingBall()
        {
            Game game = new Game();
            var pins = new int[] { 1, 2, 9, 1, 3, 4, 9, 0, 5, 2, 3, 4, 9, 1, 4, 5, 4, 6 };
            MultipleRollHandler(pins, ref game);
            game.Roll(10);
            Assert.Equal(10, game.GetCurrentFrameReamainingPins());
        }
        [Fact]
        public void TestTenthFrameStrikeOnFirstBallAndCountSlotMethod()
        {
            Game game = new Game();
            var pins = new int[] { 1, 2, 9, 1, 3, 4, 9, 0, 5, 2, 3, 4, 9, 1, 4, 5, 4, 6 };
            MultipleRollHandler(pins, ref game);
            game.Roll(10);
            Assert.Equal(3, game.GetCurrentFrameTotalSlotCount());
        }
        [Fact]
        public void TestTenthFrameSpareCurrentFrameTotalSlotCount()
        {
            Game game = new Game();
            var pins = new int[] { 1, 2, 9, 1, 3, 4, 9, 0, 5, 2, 3, 4, 9, 1, 4, 5, 4, 6 };
            MultipleRollHandler(pins, ref game);
            game.Roll(5);
            game.Roll(5);
            Assert.Equal(3, game.GetCurrentFrameTotalSlotCount());
        }
        [Fact]
        public void TestTenthFrameNoSpareNoStrikeOnFirstBallCurrentFrameTotalSlotCount()
        {
            Game game = new Game();
            var pins = new int[] { 1, 2, 9, 1, 3, 4, 9, 0, 5, 2, 3, 4, 9, 1, 4, 5, 4, 6 };
            MultipleRollHandler(pins, ref game);
            game.Roll(5);
            game.Roll(4);
            Assert.Equal(2, game.GetCurrentFrameTotalSlotCount());
        }
        [Fact]
        public void TestTenthFrameNoSpareNoStrikeOnFirstBallRemainingPins()
        {
            Game game = new Game();
            var pins = new int[] { 1, 2, 9, 1, 3, 4, 9, 0, 5, 2, 3, 4, 9, 1, 4, 5, 4, 6 };
            MultipleRollHandler(pins, ref game);
            game.Roll(5);
            game.Roll(4);
            Assert.Equal(1, game.GetCurrentFrameReamainingPins());
        }
        [Fact]
        public void TestTenthFrameStrikeOnSecondBallRemainingPins()
        {
            Game game = new Game();
            var pins = new int[] { 1, 2, 9, 1, 3, 4, 9, 0, 5, 2, 3, 4, 9, 1, 4, 5, 4, 6 };
            MultipleRollHandler(pins, ref game);
            game.Roll(10);
            game.Roll(10);
            Assert.Equal(10, game.GetCurrentFrameReamainingPins());
        }
        [Fact]
        public void TestTenthFrameNoStrikeOnSecondBallRemainingPins()
        {
            Game game = new Game();
            var pins = new int[] { 1, 2, 9, 1, 3, 4, 9, 0, 5, 2, 3, 4, 9, 1, 4, 5, 4, 6 };
            MultipleRollHandler(pins, ref game);
            game.Roll(10);
            game.Roll(5);
            Assert.Equal(5, game.GetCurrentFrameReamainingPins());
        }
        [Fact]
        public void TestTenthFrameThirdBallRemainingPins()
        {
            Game game = new Game();
            var pins = new int[] { 1, 2, 9, 1, 3, 4, 9, 0, 5, 2, 3, 4, 9, 1, 4, 5, 4, 6 };
            MultipleRollHandler(pins, ref game);
            game.Roll(10);
            game.Roll(5);
            game.Roll(3);
            // Zero Pins Now Available due to game over
            Assert.Equal(0, game.GetCurrentFrameReamainingPins());
        }
        [Fact]
        public void TestTenthFrameGameOverExpectedException()
        {
            Game game = new Game();
            var pins = new int[] { 1, 2, 9, 1, 3, 4, 9, 0, 5, 2, 3, 4, 9, 1, 4, 5, 4, 6 };
            MultipleRollHandler(pins, ref game);
            game.Roll(3);
            game.Roll(5);
            // Zero Pins Now Available due to game over
            Assert.Throws<NoMorePinsAvailable>(() => game.Roll(3));
        }
        [Fact]
        public void TestTenthFrameTwoBallStrikeAndTenBallRemaining()
        {
            Game game = new Game();
            var pins = new int[] { 1, 2, 9, 1, 3, 4, 9, 0, 5, 2, 3, 4, 9, 1, 4, 5, 4, 6 };
            MultipleRollHandler(pins, ref game);
            game.Roll(10);
            game.Roll(10);
            Assert.Equal(10, game.GetCurrentFrameReamainingPins());
        }
        [Fact]
        public void TestTenthFrameAllThreeBallStrike()
        {
            Game game = new Game();
            var pins = new int[] { 1, 2, 9, 1, 3, 4, 9, 0, 5, 2, 3, 4, 9, 1, 4, 5, 4, 6 };
            MultipleRollHandler(pins, ref game);
            game.Roll(10);
            game.Roll(10);
            game.Roll(10);
            Assert.Equal(0, game.GetCurrentFrameReamainingPins());
        }
        [Fact]
        public void TestScoreToNinthFrame()
        {
            Game game = new Game();
            var pins = new int[] { 1, 2, 9, 1, 3, 4, 9, 0, 5, 2, 3, 4, 9, 1, 4, 5, 10,8,2,3};
            MultipleRollHandler(pins, ref game);
            Assert.Equal(102, game.GetScore());
        }
        private void MultipleRollHandler(int[] pins, ref Game game)
        {
            foreach (int pin in pins)
                game.Roll(pin);

        }

    }
}
