using System;

namespace BowlingBall
{
    public class Game
    {
        Frames [] frames = new Frames[10];
        int PointerToFrame;
        const int TotalFrames = 10;
        
        public Game()
        {
            PointerToFrame = 0;

            for (int index = 0; index < TotalFrames; index++)
                frames[index] = new Frames();
        }
        public void Roll(int [] pins)
        {
      
            int ptr = 0;
           while(ptr < pins.Length)
            {
                frames[PointerToFrame].SetFrame(pins[ptr++], 0);
                frames[PointerToFrame].SetFrame(pins[ptr++], 1);

                PointerToFrame++;
            }
        }

        public int GetScore()
        {
            int TotalScores = 0;
            for(int ptr=0; ptr < TotalFrames; ptr++)
            {
                if (frames[ptr].IsSpare() == true)
                    TotalScores += 10 + frames[ptr + 1].SpareBonus();
                else if (frames[ptr].IsStrike() == true)
                    TotalScores += 10 + frames[ptr + 1].StrikeBonus();
                else if (frames[ptr].IsSpare() == false && frames[ptr].IsStrike() == false)
                    TotalScores += frames[ptr].CalculateScore();
                
            }
            return TotalScores;
        }
    }
}

