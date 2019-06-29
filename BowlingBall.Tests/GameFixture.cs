using System;
using Xunit;

namespace BowlingBall.Tests
{
    public class GameFixture
    {
        private Game game;
        
        //Writing the inilialization in the Constructor as there is no TestInilializer

        //First fail both the methods in the Game class
        
        public GameFixture(){
            game = new Game();  
        }

        [Fact]
        public void DummyTest()
        {
            // This is a dummy test that will always pass.
        }

        [Fact]
        public void DoesGameClassExists(){
            Assert.NotNull(this.game);
        }

        public void RollMany(int pins, int rolls){

            for(int i = 0; i < rolls; i++){
                this.game.Roll(pins);
            }
        }

        [Fact]

        public void canRollAllZerosGame(){
            
            RollMany(0,20);
            int expectedScore = 0;
            int actualScore = this.game.GetScore();
            Assert.Equal(expectedScore,actualScore);
        }

        [Fact]
        public void canRollAllTensGame(){
            RollMany(10,12);
            int expectedScore = 300;
            int actualScore = this.game.GetScore();
            Assert.Equal(expectedScore,actualScore);
        }

        [Fact]
        public void canRollSpare(){
            this.game.Roll(4);
            this.game.Roll(6);
            this.game.Roll(7);
            RollMany(0,17);
            int expectedScore = 24;
            int actualScore = this.game.GetScore();

            Assert.Equal(expectedScore,actualScore);
        }

        [Fact]
        public void canRollStrike(){
            this.game.Roll(10);
            this.game.Roll(7);
            this.game.Roll(2);
            RollMany(0,16);

            int expectedScore = 28;
            int actualScore = this.game.GetScore();

            Assert.Equal(expectedScore,actualScore);
        }

        [Fact]
        public void canRollAllOnes(){
            RollMany(1,20);
            int expectedScore = 20;
            int actualScore = this.game.GetScore();

            Assert.Equal(expectedScore,actualScore);
        }

        [Fact]
        public void canOnlyRollTwentyRolls(){
            //If there is not strike in the 10th Frame there will be only 20 rolls

            RollMany(4,21);
            int expectedScore = 80;
            int actualScore = this.game.GetScore();

            Assert.Equal(expectedScore,actualScore);
        }

        [Fact]
        public void canRollTwentyOneRolls(){
            //If there is a strike in the last Frame there can be 21 rolls

            RollMany(4,18);
            this.game.Roll(10);
            RollMany(4,2);

            int expectedScore = 90;
            int actualScore = this.game.GetScore();

            Assert.Equal(expectedScore,actualScore);
        }



    }
}
