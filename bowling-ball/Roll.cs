namespace Rolls
{
    public class Roll
    {
        public const char strike = 'X';
        public const char spare = '/';
        public const char emptyRoll = '-';
        private int numberOfKnockedPins;

        public Roll(int numberOfKnockedPins)
        {
            this.numberOfKnockedPins = numberOfKnockedPins;
        }

        public int GetNumberOfKnockedPins()
        {
            return numberOfKnockedPins;
        }

        public static Roll Zero()
        {
            return new Roll(0);
        }
    }
}