using Xunit;

namespace BowlingBall.Tests
{
    public class GameFixture
    {
        Game game = new Game();

        private void RollMany(int n, int pins)
        {
            for (var i = 0; i < n; i++)
                game.Roll(pins);
        }

        private void RollMany(int[] arr)
        {
            for (var i = 0; i < arr.Length; i++)
                game.Roll(arr[i]);
        }


        [Fact]
        public void TestZeroRoll()
        {
            var n = 20;
            var pins = 0;
            RollMany(n, pins);
            Assert.Equal(0, game.GetScore());
        }

        [Fact]
        public void TestAllOnes()
        {
            RollMany(20, 1);
            Assert.Equal(20, game.GetScore());
        }

        [Fact]
        public void TestOneSpare()
        {
            game.Roll(6);
            game.Roll(4);
            game.Roll(3);
            RollMany(17, 3);
            Assert.Equal(67, game.GetScore());
        }

        [Fact]
        public void TestOneStrike()
        {
            game.Roll(10);
            game.Roll(3);
            RollMany(17, 3);
            Assert.Equal(70, game.GetScore());
        }

        [Fact]
        public void TestAllStrike()
        {
            RollMany(10, 10);
            game.Roll(10);
            game.Roll(10);
            Assert.Equal(300, game.GetScore());
        }

        [Fact]
        public void TestAllSpare()
        {
            RollMany(new int[] { 6,4,6,4, 6, 4, 6, 4 , 6, 4, 6, 4 , 6, 4, 6, 4 , 6, 4, 6, 4 });
            game.Roll(6);
            Assert.Equal(160, game.GetScore());
        }

        [Fact]
        public void TestWithNoSpareAndStrike()
        {
            RollMany(10, 4);
            RollMany(10, 3);
            Assert.Equal(70, game.GetScore());
        }
    }
}
