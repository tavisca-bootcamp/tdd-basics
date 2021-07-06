using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace BowlingBall
{
    public class Game
    {
        private const int TotalFrame = 10;
        public List<Frame> Frames { get; set; }
        public int currentFrameIndex { get; set; }

        public Game()
        {
            currentFrameIndex = 0;
            Frames = new List<Frame>();
            for(int i=0; i<TotalFrame; i++)
            {
                Frames.Add(new Frame());
            }
        }
        public void Roll(int pins)
        {
            if (pins < 0 || pins > 10)
                throw new ArgumentException("Pins can't be negative or greater than 10");
            else if (pins > Frames[currentFrameIndex].PinsRemaining)
                throw new PinsNotAvailableException($"No more pins available in Frame Number -> {currentFrameIndex}");
            else
            {
                if(currentFrameIndex != 9)
                {
                    int numberOfSlotsCompleted = 0;
                    for(int i=0; i< Frames[currentFrameIndex].Slots.Count; i++)
                    {
                        if (!Frames[currentFrameIndex].Slots[i].IsSlotCompleted)
                        {
                            addSlotAndPinsInFrame(pins, i);
                            if (pins == 10)
                            {
                                Frames[currentFrameIndex].Slots[i + 1].IsSlotCompleted = true;
                                currentFrameIndex += 1;
                            }
                            break;

                        }
                        else
                        {
                            numberOfSlotsCompleted += 1;
                        }

                    }
                    if (numberOfSlotsCompleted + 1 == Frames[currentFrameIndex].Slots.Count)
                        currentFrameIndex += 1;
                }
                else
                {
                    HandleTenthFrame(pins);
                }
            }
        }
        private void HandleTenthFrame(int pins)
        {
            if (!Frames[currentFrameIndex].Slots[0].IsSlotCompleted)
            {
                addSlotAndPinsInFrame(pins, 0);
                if(pins == 10)
                {
                    Frames[currentFrameIndex].PinsRemaining = 10;
                    Frames[currentFrameIndex].AddSlot();
                }
            }
            else if (!Frames[currentFrameIndex].Slots[1].IsSlotCompleted)
            {
                addSlotAndPinsInFrame(pins, 1);
                if (Frames[currentFrameIndex].Slots[0].NumberOfBallKnocked + Frames[currentFrameIndex].Slots[1].NumberOfBallKnocked == 10)
                {
                    Frames[currentFrameIndex].PinsRemaining = 10;
                    if (Frames[currentFrameIndex].Slots.Count != 3)
                    {
                        Frames[currentFrameIndex].AddSlot();
                    }
                }
                if (pins == 10)
                    Frames[currentFrameIndex].PinsRemaining = 10;
            }
            else
            {
                if(Frames[currentFrameIndex].Slots.Count == 3)
                {
                    addSlotAndPinsInFrame(pins, 2);
                }
                Frames[currentFrameIndex].PinsRemaining = 0;
            }

        }
        private void addSlotAndPinsInFrame(int pins, int i)
        {
            Frames[currentFrameIndex].Slots[i].NumberOfBallKnocked = pins;
            Frames[currentFrameIndex].PinsRemaining -= pins;
            Frames[currentFrameIndex].Slots[i].IsSlotCompleted = true;
        }

        public int GetScore()
        {
            CalculateEachFrameScore();
            int totalScore = 0;
            foreach(var frame in Frames)
            {
                totalScore += frame.FrameScore;
            }
            return totalScore;
        }

        private void CalculateEachFrameScore()
        {
            int frameScore = 0;
            for(int frame = 0; frame < TotalFrame; frame++)
            {

                int frameBonus = 0;
                if (frame != 9)
                {
                    frameScore = Frames[frame].Slots[0].NumberOfBallKnocked
                        + Frames[frame].Slots[1].NumberOfBallKnocked;
                    if (IsSpare(frame))
                    {
                        frameBonus = Frames[frame + 1].Slots[0].NumberOfBallKnocked;
                    }
                    if (IsStrike(frame))
                    {
                        if (IsStrike(frame + 1))
                        {
                            if (frame + 2 <= 9)
                            {
                                frameBonus = Frames[frame + 1].Slots[0].NumberOfBallKnocked
                                    + Frames[frame + 2].Slots[0].NumberOfBallKnocked;
                            }
                            else
                            {
                                frameBonus = Frames[frame + 1].Slots[0].NumberOfBallKnocked
                                    + Frames[frame + 1].Slots[1].NumberOfBallKnocked;

                            }
                        }
                        else
                        {
                            frameBonus = Frames[frame + 1].Slots[0].NumberOfBallKnocked
                                    + Frames[frame + 1].Slots[1].NumberOfBallKnocked;
                        }
                    }
                    Frames[frame].FrameScore = frameScore + frameBonus;
                }
                else
                {
                    if(Frames[frame].Slots.Count == 2)
                    {
                        frameScore = Frames[frame].Slots[0].NumberOfBallKnocked
                        + Frames[frame].Slots[1].NumberOfBallKnocked;
                    }
                    else
                    {

                        frameScore = Frames[frame].Slots[0].NumberOfBallKnocked
                        + Frames[frame].Slots[1].NumberOfBallKnocked
                        + Frames[frame].Slots[2].NumberOfBallKnocked;
                    }
                    Frames[frame].FrameScore = frameScore + frameBonus;
                }
            }
        }

        private bool IsStrike(int frame) 
            => Frames[frame].Slots[0].NumberOfBallKnocked == 10;
        

        private bool IsSpare(int frame)
            => Frames[frame].Slots[0].NumberOfBallKnocked
            + Frames[frame].Slots[1].NumberOfBallKnocked == 10;

        

    }
        

    [Serializable]
    public class PinsNotAvailableException : Exception
    {
        public PinsNotAvailableException()
        {
        }

        public PinsNotAvailableException(string message) : base(message)
        {
        }

        public PinsNotAvailableException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected PinsNotAvailableException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}

