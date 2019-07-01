using System;
using System.Collections.Generic;
using System.Text;

namespace BowlingBall
{
    class Frame
    {
        private int bowlRemaining;
        private int pinsRemaining;
        private int frameScore;
        private bool isStrike;
        private bool isSpare;
        public List<Slot> Slots;

        public Frame()
        {
            bowlRemaining = 2;
            PinsRemaining = 10;
            frameScore = 0;
            isStrike = false;
            isSpare = false;
            Slots = new List<Slot>
            {
                new Slot(),
                new Slot()
            };

        }

        public int BowlRemaining { get => bowlRemaining; set => bowlRemaining = value; }
        public int FrameScore { get => frameScore; set => frameScore = value; }
        public bool IsStrike { get => isStrike; set => isStrike = value; }
        public bool IsSpare { get => isSpare; set => isSpare = value; }
        public int PinsRemaining { get => pinsRemaining; set => pinsRemaining = value; }
        public void AddNewSlot()
        {
            Slots.Add(new Slot());
        }
        
    }
}
