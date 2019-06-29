using System;

namespace BowlingBall
{
    public class Game
    {
		private int[] rolls = new int[21];
		private int currentRoll = 0;
		
        public void Roll(int pins)
        {
			this.rolls[currentRoll++] = pins;
        }

		private bool IsStrike(int frameIndex)
		{
			return (rolls[frameIndex] == 10);
		}

		private bool IsSpare(int frameIndex)
		{
			return (rolls[frameIndex] + rolls[frameIndex+1] == 10);
		}

		private int GetStrikeBonus(int frameIndex)
		{
			return (rolls[frameIndex+1] + rolls[frameIndex+2]);
		}

		private int GetSpareBonus(int frameIndex)
		{
			return (rolls[frameIndex + 2]);
		}

		private int GetFrameSum(int frameIndex)
		{
			return (rolls[frameIndex] + rolls[frameIndex+1]);
		}
		// Comment to test TravisCI
		public int GetScore()
        {
			int score = 0;
			int frameIndex = 0;
			for (int frame = 0; frame < 10; frame++)
			{
				if (IsStrike(frameIndex))
				{
					score += 10 + GetStrikeBonus(frameIndex);
					frameIndex++;
				}
				else if (IsSpare(frameIndex))
				{
					score += 10 + GetSpareBonus(frameIndex);
					frameIndex += 2;
				}
				else
				{
					score += GetFrameSum(frameIndex);
					frameIndex += 2;
				}
			}
            return score;
        }

    }
}

