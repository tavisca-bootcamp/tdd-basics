using System;

namespace BowlingBall
{
    public class Game
    {
        int[] roll = new int[21];
        int rollIndex = 0;

        public void Roll(int pins) 
        {
            if(pins < 0 || pins > 10)
                throw new ArgumentOutOfRangeException();
            if(rollIndex < 20){
                roll[rollIndex] = pins;
                rollIndex++;
            }
            else if(roll[18] == 10 && rollIndex < 21){
                roll[rollIndex] = pins;
                rollIndex++;
            }
            else{
                Console.WriteLine("Game Over You cannot Roll More");
            }
        }

        public int GetScore()
        {
            int score = 0;
            int rollingIndex = 0;

            for( int i = 0; i < 10; i++){
                
                if(isStrike(rollingIndex)){
                    score += 10 + roll[rollingIndex + 1] + roll[rollingIndex + 2];
                    rollingIndex += 1;
                }
                else if(isSpare(rollingIndex)){
                    score += 10 + roll[rollingIndex + 2];
                    rollingIndex += 2;
                }
                else{
                    score += roll[rollingIndex] + roll[rollingIndex + 1];
                    rollingIndex += 2; 
                }
            }

            return score;
        }

        public bool isSpare(int index){
            return roll[index] + roll[index + 1] == 10;
        }

        public bool isStrike(int index){
            return roll[index] == 10;
        }

    }
}

