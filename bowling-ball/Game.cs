using System;
using System.Collections.Generic;
using System.Linq;

namespace BowlingBall
{
    public class Game
    {
        public int score = 0;
        public List<int> bowlingScore = new List<int>();
        public void Roll(int pins)
        {
            bowlingScore.Add(pins);
            /*if (valid != 0)
            {
                score += pins;
                if(pins!=0)
                    valid--;
            }
            if(count%2==1)
            {
                buffer = pins;
            }
            else
            {
                buffer += pins;
                if (buffer == 10)
                {
                    valid = 1;
                    if (pins == 0)
                        valid =2;
                }
                
            }

            score += pins;
            count++;
            */
        }

        public int GetScore()
        {
            
            int individualScore = 0;
            for (int i=0;i<bowlingScore.Count();i++)
            {
                                
                if (i % 2 == 0)
                {
                    individualScore = bowlingScore[i];
                }
                else
                {
                    individualScore += bowlingScore[i];
                    if (individualScore == 10)
                    {
                        if(bowlingScore[i]==0)
                        {
                            if(i+1<bowlingScore.Count())
                                score += bowlingScore[i + 1];
                            if (i + 3 < bowlingScore.Count() && bowlingScore[i + 2] == 0 )
                                score += bowlingScore[i + 3];
                            else
                                if (i + 2 < bowlingScore.Count())
                                    score += bowlingScore[i + 2];
                        }
                        else
                            score += bowlingScore[i+1];
                        
                       
                           
                    }

                }
                score += bowlingScore[i];
            }
            return score;
        }

    }
}

