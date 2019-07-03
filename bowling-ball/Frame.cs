using System;
using System.Collections.Generic;
using System.Text;

namespace BowlingBall
{
    class Frame
    {
        private int numberOfRollRemaining;
        private int numberOfPinsRemaining;
        private int totalFrameValue;
        private bool isStrike;
        private bool isSpare;
        public List<int> Slots;

        public Frame()
        {
            numberOfRollRemaining = 2;
            numberOfPinsRemaining = 10;
            totalFrameValue = 0;
            isSpare = false;
            isStrike = false;
            Slots = new List<int>();
        }

        public int NumberOfPinsRemaining
        {
            get => numberOfPinsRemaining;
            set => numberOfPinsRemaining = value;
        }
        public int NumberOfRollRemaining
        {
            get => numberOfRollRemaining;
            set => numberOfRollRemaining = value;
        }
        public int TotalFrameValue
        {
            get => totalFrameValue;
            set => totalFrameValue = value;
        }
        public bool IsStrike
        {
            get => isStrike;
            set => isStrike = value;
        }
        public bool IsSpare
        {
            get => isSpare;
            set => isSpare = value;
        }
    }
}