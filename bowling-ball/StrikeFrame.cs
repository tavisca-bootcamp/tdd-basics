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
            if ((IsValidRoll(roll1)) && (IsValidRoll(roll2)) && (IsValidRoll(roll3)) && (roll1 == 10))
                RollList.Add(roll1);
            else
                throw new Exception("Invalid Rolls for StrikeFrame");
            NumberOfRolls = 1;
            Score = roll1 + roll2 + roll3;
        }
    }
}