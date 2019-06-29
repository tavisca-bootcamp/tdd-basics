using Frames;
using Rolls;

namespace BowlingBall
{
    public class BowlingGame
    {
        private IRollParser rollParser;
        private IFrameParser frameParser;
        private Score score;

        public BowlingGame()
        {
            rollParser = new RollParser();
            frameParser = new FrameParser();
            score = new Score();
        }

        public int CalculateScores(string rolls)
        {
            Roll []roll = rollParser.ParseRoll(rolls);
            Frame []frame = frameParser.ParseFrame(roll);
            int totalScore = score.CalculateScore(frame);
            return totalScore;
        }
    }
}

