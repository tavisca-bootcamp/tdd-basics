using System;
using Xunit;

namespace BowlingBall.Tests
{
    public class GameFixture
    {
       
        public Game g; 
        //game obj is created to access its method for testing
        public GameFixture()
        {
            g = new Game(); 
            //to assign memory to the obj
        }

        //for number of pins in each ballRoll
        
        public void rollMany(int rolls, int pins)
        {
            for (int i = 0; i < rolls; i++){
                g.Roll(pins);
            }
        }
        [Fact]
        public void rollSpare()
        {
            g.Roll(5); //to make score of 10 for spare
            g.Roll(5);
        }

        [Fact]
        public void TestBowling()
        {
            Assert.IsType<Game>(g);
        }

        [Fact]
        public void TestGutterGame()
        {
            rollMany(20, 0);//zero score in 20 balls
            Assert.Equal(0, g.Score());
        }

        [Fact]
        public void TestAllOnes()
        {
            rollMany(20, 1); //one score in all 20 balls
            Assert.Equal(20, g.Score());
        }

        [Fact]
        public void TestOneSpare()
        {
            rollSpare();
            g.Roll(4);
            rollMany(17, 0);
            Assert.Equal(18, g.Score());
        }

        [Fact]
        public void TestOneStrike()
        {
            g.Roll(10);
            g.Roll(4);
            g.Roll(5);
            rollMany(17, 0);
            Assert.Equal(28, g.Score());
        }

        [Fact]
        public void TestPerfectGame()
        {
            rollMany(12, 10);
            Assert.Equal(300, g.Score());
        }

	[Fact]
        public void RandomGameWithThreeStrikesAtEnd()
        {
            g.Roll(new int[] { 1, 3, 7, 3, 10, 1, 7, 5, 2, 5, 3, 8, 2, 8, 2, 10, 10, 10, 10 });
            Assert.Equal(163, g.Score());
        }

        [Fact]
        public void RandomGameNoExtraRoll()
        {
            g.Roll(new int[] { 1, 3, 7, 3, 10, 1, 7, 5, 2, 5, 3, 8, 2, 8, 2, 10, 9, 0 });
            Assert.Equal(131, g.Score());
        }

        [Fact]
        public void RandomGameWithSpareThenStrikeAtEnd()
        {
            g.Roll(new int[] { 1, 3, 7, 3, 10, 1, 7, 5, 2, 5, 3, 8, 2, 8, 2, 10, 9, 1, 10 });
            Assert.Equal(143, g.Score());
        }

	[Fact]
        public void RandomGameWithSpareThenStrikeAtEnd()
        {
            g.Roll(new int[] { 10, 10, 10, 10, 10, 10, 9, 1, 10, 10, 10 });
            Assert.Equal(219, g.Score());
        }
    }
}