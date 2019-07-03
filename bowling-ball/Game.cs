using System;
using System.Collections.Generic;

namespace BowlingBall
{
    public class Game
    {
        private const int totalFrame = 10;
        private List<Frame> Frames;
        private int currentFrameIndex = 0;

        public Game()
        {
            Frames = new List<Frame>();
            for (int i = 0; i < totalFrame; i++)
                Frames.Add(new Frame());
        }

        public void Roll(int pins)
        {
            if (pins < 0 || pins > 10)
                throw new ArgumentOutOfRangeException();
            else
            {
                if(currentFrameIndex!=9)
                {
                    for(int i=0;i<Frames[currentFrameIndex].NumberOfRollRemaining;i++)
                    {
                        if (Frames[currentFrameIndex].NumberOfRollRemaining>0)
                        {
                            Frames[currentFrameIndex].NumberOfPinsRemaining -= pins;
                            Frames[currentFrameIndex].NumberOfRollRemaining -= 1;
                            Frames[currentFrameIndex].Slots.Add(pins);
                            if (Frames[currentFrameIndex].NumberOfPinsRemaining == 0)
                            {
                                if(Frames[currentFrameIndex].NumberOfRollRemaining==1)
                                    Frames[currentFrameIndex].IsStrike = true;  
                                else
                                    Frames[currentFrameIndex].IsSpare = true;
                                Frames[currentFrameIndex].NumberOfRollRemaining = 0;
                                currentFrameIndex += 1;
                            }
                            if (Frames[currentFrameIndex].NumberOfRollRemaining == 0)
                                currentFrameIndex += 1;
                            break;
                        }
                    }
                }
                else
                {
                    if(Frames[currentFrameIndex].IsStrike)
                        Frames[currentFrameIndex].Slots.Add(pins);
                    else if(Frames[currentFrameIndex].IsSpare)
                        Frames[currentFrameIndex].Slots.Add(pins);
                    else if (Frames[currentFrameIndex].NumberOfRollRemaining > 0)
                    {
                        Frames[currentFrameIndex].NumberOfPinsRemaining -= pins;
                        Frames[currentFrameIndex].NumberOfRollRemaining -= 1;
                        Frames[currentFrameIndex].Slots.Add(pins);
                        if (Frames[currentFrameIndex].NumberOfPinsRemaining == 0)
                    {
                            if (Frames[currentFrameIndex].NumberOfRollRemaining == 1)
                                Frames[currentFrameIndex].IsStrike = true;
                            else
                                Frames[currentFrameIndex].IsSpare = true;
                            Frames[currentFrameIndex].NumberOfRollRemaining = 0;
                            //currentFrameIndex += 1;
                        }
                        //if (Frames[currentFrameIndex].NumberOfRollRemaining == 0)
                            //currentFrameIndex += 1;
                    }
                }
            }
        }

        public int GetScore()
        {
            //throw new NotImplementedException();
            int frameScore = 0;
            for(int i=0;i<totalFrame;i++)
            {
                int bonus = 0;
                if(i!=9)
                {
                    frameScore = Frames[i].Slots[0];
                    if (Frames[i].IsSpare)
                        bonus = Frames[i].Slots[1] + Frames[i + 1].Slots[0];
                    else if (Frames[i].IsStrike)
                    {
                        if (Frames[i + 1].IsStrike)
                        {
                            if (i + 2 <= 9)
                                bonus = Frames[i + 1].Slots[0] + Frames[i + 2].Slots[0];
                            else
                                bonus = Frames[i + 1].Slots[0] + Frames[i + 1].Slots[1];
                        }
                        else
                            bonus = Frames[i + 1].Slots[0] + Frames[i + 1].Slots[1];
                    }
                    else
                        frameScore += Frames[i].Slots[1];
                    Frames[i].TotalFrameValue = frameScore + bonus;
                }
                else
                {
                    if (Frames[i].Slots.Count == 2)
                    {
                        frameScore = Frames[i].Slots[0] + Frames[i].Slots[1];
                        if (Frames[i].IsSpare)
                            bonus = Frames[i].Slots[2];
                    }
                    else
                        frameScore = Frames[i].Slots[0] + Frames[i].Slots[1] + Frames[i].Slots[2];
                    Frames[i].TotalFrameValue = frameScore + bonus;
                }
            }

            int totalScoreOfGame = 0;
            for(int i=0;i<totalFrame;i++)
                totalScoreOfGame += Frames[i].TotalFrameValue;

            return totalScoreOfGame;
        }

    }
}

