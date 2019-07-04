using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
namespace BowlingBall
{
    public class StrikeFrame : Frame
    {
        public StrikeFrame(int roll1, int roll2, int roll3)
        {
            RollList = new ArrayList();
            RollList.Add(roll1);
            NumberOfRolls = 1;
            Score = roll1 + roll2 + roll3;
        }
    }
}