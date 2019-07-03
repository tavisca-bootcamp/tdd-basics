using System;
using System.Collections.Generic;
using System.Linq;

namespace BowlingBall
{
    public class Game1
    {
        private List<int> Frames;
        private int ValueOfPinRolled;
        private int Score;
        private int RollingTurnEachFrame;
        private Random Rand;
        private int CurrentFrame;
        private int StrikeStatus;
        private int SpareStatus;
        public Game1()
        {
            Frames = new List<int>() {10,10,10,10,10,10,10,10,10,10};
            Rand = new Random();
            Score = 0;
            CurrentFrame = 0;
            StrikeStatus = 0;
            SpareStatus = 0;
            RollingTurnEachFrame = 0;
        }

        public int ReturnSumOfFrames()
        {
            return Frames.Sum();
        }
        
        public int Roll(int remainingPins)
        {
            return Rand.Next(0, remainingPins + 1);
        }

        public bool AnotherTryRequired(int turn,int pinValue)
        {
            if (turn == 1 || pinValue == 10)
            {
                RollingTurnEachFrame = 0;
                return false;
            }
            {
                RollingTurnEachFrame = 1;
                return true;
            }
        }

        private void CheckAndAssignStrikeStatus(int pinValue)
        {
            if (pinValue == 10)
                StrikeStatus = 2;
        }

        private void CheckAndAssignSpareStatus()
        {
            if (Frames[CurrentFrame] == 0 && RollingTurnEachFrame == 1)
                SpareStatus = 1;
        }

        public bool LastFrameReached(int frame)
        {
            if (frame == 9)
                return true;
            return false;

        }

        private void GotoNewFrame()
        { 
            if(CurrentFrame != 9)
                CurrentFrame += 1;
            RollingTurnEachFrame = 0;
        }

        

        public int GetScore(int pinValue,int strikeFrame,int spareFrame)
        {
            if(strikeFrame != 0)
            {
                StrikeStatus -= 1;
                return 2 * pinValue;
            }

            else if(spareFrame != 0)
            {
                SpareStatus = 0;
                return 2 * pinValue;
            }
            return pinValue;
        }

        public int Play(int [] listPinsRolled)
        {
            bool continuePlay = true;
            int maxTurnForLastFrame = 3;
            foreach(int valueOfPinRolled in listPinsRolled)
            {
                //ValueOfPinRolled = Roll(Frame[CurrentFrame]);
                //if (Frames[CurrentFrame] - valueOfPinRolled < 0)
                    //GotoNewFrame();

                ValueOfPinRolled = valueOfPinRolled;
                Score += GetScore(ValueOfPinRolled,StrikeStatus,SpareStatus);
                CheckAndAssignStrikeStatus(ValueOfPinRolled);
                Frames[CurrentFrame] -= ValueOfPinRolled;
                if (!AnotherTryRequired(RollingTurnEachFrame,ValueOfPinRolled))
                {
                    CheckAndAssignSpareStatus();
                    GotoNewFrame();
                }



                //if(LastFrameReached(CurrentFrame) )

                
     

            }

            return Score;
        }

        
    }
}

