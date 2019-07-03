using System;

namespace BowlingBall
{
    public class Game
    {
        private int[] roll = new int[21];
        private int CurrentRoll = 0;
        public void Roll(int pins)
        {
            roll[CurrentRoll++] = pins;

            //throw new NotImplementedException();
        }
        public void Roll(int[] pins)
        {
            for (int i = 0; i < pins.Length; i++)
            {
                roll[i] = pins[i];
            }
        }

        public int GetScore()
        {
            int TotalScore = 0;
            int i = 0;

            for (int frame = 0; frame < 10; frame++)
            {
                if (roll[i] == 10 && i < 19)
                {
                    TotalScore += 10 + roll[i + 1] + roll[i + 2];
                    i++;
                }
                else if ((roll[i] + roll[i + 1]) == 10)
                {
                    TotalScore += 10 + roll[i + 2];
                    i = i + 2;
                }
                else
                {
                    TotalScore += roll[i] + roll[i + 1];
                    i = i + 2;
                }
            }
            return TotalScore;


            //throw new NotImplementedException();
        }

    }
}



    


