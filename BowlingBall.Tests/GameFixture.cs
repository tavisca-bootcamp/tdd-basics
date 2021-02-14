using System;
using Xunit;
namespace BowlingBall.Tests
{
    public class GameFixture
    {
        private Game obj;

        public GameFixture()
        {
            this.obj = new Game();
        }

        [Fact]
        
        public void AllZero()
        {
            for(int i=0; i< 20; i++){
                obj.Roll(0);
            }
            Assert.Equal(expected: 0, actual: obj.GetScore());
        }

        public void Method1(int n, int pins)
        {
            for(int i=0; i<n; i++){
                obj.Roll(pins);
            }
        }


        [Fact]
        public void AllOnes()
        {
            Method1(20,1);
            Assert.Equal(expected: 20,actual: obj.GetScore());
        }

        [Fact]
        public void OneSpare()
        {
            obj.Roll(5);
            obj.Roll(5);
            obj.Roll(3);
            Method1(17,0);
            Assert.Equal(expected: 16,actual: obj.GetScore());
        }

        [Fact]
        public void OneStrike()
        {
            RollStrike();
            obj.Roll(3);
            obj.Roll(4);
            Method1(16,0);
            Assert.Equal(expected: 24,actual: obj.GetScore());
        }

        [Fact]
        public void PerfectGame()
        {
            Method1(12,10);
            Assert.Equal(expected: 300,actual: obj.GetScore());
        }

        private void RollStrike(){
            obj.Roll(10);
        }

        public void Spare()
        {
            
            obj.Roll(5);
            obj.Roll(5);
        }
    }
}
