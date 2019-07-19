using System;
using System.Collections.Generic;
using System.Text;

namespace BowlingBall
{
    class Frame
    {
        public const int maximumBalls = 21;
        public int[] rolls = new int[maximumBalls];
        public int Rollindex = 0;
        public int Ballindex = 0;
        public int Score(int i)
        {
            return rolls[i] + rolls[i + 1];
        }
        public int ScoreSpare(int i)
        {
            Ballindex = Ballindex + 2;
            return 10 + rolls[i + 2];
        }
        public int ScoreStrike(int i)
        {
            Ballindex++;
            return 10 + rolls[i + 1] + rolls[i + 2];
        }
        public bool IsSpare(int i)
        {
            return rolls[i] + rolls[i + 1] == 10;
        }
        public bool IsStrike(int i)
        {
            return rolls[i] == 10;
        }
    }
}
