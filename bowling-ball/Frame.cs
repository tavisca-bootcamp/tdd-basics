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
    }
}