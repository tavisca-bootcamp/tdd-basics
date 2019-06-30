using Xunit;

namespace BowlingBall.Tests
{
    public class GameFixture
    {
        Game game = new Game();

        [Fact]
        public void RollGame()
        {
            RollMany(20, 0);
            Assert.Equal(0, game.GetScore());
        }

        [Fact]
        public void RollOnes()
        {
            RollMany(20, 1);
            Assert.Equal(20, game.GetScore());
        }

        void RollMany(int rolls, int pins)
        {
            for (int i = 0; i < rolls; i++)
                game.Roll(pins);
        }

        [Fact]
        public void RollSpareFirstFrame()
        {
            game.Roll(9);
            game.Roll(1);
            RollMany(18, 1);

            Assert.Equal(29, game.GetScore());
        }

        [Fact]
        public void RollSparesEveryFrame()
        {
            RollMany(21, 5);

            Assert.Equal(150, game.GetScore());
        }

        [Fact]
        public void RollNineOnesSpares()
        {
            for (int i = 0; i < 10; i++)
            {
                game.Roll(9);
                game.Roll(1);
            }
            game.Roll(9);

            Assert.Equal(190, game.GetScore());
        }

        [Fact]
        public void RollPerfectGame()
        {
            RollMany(12, 10);

            Assert.Equal(300, game.GetScore());
        }

        [Fact]
        public void TypicalGame()
        {
            game.Roll(10);
            game.Roll(9); game.Roll(1);
            game.Roll(5); game.Roll(5);
            game.Roll(7); game.Roll(2);
            game.Roll(10);
            game.Roll(10);
            game.Roll(10);
            game.Roll(9); game.Roll(0);
            game.Roll(8); game.Roll(2);
            game.Roll(9); game.Roll(1); game.Roll(10);

            Assert.Equal(187, game.GetScore());
        }

    }
}
