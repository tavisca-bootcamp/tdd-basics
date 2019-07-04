using System;
using System.Collections.Generic;
using System.Linq;
namespace BowlingBall
{
    public class SpareFrame : Frame
    {
        public SpareFrame(var roll1,var roll2,var roll3)
        {
            RollList = new ArrayList();
            RollList.Add(roll1);
            RollList.Add(roll2);
            NumberOfRolls = 2;
            Score = roll1 + roll2 + roll3;
        }
    }
}