using System;
using System.Collections.Generic;
using System.Text;

namespace BowlingBall
{
    public static class BowlingUtility
    {
        
        public static void RollMultipleTimes(this Game game, int pins, int rolls)
        {
            for (int i = 0; i < rolls; i++)
                game.Roll(pins);
        }

        public static void HandleArrayOfPins(this Game game, int[] pins)
        {
            foreach(var pin in pins)
            {
                game.Roll(pin);
            }
        }
        public static int GetTotalPins(this Game game)
        {

            int totalpins = 0;
            foreach (Frame frame in game.Frames)
            {
                totalpins += frame.PinsRemaining;
            }
            return totalpins;

        }
        public static int GetTotalBowl(this Game game)
        {
            int totalbowl = 0;
            foreach (Frame frame in game.Frames)
            {
                totalbowl += frame.BowlRemaining;
            }
            return totalbowl;
        }

        public static int GetTotalSlotsCount(this Game game)
        {
            int totalslot = 0;
            foreach (Frame frame in game.Frames)
            {
                totalslot += frame.Slots.Count;
            }
            return totalslot;
        }
        public static int GetValueInSlot(this Game game, int frameIndex)
        {
            int n;
            n = game.Frames[game.currentFrameIndex].Slots[frameIndex].NumberOfBallKnocked;
            return n;
        }
        public static int GetCurrentFrameRemainingPins(this Game game)
        {
            int n;
            n = game.Frames[game.currentFrameIndex].PinsRemaining;
            return n;
        }
        public static int GetFrameRemainingPins(this Game game, int frameIndex)
        {
            int n;
            n = game.Frames[frameIndex].PinsRemaining;
            return n;
        }
        public static int GetCurrentFrameIndex(this Game game)
        {
            return game.currentFrameIndex;
        }
        public static int GetCurrentFrameTotalSlotCount(this Game game)
        {
            return game.Frames[game.currentFrameIndex].Slots.Count;
        }
        public static int GetTotalFrameCount(this Game game)
        {
            return game.Frames.Count;
        }

    }
}
