using System;
using Xunit;

namespace BowlingBall.Tests
{
    public class GameFixture
    {
         public void SetAllOnes()  //all ones
        {
            Game Game = new Game();
            for(int i=1;i<=20;i++)Game.Roll(1);
            Assert.Equal(20, Game.GetScore());
        }

        [Fact]
        public void TestGutterGame()   //all frame zero
        {
            Game Game = new Game();
            for(int i=1;i<=20;i++) Game.Roll(0);
            Assert.Equal<int>(0, Game.GetScore());
        }

        [Fact]
        public void Test1()
        {
            Game Game = new Game(); //all strike
            int[] a = new int[] { 0,10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10 };
            for (int i = 1; i <= 12; i++) Game.Roll(a[i]);
            Assert.Equal(300, Game.GetScore());
        }

        [Fact]
        public void Test2() //one spare
        {
            Game Game = new Game();
            int[] a = new int[] { 0, 5,5, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10 };
            for (int i = 1; i <= 13; i++) Game.Roll(a[i]);
            Assert.Equal(290, Game.GetScore());
        }

        [Fact]
        public void Test3() //first spare last normal
        {
            Game Game = new Game();
            int[] a = new int[] { 0, 5, 5, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 6 };
            for (int i = 1; i <= 13; i++) Game.Roll(a[i]);
            Assert.Equal(286, Game.GetScore());
        }
        [Fact]
        public void Test4() //Random
        {
            Game Game = new Game();
            int[] a = new int[] { 0, 5, 4, 3, 2, 1, 2, 3, 4, 5, 4,  3, 2,1,2,4,3,5,4,3,2 };
            for (int i = 1; i <= 20; i++) Game.Roll(a[i]);
            Assert.Equal(62, Game.GetScore());
        }
    }
}
