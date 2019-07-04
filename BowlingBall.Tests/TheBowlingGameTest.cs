using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;
using Xunit;
using BowlingBall;
namespace BowlingBall.Tests
{
    public class TheBowlingGameTest
    {
        [Fact]
        public void ScoreCannotBeMoreThan300()
        {
            ArrayList rolls = new ArrayList();
            for(int i = 0; i < 30; i++)
            {
                rolls.Add(10);
            }
            try
            {
                TheBowlingGame theBowlingGame = new TheBowlingGame(rolls);
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
            ArrayList rolls = new ArrayList();
            for (int i = 0; i < 6; i++)
                rolls.Add(10);
            try
            {
                TheBowlingGame theBowlingGame = new TheBowlingGame(rolls);
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
            ArrayList rolls = new ArrayList();
            for (int i = 0; i < 22; i++)
                rolls.Add(5);
            try
            {
                TheBowlingGame theBowlingGame = new TheBowlingGame(rolls);
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
            ArrayList rolls = new ArrayList();
            int expectedValue = 300;
            int actualValue;

            for (int i = 0; i < 12; i++)
                rolls.Add(10);
            TheBowlingGame theBowlingGame = new TheBowlingGame(rolls);
            actualValue = theBowlingGame.GetScore();

            Assert.Equal(expectedValue, actualValue);
        }
        [Fact]
        public void AllSpareTest()
        {
            ArrayList rolls = new ArrayList();
            int expectedValue = 150;
            int actualValue;

            for (int i = 0; i < 21; i++)
                rolls.Add(5);
            TheBowlingGame theBowlingGame = new TheBowlingGame(rolls);
            actualValue = theBowlingGame.GetScore();

            Assert.Equal(expectedValue, actualValue);
        }
        [Fact]
        public void AllValues2Test()
        {
            ArrayList rolls = new ArrayList();
            int expectedValue = 40;
            int actualValue;

            for (int i = 0; i < 20; i++)
                rolls.Add(2);
            TheBowlingGame theBowlingGame = new TheBowlingGame(rolls);
            actualValue = theBowlingGame.GetScore();

            Assert.Equal(expectedValue, actualValue);
        }
        [Fact]
        public void AllValues3Test()
        {
            ArrayList rolls = new ArrayList();
            int expectedValue = 60;
            int actualValue;

            for (int i = 0; i < 20; i++)
                rolls.Add(3);
            TheBowlingGame theBowlingGame = new TheBowlingGame(rolls);
            actualValue = theBowlingGame.GetScore();

            Assert.Equal(expectedValue, actualValue);
        }
        [Fact]
        public void ExampleTest()
        {
            ArrayList rolls = new ArrayList();
            int expectedValue = 187;
            int actualValue;

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
            TheBowlingGame theBowlingGame = new TheBowlingGame(rolls);
            actualValue = theBowlingGame.GetScore();

            Assert.Equal(expectedValue, actualValue);
        }
    }
}
