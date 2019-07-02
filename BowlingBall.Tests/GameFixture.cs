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
	

    	[Fact]
		public void SpareExceptLastFrameTest()
		{
		  _game =  new Game();
		  _game.Roll(5);
		  _game.Roll(5);
		   RollAutomatically(18,2);
		   int expectedValue = 48;
		   int score = _game.GetScore();
		   Assert.Equal(expectedValue,score);
		}
	

    	[Fact]
		public void StrikeExceptLastFrameTest()
		{
		  _game = new Game();
		  _game.Roll(10);
		   RollAutomatically(18,2);
		   int expectedValue = 50;
		   int score = _game.GetScore();
		   Assert.Equal(expectedValue,score);
		}
	  

    	  [Fact]
		public void SpareStrikeExceptLastFrame()
		{
			 _game = new Game();
			 _game.Roll(5);
			 _game.Roll(5);
			 _game.Roll(10);
			  RollAutomatically(16,2);
			  int expectedValue = 66;
		      int score = _game.GetScore();
		      Assert.Equal(expectedValue,score);
		}
	

	   [Fact]
		public void SpareAnyFrameTest()
		{
			_game = new Game();
		     RollAutomatically(18,2);
			_game.Roll(5);
			_game.Roll(5);
			_game.Roll(5);
			 int expectedValue = 51;
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
