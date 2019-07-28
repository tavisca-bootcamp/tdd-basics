using System;
using System.Collections.Generic;
using Xunit;

namespace BowlingBall.Tests
{
    public class GameFixture
    {
        [Fact]
        public void Score_when_NeitherSpareNorStrike_ocurs_()
        {
            //Given
            List<int> Frame = new List<int>() { 7, 2 };
            var _Score = new Score(Frame);
            //when
            var TotalScore = _Score.GetTotalScore(7);
            //then
            Assert.Equal(9, TotalScore);
        }

        [Fact]
        public void Score_when_Spare_ocurs_()
        {
            //Given
            List<int> Frame = new List<int>() { 9, 1, 5 };
            var _Score = new Score(Frame);
            //when
            var TotalScore = _Score.GetTotalScore(9);
            //then
            Assert.Equal(15, TotalScore);
        }
        [Fact]
        public void Score_when_RepeatedStrike_ocurs()
        {
            //Given
            List<int> Frame = new List<int>() { 10, 10,10};
            var _Score = new Score(Frame);
            //when
            var TotalScore = _Score.GetTotalScore(10);
            //then
            Assert.Equal(30, TotalScore);
        }

        [Fact]
        public void Score_when_Strike_ocurs()
        {
            //Given
            List<int> Frame = new List<int>() {10,9,1,5,5};
            var _Score = new Score(Frame);
            //when
            var TotalScore=_Score.GetTotalScore(10);
            //then
            Assert.Equal(20,TotalScore);
        }

    }
}
