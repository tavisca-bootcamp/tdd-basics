using System;

namespace BowlingBall
{
    public class Game
    {
        //array to store number of pins knocked in single roll
        int[] pinFall = new int[21];
        int rollCounter;

        //Method when ball is rolled
        public void Roll(int pins)
        {
            pinFall[rollCounter] = pins;
            rollCounter++;
        }

        //Method to check for strike 
        bool IsStrike(int frameIndex)
        {
            return pinFall[frameIndex] == 10;
        }

        //Method to check for spare 
        bool IsSpare(int frameIndex)
        {
            return pinFall[frameIndex] + pinFall[frameIndex + 1] == 10;
        }

        //Method to evaluate strike bonus
        int StrikeBonus(int i)
        {
            return pinFall[i + 1] + pinFall[i + 2];
        }

        //Method to evaluate spare bonus
        int SpareBonus(int i)
        {
            return pinFall[i + 2];
        }

        //method to evaluate score
        public int GetScore()
        {
            int score = 0;
            int i = 0;
            try
            {
                for (int frame = 0; frame < 10; frame++)
                {
                    if (IsStrike(i))
                    {
                        score += 10 + StrikeBonus(i);
                        i += 1;
                    }
                    else if (IsSpare(i))
                    {
                        score += 10 + SpareBonus(i);
                        i += 2;
                    }

                    else
                    {
                        score += pinFall[i] + pinFall[i + 1];
                        i += 1;
                    }
                }
            }
            catch(Exception e)
            {
                Console.WriteLine(e.GetType().Name  );
            }
            return score;   
        }

    }
}

