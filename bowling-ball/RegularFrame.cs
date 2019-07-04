using System;
using System.Collections.Generic;
using System.Linq;
namespace BowlingBall
{
    public class RegularFrame : Frame
    {
        public RegularFrame(var roll1, var roll2)
        {
            RollList = new ArrayList();
            RollList.Add(roll1);
            RollList.Add(roll2);
            NumberOfRolls = 2;
            Score = roll1 + roll2 ;
        }
    }
}