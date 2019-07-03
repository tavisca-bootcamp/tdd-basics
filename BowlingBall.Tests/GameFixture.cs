using System;
using Xunit;
using System.Linq;
using Xunit.Abstractions;

namespace BowlingBall.Tests
{
    public class GameFixture
    {
        private readonly ITestOutputHelper _output;

        public GameFixture(ITestOutputHelper output)
        {
            _output = output;
        }

      
 

        [Theory]
        [MemberData("PlayData",MemberType =typeof(BowlingPinsInternalData))]
        public void PlayTest(int [] listPinsRolled)
        {

            //Arrange 
            Game sut;
            int actualValue;
            int expectedValue = 109;
            //Act
            sut = new Game();
            sut.Play(listPinsRolled);
            actualValue = sut.CalculateFinalScore();

            //Assert
            _output.WriteLine($"Actual score:{actualValue}");
            Assert.Equal(expectedValue,actualValue);

        }

        [Theory]
        [MemberData("PlayAllZerosData", MemberType = typeof(BowlingPinsInternalData))]
        public void TestPlayAllZeros(int[] listPinsRolled)
        {

            //Arrange
            Game sut;
            int actualValue;
            int expectedValue = 0;
            //Act
            sut = new Game();
            sut.Play(listPinsRolled);
            actualValue = sut.CalculateFinalScore();

            //Assert
            _output.WriteLine($"Actual score:{actualValue}");
            Assert.Equal(expectedValue, actualValue);

        }

        [Theory]
        [MemberData("PlayAllStrikesData", MemberType = typeof(BowlingPinsInternalData))]
        public void TestPlayAllStrikes(int[] listPinsRolled)
        {

            //Arrange
            Game sut;
            int actualValue;
            int expectedValue = 300;
            //Act
            sut = new Game();
            sut.Play(listPinsRolled);
            actualValue = sut.CalculateFinalScore();

            //Assert
            _output.WriteLine($"Actual score:{actualValue}");
            Assert.Equal(expectedValue, actualValue);

        }

        [Theory]
        [MemberData("PlayAllSparesData", MemberType = typeof(BowlingPinsInternalData))]
        public void TestPlayAllSpares(int[] listPinsRolled)
        {

            //Arrange
            Game sut;
            int actualValue;
            int expectedValue = 139;
            //Act
            sut = new Game();
            sut.Play(listPinsRolled);
            actualValue = sut.CalculateFinalScore();

            //Assert
            _output.WriteLine($"Actual score:{actualValue}");
            Assert.Equal(expectedValue, actualValue);

        }

        [Theory]
        [MemberData("PlayAllTenthFrameStrikeData", MemberType = typeof(BowlingPinsInternalData))]
        public void TestPlayAllTenthFrameStrike(int[] listPinsRolled)
        {

            //Arrange
            Game sut;
            int actualValue;
            int expectedValue = 30;
            //Act
            sut = new Game();
            sut.Play(listPinsRolled);
            actualValue = sut.CalculateFinalScore();

            //Assert
            _output.WriteLine($"Actual score:{actualValue}");
            Assert.Equal(expectedValue, actualValue);

        }

        [Theory]
        [MemberData("PlayAllTenthFrameSpareData", MemberType = typeof(BowlingPinsInternalData))]
        public void TestPlayAllTenthFrameSpare(int[] listPinsRolled)
        {

            //Arrange
            Game sut;
            int actualValue;
            int expectedValue = 20;
            //Act
            sut = new Game();
            sut.Play(listPinsRolled);
            actualValue = sut.CalculateFinalScore();

            //Assert
            _output.WriteLine($"Actual score:{actualValue}");
            Assert.Equal(expectedValue, actualValue);

        }


    }
}
