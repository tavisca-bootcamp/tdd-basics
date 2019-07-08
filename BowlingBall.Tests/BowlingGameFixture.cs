using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;
using Xunit;
using BowlingBall;
namespace BowlingBall.Tests
{
    public class BowlingGameFixture
    {
        private BowlingGame bowlingGame;
        [Fact]
        public void ScoreCannotBeMoreThan300()
        {
            var rolls = new ArrayList();
            for(int i = 0; i < 30; i++)
            {
                rolls.Add(10);
            }
            try
            {
                bowlingGame = new BowlingGame(rolls);
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
            var rolls = new ArrayList();
            for (int i = 0; i < 6; i++)
                rolls.Add(10);
            try
            {
                bowlingGame = new BowlingGame(rolls);
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
            var rolls = new ArrayList();
            for (int i = 0; i < 22; i++)
                rolls.Add(5);
            try
            {
                bowlingGame = new BowlingGame(rolls);
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
            var rolls = new ArrayList();
            var expectedValue = 300;
            var actualValue=0;

            for (int i = 0; i < 12; i++)
                rolls.Add(10);
            bowlingGame = new BowlingGame(rolls);
            actualValue = bowlingGame.GetScore();

            Assert.Equal(expectedValue, actualValue);
        }
        [Fact]
        public void AllSpareTest()
        {
            var rolls = new ArrayList();
            var expectedValue = 150;
            var actualValue=0;

            for (int i = 0; i < 21; i++)
                rolls.Add(5);
            bowlingGame = new BowlingGame(rolls);
            actualValue = bowlingGame.GetScore();

            Assert.Equal(expectedValue, actualValue);
        }
        [Fact]
        public void AllValues2Test()
        {
            var rolls = new ArrayList();
            var expectedValue = 40;
            var actualValue=0;

            for (int i = 0; i < 20; i++)
                rolls.Add(2);
            bowlingGame = new BowlingGame(rolls);
            actualValue = bowlingGame.GetScore();

            Assert.Equal(expectedValue, actualValue);
        }
        [Fact]
        public void AllValues3Test()
        {
            var rolls = new ArrayList();
            var expectedValue = 60;
            var actualValue=0;

            for (int i = 0; i < 20; i++)
                rolls.Add(3);
            bowlingGame = new BowlingGame(rolls);
            actualValue = bowlingGame.GetScore();

            Assert.Equal(expectedValue, actualValue);
        }
        [Fact]
        public void ExampleTest()
        {
            var rolls = new ArrayList();
            var expectedValue = 187;
            var actualValue=0;

            rolls.Add(10);
            rolls.Add(9);
            rolls.Add(1);
            rolls.Add(5);
            rolls.Add(5);
            rolls.Add(7);
            rolls.Add(2);
            rolls.Add(10);
            rolls.Add(10);
            rolls.Add(10);
            rolls.Add(9);
            rolls.Add(0);
            rolls.Add(8);
            rolls.Add(2);
            rolls.Add(9);
            rolls.Add(1);
            rolls.Add(10);
            bowlingGame = new BowlingGame(rolls);
            actualValue = bowlingGame.GetScore();

            Assert.Equal(expectedValue, actualValue);
        }
    }
}
