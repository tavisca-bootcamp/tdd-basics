using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace BowlingBall.Tests
{
    
    public class GameFixture
    {
        public GameFixture()
        {
           game = new Game();
        }
        private Game game;
        public const int MAX_ROLLS = 21;


        [Fact]
        public void RollAllZeros()
        {
            //Arrange            
            int expected = 0;

            //act
            RollMany(20, 0);
            int actual = game.GetScore();

            //assert
            Assert.Equal(expected, actual);
        }


        [Fact]
        public void RollAllOnes()
        {
            int expected = 20;

            RollMany(20, 1);
            int actual = game.GetScore();

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void RollOneSpare()
        {
            int expected = 10+2+2 + 17;   

            game.Roll(7); game.Roll(3); game.Roll(2); RollMany(17, 1);
            int actual = game.GetScore();

            Assert.Equal(expected, actual);

        }

        [Fact]
        public void RollOneStrike()
        {
            int expected = 10 + 4 + 5 + 4 +5 + 0;

            game.Roll(10); game.Roll(4); game.Roll(5); RollMany(17, 0);
            int actual = game.GetScore();

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void RollAllStrikes()
        {
            int expected = 300;

            RollMany(12, 10);
            int actual = game.GetScore();

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void RollRandomScore()
        {
            int expected = 164;

            int[] pins_drops = { 7, 3, 10, 10, 8, 1, 9, 1, 8, 1, 10, 9, 1, 8, 2, 6, 1 };
            foreach (int pins in pins_drops)
                game.Roll(pins);
            int actual = game.GetScore();

            Assert.Equal(expected, actual);
        }


        private void RollMany(int n, int pins)
        {
            for (int i = 0; i < n; i++)
            {
                game.Roll(pins);
            }
        }

    }
}

