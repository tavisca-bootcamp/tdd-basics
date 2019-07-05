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
        public Game()
        {
            PointerToFrame = 0;

            for (int index = 0; index < TotalPossibleFrames; index++)
                Frames[index] = new Frame();
        }
        public void Roll(int [] pins)
        {
            const int RolledStrike = 10;
            int PointerToPinsArray = 0;
            const int HigestPossiblePinsThatCanBeRolled = 21;
            int LengthOfPinsArray = pins.Length;

            // TO check for total pins rolled maximum possible value is less than equal to 21
            if (LengthOfPinsArray > HigestPossiblePinsThatCanBeRolled)
                throw new ArgumentOutOfRangeException();

            
            while (PointerToPinsArray < LengthOfPinsArray && PointerToFrame < 9)
            {
                // To check for valid pin rolled
                if (CheckForValidInput(pins[PointerToPinsArray]) == false)
                    throw new ArgumentOutOfRangeException();

                // to check if user is still playing currentframes, i.e if user rolls {1,2,3} , then set second frame to 3 and -1(default) values
                if (PointerToPinsArray + 1 == LengthOfPinsArray)
                    Frames[PointerToFrame].SetFrame(0,pins[PointerToPinsArray++]);
                //If frame contains 10, then other chance should be set to zero
                else if(pins[PointerToPinsArray] == RolledStrike)
                {
                    Frames[PointerToFrame].SetFrame(0,pins[PointerToPinsArray++]);
                    Frames[PointerToFrame].SetFrame(1, 0);
                }

                else if(pins[PointerToPinsArray] != RolledStrike)
                {
                    Frames[PointerToFrame].SetFrame(0,pins[PointerToPinsArray++]);
                    Frames[PointerToFrame].SetFrame(1,pins[PointerToPinsArray++]);
                }
                
                PointerToFrame++;
            }

            //To check for last frame
            if(PointerToFrame == TotalPossibleFrames - 1 && PointerToPinsArray < LengthOfPinsArray)
            {
                //If user rolls spare in last frame, then set the values in last frame as
                // last value is the extra roll and the two value before that are the last frame roll chances (=10)
                if (pins[LengthOfPinsArray - 2] + pins[LengthOfPinsArray - 3] == 10)
                {
                    Frames[PointerToFrame].SetExtraRollValue(pins[LengthOfPinsArray - 1]);
                    Frames[PointerToFrame].SetFrame(0, pins[LengthOfPinsArray - 2]);
                    Frames[PointerToFrame].SetFrame(1, pins[LengthOfPinsArray - 3]);
                }

                // If user rolls strike in last frame, then set the values in last frame as
                //  last value is the extra roll and the value before that is the last frame roll chance (=10)
                else if ( pins[LengthOfPinsArray - 2] == RolledStrike)
                {
                    Frames[PointerToFrame].SetExtraRollValue(pins[LengthOfPinsArray - 1]);
                    Frames[PointerToFrame].SetFrame(0, pins[LengthOfPinsArray - 2]);
                    Frames[PointerToFrame].SetFrame(1, 0);
                }
                else
                {
                    Frames[PointerToFrame].SetFrame(0, pins[LengthOfPinsArray - 1]);
                    Frames[PointerToFrame].SetFrame(1, pins[LengthOfPinsArray - 2]);
                }

            }
        }

        public int GetScore()
        {
            int TotalScores = 0;
            const int KnockedDownTen = 10;

            //Checking whether LastFrame has strike or spare and adding extra roll value
            if(PointerToFrame == TotalPossibleFrames-1)
            {
                if (Frames[PointerToFrame].IsStrike() == true && Frames[PointerToFrame].CheckForEmptyFrame() == false)
                    TotalScores += KnockedDownTen + Frames[PointerToFrame].StrikeBonus(true);
                else if (Frames[PointerToFrame].IsSpare() == true && Frames[PointerToFrame].CheckForEmptyFrame() == false)
                    TotalScores += KnockedDownTen + Frames[PointerToFrame].SpareBonus(true);
                else if (Frames[PointerToFrame].IsSpare() == false && Frames[PointerToFrame].IsStrike() == false
                    && Frames[PointerToFrame].CheckForEmptyFrame() == false)
                    TotalScores += Frames[PointerToFrame].CalculateScore();

            }

            for(int CurrentPointer=0; CurrentPointer < PointerToFrame; CurrentPointer++)
            {
                if (Frames[CurrentPointer].IsStrike() == true && Frames[CurrentPointer].CheckForEmptyFrame() == false)
                    TotalScores += KnockedDownTen + Frames[CurrentPointer + 1].StrikeBonus(false);
                else if (Frames[CurrentPointer].IsSpare() == true && Frames[CurrentPointer].CheckForEmptyFrame() == false)
                    TotalScores += KnockedDownTen + Frames[CurrentPointer + 1].SpareBonus(false);
                else if (Frames[CurrentPointer].IsSpare() == false && Frames[CurrentPointer].IsStrike() == false 
                    && Frames[CurrentPointer].CheckForEmptyFrame() == false)
                    TotalScores += Frames[CurrentPointer].CalculateScore();
                
            }
            return TotalScores;
        }

        bool CheckForValidInput(int pin)
        {
            return (pin >= LowestPossiblePinValue && pin <= HighestPossiblePinValue) ? true : false;
        }
    }
}

