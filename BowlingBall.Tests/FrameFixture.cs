using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace BowlingBall.Tests
{
    public class FrameFixture
    {
        [Fact]
        public void RollValueMoreThan10()
        {
            //roll cannot be more than 10
            var result = Frame.IsValidRoll(12);
            Assert.False(result);
        }

        [Fact]
        public void RollValueNegative()
        {
            //roll cannot be less than 0
            var result = Frame.IsValidRoll(-2);
            Assert.False(result);
        }
        [Fact]
        public void ValidRollValues()
        {
            //valid roll values lies in the range of 0 to 10
            var result1 = Frame.IsValidRoll(0);
            var result2 = Frame.IsValidRoll(10);
            var result3 = Frame.IsValidRoll(4);
            var result4 = Frame.IsValidRoll(2);
            var result5 = Frame.IsValidRoll(7);

            var result = result1 && result2 && result3 && result4 && result5;
            Assert.True(result);
        }
    }
}
