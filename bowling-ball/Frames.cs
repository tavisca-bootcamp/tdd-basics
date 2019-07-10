using System;
using System.Collections.Generic;
using System.Text;

namespace BowlingBall
{
    class Frame
    {
        int[] CurrentRoll = new int[2];

        int ExtraRollForLastFrame = 0;

        const int EmptyFrame = -1;
        const int LowestPossiblePinValue = 0;
        const int HighestPossiblePinValue = 10;
        const int KnockedDownTen = 10;

        public Frame()
        {
            this.CurrentRoll[0] = -1;
            this.CurrentRoll[1] = -1;
        }


        // Internal access specifier to make these functions accesible in the same namespace
        internal void SetFrame(int index , int pin) => this.CurrentRoll[index] = pin;

        internal int GetFrame(int index) => this.CurrentRoll[index];

        internal void SetExtraRollValue(int pin)
        {
            ExtraRollForLastFrame = pin;
        }

        internal int GetExtraRollValue()
        {
            return ExtraRollForLastFrame;
        }

        internal int CalculateScore()
        {
            return CurrentRoll[0] + CurrentRoll[1];
        }

        internal bool IsSpare()
        {
            return ((this.CurrentRoll[0] + this.CurrentRoll[1]) == KnockedDownTen) ? true : false;
        }

        internal bool IsStrike()
        {
            return (this.CurrentRoll[0] == 10 || this.CurrentRoll[1] == KnockedDownTen) ? true : false;
        }

        internal int SpareBonus(bool TrackLastFrameStatus)
        {
            if (TrackLastFrameStatus == true)
                return ExtraRollForLastFrame;
            return this.CurrentRoll[0];
        }

        internal int StrikeBonus(bool TrackLastFrameStatus)
        {
            if (TrackLastFrameStatus == true)
                return ExtraRollForLastFrame;
            return this.CurrentRoll[0] + this.CurrentRoll[1];
        }


        internal bool CheckForEmptyFrame()
        {
            if (this.CurrentRoll[0] == EmptyFrame || this.CurrentRoll[1] == EmptyFrame)
                return true;
            return false;
        }


        internal bool CheckFrameValidRollsStatus(int pointer)
        {
            if(pointer != HighestPossiblePinValue - 1)
                return (this.CurrentRoll[0] + this.CurrentRoll[1] >= LowestPossiblePinValue && this.CurrentRoll[0] + this.CurrentRoll[1] <= HighestPossiblePinValue) 
                ? true : false;

            return (this.CurrentRoll[1] >= LowestPossiblePinValue && this.CurrentRoll[1] <= HighestPossiblePinValue
                && this.ExtraRollForLastFrame >= LowestPossiblePinValue && this.ExtraRollForLastFrame <= HighestPossiblePinValue)
                ? true : false;
        }

    }
}
