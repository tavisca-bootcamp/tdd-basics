using System;
using Xunit;

namespace BowlingBall.Tests
{
    public class GameFixture
    {
        private Game game=new Game();

        public void Gamefixture()
        {
            game =new Game();
        }

        public void RollMany(int nRolls,int pins)
        {
            for (int i = 0; i < nRolls; i++)
            {
                game.Roll(pins);
            }
        }

        [Fact]
        public void RollGutterGame()
        {
           
            RollMany(20, 0);

            Assert.Equal(game.GetScore(), 0);
        }

        [Fact]
        public void RollSpareFirstFrame()
        {
            game.Roll(9);
            game.Roll(1);
            RollMany(18,1);

            Assert.Equal(game.GetScore(),29);
        }

        [Fact]
        public void RollOnes()
        {
            
            RollMany(20, 1);

            Assert.Equal(game.GetScore(), 20);
        }

        [Fact]
        public void RollSpareEveryFrame()
        {

            RollMany(21, 5);

            Assert.Equal(game.GetScore(), 150);
        }

        [Fact]
        public void RollPerfectGame()
        {

            RollMany(12, 10);

            Assert.Equal(game.GetScore(), 300);
        }

        [Fact]
        public void RollNineOeSpares()
        {

            for (int i=0;i<10;i++)
            {
                game.Roll(9);
                game.Roll(1);
            }
            game.Roll(9);

            Assert.Equal(game.GetScore(), 190);
        }
    }
}
