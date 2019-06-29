namespace Rolls
{
    internal interface IRollParser
    {
        int getPoints(int pos, string rolls);
        Roll[] rollParser(string rolls);
    }
}