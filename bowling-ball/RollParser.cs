namespace Rolls
{
    public class RollParser : IRollParser
    {
        private Roll []roll;

        public Roll[] rollParser(string rolls)
        {
            int i, len = rolls.Length;
            roll = new Roll[len];
            for(i = 0; i < len; i++)
            {
                roll[i] = createRoll(i, rolls);
            }
            return roll;
        }

        private Roll createRoll(int pos, string rolls)
        {
            int points = getPoints(pos, rolls);
            Roll roll = new Roll(points);
            return roll;
        }

        public int getPoints(int pos, string rolls)
        {
            char c = rolls[pos];
            if(c == Roll.strike)
            {
                return 10;
            }
            if(c == Roll.spare)
            {
                return 10 - getPoints(pos - 1, rolls);
            }
            if(c == Roll.emptyRoll)
            {
                return 0;
            }
            return c - '0';
        }
    }
}