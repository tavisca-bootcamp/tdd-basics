using System;

namespace BowlingBall
{
    public class Game
    {
        private int _score = 0;
        private int[] _rolling = new int[21];
        private int _currentRoll = 0;

        public void Roll(int pins)
        {
            _rolling[_currentRoll++] = pins;
        }

        public int GetScore()
        {
            int _rollIndex = 0;
            for (int frame = 0; frame < 10; frame++, _rollIndex += 2)
            {
                if (IsSpare(_rollIndex))
                    _score += 10 + GetSpareBonus(_rollIndex);
                else if (IsStrike(_rollIndex))
                {
                    _score += 10 + GetStrikeBonus(_rollIndex);
                    _rollIndex--;
                }
                else
                    _score += _rolling[_rollIndex] + _rolling[_rollIndex + 1];
            }
            return _score;
            throw new NotImplementedException();
        }
        public bool IsSpare(int rollIndex)
        {
            if(_rolling[rollIndex] + _rolling[rollIndex + 1] == 10)
                return true;
            else 
                return false;
        }

        public bool IsStrike(int rollIndex)
        {
            if (_rolling[rollIndex] == 10)
                return true;
            else
                return false;
        }

        public int GetSpareBonus(int rollIndex)
        {
            return _rolling[rollIndex + 2];
        }
        public int GetStrikeBonus(int rollIndex)
        {
            return _rolling[rollIndex + 1] + _rolling[rollIndex + 2];
        }
    }
}

