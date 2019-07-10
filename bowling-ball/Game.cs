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

            if (lengthOfPinsArray > HigestPossiblePinsThatCanBeRolled)
                throw new ArgumentOutOfRangeException();

            
            while (pointerToPinsArray < lengthOfPinsArray && PointerToFrame < TotalPossibleFrames)
            {

                // to check if user is still playing currentframes, i.e if user rolls {1,2,3} , then set second frame to 3 and -1(default) values
                if (pointerToPinsArray + 1 == lengthOfPinsArray)
                    Frames[PointerToFrame].SetFrame(0,pins[pointerToPinsArray++]);
                
                else if(pins[pointerToPinsArray] == KnockedDownTen)
                {
                    Frames[PointerToFrame].SetFrame(0,pins[pointerToPinsArray++]);
                    Frames[PointerToFrame].SetFrame(1, 0);

                    if (PointerToFrame == TotalPossibleFrames - 1)
                    {
                        Frames[PointerToFrame].SetFrame(1, pins[pointerToPinsArray++]);
                        Frames[PointerToFrame].SetExtraRollValue(pins[pointerToPinsArray++]);
                    }
                }

                else if(pins[pointerToPinsArray] != KnockedDownTen)
                {
                    Frames[PointerToFrame].SetFrame(0,pins[pointerToPinsArray++]);
                    Frames[PointerToFrame].SetFrame(1,pins[pointerToPinsArray++]);

                    if (PointerToFrame == TotalPossibleFrames - 1 && Frames[PointerToFrame].IsSpare())
                        Frames[PointerToFrame].SetExtraRollValue(pins[pointerToPinsArray++]);
                }

                if (Frames[PointerToFrame].CheckFrameValidRollsStatus(PointerToFrame) == false)
                    throw new ArgumentOutOfRangeException();

                PointerToFrame++;
            }

            if(PointerToFrame == TotalPossibleFrames)
                PointerToFrame -- ;

        }

        public int GetScore()
        {
            int totalScore = 0;
            const int SecondLastFrame = 8;

            for(int CurrentPointer=0; CurrentPointer <= PointerToFrame; CurrentPointer++)
            {
                if (Frames[CurrentPointer].CheckForEmptyFrame() == true)
                    break;

                if (Frames[CurrentPointer].IsStrike() == true)
                {
                    if (CurrentPointer == PointerToFrame)
                        totalScore += KnockedDownTen + Frames[PointerToFrame].GetFrame(1) + Frames[PointerToFrame].StrikeBonus(true);
                    else if (CurrentPointer != SecondLastFrame && Frames[CurrentPointer + 1].GetFrame(0) == KnockedDownTen)
                        totalScore += KnockedDownTen + KnockedDownTen + Frames[CurrentPointer + 2].GetFrame(0);
                    else if (CurrentPointer == SecondLastFrame && Frames[CurrentPointer + 1].GetFrame(0) == KnockedDownTen)
                        totalScore += KnockedDownTen + KnockedDownTen + Frames[CurrentPointer + 1].GetFrame(1);
                    else
                        totalScore += KnockedDownTen + Frames[CurrentPointer + 1].StrikeBonus(false);
                }

                else if (Frames[CurrentPointer].IsSpare() == true)
                {
                    if(CurrentPointer != PointerToFrame)
                        totalScore += KnockedDownTen + Frames[CurrentPointer + 1].SpareBonus(false);
                    else if(CurrentPointer == PointerToFrame)
                        totalScore += KnockedDownTen + Frames[PointerToFrame].SpareBonus(true);
                }

                else if (Frames[CurrentPointer].IsSpare() == false && Frames[CurrentPointer].IsStrike() == false)
                    totalScore += Frames[CurrentPointer].CalculateScore();
                
            }

            return totalScore;
        }


    }
}

