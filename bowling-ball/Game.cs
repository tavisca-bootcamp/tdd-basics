using System;

namespace BowlingBall
{
    public class Game
    {
        Frames [] frames = new Frames[10];
        int PointerToFrame;
        const int TotalPossibleFrames = 10;
        int ActualFrames;
        public Game()
        {
            PointerToFrame = 0;

            for (int index = 0; index < TotalPossibleFrames; index++)
                frames[index] = new Frames();
        }
        public void Roll(int [] pins)
        {
            const int StrikeConstant = 10;
            int ptr = 0;
           while(ptr < pins.Length)
            {
                // to check if user is still playing currentframes
                if (ptr + 1 == pins.Length)
                    frames[PointerToFrame].SetFrame(pins[ptr++], 0);
                else if(pins[ptr] == StrikeConstant)
                {
                    frames[PointerToFrame].SetFrame(pins[ptr++], 0);
                    frames[PointerToFrame].SetFrame(0, 1);
                }

                else if(pins[ptr] != StrikeConstant)
                {
                    frames[PointerToFrame].SetFrame(pins[ptr++], 0);
                    frames[PointerToFrame].SetFrame(pins[ptr++], 1);
                }
                
                PointerToFrame++;
            }
            ActualFrames = PointerToFrame;
        }

        public int GetScore()
        {
            int TotalScores = 0;
            for(int ptr=0; ptr <= PointerToFrame; ptr++)
            {
                if (frames[ptr].IsStrike() == true)
                    TotalScores += 10 + frames[ptr + 1].StrikeBonus();
                else if (frames[ptr].IsSpare() == true)
                    TotalScores += 10 + frames[ptr + 1].SpareBonus();
                else if (frames[ptr].IsSpare() == false && frames[ptr].IsStrike() == false 
                    && frames[ptr].CheckForEmptyFrame() == false)
                    TotalScores += frames[ptr].CalculateScore();
                
            }
            return TotalScores;
        }
    }
}

