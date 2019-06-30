using System;

namespace BowlingBall
{
    public class Game
    {
        public  int[] GameChances = new int[22];
        public  int count = 1;
        public  int score = 0;
        public  int LastFrame = 19;
        public Game()
        {
            for (int i = 0; i < 22; i++) GameChances[i] = 0;
            count = 1;
            score = 0;
            LastFrame = 19;
        }
        public void Roll(int pins)
        {
            if (pins == 10 && count < 19)
            {
                GameChances[count] = pins;
                count += 2;
            }
            else
            {
                GameChances[count++] = pins;
            }
        }

        public int GetScore()
        {
           for (int i = 1; i <= 19; i += 2)
            {

                if (i < 17)
                {
                    score = GetScoreNormal(i);
                }
                else if (i == 17)
                {
                    score = GetScoreFor_17th_Frame(i);
                }
                else
                {
                    score += GameChances[19] + GameChances[20] + GameChances[21];
                }
            }
            return score;
        }
        
         public  int GetScoreNormal(int FrameNO)
        {
            if (IsSpare(FrameNO))
            {
                score += 10 + GameChances[FrameNO + 2];
            }
            else if (IsStrike(FrameNO))
            {
                if (IsStrike(FrameNO + 2))
                {
                    score += 10 + GameChances[FrameNO + 2] + GameChances[FrameNO + 4];
                }
                else
                {
                    score += 10 + GameChances[FrameNO + 2] + GameChances[FrameNO + 3];
                }
            }
            else
            {
                score += GameChances[FrameNO] + GameChances[FrameNO + 1];
            }
            return score;
        }
        
        
         public  int GetScoreFor_17th_Frame(int FrameNo)
        {
            if (IsSpare(FrameNo))
            {
                score += 10 + GameChances[FrameNo + 2];
            }
            else if (IsStrike(FrameNo))
            {
                score += 10 + GameChances[FrameNo + 2] + GameChances[FrameNo + 3];
            }
            else
            {
                score += GameChances[FrameNo] + GameChances[FrameNo + 1];
            }
            return score;
        }
        
        
         public  bool IsSpare(int currentBallNo)
        {
            return (((GameChances[currentBallNo] + GameChances[currentBallNo + 1]) == 10) && (GameChances[currentBallNo] != 10)) ? true : false;
        }
        
         public  bool IsStrike(int currentBallNo)
        {
            return (GameChances[currentBallNo] == 10) ? true : false;
        }

    }
}

