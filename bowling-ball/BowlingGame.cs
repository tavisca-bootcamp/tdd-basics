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

        public int calculateScores(string rolls)
        {
            Roll []roll = rollParser.rollParser(rolls);
            Frame []frame = frameParser.frameParser(roll);
            int totalScore = score.calculateScore(frame);
            return totalScore;
        }
    }
}

