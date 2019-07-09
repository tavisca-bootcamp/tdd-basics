using System;
using System.Collections.Generic;
using System.Text;

namespace BowlingBall
{
    public class Slot
    {
        public int NumberOfBallKnocked { get; set; }
        public bool IsSlotCompleted { get; set; }

        public Slot()
        {
            NumberOfBallKnocked = 0;
            IsSlotCompleted = false;
        }

    }
}
