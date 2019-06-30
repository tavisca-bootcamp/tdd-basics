
 using System;

namespace BowlingBall
{
    public class Game
    {
        int[] pinFall = new int[21];
        int rollCounter=0;
        public void Roll(int pins)
        {
            pinFall[rollCounter] = pins;
            rollCounter++;
        }

        bool IsStrike(int frameIndex)
        {
            return pinFall[frameIndex] == 10;
        }

        bool IsSpare(int frameIndex)
        {
            return pinFall[frameIndex] + pinFall[frameIndex + 1] == 10;
        }

        int StrikeBonus(int i)
        {
            return pinFall[i + 1] + pinFall[i + 2];
        }

        int SpareBonus(int i)
        {
            return pinFall[i + 2];
        }

        public int GetScore()
        {
            int score = 0;
            int i = 0;
            for (int frame=0;frame<10;frame++)
            {
                if (IsStrike(i))
                {
                    score += 10 + StrikeBonus(i);
                    i += 1;
                }
                else if (IsSpare(i))
                {
                    score +=10+ SpareBonus(i);
                    i += 2;
                }

                else
                {
                    score += pinFall[i] + pinFall[i + 1];
                    i += 1;
                }
            }
            return score;   
        }

    }
}



