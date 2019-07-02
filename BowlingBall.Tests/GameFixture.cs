using System;
using Xunit;

namespace BowlingBall.Tests
{
    public class GameFixture
    {
		private int _game = null;
        [Fact]
        public void DummyTest()
        {
            // This is a dummy test that will always pass.
        }
		
		 [Fact]
	  	 public void GutterBallTest()
		{
		   _game = new Game(); 
		    for(int i=0;i<20;i++)
		        _game.Roll(0);
		    int score = _game.GetScore();
		    int ExpectedValue = 0;
		    Assert.Equal(ExpectedValue,score);
		}
    }
}
