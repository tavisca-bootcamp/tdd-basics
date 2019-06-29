using System;

namespace BowlingBall
{
    public class Game
    {
        private int totalScore;
        private int frameNum;                           // the current frma number
        private Frame[] frame;                          // Frame object array
        private int roll;                               // current frames roll number
        private int canRoll;


        public Game()                                   // the constructor for Game obj
        {
            totalScore=0;
            frameNum=0;
            roll=0;
            frame= new Frame[10];
            for(int i =0;i<10;i++)
                frame[i]= new Frame();
                
            canRoll=1;
        }



        public void Roll(int pins)                      // the function called for each roll of the game
        {
            if(pins>10)                                 // a litlle error handeling
                pins=10;
            else if(pins<0)
                pins=0;

            if(IsOver())
                return ;

            frame[frameNum].rolls[roll]=pins;

            if(frameNum!=9)                             //if its not the last frame
            {

                if(pins==10 && roll==0)                 // if its a strike
                {
                    frame[frameNum].isStrike=1;                                                  
                    frameNum+=1;
                }
                else                                    // if it is not a strike
                {
                    if(roll==1 && ( frame[frameNum].rolls[roll] + frame[frameNum].rolls[roll-1] == 10 ))                            //if it is a spare
                        frame[frameNum].isSpare=1;
                                        
                    roll= (roll+1)%2;

                    if(roll==0)
                        frameNum+=1;

                }
            }


            else                                        // if it is the last frame
            {
               if(pins==10 && roll==0)
                    frame[frameNum].isStrike=1;
                    
                else if(roll==1 &&(frame[frameNum].rolls[roll-1]+pins)==10)
                    frame[frameNum].isSpare=1;

                if(roll==1 && !( frame[frameNum].isSpare==1 || frame[frameNum].isStrike==1 ))
                    canRoll=0;                          // if 2 rolls have occured witout a strike or spare, stop
                
                roll= (roll+1)%3;

                if(roll==0)                             // if 3 rolls have occured, stop game
                    canRoll=0;
            }
            
        }

        public int GetScore()
        {
            if(!IsOver())
                System.Console.WriteLine("Game isnt over...");
            
            for(int i=0; i<=frameNum && i<9;i++)
            {
                if(frame[i].isStrike==1)                //if this is a strike add the next two rolls 
                    {   
                        frame[i].score=10;

                        if(frame[i+1].isStrike==1)      //if the nxt one is also a strike then the frame after it shud also be taken
                        {
                            if(i+1==9)
                                frame[i].score+= (frame[i+1].rolls[0] + frame[i+1].rolls[1]);       //if the nxt frame is the last frame then the consecutive rolls to be taken

                            else
                                frame[i].score+= 10 + frame[i+2].rolls[0];
                        }

                        else
                            frame[i].score+= frame[i+1].rolls[0] + frame[i+1].rolls[1];
                    }
                    
                
                else if(frame[i].isSpare==1)
                    frame[i].score= 10 + frame[i+1].rolls[0];                                       //if its a spare add the nxt roll
                
                else
                    frame[i].score= frame[i].rolls[0] + frame[i].rolls[1];                          // else jst the rolls of this frame

                totalScore+=frame[i].score;

            }
            if(frameNum==9)                                                                         // if the game has been played till the last frame before GetScore() is called add it
                {
                    frame[9].score= frame[9].rolls[0] + frame[9].rolls[1];
                    if(frame[9].rolls[2]!=-1)
                        frame[9].score+= frame[9].rolls[2];

                    totalScore+= frame[9].score;
                }

            return totalScore;
        }

        public bool IsOver()
        {
            if(canRoll==0)
                return true;
            
            else
                return false;
        }
        
        public static void Main(string[] args)
        {
            Game g = new Game();
            g.Roll(10); // strike
            g.Roll(3);
            g.Roll(4);
            System.Console.WriteLine( g.GetScore());
        }

    }
}

