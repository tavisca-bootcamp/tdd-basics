using System;
using Xunit;

namespace BowlingBall.Tests
{
    public class GameFixture
    {
        private Game g =new Game();
        [Fact]
        
        public void DummyTest()
        {
            // This is a dummy test that will always pass.
            
        }
        private void RollMany(int n,int pins)
        {
            for (int i = 0; i < n; i++)
                g.Roll(pins);
        }
        [Fact]
        public void AllZeros()
        {
            int n = 20;
            int pins = 0;
            RollMany(n, pins);
            Assert.Equal(0, g.GetScore());
        }
        [Fact]
        public void AllOnes()
        {
            int n = 20;
            int pins = 1;
            RollMany(20, pins);
            Assert.Equal(20, g.GetScore());
        }

        
        

        [Fact]
        public void NoSpareOrStrike()
        {
            g.Roll(1);
            g.Roll(6);

            g.Roll(1);
            g.Roll(8);

            g.Roll(5);
            g.Roll(4);

            g.Roll(3);
            g.Roll(1);

            g.Roll(2);
            g.Roll(3);

            g.Roll(3);
            g.Roll(4);

            g.Roll(1);
            g.Roll(1);

            g.Roll(2);
            g.Roll(7);

            g.Roll(3);
            g.Roll(1);

            g.Roll(0);
            g.Roll(2);

            Assert.Equal(58, g.GetScore());
        }

        [Fact]
        public void OneSpare()
        {
            g.Roll(1);
            g.Roll(7);

            g.Roll(4);
            g.Roll(0);

            g.Roll(2);
            g.Roll(4);

            g.Roll(5);
            g.Roll(5);

            g.Roll(1);
            g.Roll(7);

            g.Roll(1);
            g.Roll(1);

            g.Roll(5);
            g.Roll(2);

            g.Roll(1);
            g.Roll(4);

            g.Roll(2);
            g.Roll(3);

            g.Roll(2);
            g.Roll(2);
            Assert.Equal(60, g.GetScore());
        }

        [Fact]
        public void MulipleSpares()
        {
            g.Roll(5);
            g.Roll(3);

            g.Roll(4);
            g.Roll(6);

            g.Roll(1);
            g.Roll(8);

            g.Roll(2);
            g.Roll(1);

            g.Roll(1);
            g.Roll(9);

            g.Roll(5);
            g.Roll(2);

            g.Roll(0);
            g.Roll(0);

            g.Roll(1);
            g.Roll(8);

            g.Roll(1);
            g.Roll(8);

            g.Roll(9);
            g.Roll(0);

            Assert.Equal(80, g.GetScore());
        }

        [Fact]
        public void OneStrike()
        {
            g.Roll(0);
            g.Roll(2);

            g.Roll(0);
            g.Roll(9);

            g.Roll(0);
            g.Roll(0);

            g.Roll(6);
            g.Roll(1);

            g.Roll(4);
            g.Roll(4);

            g.Roll(6);
            g.Roll(0);

            g.Roll(1);
            g.Roll(8);

            g.Roll(6);
            g.Roll(3);

            g.Roll(10);
            g.Roll(0);

            g.Roll(8);
            g.Roll(1);

            Assert.Equal(78, g.GetScore());
        }

        [Fact]
        public void AllStrikes()
        {
            g.Roll(10);//1
            g.Roll(0);

            g.Roll(10);//2
            g.Roll(0);

            g.Roll(10);//3
            g.Roll(0);

            g.Roll(10);//4
            g.Roll(0);

            g.Roll(10);//5
            g.Roll(0);

            g.Roll(10);//6
            g.Roll(0);

            g.Roll(10);//7
            g.Roll(0);

            g.Roll(10);//8
            g.Roll(0);

            g.Roll(10);//9
            g.Roll(0);

            g.Roll(10);//10
            g.Roll(0);
            g.Roll(10);
            Assert.Equal(300, g.GetScore());
        }

