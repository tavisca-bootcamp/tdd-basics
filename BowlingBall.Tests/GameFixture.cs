using System;
using Xunit;

namespace BowlingBall.Tests
{
    public class GameFixture
    {
        [Fact]
        public void AllStrikeTest()
        {
            int expected = 300;
            Assert.Equal(CalculateScore("XXXXXXXXXXXX"), expected);
        }

        [Fact]
        public void AllEmptyRollTest()
        {
            int expected = 0;
            Assert.Equal(CalculateScore("--------------------"), expected);
        }
        

        [Fact]
        public void AllOneTest()
        {
            int expected = 20;
            Assert.Equal(CalculateScore("11111111111111111111"), expected);
        }

        [Fact]
        public void OneStrikeTest()
        {
            int expected = 10;
            Assert.Equal(CalculateScore("X------------------"), expected);
        }

        [Fact]
        public void OneSpareTest()
        {
            int expected = 10;
            Assert.Equal(CalculateScore("3/------------------"), expected);
        }

        [Fact]
        public void AllSpareTest()
        {
            int expected = 150;
            Assert.Equal(CalculateScore("5/5/5/5/5/5/5/5/5/5/5"), expected);
        }

        [Fact]
        public void MyTest()
        {
            int expected = 187;
            Assert.Equal(CalculateScore("X9/5/72XXX9-8/9/X"), expected);
        }
        
        private int CalculateScore(string rolls)
        {
            BowlingGame bg = new BowlingGame();
            int score = bg.CalculateScores(rolls);
            return score;
        }
    }
}
