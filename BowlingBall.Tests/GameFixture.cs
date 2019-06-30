using System;
using Xunit;
namespace BowlingBall.Tests
{
    public class GameFixture
    {
        Game g = new Game();


        [Fact]
        public void TestGameObjectNotNullCheck()
        {
            Assert.NotNull(g);
        }

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

        [Fact]
        public void TestGameWithRandomRightInput()
        {
            int[] pinsDown = {5,2,5,5,7,3,2,5,4,6,6,4,10,1,9,2,6,3,3};
            for (int i = 0; i < pinsDown.Length; i++)
                    g.Roll(pinsDown[i]);
            Assert.Equal(125, g.GetScore());
        }

        [Fact]
        public void TestGameWithBestCase()
        {
            int[] pinsDown = {10,10,10,10,10,10,10,10,10,10,10,10};
            for (int i = 0; i < pinsDown.Length; i++)
                g.Roll(pinsDown[i]);
            Assert.Equal(300, g.GetScore());
        }

        [Fact]
        public void TestGameWithNoStrikeNoSpare()
        {
            int[] pinsDown = { 2,2,3,2,4,4,7,2,3,6,1,8,2,5,3,2,9,0,0,1};
            for (int i = 0; i < pinsDown.Length; i++)
                g.Roll(pinsDown[i]);
            Assert.Equal(66, g.GetScore());
        }

        [Fact]
        public void TestGameWithAllSpareWithExtraBall()
        {
            int[] pinsDown = { 2, 8, 1, 9, 4, 6, 5, 5, 6, 4, 1, 9, 9, 1, 3, 7, 8, 2, 7, 3,1 };
            for (int i = 0; i < pinsDown.Length; i++)
                g.Roll(pinsDown[i]);
            Assert.Equal(145, g.GetScore());
        }


        [Fact]
        public void TestGameWithStrikeInEndCaseOfExtraBall()
        {
            int[] pinsDown = { 2, 4, 10, 2, 6, 4, 6, 3, 4, 0, 0, 1, 3, 5, 5, 10, 10, 4, 3 };
            for (int i = 0; i < pinsDown.Length; i++)
                g.Roll(pinsDown[i]);
            Assert.Equal(117, g.GetScore());
        }

        [Fact]
        public void TestGameWithInvalidExtraBall()
        {
            int[] pinsDown = { 2,8,5,4,10,10,5,5,3,2,6,3,10,2,7,1,3,3}; // no spare and strike but 3rd ball is given in 10th frame.
            for (int i = 0; i < pinsDown.Length; i++)
                g.Roll(pinsDown[i]);
            Assert.Equal(-1, g.GetScore());
        }




    }
}
