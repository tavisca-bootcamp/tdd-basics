using System;
using Xunit;

namespace BowlingBall.Tests
{
    public class GameFixture
    {
        Game g = new Game();
        private void Input(int[] PinsFallDownInEachRoll)
        {
            foreach(var pins in PinsFallDownInEachRoll)
            {
                g.Roll(pins);
            }
        }

        [Fact]
        public void PinsWithNoSpareNoStrikeNoExtraBallInLastFrame()
        { 
            int[] PinsFallDownInEachRoll = {4,1,8,1,2,6,0,9,5,2,3,2,1,4,2,3,4,3,6,2};
            int finalScoreFromCall;

            Input(PinsFallDownInEachRoll);
            finalScoreFromCall = g.GetScore();

            Assert.Equal(68,finalScoreFromCall);
        }

        [Fact]
        public void PinsWithOneSpare()
        {
            int[] PinsFallDownInEachRoll = {5,2,4,3,5,5,3,5,7,2,5,0,9,0,2,6,3,6,4,5};
            int finalScoreFromCall;

            Input(PinsFallDownInEachRoll);
            finalScoreFromCall = g.GetScore();
            
            Assert.Equal(84,finalScoreFromCall);
        }

        [Fact]
        public void PinsWithOneStrike()
        {
            int[] PinsFallDownInEachRoll = {6,1,3,5,10,6,2,4,5,2,0,7,1,3,4,7,1,1,1};
            int finalScoreFromCall;

            Input(PinsFallDownInEachRoll);
            finalScoreFromCall = g.GetScore();
            
            Assert.Equal(77,finalScoreFromCall);
        }
        
        [Fact]
        public void FirstFrameWithZeroRollDown()
        {
            int[] PinsFallDownInEachRoll = {0,0,2,5,8,1,1,6,4,1,4,0,2,5,7,2,3,5,3,6};
            int finalScoreFromCall;

            Input(PinsFallDownInEachRoll);
            finalScoreFromCall = g.GetScore();
            
            Assert.Equal(65,finalScoreFromCall);

        }

       [Fact]
        public void TwoSpareConsecutive()
        {
            int[] PinsFallDownInEachRoll = {4,5,7,3,5,5,7,0,2,6,2,6,5,2,3,4,1,1,2,1};
            int finalScoreFromCall;

            Input(PinsFallDownInEachRoll);
            finalScoreFromCall = g.GetScore();
            
            Assert.Equal(83,finalScoreFromCall);

        }

        [Fact]
        public void ThreeStrikeConsecutive()
        {
            int[] PinsFallDownInEachRoll = {10,10,10,3,6,2,4,6,2,1,3,0,0,3,1,5,4};
            int finalScoreFromCall;
            
            Input(PinsFallDownInEachRoll);
            finalScoreFromCall = g.GetScore();
            
            Assert.Equal(112,finalScoreFromCall);

        }
        
        [Fact]
        public void LastFrameWithSpare()
        {
            int[] PinsFallDownInEachRoll = {4,5,2,4,1,7,6,3,2,5,10,10,3,6,0,0,6,4,1};
            int finalScoreFromCall;
            
            Input(PinsFallDownInEachRoll);
            finalScoreFromCall = g.GetScore();
            
            Assert.Equal(101,finalScoreFromCall);

        }

        [Fact]
        public void ThreeStrikeInLastFrame()
        {
            int[] PinsFallDownInEachRoll = {4,5,2,4,1,7,6,3,2,5,10,10,6,0,0,0,10,10,10};
            int finalScoreFromCall;
            
            Input(PinsFallDownInEachRoll);
            finalScoreFromCall = g.GetScore();
            
            Assert.Equal(117,finalScoreFromCall);

        }

        [Fact]
        public void TotalPinsInOneFrameNotInRange()
        {
            int[] PinsFallDownInEachRoll = {-1,7,2,4,1,7,6,3,2,5,10,10,6,0,0,0,10,10,10};
            int finalScoreFromCall;
            bool checkPinsInRange = false;

            foreach(var pins in PinsFallDownInEachRoll)
            {
                if(pins >=0 && pins <=10)
                {
                   checkPinsInRange=true;
                }
                else
                {
                    checkPinsInRange = false;
                    Assert.NotInRange(pins,0,10);
                    break;
                }
            }

            Input(PinsFallDownInEachRoll);
            finalScoreFromCall = g.GetScore();

            if(checkPinsInRange == true)
            {
                Assert.Equal(117,finalScoreFromCall);
            }  
        }
    }
}