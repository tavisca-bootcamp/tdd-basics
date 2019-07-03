using System;
using Xunit;

namespace BowlingBall.Tests
{
    public class GameFixture
    {
        private Game game=new Game();
        public void RollMany(int nRolls,int pins)
        {
            for (int i = 0; i < nRolls; i++)
            {
                game.Roll(pins);
            }
        }

        //test when no pins is knocked
        [Fact]
        public void RollGutterGame()
        {
           
            RollMany(20, 0);

            Assert.Equal(game.GetScore(), 0);
        }

        
        //test when first frame is spare and on every attempt case one pin is knocked
        [Fact]
        public void RollSpareFirstFrame()
        {
            game.Roll(9);
            game.Roll(1);
            RollMany(18,1);

            Assert.Equal(game.GetScore(),29);
        }

        [Fact]

        //test when in every attempt only one pin is knocked
        public void RollOnes()
        {
            
            RollMany(20, 1);

            Assert.Equal(game.GetScore(), 20);
        }


        //test when spare occur on every frame
        [Fact]
        public void RollSpareEveryFrame()
        {

            RollMany(21, 5);

            Assert.Equal(game.GetScore(), 150);
        }

        //test when strike occurs on every attempt
        [Fact]
        public void RollPerfectGame()
        {

            RollMany(12, 10);
            Assert.Equal(game.GetScore(), 300);
        }

        //test when every frame has 9 pins knocked in first attempt and 1 pin knocked at second attempt
        //i.e on every frame spare occur
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

