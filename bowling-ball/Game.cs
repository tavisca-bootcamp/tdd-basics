using System;

namespace BowlingBall
{
    public class Game
    {
        int[] Rolls = new int[21];

        //This method takes an input of integer array and sets it to Rolls, which denotes
        //number of pins put down in each roll
        public void SetRoll(int[] pins)
        {
            Rolls = pins;
        }

        //This method computes and returns the final score of a game
        public int GetScore()
        {
            int score = 0;
            int FrameIndex = 0;
            for (int i = 0; i < 10; i++) {
                if (IsStrike(FrameIndex)) {
                    score = score + 10 + StrikeBonus(FrameIndex);
                    FrameIndex = FrameIndex + 1;//in a strike, there is only one roll per frame, the increment value is 1
                } else if (IsSpare(FrameIndex)) {
                    score =score + 10 + SpareBonus(FrameIndex);
                    FrameIndex = FrameIndex + 2;//a spare in when the pins are knocked down in two rolls, hence 2 is the increment value
                } else {
                    score = score + SumOfBallsInFrame(FrameIndex);
                    FrameIndex = FrameIndex + 2;//in a neither a spare nor a strike case, two rolls are done per frame, hence 2 is the increment value
                }
            }
            return score;
        }
        //This method checks if the current frame is a strike
        private bool IsStrike(int frameIndex) {
            return (Rolls[frameIndex] == 10);
        }
        //This method checks if the current frame is a spare
        private bool IsSpare(int frameIndex) {
            return (Rolls[frameIndex] + Rolls[frameIndex+1] == 10);
        }
        //This method returns the number of pins put down in a frame which is
        //neither strike nor spare
        private int SumOfBallsInFrame(int frameIndex) {
            return (Rolls[frameIndex] + Rolls[frameIndex+1]);
        }
        //This method returns bonus when the current frame is a spare
        private int SpareBonus(int frameIndex) {
            return (Rolls[frameIndex+2]);
        }
        //This method returns bonus when the current frame is a strike
        private int StrikeBonus(int frameIndex) {
            return (Rolls[frameIndex+1] + Rolls[frameIndex+2]);
        }
    }
}

