using System;
using System.Collections.Generic;
using System.Text;
using Xunit;


namespace BowlingBall.Tests
{
    public class GameFixturesNegativeTests
    {
        [Theory]
        [InlineData(new int[] { 7, 4, 4, 2, 4, 6, 3, 1, 5, 4, 2, 7, 4, 3, 4, 5, 6, 4, 3, 7, 5 })]
        public void GetScores_InvalidSumForFrame(int[] inputPins)
        {
            Game game = new Game();
            
            Assert.Throws<InvalidOperationException>(() =>
            {
                for (int i = 0; i < inputPins.Length; i++)
                {
                    game.Roll(inputPins[i]);
                }
            });
        }
    }
}
