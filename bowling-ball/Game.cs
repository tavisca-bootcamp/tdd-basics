using System;
using System.Collections.Generic;

namespace BowlingBall
{
    public class Game
    {
        private List<int> _rolls = new List<int>();
        public void Roll(int pins)
        {
            _rolls.Add(pins);

        }

        public int GetScore()
        {
            var score = 0;
            var frame_index = 0;
            for (var frame = 0; frame < 10; frame++)
            {
                if (_rolls[frame_index] == 10)
                {
                    score += 10 + _rolls[frame_index + 1] + _rolls[frame_index + 2];
                    frame_index += 1;

                }
                else if (_rolls[frame_index] + _rolls[frame_index + 1] == 10)
                {
                    score += 10 + _rolls[frame_index + 2];
                    frame_index += 2;
                }
                else
                {
                    score += _rolls[frame_index] + _rolls[frame_index + 1];
                    frame_index += 2;
                }
            }
            return score;

        }

    }
}

