using System;
using System.Collections.Generic;

namespace BowlingBall
{
    public class Game
    {
        bool extraFrame = false;
        int remainingPins = 0;
        int currentFrame = 1;
        bool secondShot = false;
        List<Frame> frame= new List<Frame>();
        public void Roll(int pins)
        {
            if(currentFrame < 10)
            {
                if(pins == 10){
                    currentFrame++;
                    frame.Add(new Frame(pins, false, true));
                }
                else if(pins < 10){
                    if(!secondShot){
                        secondShot = true;
                        remainingPins = 10 - pins;
                        frame.Add(new Frame(pins, false, false));
                    }
                    else{
                        secondShot = false;
                        if(pins == remainingPins){
                            frame[currentFrame - 1].SetRoll2(pins, true);
                            currentFrame++;
                        }
                        else if(pins < remainingPins){
                            frame[currentFrame - 1].SetRoll2(pins, false);
                            currentFrame++;
                        }
                        else{
                            throw new Exception ("Didn't had those many pins.");
                        }
                        remainingPins = 0;
                    }
                }
                else{
                    throw new Exception ("Didn't had those many pins.");
                }
            }
            else if(currentFrame == 10){
                if(secondShot){
                    secondShot = false;
                        if(pins == 10){
                            frame[9].SetRoll2(pins, true);
                            extraFrame = true;
                        }
                        else if(pins == remainingPins){
                            frame[9].SetRoll2(pins, true);
                            extraFrame = true;
                        }
                        else if(pins < remainingPins){
                            frame[9].SetRoll2(pins, false);
                            currentFrame++;
                        }
                        else{
                            throw new Exception ("Didn't had those many pins.");
                        }
                        remainingPins = 0;
                }
                else if(extraFrame){
                    currentFrame++;
                    if(pins == 10){
                        frame.Add(new Frame(pins, true, true));
                    }
                    else if(pins < 10){
                        frame.Add(new Frame(pins, true, false));
                    }
                    else{
                        throw new Exception ("Didn't had those many pins.");
                    }
                }
                else if(pins == 10){
                    secondShot = true;
                    frame.Add(new Frame(pins, true, true));
                    extraFrame = true;
                    secondShot = true;
                }
                else if(pins < 10){
                    if(!secondShot){
                        secondShot = true;
                        remainingPins = 10 - pins;
                        frame.Add(new Frame(pins, true, false));
                    }
                }
                else{
                    throw new Exception ("Didn't had those many pins.");
                }

            }
        }

        public int GetScore(){
            int score = 0;
            for(int frameIterator = 0; frameIterator < 8; frameIterator++){
                score += frame[frameIterator].GetRoll1() + frame[frameIterator].GetRoll2();
                if(frame[frameIterator].GetIsSpare()){
                    score += frame[frameIterator + 1].GetRoll1();
                }
                if(frame[frameIterator].GetIsStrike()){
                    if(frame[frameIterator + 1].GetIsStrike()){
                        score += frame[frameIterator + 1].GetRoll1() + frame[frameIterator + 2].GetRoll1();
                    }
                    else{
                        score += frame[frameIterator + 1].GetRoll1() + frame[frameIterator + 1].GetRoll2();
                    }
                }
            }
            score += frame[8].GetRoll1() + frame[8].GetRoll2();
                if(frame[8].GetIsSpare()){
                    score += frame[9].GetRoll1();
                }
                if(frame[8].GetIsStrike()){
                    score += frame[9].GetRoll1() + frame[9].GetRoll2();
                }
            
            score += frame[9].GetRoll1() + frame[9].GetRoll2();
                if(frame[8].GetIsSpare()){
                    score += frame[10].GetRoll1();
                }
                if(frame[8].GetIsStrike()){
                    score += frame[10].GetRoll1();
                }

            return score;
        }
    }

    class Frame{
        int pinsInRoll1;
        int pinsInRoll2 = 0;
        bool isLastFrame = false;
        bool isStrike = false;
        bool isSpare = false;
        public Frame(int pinsInRoll1, bool isLastFrame, bool isStrike){
            this.pinsInRoll1 = pinsInRoll1;
            this.isLastFrame = isLastFrame;
            this.isStrike = isStrike;
        }
        public void SetRoll2(int pinsInRoll2, bool isSpare){
            this.pinsInRoll2 = pinsInRoll2;
            this.isSpare = isSpare;
        }
        public int GetRoll1(){
            return pinsInRoll1;
        }
        public int GetRoll2(){
            return pinsInRoll2;
        }
        public bool GetIsStrike(){
            return isStrike;
        }
        public bool GetIsSpare(){
            return isSpare;
        }
        public bool GetIsLastFrame(){
            return isLastFrame;
        }
    }
}

