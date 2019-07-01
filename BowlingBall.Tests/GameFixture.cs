using System;
using Xunit;

namespace BowlingBall.Tests
{
 public class GameFixture
    {
        
        [Fact]
        public void AllStrike()
        {
            var expected = 300;
            var game = new Game();
            int[] a = new[] { 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10 };
            game.Test = a;

            int result = game.Roll(game.Test);

            Assert.Equal(expected, result);
        }

        [Fact]
        public void AllSpare()
        {
            var expected = 150;
            var game = new Game();
            int[] a = new[] { 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5 };
            game.Test = a;

            int result = game.Roll(game.Test);

            Assert.Equal(expected, result);
        }

        [Fact]
        public void NoScore()
        {
            var expected = 0;
            var game = new Game();
            int[] a = new[] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
            game.Test = a;

            int result = game.Roll(game.Test);

            Assert.Equal(expected, result);
        }

        [Fact]
        public void NoSpareNoStrike()
        {
            var expected = 54;
            var game = new Game();
            int[] a = { 3, 2, 3, 2, 3, 2, 4, 3, 4, 3, 4, 3, 2, 1, 2, 1, 2, 1, 4, 5 };
            game.Test = a;

            int result = game.Roll(game.Test);

            Assert.Equal(expected, result);
        }

        [Fact]
        public void OnlySpareNoStrike()
        {
            var expected = 93;
            var game = new Game();
            int[] a = new[] { 3, 2, 5, 5, 3, 2, 5, 5, 3, 2, 5, 5, 3, 2, 5, 5, 3, 2, 5, 5, 6 };
            game.Test = a;

            int result = game.Roll(game.Test);

            Assert.Equal(expected, result);
        }

        [Fact]
        public void NoSpareOnlyStrike()
        {
            var expected = 100;
            var game = new Game();
            int[] a = new[] { 3, 2, 10, 3, 2, 10, 3, 2, 10, 3, 2, 10, 3, 2, 10, 3, 2 };
            game.Test = a;

            int result = game.Roll(game.Test);

            Assert.Equal(expected, result);
        }

        [Fact]
        public void LastFrameAllStrike()
        {
            var expected = 115;
            var game = new Game();
            int[] a = new[] { 3, 2, 10, 3, 2, 10, 3, 2, 10, 3, 2, 10, 3, 2, 10, 10, 10 };
            game.Test = a;

            int result = game.Roll(game.Test);

            Assert.Equal(expected, result);
        }

        [Fact]
        public void RandomSpareRandomStrike()
        {
            var expected = 187;
            var game = new Game();
            int[] a = new[] { 10, 9, 1, 5, 5, 7, 2, 10, 10, 10, 9, 0, 8, 2, 9, 1, 10 };
            game.Test = a;

            int result = game.Roll(game.Test);

            Assert.Equal(expected, result);
        }

        [Fact]
        public void InputOutOfRange()   //extra frame
        {
            var g = new Game();
            Assert.Throws<IndexOutOfRangeException>(() => g.Roll(new[] { 10, 9, 1, 5, 5, 7, 2, 10, 10, 10, 9, 0, 8, 2, 9, 1, 10, 2, 3 }));
        }

        [Fact]
        public void InputInOfRange()   //less frame
        {
            var g = new Game();
            Assert.Throws<ArgumentException>(() => g.Roll(new[] { 10, 9, 1, 5, 5, 9, 1, 10, 2, 3 }));
        }

        [Fact]
        public void WrongInput()   //max limit of pin is 10
        {
            var g = new Game();
            Assert.Throws<ArgumentOutOfRangeException>(() => g.Roll(new[] { 10, 10, 10, 12, 10, 10, 10, 10, 10, 10, 10, 10 }));
        }
    }

}
