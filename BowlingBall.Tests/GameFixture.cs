using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
namespace BowlingBall.Tests
{
    public class GameFixture
    {
        private Game NewGame;
        public GameFixture()
        {
            NewGame = new Game();
        }
        [Fact]
        public void RollWithPinsMoreThan10()
        {
            //roll cannot be more than 10 or negative
            try
            {
                NewGame.Roll(11);
            }
            catch(Exception E)
            {
                //throws Exception
                return;
            }
            Assert.True(false);
        }
        [Fact]
        public void RollWithPinsLessThan0()
        {
            //roll cannot be more than 10 or negative
            try
            {
                NewGame.Roll(-2);
            }
            catch (Exception E)
            {
                //throws Exception
                return;
            }
            Assert.True(false);
        }
        [Fact]
        public void RollWithvalidPins()
        {
            //roll cannot be more than 10 or negative
            try
            {
                NewGame.Roll(2);
            }
            catch (Exception E)
            {
                //should not throw exception
                Assert.True(false);
            }
            Assert.True(true);
        }
    }
}
