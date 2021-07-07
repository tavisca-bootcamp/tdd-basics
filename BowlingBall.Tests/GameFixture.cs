using System;
using Xunit;

namespace BowlingBall.Tests
{
    public class GameFixture
    {
        [Fact]
        public void AllStrike()
        {
            var g=new Game();
            var result=g.Roll(new[]{10,10,10,10,10,10,10,10,10,10,10,10});
            Assert.Equal(300,result);
        }

        [Fact]
        public void AllSpare()
        {
            var g=new Game();
            var result=g.Roll(new[]{5,5,5,5,5,5,5,5,5,5,5,5,5,5,5,5,5,5,5,5,5});
            Assert.Equal(150,result);
        }

        [Fact]
        public void NoScore()
        {
            var g=new Game();
            var result=g.Roll(new[]{0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0});
            Assert.Equal(0,result);
        }

        [Fact]
        public void NoSpareNoStrike()
        {
            var g=new Game();
            var result=g.Roll(new[]{3,2,3,2,3,2,4,3,4,3,4,3,2,1,2,1,2,1,4,5});
            Assert.Equal(54,result);
        }

        [Fact]
        public void OnlySpareNoStrike()
        {
            var g=new Game();
            var result=g.Roll(new[]{3,2,5,5,3,2,5,5,3,2,5,5,3,2,5,5,3,2,5,5,6});
            Assert.Equal(93,result);
        }

        [Fact]
        public void NoSpareOnlyStrike()
        {
            var g=new Game();
            var result=g.Roll(new[]{3,2,10,3,2,10,3,2,10,3,2,10,3,2,10,3,2});
            Assert.Equal(100,result);
        }

        [Fact]
        public void LastFrameAllStrike()
        {
            var g=new Game();
            var result=g.Roll(new[]{3,2,10,3,2,10,3,2,10,3,2,10,3,2,10,10,10});
            Assert.Equal(115,result);
        }

        [Fact]
        public void RandomSpareRandomStrike()
        {
            var g=new Game();
            var result=g.Roll(new[]{10,9,1,5,5,7,2,10,10,10,9,0,8,2,9,1,10});
            Assert.Equal(187,result);
        }

        [Fact]
        public void InputOutOfRange()   //extra frame
        {
            var g=new Game();
            Assert.Throws<IndexOutOfRangeException>(() => g.Roll(new[]{10,9,1,5,5,7,2,10,10,10,9,0,8,2,9,1,10,2,3}));
        }

        [Fact]
        public void InputInOfRange()   //less frame
        {
            var g=new Game();
            Assert.Throws<ArgumentException>(() => g.Roll(new[]{10,9,1,5,5,9,1,10,2,3}));
        }

        [Fact]
        public void WrongInput()   //max limit of pin is 10
        {
            var g=new Game();
            Assert.Throws<ArgumentOutOfRangeException>(() => g.Roll(new[]{10,10,10,12,10,10,10,10,10,10,10,10}));
        }

        [Fact]
        public void MaxStrike()   //max Strike Can Be 12
        {
            var g=new Game();
            Assert.Throws<ArgumentOutOfRangeException>(() => g.Roll(new[]{10,10,10,10,10,10,10,10,10,10,10,10,10}));
        }
    }
}
