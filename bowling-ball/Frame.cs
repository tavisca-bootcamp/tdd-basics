using System;
using System.Collections.Generic;
using System.Text;

namespace BowlingBall
{
    public class Frame
    {
        public int BowlRemaining { get; set; }
        public int PinsRemaining { get; set; }
        public int FrameScore { get; set; }
        public bool IsStrike { get; set; }
        public bool IsSpare { get; set; }
        public List<Slot> Slots { get; set; }

        public Frame()
        {
            BowlRemaining = 2;
            PinsRemaining = 10;
            FrameScore = 0;
            IsStrike = false;
            IsSpare = false;
            Slots = new List<Slot>
            {
                new Slot(),
                new Slot()
            };
        }
        public void AddSlot()
        {
            Slots.Add(new Slot());
        }
    }
}
