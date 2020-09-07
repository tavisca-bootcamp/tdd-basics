using System;
using Xunit;

namespace BowlingBall.Tests
{
    public class GameFixture
    {
		private Game g;

		public GameFixture()
		{
			this.g = new Game();
		}

		private void IterateRollsWithSamePins(int numberOfRolls, int pins)
		{
			for (int i = 0; i < numberOfRolls; i++)
			{
				g.Roll(pins);
			}
		}

		private void RollStrike()
		{
			g.Roll(10);
		}
		private void RollSpare()
		{
			g.Roll(5);
			g.Roll(5);
		}

		[Fact]
        public void DummyTest()
        {
            // This is a dummy test that will always pass.
        }

		[Fact]
		public void AllZeroTest()
		{
			IterateRollsWithSamePins(20,0);
			int expectedResult = 0;
			int actualResult = g.GetScore();
			Assert.Equal(expectedResult, actualResult);
		}

		[Fact]
		public void AllOneTest()
		{
			IterateRollsWithSamePins(20, 1);
			int expectedResult = 20;
			int actualResult = g.GetScore();
			Assert.Equal(expectedResult, actualResult);
		}

		[Fact]
		public void PerfectGameTest()
		{
			IterateRollsWithSamePins(12, 10);
			int expectedResult = 300;
			int actualResult = g.GetScore();
			Assert.Equal(expectedResult, actualResult);
		}

		[Fact]
		public void StrikeTest()
		{
			RollStrike();
			g.Roll(4);
			g.Roll(3);
			IterateRollsWithSamePins(16, 0);
			int expectedResult = 24;
			int actualResult = g.GetScore();
			Assert.Equal(expectedResult, actualResult);
		}

		[Fact]
		public void SpareTest()
		{
			RollSpare();
			g.Roll(4);
			IterateRollsWithSamePins(17, 0);
			int expectedResult = 18;
			int actualResult = g.GetScore();
			Assert.Equal(expectedResult, actualResult);
		}

		[Fact]
		public void ExtraInputTest()
		{
			IterateRollsWithSamePins(21, 1);
			int expectedResult = 20;
			int actualResult = g.GetScore();
			Assert.Equal(expectedResult, actualResult);
		}

		[Fact]
		public void SpareStrikeTest()
		{
			RollStrike();
			g.Roll(4);
			g.Roll(3);
			RollSpare();
			g.Roll(4);
			IterateRollsWithSamePins(13, 0);
			int expectedResult = 42;
			int actualResult = g.GetScore();
			Assert.Equal(expectedResult, actualResult);
		}
	}
}
