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
            RollList.Add(roll1);
            RollList.Add(roll2);
            NumberOfRolls = 2;
            Score = roll1 + roll2 + roll3;
        }
    }
}