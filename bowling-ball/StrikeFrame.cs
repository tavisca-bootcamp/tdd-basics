using System;
using System.Collections.Generic;
using System.Linq;
namespace BowlingBall
{
    public class StrikeFrame : Frame
    {
        public StrikeFrame(var roll1, var roll2, var roll3)
        {
            RollList = new ArrayList();
            RollList.Add(roll1);
            NumberOfRolls = 1;
            Score = roll1 + roll2 + roll3;
        }
    }
}