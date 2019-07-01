using System;
using System.Collections.Generic;
using System.Text;

namespace BowlingBall
{
    class Slot
    {
        private int numberOfBallKnocked;
        private bool isSlotCompleted = false;
     
        public bool IsSlotCompleted { get => isSlotCompleted; set => isSlotCompleted = value; }
        public int NumberOfBallKnocked { get => numberOfBallKnocked; set => numberOfBallKnocked = value; }
    }
}
