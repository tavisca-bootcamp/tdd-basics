using System;
using Xunit;
using BowlingBall;

namespace BowlingBall.Tests
{
    public class GameFixture
    {
        public Game game = new Game();
        [Fact]
        public void DummyTest()
        {
            // This is a dummy test that will always pass.
        }

        // Test for normal Roll
        [Fact]
        
        public void NormalRollTest()
        {
            int[] rolls = new int[] { 2,2 };
            game.InitializeRoll(rolls);
            int score = game.GetScore();
            Assert.Equal(4, score);   
        }

        // Test for Strike
        [Fact]
        public void StrikeOnlyTest()
        {
            int[] rolls = new int[] { 8, 1, 10, 6, 2 };
            game.InitializeRoll(rolls);
            int score = game.GetScore();
            Assert.Equal(35, score);
        }
        // Test for Spare
        [Fact]
        public void SpareOnlyTest()
        {
            int[] rolls = new int[] { 8, 2, 8, 1, 6, 2 };
            game.InitializeRoll(rolls);
            int score = game.GetScore();
            Assert.Equal(35, score);
        }
        // Test for Strike then Spare
        [Fact]
        public void StrikeThenSpareTest(){
            int[] rolls = new int[] { 10, 2, 8, 1, 6 };
            game.InitializeRoll(rolls);
            int score = game.GetScore();
            Assert.Equal(38, score);
        }
        // Test for Spare then Strike
        [Fact]
        public void SpareThenStrike(){
            int[] rolls = new int[] { 2, 8, 10, 1, 6 };
            game.InitializeRoll(rolls);
            int score = game.GetScore();
            Assert.Equal(44, score);
        }
        // Test for Strike on Last Roll
        [Fact]
        public void StrikeOnLastRoll()
        {
            int[] rolls = new int[] { 2, 6, 10, 1, 8, 10 };
            game.InitializeRoll(rolls);
            int score = game.GetScore();
            Assert.Equal(46, score);
        }
        // Test for Spare on Last Roll
        [Fact]
        public void SpareOnLastFrame()
        {
            int[] rolls = new int[] { 2, 8, 10, 2, 8 };
            game.InitializeRoll(rolls);
            int score = game.GetScore();
            Assert.Equal(50, score);
        }
        // Test for all strikes on last Roll
        [Fact]
        public void AllStrikes()
        {
            int[] rolls = new int[] { 10, 10, 10, 10, 10 };
            game.InitializeRoll(rolls);
            int score = game.GetScore();
            Assert.Equal(120, score);
        }

    }
}
