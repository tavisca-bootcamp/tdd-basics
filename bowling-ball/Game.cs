using System;

namespace BowlingBall
{
   public class Game

    {
        public int[] Test { get; set; }
        public static void Main(string[] args)
        {
         
        }

        public static int CheckStrike(int i)//checks whether its a strike or not
        {
            if (i == 10)
                return 1;
            else
                return 0;

        }

        public static int CheckSpare(int i, int j)//checks whether its a spare or not
        {
            if ((i + j) == 10)
                return 1;
            else if ((i + j) > 10)
                return 0;
            else
                return -1;
        }
        public int Roll(int []pins)
            {
             CheckExceptions(pins);  //for checking exceptions
            int i;
            int[] frame = new int[10];  //array storing score of each frame
            int frameNo = 1, sum = 0;
            int str = 0, spr = 0;
            
                for (i = 0; (i < pins.Length - 2) && (frameNo <= 9); i++) //initially running the loop upto 9 frames
                {
                    str = CheckStrike(pins[i]);
                    if (str == 1)//if its a strike
                    {
                        sum += 10 + pins[i + 1] + pins[i + 2];
                        frame[frameNo - 1] = sum;
                    }
                    else
                    {
                        spr = CheckSpare(pins[i], pins[i + 1]);//if its a spare
                        if (spr == 1)
                        {
                            sum += 10 + pins[i + 2];
                            frame[frameNo - 1] = sum;
                        }
                        else if (spr == -1)//if its a miss
                        {
                            sum += pins[i] + pins[i + 1];
                            frame[frameNo - 1] = sum;
                        }
                        else if (spr == 0)//in case of invalid input
                        {
                            throw new ArgumentException("Invalid entry since the maximum number of balls in each frame can be 10");
                            
                        }
                        i++;
                    }
                 
                    frameNo++;

                }
               
                if (frameNo == 10)//in case of 10th frame
                {
                    if((pins[i]!=10)&&(pins[i]+pins[i+1]>10))
                        throw new ArgumentException("Invalid entry since the maximum number of balls in each frame can be 10");

                    if ((pins[i]==10)||(pins[i]+pins[i+1]==10))//if its a strike or a spare
                    {
                        sum += pins[i] + pins[i + 1] + pins[i + 2];
                        frame[frameNo - 1] = sum;
                        frameNo++;
                        i += 2;
                    }
                    else//if its a miss
                    {
                        sum += pins[i] + pins[i + 1];
                        frame[frameNo - 1] = sum;
                        frameNo++;
                        i += 1;
                    }
                    

                }
                if (pins.Length - 1 > i)
                    throw new IndexOutOfRangeException("frames cannot be more than 10");
                
            
           return frame[frame.Length-1];

        }

        public static void CheckExceptions(int[] pins)
        {
            int count = 0;
            //count for strike,and normal pins
            if (pins.Length > 21 || pins.Length < 12)                    //inappropiate input
                throw new ArgumentException("Input must be from 12 to 21 inclusive");

            for (int i = 0; i < pins.Length; i++)
            {
                if (pins[i] < 0 || pins[i] > 10)
                    throw new ArgumentOutOfRangeException("i", "Pins can be from 0 to 10");
                if (pins[i] == 10)
                    count++;
            }

            if (count > 12)
                throw new ArgumentOutOfRangeException("count", "Max Strikes can be 12 in a game");

            for (int i = 0; i < pins.Length - 1; i++)
            {
                if (pins[i] == 10)
                    continue;
                if (pins[i] + pins[i + 1] > 10)
                    throw new ArgumentException("Single frame can have max of 10 pins to bowl");
                i++;

            }

        }
        public int GetScore()
            {
                throw new NotImplementedException();
            }

        }
}

