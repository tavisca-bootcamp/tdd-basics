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
    }
}
