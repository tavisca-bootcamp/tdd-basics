using System;
using System.Collections.Generic;

namespace BowlingBall
{
    public class Game
    {
        public List<int> turns = new List<int>();
        public int attempt = 1, index = 0;
        public Dictionary<int, int> isStrikeOrSpare = new Dictionary<int, int>();

        public void Roll(int pins)
        {
            // mark strike index
            if (pins == 10 && (attempt % 2) == 1)
            {
                isStrikeOrSpare.Add(index, 1);
                ++attempt;
            }
            // mark spare index
            if ((attempt % 2) == 0 && index > 0 && turns[index - 1] + pins == 10)
            {
                isStrikeOrSpare.Add(index, 2);
            }
            turns.Add(pins);
            ++index;
            ++attempt;
            // throw new NotImplementedException();
        }
        public int GetScore()
        {
            int Score = 0;
            for (int i = 0; i < index; ++i)
            {
                int check = -1;
                isStrikeOrSpare.TryGetValue(i, out check);
                if (check == 1)
                {
                    if (i + 2 < index)
                        Score += turns[i] + turns[i + 1] + turns[i + 2];
                }
                else if (check == 2)
                {
                    if (i + 1 < index)
                        Score += turns[i] + turns[i + 1];
                }
                else
                {
                    if (attempt - 1 == 21 && i == index - 1)
                        continue;
                    Score += turns[i];
                }
            }
            return Score;
        }
    }
}
