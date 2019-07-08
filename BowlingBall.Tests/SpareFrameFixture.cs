using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
namespace BowlingBall.Tests
{
    public class SpareFrameFixture
    {
        [Fact]
        public void NegativeRollsToCreateSpareFrame()
        {
            //Negative roll shall throw exception
            try
            {
                var spareFrame = new SpareFrame(-1, -2,-8);
            }
            catch (Exception e)
            {
                //Throws exception
                return;
            }
            Assert.True(false);
        }
        [Fact]
        public void FirstRollNegativeToCreateSpareFrame()
        {
            //Negative roll shall throw exception
            try
            {
                var spareFrame = new SpareFrame(-1, 2, 8);
            }
            catch (Exception e)
            {
                //Throws exception
                return;
            }
            Assert.True(false);
        }

        [Fact]
        public void SecondRollNegativeToCreateSpareFrame()
        {
            //Negative roll shall throw exception
            try
            {
                var spareFrame = new SpareFrame(1, -2, 8);
            }
            catch (Exception e)
            {
                //Throws exception
                return;
            }
            Assert.True(false);
        }

        [Fact]
        public void ThirdRollNegativeToCreateSpareFrame()
        {
            //Negative roll shall throw exception
            try
            {
                var spareFrame = new SpareFrame(1, 2, -8);
            }
            catch (Exception e)
            {
                //Throws exception
                return;
            }
            Assert.True(false);
        }
        [Fact]
        public void RollsSumUpToValueLessThanExpectedToCreateSpareFrame()
        {
            //sum of rolls shall be 10 to create a spare frame
            try
            {
                var spareFrame = new SpareFrame(5,4,10);
            }
            catch (Exception e)
            {
                //Throws exception
                return;
            }
            Assert.True(false);
        }
        [Fact]
        public void RollsSumUpToValueMoreThanExpectedToCreateSpareFrame()
        {
            //sum of rolls shall be 10 to create a spare frame
            try
            {
                var spareFrame = new SpareFrame(5, 6, 10);
            }
            catch (Exception e)
            {
                //Throws exception
                return;
            }
            Assert.True(false);
        }
        [Fact]
        public void InvalidFirstRollToCreateSpareFrame()
        {
            //roll can't be more than 10
            try
            {
                var spareFrame = new SpareFrame(50, 4, 1);
            }
            catch (Exception e)
            {
                //Throws exception
                return;
            }
            Assert.True(false);
        }
        [Fact]
        public void InvalidSecondRollToCreateSpareFrame()
        {
            //roll can't be more than 10
            try
            {
                var spareFrame = new SpareFrame(5, 14, 1);
            }
            catch (Exception e)
            {
                //Throws exception
                return;
            }
            Assert.True(false);
        }
        [Fact]
        public void InvalidThirdRollToCreateSpareFrame()
        {
            //roll can't be more than 10
            try
            {
                var spareFrame = new SpareFrame(5, 4, 11);
            }
            catch (Exception e)
            {
                //Throws exception
                return;
            }
            Assert.True(false);
        }
        [Fact]
        public void ValidSetOfRollsToCreateSpareFrame()
        {
            try
            {
                var spareFrame = new SpareFrame(5, 5, 1);
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
