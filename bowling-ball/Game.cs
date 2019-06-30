using System;
using System.Collections.Generic;

namespace BowlingBall
{
    public class Game
    {
        private Frame[] Frames;
        private int OpportunityCount= 0;
        private int Index = 0;
        public const int  LASTFRAMEINDEX= 9;
        public const int STRIKE = 10;

        public Game()
        {
            Frames = new Frame[10];
        }
        public void Roll(int pins)
        {
             if(Index==LASTFRAMEINDEX+1)//special case for third roll in tenth frame
            {
                TenthFrameUpdate(pins);
                return;
            }


               
           
          if (pins == STRIKE && Index!=LASTFRAMEINDEX)
            {
                Frames[Index] = new Frame();
                Frames[Index].FirstRoll = pins;
                Frames[Index].CalculateScore();
                UpdateFramesScore();
                Index++;
            }
            else if(OpportunityCount==0)
            {
                Frames[Index] = new Frame();
                Frames[Index].FirstRoll = pins;
                OpportunityCount=1;
                
                

            }
            else if(OpportunityCount==1)
            {
                Frames[Index].SecondRoll = pins;
                Frames[Index].CalculateScore();
                UpdateFramesScore();
                OpportunityCount = 0;
                Index++;


            }
                
        }

        public int GetScore()
        {
            return Frames[LASTFRAMEINDEX].Score;
        }
        //UpdateFramesScore method is used to update previous frames if they are strike or  spare
        public void UpdateFramesScore()
        {    if (Index == 0)//for first frame we don't have previous previous frame to update score
                return;
            if (Index>1 &&Frames[Index-1].IsStrike()&&Frames[Index-2].IsStrike())
            {   if (Frames[Index].IsStrike())
                {
                    Frames[Index - 2].Score += 10;
                    Frames[Index - 1].Score += 20;
                }
                else
                {
                    Frames[Index - 2].Score += Frames[Index].FirstRoll;
                    Frames[Index-1].Score+=(Frames[Index].FirstRoll+ Frames[Index].Score);
                }
            }
            else if(Index>0 && Frames[Index-1].IsStrike())
            {
                Frames[Index - 1].Score += Frames[Index].Score;
            }
          else if(Index>0 && Frames[Index-1].IsSpare())
            {
                Frames[Index - 1].Score += Frames[Index].FirstRoll;
            }

            Frames[Index].Score += Frames[Index - 1].Score;

        }
        public void TenthFrameUpdate(int tenthFrameThirdRollPins)
        {       if (Frames[LASTFRAMEINDEX-1].IsStrike())
            {
                Frames[LASTFRAMEINDEX-1].Score += Frames[LASTFRAMEINDEX].SecondRoll;
                Frames[LASTFRAMEINDEX].Score += Frames[LASTFRAMEINDEX].SecondRoll;
            }

            Frames[LASTFRAMEINDEX].Score += tenthFrameThirdRollPins; 
        }
        //public void Traverse()
        //{
        //    for (int i = 0; i < 10; i++)
        //        Console.WriteLine(Frames[i].Score);
        //}
           
        

    }
}

