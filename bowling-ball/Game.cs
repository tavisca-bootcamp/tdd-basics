using System;
using System.Collections.Generic;

namespace BowlingBall
{
    public class Game:FramesManage
    {
       
        private int OpportunityNumber= 1;
        Frame CurrentFrame;
        

        public Game():base(new Frame[10])
        {
            
        }

        public void Roll(int pins)
        {
            if (PresentFrame==FRAMESEXCEEDED)//it is for handling third roll of tenth frame;
            {
                CurrentFrame.TenthFrameUpdate(pins);
                return;

            }

                   switch (OpportunityNumber)
                  {

                        case var opportunity when opportunity==FIRST:
                                                CurrentFrame= new Frame();
                                                CurrentFrame.DoFirstRoll(pins);
                                                if (pins == STRIKEPINS&&PresentFrame!=LASTFRAMEINDEX)
                                                     OpportunityNumber = COMPLETED;
                                                 else
                                                      OpportunityNumber++;
                                break;
                
                        case var opportunity when opportunity== SECOND:
                                              CurrentFrame.DoSecondRoll(pins);
                                              OpportunityNumber = COMPLETED;

                                break;
                  }

            UpdateCurrentFrame();
            
                
        }


        public int GetScore()
        {
            return CurrentFrame.Score;
        }


        private void UpdateCurrentFrame()
        {
            if (OpportunityNumber == COMPLETED)
            {
                UpdateInFrames(CurrentFrame);
                OpportunityNumber = FIRST;
            }
        }

        
        //UpdateFramesScore method is used to update previous frames if they are strike or  spare
       
          
       
           
        

    }
}

