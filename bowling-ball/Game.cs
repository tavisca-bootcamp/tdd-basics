using System;

namespace BowlingBall
{    
    public class Game
    {
        public int[] rolls = new int[21];
        public int rollIndex = 0;
        public void Roll(int pins)
        {
            rolls[rollIndex++] = pins;
        }

        public int GetScore()
        {
            int score = 0;
            int framePosition = 0;
            for (int frameIndex = 0; frameIndex < 10; frameIndex++)
            {
                // to get score when the player hits strike
                if (IsStrike(framePosition))
                {
                    score += 10 + StrikeBonus(framePosition);                    
                }
                // to get score when the player hits spare
                else if (IsSpare(framePosition))
                {
                    score += 10 + SpareBonus(framePosition);
                }
                // to get score when the player did not hit a strike or a spare
                else
                {
                    score += TotalPinsRolledInFrame(framePosition);
                }
            }
            return score;
        }
        
        public bool IsStrike(int numberOfPins)
        {
            // checking strike
            return rolls[numberOfPins] == 10;
        }

        public bool IsSpare(int numberOfPins)
        {
            // checking spare
            return rolls[numberOfPins] + rolls[numberOfPins + 1] == 10;
        }

        public int StrikeBonus(int framePosition)
        {
            // calculate bonus for strike
            return rolls[framePosition + 1] + rolls[framePosition + 2];
        }

        public int SpareBonus(int framePosition)
        {
            // calculate bonus for spare
            return rolls[framePosition + 1];
        }
                
        public int TotalPinsRolledInFrame(int framePosition)
        {
            // calculate total pins rolled in a frame
            return rolls[framePosition] + rolls[framePosition + 1];
        }
    }
}

