using System;

namespace BowlingBall
{
    public class Game
    {
        public int roll = 0;
        public int[] rolls = new int[21];

        public void Roll(int[] Rolls)
        {
            foreach (int pinsDown in Rolls)
            {
                Rolling(pinsDown);
            }
            
        }

        public void Rolling (int p)
        {
            rolls[roll++] = p;
        }

        public int GetScore()
        {
            int score = 0;
            int cursor = 0;
            int[] a = { 3, 4 };
            for (int frame=0; frame<10; frame++)
            {
                if (rolls[cursor]==10)
                {
                    score += 10 + rolls[cursor + 1] + rolls[cursor + 2];
                    cursor++;
                }
                else if (rolls[cursor]+rolls[cursor+1]==10)
                {
                    score += 10 + rolls[cursor + 2];
                    cursor += 2;
                }
                else
                {
                    score += rolls[cursor] + rolls[cursor + 1];
                    cursor += 2;
                }
            }
            return score;
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}

