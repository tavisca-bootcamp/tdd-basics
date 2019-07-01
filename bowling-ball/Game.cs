using System;
using System.Linq;

namespace BowlingBall
{
    public class Game
    {
        public static void Main(string[] args)
        {  
        }
         
        public int Roll(int[] pins)
        {
            Check(pins);                                            //checking various input errors
            int[] frame =new int[10];
            int fIndex=0,sum=0;
            for(int i=0;i<pins.Length-2;i++)
            {    if(pins[i]+pins[i+1]<10)
                {
                    sum+=pins[i]+pins[i+1];                             //Normal Score
                    frame[fIndex]=sum;
                    fIndex++;
                    i++;
                    if(i==pins.Length-3)
                        frame[fIndex]=sum+pins[i+1]+pins[i+2];    
                }
                if(pins[i]==10)                                        //Checks Strike
                {
                    sum+=pins[i]+pins[i+1]+pins[i+2];
                    frame[fIndex]=sum;
                    fIndex++;
                }

                if(pins[i]+pins[i+1]==10)                              //Checks Spare
                {
                    sum+=pins[i]+pins[i+1]+pins[i+2];
                    frame[fIndex]=sum;
                    fIndex++;
                    i++;
                }
            }
            return frame[9];                                         //returning Score of last frame
        }

        public static void Check(int[] pins)
        {
            int count=0;                                            //count for strike,and normal pins
            if(pins.Length>21 || pins.Length<12)                    //inappropiate input
                throw new ArgumentException("Input must be from 12 to 21 inclusive");

            for(int i=0; i<pins.Length;i++)
            {   
                if(pins[i]<0 || pins[i]>10)
                    throw new ArgumentOutOfRangeException("i","Pins can be from 0 to 10");
                if(pins[i]==10)
                    count++;
            }
            
            if(count>12)
                throw new ArgumentOutOfRangeException("count","Max Strikes can be 12 in a game");

            for(int i=0;i<pins.Length-1;i++)
            {
                if(pins[i]==10)
                    continue;
                if(pins[i]+pins[i+1]>10)
                    throw new ArgumentException("Single frame can have max of 10 pins to bowl");
                i++;
                    
            }
            
        }
    }
}

