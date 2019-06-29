namespace Rolls
{
    internal interface IRollParser
    {
        int GetPoints(int pos, string rolls);
        Roll[] ParseRoll(string rolls);
    }
}