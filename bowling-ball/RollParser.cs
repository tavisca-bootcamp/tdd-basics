namespace Rolls
{
    public class RollParser : IRollParser
    {
        private Roll []roll;

        public Roll[] ParseRoll(string rolls)
        {
            int i, len = rolls.Length;
            roll = new Roll[len];
            for(i = 0; i < len; i++)
            {
                roll[i] = CreateRoll(i, rolls);
            }
            return roll;
        }

        private Roll CreateRoll(int pos, string rolls)
        {
            int points = GetPoints(pos, rolls);
            Roll roll = new Roll(points);
            return roll;
        }

        public int GetPoints(int pos, string rolls)
        {
            char c = rolls[pos];
            if(c == Roll.strike)
            {
                return 10;
            }
            if(c == Roll.spare)
            {
                return 10 - GetPoints(pos - 1, rolls);
            }
            if(c == Roll.emptyRoll)
            {
                return 0;
            }
            return c - '0';
        }
    }
}