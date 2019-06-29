using System;
using Xunit;

namespace BowlingBall.Tests
{
    public class GameFixture
    {
        [Fact]
        public void DummyTest()
        {
            //arrange
            Game g = new Game();

            //act
            g.Roll(5);
            g.Roll(5);
            g.Roll(5);
            var res= g.GetScore();
            System.Console.WriteLine("Running the test");

            //assert
            Assert.Equal(20,res);

        }
        [Fact]
        public void GutterTest()
        {
            Game g = new Game();
            for (int i = 0; i < 20; i++)
                g.Roll(0);

            var score = g.GetScore();
            Assert.Equal(0,score);

        }

        [Fact]
        public void testAllOnes()
        {
             Game g = new Game();
            for (int i = 0; i < 20; i++)
                g.Roll(1);
            
            Assert.Equal(20, g.GetScore());
        }

        [Fact]
        public void testOneSpare() 
        {
            Game g = new Game();
            g.Roll(5);
            g.Roll(5); // spare
            g.Roll(3);
            Assert.Equal(16,g.GetScore());
  
        }

        [Fact]
        public void testOneStrike()
        {
            Game g = new Game();
            g.Roll(10); // strike
            g.Roll(3);
            g.Roll(4);
            Assert.Equal(24, g.GetScore());
        }

        [Fact]
        public void PerfectGame()
        {
            Game g = new Game();
            for(int i=0;i<12;i++)
                g.Roll(10);
            Assert.Equal(300,g.GetScore());

        }



    }
}
