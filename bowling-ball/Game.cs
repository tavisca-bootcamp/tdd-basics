using System;

namespace BowlingBall
{
    public class Game
    {
        private int Score = 0;
        private int[] RollScore = new int[21];
        private int CurrentRoll = 0;

        public void Roll(int pins)
        {
            RollScore[CurrentRoll++] = pins;
        }

        public int GetScore()
        {
            int RollScoreIndex = 0;
            for(int Frame=0; Frame < 10; Frame++)
            {
                if (IsStrike(RollScoreIndex))
                {
                    Score += 10 + StrikeBonusPoint(RollScoreIndex);
                    RollScoreIndex += 1;
                }
                else if (IsSpare(RollScoreIndex))
                {
                    Score += 10 + SpareBonusPoint(RollScoreIndex);
                    RollScoreIndex += 2;
                }
                else
                {
                    Score += RollScore[RollScoreIndex] + RollScore[RollScoreIndex + 1];
                    RollScoreIndex += 2;
                }
            }
            return Score;
        }

        public bool IsStrike(int RollScoreIndex)
        {
            return (RollScore[RollScoreIndex] == 10);
        }

        public bool IsSpare(int RollScoreIndex)
        {
            return (RollScore[RollScoreIndex] + RollScore[RollScoreIndex + 1] == 10);
        }

        public int StrikeBonusPoint(int RollScoreIndex)
        {
            return (RollScore[RollScoreIndex + 1] + RollScore[RollScoreIndex + 2]);
        }

        public int SpareBonusPoint(int RollScoreIndex)
        {
            return (RollScore[RollScoreIndex + 2]);
        }

    }
}

