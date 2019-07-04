using System;
using System.Collections;
namespace BowlingBall
{
    public abstract class Frame
    {
        public ArrayList RollList;
        public int NumberOfRolls;
        public int Score;
        public int GetScore()
        {
            return Score;
        }
        public static bool IsValidRoll(int roll)
        {
            if ((roll <= 10) && (roll >= 0))
                return true;
            return false;
        }
    }
}