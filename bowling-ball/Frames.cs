using System;
using System.Collections.Generic;
using System.Text;

namespace BowlingBall
{
    class Frame
    {
        int[] RollChance = new int[2];

        int ExtraRollForLastFrame = -1;
        const int EmptyFrame = -1;

        public Frame()
        {
            this.RollChance[0] = -1;
            this.RollChance[1] = -1;
        }

        internal void SetFrame(int index , int pin) => this.RollChance[index] = pin;

        internal int GetFrame(int index) => this.RollChance[index];

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
            return RollChance[0] + RollChance[1];
        }

        internal bool IsSpare()
        {
            return ((this.RollChance[0] + this.RollChance[1]) == 10) ? true : false;
        }

        internal bool IsStrike()
        {
            return (this.RollChance[0] == 10 || this.RollChance[1] == 10) ? true : false;
        }

        internal int SpareBonus(bool TrackLastFrameStatus)
        {
            if (TrackLastFrameStatus == true)
                return ExtraRollForLastFrame;
            return this.RollChance[0];
        }

        internal int StrikeBonus(bool TrackLastFrameStatus)
        {
            if (TrackLastFrameStatus == true)
                return ExtraRollForLastFrame;
            return this.RollChance[0] + this.RollChance[1];
        }


        internal bool CheckForEmptyFrame()
        {
            if (this.RollChance[0] == EmptyFrame || this.RollChance[1] == EmptyFrame)
                return true;
            return false;
        }
    }
}
