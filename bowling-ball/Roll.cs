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

        public int getNumberOfKnockedPins()
        {
            return numberOfKnockedPins;
        }

        public static Roll zero()
        {
            return new Roll(0);
        }
    }
}