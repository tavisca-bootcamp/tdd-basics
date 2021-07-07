namespace BowlingBall
{
    public class Game
    {
        int[] pinFalls = new int[21];
        int rollCounter = 0;
        public void Roll(int pins)
        {
            pinFalls[rollCounter] = pins;
            rollCounter++;
        }

        public int GetScore()
        {
            int score = 0;
            int frameIndex = 0;
            for (int frame = 0; frame < 10; frame++)
            {
                if (IsStrike(frameIndex))
                {
                    score += 10 + StrikeBonus(frameIndex);
                }
                else if (IsSpare(frameIndex))
                {
                    score += 10 + SpareBonus(frameIndex);
                    frameIndex++;
                }
                else
                {
                    score += pinFalls[frameIndex] + pinFalls[frameIndex + 1];
                    frameIndex++;
                }

                frameIndex++;
            }
            return score;
        }

        bool IsStrike(int frameIndex)
        {
            return pinFalls[frameIndex] == 10;
        }

        bool IsSpare(int frameIndex)
        {
            return pinFalls[frameIndex] + pinFalls[frameIndex + 1] == 10;
        }

        int StrikeBonus(int frameIndex)
        {
            return pinFalls[frameIndex + 1] + pinFalls[frameIndex + 2];
        }

        int SpareBonus(int frameIndex)
        {
            return pinFalls[frameIndex + 2];
        }

    }
}

