using System;
using System.Collections.Generic;
using System.Text;

namespace BowlingBall
{
    public class Score
    {
       
        
        int Total = 0;
        private List<int> Frame;

        public Score(List<int> Frame)
        {
            this.Frame = Frame;
        }

        public int GetTotalScore(int PinsFalled)
        {
            for(int i=Frame.IndexOf(PinsFalled);i<i+1;i++)
            {
                //for strike
                //..........
                if(Frame[i]==10 &&Frame[i+1]==10 && Frame[i+2]==10)
                {
                    Total += 30;
                    break;
                }
                else if(Frame[i] == 10 && Frame[i + 1] == 10 && (Frame[i+2]+Frame[i+3] ==10))
                {
                     Total += 30;
                     break;
                }
                else if(Frame[i] == 10 &&( Frame[i + 1] + Frame[i + 2] == 10))
                {
                    Total += 20;
                    break;
                }
                else if(Frame[i]+Frame[i+1]==10)
                {
                    Total += 10 + Frame[i + 2];
                    break;
                }
                else
                {
                    Total += Frame[i] + Frame[i + 1];
                    break;
                }

            }

            return Total;
        }

        
    }
}
