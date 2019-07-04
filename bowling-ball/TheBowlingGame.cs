using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
namespace BowlingBall
{
    public class TheBowlingGame
    {
        private int TotalScore;
        private Dictionary<int,Frame> Frames;
        public TheBowlingGame(ArrayList rolls)
        {
            GameSetup();
            Play(rolls);
        }
        private void GameSetup()
        {
            TotalScore = 0;
            Frames = new Dictionary<int, Frame>();
        }
        private void Play(ArrayList rolls)
        {
            var currentRoll = 0;
            var totalRolls = rolls.Count;
            var currentFrame = 1;

            while (currentFrame <= 10)
            {
                //strike
                if((int)rolls[currentRoll] == 10)
                {
                    Frames.Add(currentFrame, new StrikeFrame((int)rolls[currentRoll], (int)rolls[currentRoll+1], (int)rolls[currentRoll+2]));
                    TotalScore += Frames[currentFrame].GetScore();
                    currentRoll += 1;
                    //extra roll
                    if (currentFrame == 10)
                        currentRoll += 2;
                }
                //spare
                else if ((int)rolls[currentRoll] + (int)rolls[currentRoll+1]== 10)
                {
                    Frames.Add(currentFrame, new SpareFrame((int)rolls[currentRoll], (int)rolls[currentRoll + 1], (int)rolls[currentRoll + 2]));
                    TotalScore += Frames[currentFrame].GetScore();
                    currentRoll += 2;
                    //extra roll
                    if (currentFrame == 10)
                        currentRoll++;
                }
                //regular
                else
                {
                    Frames.Add(currentFrame, new RegularFrame((int)rolls[currentRoll], (int)rolls[currentRoll + 1]));
                    TotalScore += Frames[currentFrame].GetScore();
                    currentRoll += 2;
                }
                currentFrame++;
            }
            if (currentRoll < totalRolls)
                throw new Exception("More than expected rolls");
        }
        public int GetScore()
        {
            return TotalScore;
        }
    }
}