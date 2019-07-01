using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace BowlingBall
{
    
    public class Game
    {
        private const int TotalFrame = 10;
        private List<Frame> Frames;
        private int CurrentFrameIndex = 0;

        public Game()
        {  Frames = new List<Frame>();
            for (int i = 0; i < TotalFrame; i++)
            {
                Frames.Add(new Frame());
            }
        }

        public void Roll(int pins)
        {
            if (pins < 0 || pins > 10)
                throw new ArgumentOutOfRangeException();
            else if (pins > Frames[CurrentFrameIndex].PinsRemaining)
                throw new NoMorePinsAvailable($"No more Pins Available in Frame {CurrentFrameIndex}");
            else
            {
                if (CurrentFrameIndex != 9)
                {
                    int numberOfSlotCompleted = 0;
                    for (int i = 0; i < Frames[CurrentFrameIndex].Slots.Count; i++)
                    {
                        if (!Frames[CurrentFrameIndex].Slots[i].IsSlotCompleted)
                        {
                            Frames[CurrentFrameIndex].Slots[i].NumberOfBallKnocked = pins;
                            Frames[CurrentFrameIndex].PinsRemaining -= pins;
                            Frames[CurrentFrameIndex].Slots[i].IsSlotCompleted = true;
                            if (pins == 10)
                            {
                                Frames[CurrentFrameIndex].Slots[i + 1].IsSlotCompleted = true;
                                CurrentFrameIndex += 1;
                            }

                            break;
                        }
                        else
                        {
                            numberOfSlotCompleted += 1;
                        }
                    }
                    if (numberOfSlotCompleted + 1 == Frames[CurrentFrameIndex].Slots.Count)
                        CurrentFrameIndex += 1;
                }
                else
                {
                    HandleFrameNumberTen(pins);
                }
            }
        }

        private void HandleFrameNumberTen(int pins)
        {
            if (!Frames[CurrentFrameIndex].Slots[0].IsSlotCompleted)
            {
                Frames[CurrentFrameIndex].Slots[0].NumberOfBallKnocked = pins;
                Frames[CurrentFrameIndex].PinsRemaining -= pins;
                Frames[CurrentFrameIndex].Slots[0].IsSlotCompleted = true; 
                if(pins==10)
                {
                    Frames[CurrentFrameIndex].PinsRemaining = 10;
                    Frames[CurrentFrameIndex].AddNewSlot();
                }

            }
            else
            {
                if (!Frames[CurrentFrameIndex].Slots[1].IsSlotCompleted)
                {
                    Frames[CurrentFrameIndex].Slots[1].NumberOfBallKnocked = pins;
                    Frames[CurrentFrameIndex].PinsRemaining -= pins;
                    Frames[CurrentFrameIndex].Slots[1].IsSlotCompleted = true;
                    if (Frames[CurrentFrameIndex].Slots[0].NumberOfBallKnocked + Frames[CurrentFrameIndex].Slots[1].NumberOfBallKnocked == 10)
                    {
                        Frames[CurrentFrameIndex].PinsRemaining = 10;
                        if (Frames[CurrentFrameIndex].Slots.Count != 3)
                        {
                            Frames[CurrentFrameIndex].AddNewSlot();
                        }
                    }
                    if(pins==10)
                        Frames[CurrentFrameIndex].PinsRemaining = 10;

                }
                else
                {
                    if (Frames[CurrentFrameIndex].Slots.Count == 3)
                    {
                        Frames[CurrentFrameIndex].Slots[2].NumberOfBallKnocked = pins;
                        Frames[CurrentFrameIndex].PinsRemaining = 0;
                        Frames[CurrentFrameIndex].Slots[2].IsSlotCompleted = true;
                    }
                        
                }
            }


        }

        public int GetScore()
        {
            computeFrameScore();
            int totalscore = 0;
            for(int i=0;i<TotalFrame;i++)
            {
                totalscore += Frames[i].FrameScore;
            }
            return totalscore;

        }

        private void computeFrameScore()
        {
            int framescore = 0;
            
            for(int i = 0; i < TotalFrame; i++)
            {
                int bonus = 0;
                if (i!=9)
                {
                    framescore = Frames[i].Slots[0].NumberOfBallKnocked + Frames[i].Slots[1].NumberOfBallKnocked;
                    if (isSpare(i))
                        bonus = Frames[i + 1].Slots[0].NumberOfBallKnocked;
                    if (isStrike(i))
                       if(isStrike(i+1))
                            if(i+2 <=9)
                                bonus = Frames[i + 1].Slots[0].NumberOfBallKnocked + Frames[i + 2].Slots[0].NumberOfBallKnocked;
                           else
                                bonus = Frames[i + 1].Slots[0].NumberOfBallKnocked + Frames[i + 1].Slots[1].NumberOfBallKnocked;
                        else
                            bonus = Frames[i + 1].Slots[0].NumberOfBallKnocked + Frames[i + 1].Slots[1].NumberOfBallKnocked;
                    Frames[i].FrameScore = framescore + bonus;
                }
                else
                {
                    if(Frames[i].Slots.Count==2)
                        framescore = Frames[i].Slots[0].NumberOfBallKnocked + Frames[i].Slots[1].NumberOfBallKnocked;

                    else
                    {
                        framescore = Frames[i].Slots[0].NumberOfBallKnocked
                            + Frames[i].Slots[1].NumberOfBallKnocked
                            + Frames[i].Slots[2].NumberOfBallKnocked;

                    }

                    Frames[i].FrameScore = framescore + bonus;
                }
               
                
            }
            
        }
        private bool isSpare(int indexFrame)
        {
            return Frames[indexFrame].Slots[0].NumberOfBallKnocked + Frames[indexFrame].Slots[1].NumberOfBallKnocked == 10;
        }

        private bool isStrike(int indexFrame)
        {
            return Frames[indexFrame].Slots[0].NumberOfBallKnocked == 10;
        }
        public int GetTotalPins()
        {
            int totalpins = 0;
            foreach (Frame frame in Frames)
            {
                totalpins += frame.PinsRemaining;
            }
            return totalpins;

        }
        public int GetTotalBowl()
        {
            int totalbowl = 0;
            foreach (Frame frame in Frames)
            {
                totalbowl += frame.BowlRemaining;
            }
            return totalbowl;

        }

        public int GetTotalSlotsCount()
        {
            int totalslot = 0;
            foreach (Frame frame in Frames)
            {
                totalslot += frame.Slots.Count;
            }
            return totalslot;
        }
        public int GetValueInSlot(int x)
        {
            int n;
            n= Frames[CurrentFrameIndex].Slots[x].NumberOfBallKnocked;
            return n;
        }
        public int GetCurrentFrameReamainingPins()
        {
            int n;
            n = Frames[CurrentFrameIndex].PinsRemaining;
            return n;
        }
        public int GetFrameReamainingPins(int x)
        {
            int n;
            n = Frames[x].PinsRemaining;
            return n;
        }
        public int GetCurrentFrameIndex()
        {
            return CurrentFrameIndex;
        }
        public int GetCurrentFrameTotalSlotCount()
        {
            return Frames[CurrentFrameIndex].Slots.Count;
        }
        public int GetTotalFrameCount()
        {
            return Frames.Count;
        }

    }

    
    public class NoMorePinsAvailable : Exception
    {
       
        public NoMorePinsAvailable(string message) : base(message)
        {
        }
    }
  
}

