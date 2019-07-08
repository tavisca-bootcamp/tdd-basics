using System;
using System.Collections.Generic;
using System.Text;
using BowlingBall;
using Xunit;
namespace BowlingBall.Tests
{
    public class RegularFrameFixture
    {
        private RegularFrame regularFrame;
        [Fact]
        public void NegativeRollsToCreateRegularFrame()
        {
            //Negative roll shall throw exception
            try
            {
                regularFrame = new RegularFrame(-1, -2);
            }
            catch(Exception e)
            {
                //Throws exception
                return;
            }
            Assert.True(false);
        }
        [Fact]
        public void OneNegativeRollToCreateRegularFrame()
        {
            //Negative roll shall throw exception
            try
            {
                regularFrame = new RegularFrame(-1, 2);
            }
            catch (Exception e)
            {
                //Throws exception
                return;
            }
            Assert.True(false);
        }
        [Fact]
        public void InvalidRollToCreateRegularFrame()
        {
            //Negative roll shall throw exception
            try
            {
                regularFrame = new RegularFrame(100,1);
            }
            catch (Exception e)
            {
                //Throws exception
                return;
            }
            Assert.True(false);
        }
        [Fact]
        public void RollsSumUpToValueMoreThanExpectedToCreateRegularFrame()
        {
            //Negative roll shall throw exception
            try
            {
                regularFrame = new RegularFrame(5, 6);
            }
            catch (Exception e)
            {
                //Throws exception
                return;
            }
            Assert.True(false);
        }
        [Fact]
        public void validRollsToCreateRegularFrame()
        {
            //valid roll shall not throw exception
            try
            {
                regularFrame = new RegularFrame(5, 4);
            }
            catch (Exception e)
            {
                Assert.True(false);
            }
            Assert.True(true);
        }

    }
}
