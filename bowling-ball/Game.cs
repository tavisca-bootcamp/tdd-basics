using System;

namespace BowlingBall
{
    public class Game
    {
        Frame [] Frames = new Frame[10];
        int PointerToFrame;
        const int TotalPossibleFrames = 10;
        const int LowestPossiblePinValue = 0;
        const int HighestPossiblePinValue = 10;
        const int KnockedDownTen = 10;
        public Game()
        {
            PointerToFrame = 0;

            for (int index = 0; index < TotalPossibleFrames; index++)
                Frames[index] = new Frame();
        }
        public void Roll(int [] pins)
        {
            
            int pointerToPinsArray = 0;
            const int HigestPossiblePinsThatCanBeRolled = 21;
            int lengthOfPinsArray = pins.Length;

            // TO check for total pins rolled maximum possible value is less than equal to 21
            if (lengthOfPinsArray > HigestPossiblePinsThatCanBeRolled)
                throw new ArgumentOutOfRangeException();

            
            while (pointerToPinsArray < lengthOfPinsArray && PointerToFrame < TotalPossibleFrames - 1)
            {
                // To check for valid pin rolled
                if (CheckForValidInput(pins[pointerToPinsArray]) == false)
                    throw new ArgumentOutOfRangeException();

                // to check if user is still playing currentframes, i.e if user rolls {1,2,3} , then set second frame to 3 and -1(default) values
                if (pointerToPinsArray + 1 == lengthOfPinsArray)
                    Frames[PointerToFrame].SetFrame(0,pins[pointerToPinsArray++]);
                //If frame contains 10, then other chance should be set to zero
                else if(pins[pointerToPinsArray] == KnockedDownTen)
                {
                    Frames[PointerToFrame].SetFrame(0,pins[pointerToPinsArray++]);
                    Frames[PointerToFrame].SetFrame(1, 0);
                }

                else if(pins[pointerToPinsArray] != KnockedDownTen)
                {
                    Frames[PointerToFrame].SetFrame(0,pins[pointerToPinsArray++]);
                    Frames[PointerToFrame].SetFrame(1,pins[pointerToPinsArray++]);
                }
                
                PointerToFrame++;
            }

            //To check for last frame seperately, to store extra roll in case of strike or spare
            // I added this seperately because i didn't want to add unnecesary check statements in the above loop.
            if(PointerToFrame == TotalPossibleFrames - 1 && pointerToPinsArray < lengthOfPinsArray)
            {
                //If user rolls spare in last frame, then set the values in last frame as
                // last value is the extra roll and the two value before that are the last frame roll chances (=10)
                if (pins[lengthOfPinsArray - 2] + pins[lengthOfPinsArray - 3] == 10)
                {
                    Frames[PointerToFrame].SetExtraRollValue(pins[lengthOfPinsArray - 1]);
                    Frames[PointerToFrame].SetFrame(0, pins[lengthOfPinsArray - 3]);
                    Frames[PointerToFrame].SetFrame(1, pins[lengthOfPinsArray - 2]);
                }

                // If user rolls strike in last frame, then set the values in last frame as
                //  last value is the extra roll and the value before that is the last frame roll chance (=10)
                else if ( pins[lengthOfPinsArray - 3] == KnockedDownTen)
                {
                    Frames[PointerToFrame].SetExtraRollValue(pins[lengthOfPinsArray - 1]);
                    Frames[PointerToFrame].SetFrame(0, pins[lengthOfPinsArray - 3]);
                    Frames[PointerToFrame].SetFrame(1, pins[lengthOfPinsArray - 2]);
                }
                else
                {
                    Frames[PointerToFrame].SetFrame(0, pins[lengthOfPinsArray - 2]);
                    Frames[PointerToFrame].SetFrame(1, pins[lengthOfPinsArray - 1]);
                }

            }
        }

        public int GetScore()
        {
            int totalScore = 0;
            const int SecondLastFrame = 8;

            for(int CurrentPointer=0; CurrentPointer < PointerToFrame; CurrentPointer++)
            {
                // Checking for strike
                if (Frames[CurrentPointer].IsStrike() == true && Frames[CurrentPointer].CheckForEmptyFrame() == false)
                {
                    // If it is not SecondLastFrame and next frame is strike again, then adding two strikes and first roll of CurrentPointer + 2
                    if (CurrentPointer != SecondLastFrame && Frames[CurrentPointer + 1].GetFrame(0) == KnockedDownTen)
                            totalScore += KnockedDownTen + KnockedDownTen + Frames[CurrentPointer + 2].GetFrame(0);
                    // If it is second last frame and last frame is strike, then adding two strikes and immediate next roll
                    else if(CurrentPointer == SecondLastFrame && Frames[CurrentPointer + 1].GetFrame(0) == KnockedDownTen)
                            totalScore += KnockedDownTen + KnockedDownTen + Frames[CurrentPointer + 1].GetFrame(1);
                    // If neither of the above conditions. then adding strike and next frames bonus
                    else
                        totalScore += KnockedDownTen + Frames[CurrentPointer + 1].StrikeBonus(false);
                }
                // Checking for spare
                else if (Frames[CurrentPointer].IsSpare() == true && Frames[CurrentPointer].CheckForEmptyFrame() == false)
                    totalScore += KnockedDownTen + Frames[CurrentPointer + 1].SpareBonus(false);
                // Neither strike nor spare
                else if (Frames[CurrentPointer].IsSpare() == false && Frames[CurrentPointer].IsStrike() == false 
                    && Frames[CurrentPointer].CheckForEmptyFrame() == false)
                    totalScore += Frames[CurrentPointer].CalculateScore();
                
            }

            //Checking whether LastFrame has strike or spare and adding extra roll value to totalScores 
            if (PointerToFrame == TotalPossibleFrames - 1)
            {
                // If first roll is strike, then adding strike and next two rolls
                if (Frames[PointerToFrame].GetFrame(0) == KnockedDownTen && Frames[PointerToFrame].CheckForEmptyFrame() == false)
                    totalScore += KnockedDownTen + Frames[PointerToFrame].GetFrame(1) + Frames[PointerToFrame].StrikeBonus(true);
                // If it is spare, then adding 10 and bonus
                else if (Frames[PointerToFrame].IsSpare() == true && Frames[PointerToFrame].CheckForEmptyFrame() == false)
                    totalScore += KnockedDownTen + Frames[PointerToFrame].SpareBonus(true);
                // If neither strike or spare, then adding current frames rolls
                else if (Frames[PointerToFrame].IsSpare() == false && Frames[PointerToFrame].IsStrike() == false
                    && Frames[PointerToFrame].CheckForEmptyFrame() == false)
                    totalScore += Frames[PointerToFrame].CalculateScore();

            }

            return totalScore;
        }

        bool CheckForValidInput(int pin)
        {
            return (pin >= LowestPossiblePinValue && pin <= HighestPossiblePinValue) ? true : false;
        }

    }
}

