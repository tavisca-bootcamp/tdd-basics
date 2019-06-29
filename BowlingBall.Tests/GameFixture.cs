using System;
using Xunit;
namespace BowlingBall.Tests
{
    public class GameFixture
    {
        Game g = new Game();
        [Fact]
        public void TestGameWithOutOfRangePinValues()
        {
            int[] pinsDown = {3,2,9,1,4,-2,-5,19,6,3,10,1,1,5,2,5,9,8,1};
            for(int i=0; i<pinsDown.Length;i++)
                {
                    if(pinsDown[i]<0 || pinsDown[i]>10)
                    {
                         Assert.NotInRange(pinsDown[i], 0, 10);
                         return;
                    }
                    else
                    {
                         g.Roll(pinsDown[i]);
                    }
                }
        }
    }
}
