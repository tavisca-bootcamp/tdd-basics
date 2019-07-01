using System;
using Xunit;

namespace BowlingBall.Tests
{
    public class GameFixture
    {
        
       private Game game;
       public GameFixture(){
           game=new Game();
       }


        [Fact]
        public void DummyTest()
        {
            // This is a dummy test that will always pass.
        }
        [Fact]
		public void testAllZeros()
		{
			rollRestOfAll(20,0);
			int expected = 0;
			int actual = game.GetScore();
			Assert.Equal(expected, actual);
		}

		[Fact]
		public void testAllOnes()
		{
			rollRestOfAll(20, 1);
			int expected = 20;
			int actual = game.GetScore();
			Assert.Equal(expected, actual);
		}

		[Fact]
		public void testPerfectShots()
		{
			rollRestOfAll(12, 10);
			int expected = 300;
			int actual = game.GetScore();
			Assert.Equal(expected, actual);
		}

         [Fact]
        public void testOneSpare() {
            game.Roll(5);
            game.Roll(5); // spare
            game.Roll(3);
           rollRestOfAll(17,0);
            int expected = 16;
			int actual = game.GetScore();
           Assert.Equal(expected, actual);
       }

        [Fact]
		public void testSpare()
		{   
            rollSpare();
            game.Roll(7);
			rollRestOfAll(17, 0);
			int expected = 24;
			int actual = game.GetScore();
			Assert.Equal(expected, actual);
		}
    
		[Fact]
		public void testStrike()
		{
			rollStrike();
			game.Roll(2);
            game.Roll(3);
			rollRestOfAll(17, 0);
			int expected = 20;
			int actual = game.GetScore();
			Assert.Equal(expected, actual);
		}

         [Fact]
		public void testGivenExampleImage()
		{
			rollStrike();
			game.Roll(9);
            game.Roll(1);
            rollSpare();
            game.Roll(7);
            game.Roll(2);
            rollStrike();
            rollStrike();
            rollStrike();
            game.Roll(9);
            game.Roll(0);
            game.Roll(8);
            game.Roll(2);
            game.Roll(9);
			game.Roll(1);
            rollStrike();
			int expected = 187;
			int actual = game.GetScore();
			Assert.Equal(expected, actual);
		}

        [Fact]
		public void testRandomnShots()
		{
			game.Roll(8);
            game.Roll(1);
            game.Roll(3);
            rollStrike();
			rollRestOfAll(16, 0);
			int expected = 22;
			int actual = game.GetScore();
			Assert.Equal(expected, actual);
		}
        private void rollStrike() {
              game.Roll(10);
        }

        private void rollSpare() {
             game.Roll(5);
             game.Roll(5);
       }
        private void rollRestOfAll(int numberOfRolls, int pins)
		{
			for (int i = 0; i < numberOfRolls; i++)
			{
				game.Roll(pins);
			}
		}

    }
}
