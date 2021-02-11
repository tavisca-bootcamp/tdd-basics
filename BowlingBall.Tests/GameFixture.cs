using System;
using Xunit;

namespace BowlingBall.Tests
{
    public class GameFixture
    {
        [Fact]
        public void DummyTest()
        {
            // This is a dummy test that will always pass.
        }
        
        [TestMethod]
        public void CanRollTheBallTest()
        {
            var bb = new BowlingBall();
            bb.Roll(0);
        }

        [TestMethod]
        public void GetTheScoreTest()
        {
            var bb = new BowlingBall();
            for (int i = 0; i < 20; i++)
                bb.Roll(1);
            Console.WriteLine(bb.GetScore());
            //Assert.(20, bb.GetScore());
            Assert.AreEqual(20, bb.GetScore());
        }

       [TestMethod]
        public void ThrowingASpareTest()
        {
            var bb = new BowlingBall();
            for (int i = 0; i < 20; i++)
            {
                bb.Roll(5);

            }
            Assert.AreEqual(150, bb.GetScore());


        }
       [TestMethod]
        public void StrikeTest()
        {
            var bb = new BowlingBall();
          
            for(int i=0;i<21;i++)
            {
                bb.Roll(10);

            }

            Assert.AreEqual(300, bb.GetScore());

        }
        [TestMethod]
        public void PerfectGameTesst()
        {
            var bb = new BowlingBall();
            for (int i = 0; i < 20; i++)
            {
                bb.Roll(10);
            }
            Assert.AreEqual(300, bb.GetScore());
        }
    }
}
