using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace BowlingBall
{
    public class Game
    {
        private  List<Frame> FrameList = new List<Frame>(10) {
            new Frame(),
            new Frame(),
            new Frame(),
            new Frame(),
            new Frame(),
            new Frame(),
            new Frame(),
            new Frame(),
            new Frame(),
            new Frame()
        };

      
       

        public void Play(int [] pinValuesList)
        {
            int counter = 0;
            //FrameList[counter] = new Frame();
            FrameList[counter].MaxTry = 2;
            foreach (int pinValue in pinValuesList)
            { 
                
                if (FrameList[counter].Roll(pinValue) == 1 && counter < 9)
                {
                    counter += 1;
                    //FrameList[counter] = new Frame();
                    FrameList[counter].MaxTry = 2;
                }

                else if (counter == 9 && FrameList[counter].Score.Count == 1 && FrameList[counter].Score.Sum() == 10)
                {
                    FrameList.Add(new Frame());
                    counter += 1;
                    FrameList[counter].MaxTry = 2;
                }

                else if (counter == 9 && FrameList[counter].Score.Count == 2 && FrameList[counter].Score.Sum() == 10)
                {
                    FrameList.Add(new Frame());
                    counter += 1;
                    FrameList[counter].MaxTry = 1;
                }


            }
        }

        public int CalculateFinalScore()
        {
            int finalScore = 0;
            int penultimate = FrameList.Count - 1;
            for (int i = 0; i < FrameList.Count; i++)
            {
              

                if (i < penultimate-1)
                {
                    if (FrameList[i].StrikeStatus == 1)
                    {
                        if(FrameList[i].Score.Count == 2)
                            finalScore += FrameList[i + 1].Score[0] + FrameList[i + 1].Score[1];
                        else
                         finalScore += FrameList[i + 1].Score[0] + FrameList[i + 2].Score[0];
                    }

                    if (FrameList[i].SpareStatus == 1)
                    {
                        finalScore += FrameList[i + 1].Score[0];
                    }

                }

                finalScore += FrameList[i].Score.Sum();



            }

            //return FrameList.Count;
            return finalScore;
        }
    }
}
