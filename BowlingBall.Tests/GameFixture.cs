using System;
using Xunit;
using System.Collections.Generic;

namespace BowlingBall.Tests
    {
        public class GameFixture
        {
            [Fact]
            public void AllZeroesTest()
            {
                Game game = createObjectOfGame();
                RollPins(game, 20, 0);
                Assert.Equal(0, game.GetScore());
            }

            [Fact]
            public void AllOnesTest()
            {
                Game game = createObjectOfGame();
                RollPins(game, 20, 1);
                Assert.Equal(20, game.GetScore());
            }

            [Fact]
            public void OneSpareTest()
            {
                Game game = createObjectOfGame();
                RollSpare(game);
                game.Roll(3);
                RollPins(game, 17, 0);
                Assert.Equal(16, game.GetScore());
            }

            [Fact]
            public void OneStrikeTest()
            {
                Game game = createObjectOfGame();
                RollStrike(game);
                game.Roll(3);
                game.Roll(4);
                RollPins(game, 16, 0);
                Assert.Equal(24, game.GetScore());
            }

            [Fact]
            public void PerfectGameTest()
            {
                Game game = createObjectOfGame();
                RollPins(game, 12, 10);
                Assert.Equal(300, game.GetScore());
            }

            #region PRIVATE METHODS
            private Game createObjectOfGame()
            {
                return new Game();
            }
            private void RollPins(Game game, int noOfRolls, int noOfPinsPerRoll)
            {
                //throw new NotImplementedException();
                for (var i = 0; i < noOfRolls; i++)
                {
                    game.Roll(noOfPinsPerRoll);
                }
            }

            private void RollSpare(Game game)
            {
                game.Roll(5);
                game.Roll(5);
            }

            private void RollStrike(Game game)
            {
                game.Roll(10);
            }

            #endregion

        }
    }