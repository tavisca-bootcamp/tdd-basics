using System;

namespace BowlingBall
{
    public class Game
    {
        public const int maximumBalls = 21;
        private int[] rolls = new int[maximumBalls];
        int Rollindex = 0;
        int Ballindex = 0;

        public void Roll(int pins)
        {
            rolls[Rollindex++] = pins;
        }
        public int GetScore()
        {
            int score = 0;
            for (int i = 0; i < 10; i++)
            {
                if (isSpare(Ballindex))
                {
                    score += scoreSpare(Ballindex);
                }
                else if (isStrike(Ballindex))
                {
                    score += scoreStrike(Ballindex);
                }
                else
                {
                    score += Score(Ballindex);
                    Ballindex += 2;
                }
            }
            if (Ballindex != Rollindex)
            {
                if (isStrike(Ballindex - 1) || isSpare(Ballindex - 2))
                { }
                else
                    return -1;
            }
            Console.WriteLine(Ballindex + " " + Rollindex);
            return score;
        }
        private int Score(int i)
        {
            return rolls[i] + rolls[i + 1];
        }
        private int scoreSpare(int i)
        {
            Ballindex = Ballindex + 2;
            return 10 + rolls[i + 2];
        }
        private int scoreStrike(int i)
        {
            Ballindex++;
            return 10 + rolls[i + 1] + rolls[i + 2];
        }
        private bool isSpare(int i)
        {
            return rolls[i] + rolls[i + 1] == 10;
        }
        private bool isStrike(int i)
        {
            return rolls[i] == 10;
        }
    }
}
