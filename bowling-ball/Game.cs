using System;

namespace BowlingBall
{
    public class Game
    {
        public Frame[] Frames = new Frame[10];
        int currentFrame = 0;
        public int Score = 0;
        public void Roll(int pins)
        {
            try
            {
                if (currentFrame == 10)
                    throw new InvalidOperationException("Cannot roll beyond 10 frames");

                if (Frames[currentFrame] == null)
                {
                    Frames[currentFrame] = new Frame();
                    //Check for final frame
                    Frames[currentFrame].Type = currentFrame == 9 ? FrameType.Final : FrameType.Normal;
                }

                Frames[currentFrame].Roll(pins);

                if (Frames[currentFrame].State != FrameState.NotAttempted && Frames[currentFrame].Type != FrameType.Final)
                    currentFrame++;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public int GetScore()
        {
            CalculateFrameBonuses();
            CalculateTotalScore();
            return Score;
        }

        private void CalculateTotalScore()
        {
            Score = 0;
            for (int frameIndex = 0; frameIndex <= currentFrame; frameIndex++)
            {
                Score += Frames[frameIndex].GetPinCount() + Frames[frameIndex].Bonus;
            }
        }

        private void CalculateFrameBonuses()
        {
            try
            {
                for (int frameIndex = 0; frameIndex < currentFrame; frameIndex++)
                {
                    if (Frames[frameIndex].Type != FrameType.Final)
                    {
                        if (Frames[frameIndex].State == FrameState.Strike)
                        {
                            if (Frames[frameIndex + 1].Type != FrameType.Final && Frames[frameIndex + 1].State == FrameState.Strike)
                            {
                                Frames[frameIndex].Bonus = Frames[frameIndex + 1].Rolls[0] + Frames[frameIndex + 2].Rolls[0];
                            }
                            else //for second last frame
                                Frames[frameIndex].Bonus = Frames[frameIndex + 1].Rolls[0] + Frames[frameIndex + 1].Rolls[1];
                        }
                        if (Frames[frameIndex].State == FrameState.Spare)
                            Frames[frameIndex].Bonus = Frames[frameIndex + 1].Rolls[0];
                    }
                    else //Final
                        Frames[frameIndex].Bonus = 0;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}

