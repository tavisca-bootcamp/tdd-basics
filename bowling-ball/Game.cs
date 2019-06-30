using System;

namespace BowlingBall
{
    public class Game
    {
        int[] frame = new int[21];
        int currentRoll;

        public void Roll(int pins)
        {
            frame[currentRoll++] = pins;
        }

        public int getScore()
        {
            var score = 0;
            var roll = 0;

            for (var frameNumber = 1; frameNumber <= 10; frameNumber++)
            {
                if (isStrike(roll))
                {
                    score += 10 + strikeBonus(roll);
                    roll++;
                }
                else if (isSpare(roll))
                {
                    score += 10 + spareBonus(roll);
                    roll += 2;
                }
                else
                {
                    score += sumOfBallsInFrame(roll);
                    roll += 2;
                }
            }
            return score;
        }
        private int sumOfBallsInFrame(int roll)
        {
            return frame[roll] + frame[roll + 1];
        }

        private int spareBonus(int roll)
        {
            return frame[roll + 2];
        }

        private int strikeBonus(int roll)
        {
            return frame[roll + 1] + frame[roll + 2];
        }

        private bool isStrike(int roll)
        {
            return frame[roll] == 10;
        }

        private bool isSpare(int roll)
        {
            return frame[roll] + frame[roll + 1] == 10;
        }

    }
}

