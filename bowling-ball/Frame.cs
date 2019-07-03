using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace BowlingBall
{
    class Frame
    {
        public int MaxTry { get; set;}
        public int StrikeStatus;
        public int SpareStatus;
        public List<int> Score;

        public Frame()
        {
            MaxTry = 0;
            StrikeStatus = 0;
            SpareStatus = 0;
            Score = new List<int>();
        }

        public int Roll(int pinValue)
        {

           
                if (pinValue == 10 && MaxTry == 2)
                {
                    StrikeStatus = 1;
                    Score.Add(pinValue);
                    MaxTry = 0;
                }



                else
                {
                    Score.Add(pinValue);
                    if (Score.Sum() == 10)
                        SpareStatus = 1;
                    MaxTry -= 1;
                }

                if (MaxTry == 0)
                    return 1;
                return 0;
            }

           

                
            
        
    }
}
