using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
namespace BowlingBall.Tests
{
    public class StrikeFrameFixture
    {

        [Fact]
        public void NegativeRollsToCreateStrikeFrame()
        {
            //Negative roll shall throw exception
            try
            {
                var strikeFrame=new StrikeFrame(-1, -2, -8);
            }
            catch (Exception e)
            {
                //Throws exception
                return;
            }
            Assert.True(false);
        }
        [Fact]
        public void FirstRollNegativeToCreateStrikeFrame()
        {
            //Negative roll shall throw exception
            try
            {
                var strikeFrame = new StrikeFrame(-1, 2, 8);
            }
            catch (Exception e)
            {
                //Throws exception
                return;
            }
            Assert.True(false);
        }

        [Fact]
        public void SecondRollNegativeToCreateStrikeFrame()
        {
            //Negative roll shall throw exception
            try
            {
                var strikeFrame = new StrikeFrame(10, -2, 8);
            }
            catch (Exception e)
            {
                //Throws exception
                return;
            }
            Assert.True(false);
        }

        [Fact]
        public void ThirdRollNegativeToCreateStrikeFrame()
        {
            //Negative roll shall throw exception
            try
            {
                var strikeFrame = new StrikeFrame(10, 2, -8);
            }
            catch (Exception e)
            {
                //Throws exception
                return;
            }
            Assert.True(false);
        }
        [Fact]
        public void RollIsLessThanExpectedToCreateStrikeFrame()
        {
            //strike frame shall have a roll of 10 pins
            try
            {
                var strikeFrame = new StrikeFrame(5, 4, 10);
            }
            catch (Exception e)
            {
                //Throws exception
                return;
            }
            Assert.True(false);
        }
        [Fact]
        public void RollIsMoreThanExpectedToCreateStrikeFrame()
        {
            //strike frame shall have a roll of 10 pins
            try
            {
                var strikeFrame = new StrikeFrame(15, 6, 10);
            }
            catch (Exception e)
            {
                //Throws exception
                return;
            }
            Assert.True(false);
        }
        [Fact]
        public void InvalidFirstRollToCreateStrikeFrame()
        {
            //roll can't be more than 10
            try
            {
                var strikeFrame = new StrikeFrame(50, 4, 1);
            }
            catch (Exception e)
            {
                //Throws exception
                return;
            }
            Assert.True(false);
        }
        [Fact]
        public void InvalidSecondRollToCreateStrikeFrame()
        {
            //roll can't be more than 10
            try
            {
                var strikeFrame = new StrikeFrame(10, 14, 1);
            }
            catch (Exception e)
            {
                //Throws exception
                return;
            }
            Assert.True(false);
        }
        [Fact]
        public void InvalidThirdRollToCreateStrikeFrame()
        {
            //roll can't be more than 10
            try
            {
                var strikeFrame = new StrikeFrame(10, 4, 11);
            }
            catch (Exception e)
            {
                //Throws exception
                return;
            }
            Assert.True(false);
        }
        [Fact]
        public void ValidSetOfRollsToCreateStrikeFrame()
        {
            try
            {
                var strikeFrame = new StrikeFrame(10, 5, 1);
            }
            catch (Exception e)
            {
                //No exception is expected
                Assert.True(false);
            }
            Assert.True(true);
        }
    }
}
