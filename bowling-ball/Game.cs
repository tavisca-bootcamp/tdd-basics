﻿using System;

namespace BowlingBall
{
    public class Game
    {
        public int[] numberOfRolls = new int[21];
        int pinIndex = 0;
        private int score = 0;
        private int[] frames = new int[10];

        public void Roll(int pins)
        {
             this.numberOfRolls[pinIndex++] = pins;
        }

        public int GetScore()
        {
            pinIndex = 0;
            for(int frameIndex=0 ; frameIndex < frames.Length; frameIndex++)
            {
                
                if((numberOfRolls[pinIndex] + numberOfRolls[pinIndex+1]) >=0 && (numberOfRolls[pinIndex] + numberOfRolls[pinIndex+1]) < 10)
                {
                    score  = score + NoSpareNoStrike(pinIndex);
                    pinIndex = pinIndex +2;
                }
                else if(numberOfRolls[pinIndex] == 10)
                {
                    score = score + Strike(pinIndex);
                    pinIndex = pinIndex + 1;
                }
                else if((numberOfRolls[pinIndex] + numberOfRolls[pinIndex + 1] )== 10)
                {
                    score = score + Spare(pinIndex);
                     pinIndex = pinIndex + 2;
                }
                   frames[frameIndex] = score;
            }
            return score;
        }

        private int Strike(int pinIndex)
        {
             return numberOfRolls[pinIndex] +  numberOfRolls[pinIndex+1] + numberOfRolls[pinIndex+2];
        }

        private int Spare(int pinIndex)
        {
           return  numberOfRolls[pinIndex] + numberOfRolls[pinIndex+1] + numberOfRolls[pinIndex+2];
        }
         
        private int NoSpareNoStrike(int pinIndex)
        {
            return numberOfRolls[pinIndex] + numberOfRolls[pinIndex+1];  
        }
    }
}