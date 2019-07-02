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
		    int expectedValue = 0;
		    Assert.Equal(expectedValue,score);
		}
		
		
		[Fact]
		public void NoSpareNoStrikeTest()
		{
			_game = new Game();
		 	 RollAutomatically(20,2);
			 int expectedValue = 40;
			 int score = _game.GetScore();
			 Assert.Equal(expectedValue,score);
		}
		
		
		
		
		
		private void RollAutomatically(int rollingCount,int pins)
            {
               for(int i=0;i<rollingCount;i++)
	               _game.Roll(pins);
            }
    
	}
}
