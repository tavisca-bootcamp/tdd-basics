using System;
using System.Collections;
using System.Linq;
namespace BowlingBall
{
    public class SpareFrame : Frame
    {
        public SpareFrame(int roll1,int roll2,int roll3)
        {
            RollList = new ArrayList();
            if ((IsValidRoll(roll1)) && (IsValidRoll(roll2)) && (IsValidRoll(roll3)) && (roll1 + roll2 == 10))
            {
                RollList.Add(roll1);
                RollList.Add(roll2);
            }
            else
                throw new Exception("Invalid Roll");
            NumberOfRolls = 2;
            Score = roll1 + roll2 + roll3;
        }
    }
}