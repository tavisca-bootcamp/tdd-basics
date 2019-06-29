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
        //Yet to implement logic
        /*
        [Fact]
        public void TestCase3()
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
        public void TestCase5()
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

            g.Roll(8);
            g.Roll(2);

            g.Roll(9);
            g.Roll(1);
            g.Roll(10);
            Assert.Equal(99, g.GetScore());
        }

        [Fact]
        public void TestCase10()
        {
            g.Roll(10);
            g.Roll(0);

            g.Roll(10);
            g.Roll(0);

            g.Roll(10);
            g.Roll(0);

            g.Roll(10);
            g.Roll(0);

            g.Roll(10);
            g.Roll(0);

            g.Roll(10);
            g.Roll(0);

            g.Roll(10);
            g.Roll(0);

            g.Roll(10);
            g.Roll(0);

            g.Roll(10);
            g.Roll(0);

            g.Roll(10);
            g.Roll(0);

            g.Roll(10);
            g.Roll(0);

            g.Roll(10);
            g.Roll(0);
            g.Roll(10);
            Assert.Equal(300, g.GetScore());
        }
        
        [Fact]
        public void TestCase11()
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
            g.Roll(9);

            g.Roll(10);
            g.Roll(0);
            g.Roll(3);
            Assert.Equal(98, g.GetScore());
        }

        [Fact]
        public void TestCase12()
        {
            g.Roll(2);
            g.Roll(5);

            g.Roll(2);
            g.Roll(5);

            g.Roll(2);
            g.Roll(2);

            g.Roll(1);
            g.Roll(9);

            g.Roll(8);
            g.Roll(2);

            g.Roll(5);
            g.Roll(5);

            g.Roll(1);
            g.Roll(2);

            g.Roll(5);
            g.Roll(0);

            g.Roll(3);
            g.Roll(5);

            g.Roll(8);
            g.Roll(2);
            g.Roll(5);
            Assert.Equal(94, g.GetScore());
        }

        [Fact]
        public void TestCase13()
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
