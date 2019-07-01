using System;

namespace BowlingBall
{
    public class Game
    {
        int maxRollPossible = 21;
        public int TotalScore { get; set; }
        public int[]  ScoreOfEachRoll { get; set; }
        public int currentRollIndex { get; set; }

        public Game()
        {
            TotalScore = 0;
            ScoreOfEachRoll = new int[maxRollPossible];
            currentRollIndex = 0;

        }
        public void Roll(int pins)
        {
            ScoreOfEachRoll[currentRollIndex++] = pins;
        }

        public int GetScore()
        {
            int _rollIndex = 0;
            for (int frame = 0; frame < 10; frame++, _rollIndex += 2)
            {
                if (IsSpare(_rollIndex))
                    TotalScore += 10 + GetSpareBonus(_rollIndex);
                else if (IsStrike(_rollIndex))
                {
                    TotalScore += 10 + GetStrikeBonus(_rollIndex);
                    _rollIndex--;
                }
                else
                    TotalScore += ScoreOfEachRoll[_rollIndex] + ScoreOfEachRoll[_rollIndex + 1];
            }
            return TotalScore;
            throw new NotImplementedException();
        }
        public bool IsSpare(int rollIndex)
        {
            if(ScoreOfEachRoll[rollIndex] + ScoreOfEachRoll[rollIndex + 1] == 10)
                return true;
            else 
                return false;
        }

        public bool IsStrike(int rollIndex)
        {
            if (ScoreOfEachRoll[rollIndex] == 10)
                return true;
            else
                return false;
        }

        public int GetSpareBonus(int rollIndex)
        {
            return ScoreOfEachRoll[rollIndex + 2];
        }
        public int GetStrikeBonus(int rollIndex)
        {
            return ScoreOfEachRoll[rollIndex + 1] + ScoreOfEachRoll[rollIndex + 2];
        }
    }
}

