using System;
using System.Collections.Generic;

namespace BowlingBall
{
    public class Game
    {
        private List <int> rolls;
        private int rollno=0;
        private const int MAXROLLs = 21;
        private const int MAXFRAMES = 10;

        public Game(){
            rolls = new List<int>();
        }

        public void Roll(int pins)
        {
            if(rollno < MAXROLLs){
                rolls.Add(pins);
                rollno++;
            }
        }

        public int GetScore()
        {
            int score = 0;
            int current=0;
            for(var frames=1; frames <= MAXFRAMES; frames++){
                if(IsStrike(current)){
                    score += GetScoreByRoll(current) + Bonus(current);
                    current++;
                }
                else if(IsSpare(current)){
                    score += GetScoreByRoll(current) + Bonus(current);
                    current+=2;
                }
                else{   
                    score += GetScoreByRoll(current++);
                    score += GetScoreByRoll(current++);
                }
            }

            return score;
        }

        private bool IsStrike(int current){
            return rolls[current]==10;
        }

        private bool IsSpare(int current){
            return rolls[current] + rolls[current+1] == 10;
        }

        private int Bonus(int current){
            return rolls[current+1] + rolls[current+2];
        }

        private int GetScoreByRoll(int current){
            return rolls[current];
        }
    }
}


