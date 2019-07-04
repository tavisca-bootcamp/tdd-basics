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
            //Checking if rolls are valid
            if ( ( IsValidRoll(roll2) )   &&   ( IsValidRoll(roll2) ) )
            {
                RollList.Add(roll1);
                RollList.Add(roll2);
            }
            else
                throw new Exception("Invalid roll");

            NumberOfRolls = 2;
            Score = roll1 + roll2 ;
        }
    }
}