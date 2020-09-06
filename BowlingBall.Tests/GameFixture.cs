using System;
using Xunit;

namespace BowlingBall.Tests
{
    public class GameFixture
    {
        private Game bowlingGame;
        [Fact]
        public void ScoreCannotBeMoreThan300()
        {
            bowlingGame = new Game();
            try
            {
                for(int i = 0; i < 15; i++)
                {
                    bowlingGame.Roll(10);
                }
            }
            catch(Exception e)
            {
                //throws exception in creating rolls scoring more than 300
                return;
            }
            Assert.True(false);            
        }
        [Fact]
        public void BowlingGameWithLessRolls()
        {
            bowlingGame = new Game();
            try
            {
                for(int i = 0; i < 6; i++)
                {
                    bowlingGame.Roll(10);
                }
            }
            catch(Exception e)
            {
                //throws exception in creating less rolls
                return;
            }
            Assert.True(false);
        }
        [Fact]
        public void BowlingGameWithMoreRolls()
        {
            bowlingGame = new Game();
            try
            {
                for(int i = 0; i < 22; i++)
                {
                    bowlingGame.Roll(5);
                }
            }
            catch (Exception e)
            {
                //throws exception in creating more rolls
                return;
            }
            Assert.True(false);
        }
        [Fact]
        public void PerfectGameScoreTest()
        {
            var expectedValue = 300;
            var actualValue=0;

            bowlingGame = new Game();
            for (int i = 0; i < 12; i++)
                bowlingGame.Roll(10);
            actualValue = bowlingGame.GetScore();

            Assert.Equal(expectedValue, actualValue);
        }
        [Fact]
        public void AllSpareTest()
        {
            var expectedValue = 150;
            var actualValue=0;

            bowlingGame = new Game();
            for (int i = 0; i < 21; i++)
                bowlingGame.Roll(5);
            actualValue = bowlingGame.GetScore();

            Assert.Equal(expectedValue, actualValue);
        }
        [Fact]
        public void AllValues2Test()
        {
            var expectedValue = 40;
            var actualValue=0;

            bowlingGame = new Game();
            for (int i = 0; i < 20; i++)
                bowlingGame.Roll(2);
            actualValue = bowlingGame.GetScore();

            Assert.Equal(expectedValue, actualValue);
        }
        [Fact]
        public void AllValues3Test()
        {
            var expectedValue = 60;
            var actualValue=0;

            bowlingGame = new Game();
            for (int i = 0; i < 20; i++)
                bowlingGame.Roll(3);
            actualValue = bowlingGame.GetScore();

            Assert.Equal(expectedValue, actualValue);
        }
        [Fact]
        public void ExampleTest()
        {
            //arrange
            var game = new Game();

            game.Roll(10);
            game.Roll(9);

            game.Roll(1);
            game.Roll(5);

            game.Roll(5);
            game.Roll(7);

            game.Roll(2);
            game.Roll(10);

            game.Roll(10);
            game.Roll(10);

            game.Roll(9);
            game.Roll(0);

            game.Roll(8);
            game.Roll(2);

            game.Roll(9);
            game.Roll(1);
            game.Roll(10);

            int expected = 187;

            //act
            var actual = game.GetScore();

            //assert
            Assert.Equal(expected, actual);
        }
    }

}


