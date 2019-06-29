namespace BowlingBall
{

    public class Frame
    {
        public int score;
        public int isStrike;
        public int isSpare;

        public int[] rolls;

        public Frame()
        {
            score=isStrike=isSpare=0;
            rolls= new int[3] {0,0,0};

        }



    }
}