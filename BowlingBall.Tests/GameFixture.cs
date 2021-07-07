using System;
using Xunit;

namespace BowlingBall.Tests
{
    public class GameFixture : IDisposable
    {

        private Game g;

        public GameFixture(){
          g = new Game();
        }

        public void Dispose(){
          g = null;
        }

        [Fact]
        public void RollTest()
        {
          g.Roll(0);
        }

        [Fact]
        public void TestScore(){
          RollMultiple(20, 1);
          Assert.Equal(20, g.GetScore());
        }

        [Fact]
        public void TestSpare(){
          Spare();
          g.Roll(2);

          RollMultiple(17, 0);
          Assert.Equal(14, g.GetScore());
        }

        [Fact]
        public void TestStrike(){
          Strike();
          g.Roll(3);
          g.Roll(4);
          RollMultiple(16, 0);
          Assert.Equal(24, g.GetScore());
        }

        private void Spare(){
          g.Roll(4);
          g.Roll(6);
        }

        private void Strike(){
          g.Roll(10);
        }

        private void RollMultiple(int turns, int pins){
          for(int i = 0; i < turns; i++){
            if(pins < 0 || pins > 10){
              InvalidPinsTest(pins);
              return;
            }
            g.Roll(pins);
          }
        }
        [Fact]
        public void TestAllCase1(){
         int[] input1 = {10, 9, 1, 5, 5, 7, 2, 10, 10,
                         10, 9, 0, 8, 2, 9, 1, 10
                        };
         foreach(int element in input1){
           if(element > 10 || element < 0) {
             InvalidPinsTest(element);
             return;
           }
           g.Roll(element);
         }
         Assert.Equal(187, g.GetScore());
        }
        
                [Fact]
        public void TestAllCase2(){
        
        int[] input2 = {1, 4, 4, 5, 6, 4, 5, 5, 10, 0,
                        1, 7, 3, 6, 4, 10, 2, 8, 6};
         foreach(int element in input2){
           if(element > 10 || element < 0) {
             InvalidPinsTest(element);
             return;
           }
           g.Roll(element);
         }
         Assert.Equal(133, g.GetScore());
        }

        [Fact]
        public void TestAllCase3(){
        
        int[] input3 = {10, 7, 3, 9, 0, 10, 0, 8, 8,
                       2, 0, 6, 10, 10, 10, 8, 1};

         foreach(int element in input3){
           if(element > 10 || element < 0) {
             InvalidPinsTest(element);
             return;
           }
           g.Roll(element);
         }
         Assert.Equal(167, g.GetScore());
        }
        private void InvalidPinsTest(int element)
        {
            Assert.NotInRange(element, 0, 10);
        }
    }
    
    }