        [Fact]
        public void AllSpares()
        {
            g.Roll(8);
            g.Roll(2);

            g.Roll(8);
            g.Roll(2);

            g.Roll(8);
            g.Roll(2);

            g.Roll(8);
            g.Roll(2);

            g.Roll(8);
            g.Roll(2);

            g.Roll(8);
            g.Roll(2);

            g.Roll(8);
            g.Roll(2);

            g.Roll(8);
            g.Roll(2);

            g.Roll(8);
            g.Roll(2);

            g.Roll(8);
            g.Roll(2);
            g.Roll(5);
            Assert.Equal(182, g.GetScore());
        }

        [Fact]
        public void SparesAndStrikes()
        {
            g.Roll(5);
            g.Roll(4);

            g.Roll(4);
            g.Roll(1);

            g.Roll(6);
            g.Roll(4);

            g.Roll(10);
            g.Roll(0);

            g.Roll(3);
            g.Roll(5);

            g.Roll(5);
            g.Roll(3);

            g.Roll(2);
            g.Roll(8);

            g.Roll(2);
            g.Roll(5);

            g.Roll(3);
            g.Roll(6);

            g.Roll(1);
            g.Roll(8);

            Assert.Equal(105, g.GetScore());
        }
        //Yet to implement logic
        /*
        

        

        
        
        

        

        

        */

        //Extra test cases (Repeated cases) 
        /*
        [Fact]
        public void TestCase6()
        {
            g.Roll(3);
            g.Roll(5);
            g.Roll(4);
            g.Roll(0);
            g.Roll(3);
            g.Roll(6);
            g.Roll(1);
            g.Roll(5);
            g.Roll(4);
            g.Roll(2);
            g.Roll(0);
            g.Roll(9);
            g.Roll(7);
            g.Roll(3);
            g.Roll(7);
            g.Roll(2);
            g.Roll(6);
            g.Roll(0);
            g.Roll(1);
            g.Roll(6);
            Assert.Equal(0, g.GetScore());
        }

        [Fact]
        public void TestCase7()
        {
            g.Roll(5);
            g.Roll(4);
            g.Roll(1);
            g.Roll(2);
            g.Roll(0);
            g.Roll(0);
            g.Roll(1);
            g.Roll(4);
            g.Roll(6);
            g.Roll(0);
            g.Roll(7);
            g.Roll(1);
            g.Roll(3);
            g.Roll(3);
            g.Roll(1);
            g.Roll(8);
            g.Roll(2);
            g.Roll(6);
            g.Roll(6);
            g.Roll(0);
            Assert.Equal(0, g.GetScore());
        }

        [Fact]
        public void TestCase8()
        {
            g.Roll(0);
            g.Roll(1);
            g.Roll(2);
            g.Roll(5);
            g.Roll(0);
            g.Roll(9);
            g.Roll(5);
            g.Roll(1);
            g.Roll(2);
            g.Roll(0);
            g.Roll(1);
            g.Roll(6);
            g.Roll(4);
            g.Roll(0);
            g.Roll(6);
            g.Roll(1);
            g.Roll(1);
            g.Roll(4);
            g.Roll(2);
            g.Roll(8);
            g.Roll(2);
            Assert.Equal(0, g.GetScore());
        }

        [Fact]
        public void TestCase9()
        {
            g.Roll(7);
            g.Roll(1);
            g.Roll(0);
            g.Roll(7);
            g.Roll(3);
            g.Roll(4);
            g.Roll(5);
            g.Roll(1);
            g.Roll(0);
            g.Roll(9);
            g.Roll(5);
            g.Roll(5);
            g.Roll(3);
            g.Roll(3);
            g.Roll(3);
            g.Roll(7);
            g.Roll(4);
            g.Roll(3);
            g.Roll(10);
            g.Roll(0);
            g.Roll(10);
            Assert.Equal(0, g.GetScore());
        }
        */



    }
}
