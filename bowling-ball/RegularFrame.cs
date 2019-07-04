using System;
using System.Collections;
using System.Linq;
namespace BowlingBall
{
    public class RegularFrame : Frame
    {
        public RegularFrame(int roll1, int roll2)
        {
            RollList = new ArrayList();
            RollList.Add(roll1);
            RollList.Add(roll2);
            NumberOfRolls = 2;
            Score = roll1 + roll2 ;
        }
    }
}