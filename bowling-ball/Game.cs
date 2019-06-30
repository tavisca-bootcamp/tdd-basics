using System;

namespace BowlingBall
{
    public class Game
    {
        private int[] roll = new int[21];
        private int index = 0;
        public void Roll(int pins)
        {
            if (index < 21)
            {
                roll[index++] = pins;
            } 
           // throw new NotImplementedException();
        }

        public int GetScore()
        {
            int score = 0;
            int i = 0;
            for(int frames = 0; frames < 10; frames++)
            {
                if(IsStrike(i))
                {
                    score = StrikeScore(score, i);
                    i += 1;
                }
                else if(IsSpare(i))
                {
                    score = SpareScore(score, i);
                    i += 2;
                }
                else
                {
                    score = Score(score, i);
                    i += 2;
                }
            }

            return score;
           // throw new NotImplementedException();
        }

        private int Score(int score, int i)
        {
            score += roll[i] + roll[i + 1];
            return score;
        }

        private int SpareScore(int score, int i)
        {
            score += roll[i] + roll[i + 1] + roll[i + 2];
            return score;
        }

        private int StrikeScore(int score, int i)
        {
            score += roll[i] + roll[i + 1] + roll[i + 2];
            return score;
        }

        private bool IsSpare(int i)
        {
            return roll[i] + roll[i + 1] == 10;
        }

        private bool IsStrike(int i)
        {
            return roll[i] == 10;
        }
    }
}

